using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watchbox
{
    public partial class FormMovies : Form
    {
        List<FilmItem> allFilms = new List<FilmItem>();
        private int? targetListId = null;

        public FormMovies()
        {
            InitializeComponent();
        }

        public FormMovies(int listId)
        {
            InitializeComponent();
            targetListId = listId;
        }

        private void LoadFilms(string filter = "")
        {
            allFilms.Clear();
            lstFilms.Items.Clear();

            using (var con = DB.GetConnection())
            {
                con.Open();

                string query = @"
                    SELECT
                        f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                        s.Rating, s.IsLiked, s.WatchedAt
                    FROM Films f
                    LEFT JOIN UserFilmStatus s
                        ON s.FilmId = f.Id AND s.UserId = @u";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allFilms.Add(new FilmItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Year = reader["Year"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Year"]),
                                Genre = reader["Genre"]?.ToString(),
                                CoverPath = reader["CoverPath"]?.ToString(),
                                Description = reader["FilmDescription"]?.ToString(),

                                Rating = reader["Rating"] != DBNull.Value ? Convert.ToDouble(reader["Rating"]) : 0.0,
                                IsLiked = reader["IsLiked"] != DBNull.Value && Convert.ToInt32(reader["IsLiked"]) == 1,
                                WatchedAt = reader["WatchedAt"] != DBNull.Value
                                    ? DateTime.Parse(reader["WatchedAt"].ToString())
                                    : (DateTime?)null
                            });
                        }
                    }
                }
            }

            ApplyFilters();
        }


        private void LoadGenres()
        {
            cmbFilterGenre.Items.Clear();
            cmbFilterGenre.Items.Add("Tümü");

            cmbFilterGenre.Items.AddRange(new string[]
            {
            "Aksiyon",
            "Dram",
            "Komedi",
            "Korku",
            "Bilim Kurgu",
            "Gerilim",
            "Animasyon",
            "Fantastik",
            "Romantik"
            });

            cmbFilterGenre.SelectedIndex = 0;
        }

        private void LoadYears()
        {
            cmbFilterYear.Items.Clear();
            cmbFilterYear.Items.Add("Tümü");

            int currentYear = DateTime.Now.Year;
            for (int y = currentYear; y >= 1950; y--)
                cmbFilterYear.Items.Add(y);

            cmbFilterYear.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            if (cmbFilterGenre.SelectedItem == null ||
                cmbFilterYear.SelectedItem == null)
                return;

            lstFilms.Items.Clear();

            string search = txtSearch.Text.ToLower();
            string genre = cmbFilterGenre.SelectedItem.ToString();
            string year = cmbFilterYear.SelectedItem.ToString();

            foreach (var film in allFilms)
            {
                if (!film.Title.ToLower().Contains(search))
                    continue;

                if (genre != "Tümü" && film.Genre != genre)
                    continue;

                if (year != "Tümü" && film.Year.ToString() != year)
                    continue;

                lstFilms.Items.Add(film);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void HideFilmStats()
        {
            lblRating.Visible = false;
            lblLike.Visible = false;
        }

        private void lstFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is FilmItem film)
            {
                // Kapak
                picCover.ImageLocation = CoverHelper.GetCover(film.CoverPath);
                picCover.SizeMode = PictureBoxSizeMode.Zoom;

                // Rating
                if (film.Rating > 0)
                {
                    lblRating.Text = $"⭐ {film.Rating:0.0}";
                    lblRating.Visible = true;
                    lblRating.ForeColor = Color.Goldenrod;
                }
                else
                {
                    lblRating.Visible = false;
                }

                // Like
                if (film.IsLiked)
                {
                    lblLike.Text = "❤️";
                    lblLike.Visible = true;
                    lblLike.ForeColor = Color.DarkRed;
                }
                else
                {
                    lblLike.Visible = false;
                }

                btnAddToList.Enabled = true;
            }
            else
            {
                HideFilmStats();
                btnAddToList.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFilms(txtSearch.Text.Trim());
        }

        private void FormMovies_Load(object sender, EventArgs e)
        {
            LoadGenres();
            LoadYears();
            LoadFilms();
            HideFilmStats();

            btnAddToList.Enabled = false;

            picCover.ImageLocation = CoverHelper.DefaultCoverPath;
            picCover.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            FormAddFilm addFilm = new FormAddFilm();

            if (addFilm.ShowDialog() == DialogResult.OK)
            {
                LoadFilms();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is FilmItem film)
            {
                FormAddFilm frm = new FormAddFilm(film);

                if (frm.ShowDialog() == DialogResult.OK)
                    LoadFilms();
            }
        }

        private void lstFilms_DoubleClick(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is not FilmItem film)
                return;

            using var frm = new FormFilmDetail(film);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadFilms();
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is not FilmItem film)
                return;

            // Liste detayından geldiysek
            if (targetListId != null)
            {
                using (var con = DB.GetConnection())
                {
                    con.Open();

                    var checkCmd = new SQLiteCommand(
                        "SELECT COUNT(*) FROM ListFilms WHERE ListId=@l AND FilmId=@f", con);
                    checkCmd.Parameters.AddWithValue("@l", targetListId);
                    checkCmd.Parameters.AddWithValue("@f", film.Id);

                    if ((long)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Bu film zaten bu listede.");
                        return;
                    }

                    new SQLiteCommand(
                        "INSERT INTO ListFilms (ListId, FilmId) VALUES (@l, @f)", con)
                    {
                        Parameters =
                {
                    new SQLiteParameter("@l", targetListId),
                    new SQLiteParameter("@f", film.Id)
                }
                    }.ExecuteNonQuery();
                }

                MessageBox.Show("Film listeye eklendi 🎉");
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // Normal film arama → liste seçtir
            new FormSelectList(film.Id).ShowDialog();
        }
    }
}
