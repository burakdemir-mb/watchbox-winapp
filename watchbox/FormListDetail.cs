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
    public partial class FormListDetail : Form
    {
        private ListItem currentList;

        public FormListDetail(ListItem list)
        {
            InitializeComponent();
            currentList = list;
        }

        private void LoadFilms()
        {
            lstFilms.Items.Clear();

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT
                        f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                        s.Rating, s.IsLiked, s.WatchedAt
                    FROM Films f
                    INNER JOIN ListFilms lf ON lf.FilmId = f.Id
                    LEFT JOIN UserFilmStatus s
                        ON s.FilmId = f.Id AND s.UserId = @u
                    WHERE lf.ListId = @l
                    ORDER BY lf.AddedAt DESC", con);

                cmd.Parameters.AddWithValue("@l", currentList.Id);
                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstFilms.Items.Add(new FilmItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString(),
                        Year = Convert.ToInt32(reader["Year"]),
                        Genre = reader["Genre"].ToString(),
                        CoverPath = reader["CoverPath"]?.ToString(),
                        Description = reader["FilmDescription"]?.ToString(),
                        Rating = reader["Rating"] != DBNull.Value
                            ? Convert.ToDouble(reader["Rating"])
                            : 0,
                        IsLiked = reader["IsLiked"] != DBNull.Value &&
                                  Convert.ToInt32(reader["IsLiked"]) == 1
                    });
                }
            }
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bu listeyi silmek istediğine emin misin?\nİçindeki filmler silinmez.",
                "Listeyi Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd1 = new SQLiteCommand(
                    "DELETE FROM ListFilms WHERE ListId=@l", con);
                cmd1.Parameters.AddWithValue("@l", currentList.Id);
                cmd1.ExecuteNonQuery();

                var cmd2 = new SQLiteCommand(
                    "DELETE FROM Lists WHERE Id=@l", con);
                cmd2.Parameters.AddWithValue("@l", currentList.Id);
                cmd2.ExecuteNonQuery();
            }

            MessageBox.Show("Liste silindi.");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRemoveFilm_Click(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is not FilmItem film)
                return;

            var result = MessageBox.Show(
                $"\"{film.Title}\" filmi bu listeden silinsin mi?",
                "Film Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (var con = DB.GetConnection())
            {
                con.Open();

                using (var cmd = new SQLiteCommand(
                    "DELETE FROM ListFilms WHERE ListId=@l AND FilmId=@f", con))
                {
                    cmd.Parameters.AddWithValue("@l", currentList.Id);
                    cmd.Parameters.AddWithValue("@f", film.Id);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadFilms();
        }

        private void lstFilms_DoubleClick(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is FilmItem film)
            {
                if (new FormFilmDetail(film).ShowDialog() == DialogResult.OK)
                {
                    LoadFilms();
                    ResetFilmPreview();
                }
            }
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            var frm = new FormMovies(currentList.Id);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadFilms();
        }

        private void FormListDetail_Load(object sender, EventArgs e)
        {
            lblListName.Text = currentList.Name;

            txtDescription.Text = currentList.Description;
            txtDescription.ReadOnly = true;
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.BackColor = this.BackColor;

            lblVisibility.Text = currentList.IsPublic ? "🌍 Herkese Açık" : "🔒 Gizli";
            lblVisibility.ForeColor = currentList.IsPublic
                ? Color.ForestGreen
                : Color.Gray;

            ResetFilmPreview();
            LoadFilms();
        }

        private void ResetFilmPreview()
        {
            picCover.ImageLocation = CoverHelper.DefaultCoverPath;
            picCover.SizeMode = PictureBoxSizeMode.Zoom;

            lblRating.Visible = false;
            lblLike.Visible = false;
        }

        private void lstFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is FilmItem film)
            {
                // Kapak
                var coverPath = CoverHelper.GetCover(film.CoverPath);
                picCover.ImageLocation = string.IsNullOrEmpty(coverPath)
                    ? null
                    : coverPath;

                if (string.IsNullOrEmpty(coverPath))
                    picCover.ImageLocation = CoverHelper.DefaultCoverPath;
                picCover.SizeMode = PictureBoxSizeMode.Zoom;


                // Rating
                if (film.Rating > 0)
                {
                    lblRating.Text = $"⭐ {film.Rating:0.0}";
                    lblRating.Visible = true;
                    lblRating.ForeColor = Color.Goldenrod;
                }
                else
                    lblRating.Visible = false;

                // Like
                lblLike.Visible = film.IsLiked;
                lblLike.Text = "❤️";
                lblLike.ForeColor = Color.DarkRed;
            }
            else
            {
                ResetFilmPreview();
            }
        }

        private void ReloadListInfo()
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(
                    "SELECT * FROM Lists WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", currentList.Id);

                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    currentList.Name = r["Name"].ToString();
                    currentList.Description = r["Description"]?.ToString();
                    currentList.IsPublic = Convert.ToInt32(r["IsPublic"]) == 1;
                }
            }

            lblListName.Text = currentList.Name;
            txtDescription.Text = currentList.Description;

            lblVisibility.Text = currentList.IsPublic
                ? "🌍 Herkese Açık"
                : "🔒 Gizli";

            lblVisibility.ForeColor = currentList.IsPublic
                ? Color.ForestGreen
                : Color.Gray;
        }

        private void btnEditList_Click(object sender, EventArgs e)
        {
            var frm = new FormCreateList(currentList);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReloadListInfo();
                LoadFilms();
            }
        }
    }
}
