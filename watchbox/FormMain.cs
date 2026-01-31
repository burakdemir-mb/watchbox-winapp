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
    public partial class FormMain : Form
    {
        List<FilmItem> suggestedFilms = new();

        int GetDailySeed()
        {
            return DateTime.Today.ToString("yyyyMMdd").GetHashCode();
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadDailySuggestions()
        {
            var allFilms = new List<FilmItem>();

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT
                        f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                        s.Rating, s.IsLiked, s.WatchedAt
                    FROM Films f
                    LEFT JOIN UserFilmStatus s
                        ON s.FilmId = f.Id AND s.UserId = @u", con);

                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    allFilms.Add(new FilmItem
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Title = r["Title"].ToString(),
                        Year = Convert.ToInt32(r["Year"]),
                        Genre = r["Genre"].ToString(),
                        CoverPath = r["CoverPath"]?.ToString(),
                        Description = r["FilmDescription"]?.ToString(),
                        Rating = r["Rating"] != DBNull.Value ? Convert.ToDouble(r["Rating"]) : 0,
                        IsLiked = r["IsLiked"] != DBNull.Value && Convert.ToInt32(r["IsLiked"]) == 1,
                        WatchedAt = r["WatchedAt"] != DBNull.Value
                            ? DateTime.Parse(r["WatchedAt"].ToString())
                            : null
                    });
                }
            }

            if (allFilms.Count < 3)
                return;

            var rng = new Random(GetDailySeed());

            var dailyFilms = allFilms
                .OrderBy(f => rng.Next())
                .Take(3)
                .ToList();

            SetSuggestion(picSuggest1, dailyFilms[0]);
            SetSuggestion(picSuggest2, dailyFilms[1]);
            SetSuggestion(picSuggest3, dailyFilms[2]);
        }

        private void picSuggest_DoubleClick(object sender, EventArgs e)
        {
            if (sender is PictureBox pic && pic.Tag is FilmItem film)
            {
                new FormFilmDetail(film).ShowDialog();
                LoadRecentlyWatched();
            }
        }

        private void LoadRecentlyWatched()
        {
            lstRecentlyWatched.Items.Clear();

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT
                        f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                        s.Rating, s.IsLiked, s.WatchedAt
                    FROM Films f
                    JOIN UserFilmStatus s ON s.FilmId = f.Id
                    WHERE s.UserId = @u AND s.WatchedAt IS NOT NULL
                    ORDER BY datetime(s.WatchedAt) DESC
                    LIMIT 10", con);

                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lstRecentlyWatched.Items.Add(new FilmItem
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Title = r["Title"].ToString(),
                        Year = Convert.ToInt32(r["Year"]),
                        Genre = r["Genre"].ToString(),
                        CoverPath = r["CoverPath"]?.ToString(),
                        Description = r["FilmDescription"]?.ToString(),
                        Rating = r["Rating"] != DBNull.Value ? Convert.ToDouble(r["Rating"]) : 0,
                        IsLiked = r["IsLiked"] != DBNull.Value && Convert.ToInt32(r["IsLiked"]) == 1,
                        WatchedAt = DateTime.Parse(r["WatchedAt"].ToString())
                    });
                }
            }
        }

        private void lstRecentlyWatched_DoubleClick(object sender, EventArgs e)
        {
            if (lstRecentlyWatched.SelectedItem is FilmItem film)
            {
                new FormFilmDetail(film).ShowDialog();
                LoadRecentlyWatched();
            }
        }

        private void SetSuggestion(PictureBox pic, FilmItem film)
        {
            pic.ImageLocation = CoverHelper.GetCover(film.CoverPath);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Tag = film;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Hoş geldin, " + CurrentUser.Username;
            RefreshHome();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            using (var profile = new FormProfile())
                profile.ShowDialog();

            RefreshHome();
        }

        private void RefreshHome()
        {
            LoadRecentlyWatched();
            LoadDailySuggestions();
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            using (var lists = new FormLists())
                lists.ShowDialog();

            RefreshHome();
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            using (var movies = new FormMovies())
                movies.ShowDialog();

            RefreshHome();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Id = 0;
            CurrentUser.Username = null;

            FormLogin login = Application.OpenForms.OfType<FormLogin>().FirstOrDefault();

            if (login == null)
                login = new FormLogin();

            login.Show();
            login.ResetFields();
            login.BringToFront();

            this.Hide();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            RefreshHome();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
