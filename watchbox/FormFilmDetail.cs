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
    public partial class FormFilmDetail : Form
    {
        bool hasComment = false;
        FilmItem film;
        bool isLiked;
        double currentRating = 0;
        PictureBox[] stars;


        public FormFilmDetail(FilmItem filmItem)
        {
            InitializeComponent();
            film = filmItem;
        }
        public static void AddFilmToList(int listId, int filmId)
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                string q = "INSERT INTO ListFilms (ListId, FilmId) VALUES (@l, @f)";
                SQLiteCommand cmd = new SQLiteCommand(q, con);
                cmd.Parameters.AddWithValue("@l", listId);
                cmd.Parameters.AddWithValue("@f", filmId);
                cmd.ExecuteNonQuery();
            }
        }

        private void LoadLike()
        {
            isLiked = film.IsLiked;
            picLike.ImageLocation = isLiked
                ? Path.Combine(Application.StartupPath, "Assets", "heart_filled.png")
                : Path.Combine(Application.StartupPath, "Assets", "heart_empty.png");
        }

        void DrawStars(double rating)
        {
            for (int i = 0; i < 5; i++)
            {
                double starValue = rating - i;

                if (starValue >= 1)
                    stars[i].ImageLocation =
                        Path.Combine(Application.StartupPath, "Assets", "star_full.png");
                else if (starValue >= 0.5)
                    stars[i].ImageLocation =
                        Path.Combine(Application.StartupPath, "Assets", "star_half.png");
                else
                    stars[i].ImageLocation =
                        Path.Combine(Application.StartupPath, "Assets", "star_empty.png");
            }
        }

        private void Star_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox star = sender as PictureBox;
            int index = Array.IndexOf(stars, star);

            bool half = e.X < star.Width / 2;
            double hoverRating = index + (half ? 0.5 : 1);

            DrawStars(hoverRating);
        }

        private void Star_MouseLeave(object sender, EventArgs e)
        {
            DrawStars(currentRating);
        }

        private void SaveRatingToDatabase()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                INSERT INTO UserFilmStatus (UserId, FilmId, Rating)
                VALUES (@u, @f, @r)
                ON CONFLICT(UserId, FilmId)
                DO UPDATE SET Rating = excluded.Rating;", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
            cmd.Parameters.AddWithValue("@f", film.Id);
            cmd.Parameters.AddWithValue("@r", currentRating);
            cmd.ExecuteNonQuery();
        }


        private void Star_Click(object sender, EventArgs e)
        {
            PictureBox clickedStar = sender as PictureBox;
            int index = Array.IndexOf(stars, clickedStar);

            var me = (MouseEventArgs)e;
            bool half = me.X < clickedStar.Width / 2;

            currentRating = index + (half ? 0.5 : 1);

            DrawStars(currentRating);

            film.Rating = currentRating;
            SaveRatingToDatabase();
        }
        private void btnClearRating_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Puan sıfırlansın mı?", "Onay",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                currentRating = 0;
                DrawStars(0);
                SaveRatingToDatabase();
            }
        }

        private void UpdateCommentButton()
        {
            using (var con = DB.GetConnection())
            {
                con.Open();
                var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM FilmNotes WHERE FilmId=@f AND UserId=@u", con);
                cmd.Parameters.AddWithValue("@f", film.Id);
                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

                long count = (long)cmd.ExecuteScalar();
                btnComment.Text = count > 0 ? "Yorumu Görüntüle" : "Yorum Yap";
            }
        }

        private void CheckUserComment()
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM FilmNotes WHERE FilmId=@f AND UserId=@u", con);
                cmd.Parameters.AddWithValue("@f", film.Id);
                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

                hasComment = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }

            btnComment.Text = hasComment
                ? "Yorumu Görüntüle"
                : "Yorum Yap";
        }

        private void FormFilmDetail_Load(object sender, EventArgs e)
        {
            lblTitle.Text = film.Title;
            lblYear.Text = "Yıl: " + film.Year;
            lblGenre.Text = "Tür: " + film.Genre;
            LoadLike();
            LoadUserFilmStatus();
            UpdateCommentButton();
            CheckUserComment();
            UpdateWatchedUI();

            this.ActiveControl = lblTitle;

            stars = new PictureBox[]
            {
            picStar1, picStar2, picStar3, picStar4, picStar5
            };

            currentRating = film.Rating;
            DrawStars(currentRating);

            picCover.ImageLocation = CoverHelper.GetCover(film.CoverPath);

            // Description
            txtFilmDescription.Text = film.Description;
            txtFilmDescription.ReadOnly = true;
            txtFilmDescription.BackColor = this.BackColor;
            txtFilmDescription.BorderStyle = BorderStyle.None;
            txtFilmDescription.TabStop = false;
            txtFilmDescription.HideSelection = true;
            txtFilmDescription.Cursor = Cursors.Default;
        }

        private void LoadUserFilmStatus()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                SELECT Rating, IsLiked, WatchedAt
                FROM UserFilmStatus
                WHERE UserId=@u AND FilmId=@f", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
            cmd.Parameters.AddWithValue("@f", film.Id);

            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                film.Rating = r["Rating"] != DBNull.Value ? Convert.ToDouble(r["Rating"]) : 0;
                film.IsLiked = r["IsLiked"] != DBNull.Value && Convert.ToInt32(r["IsLiked"]) == 1;
                film.WatchedAt = r["WatchedAt"] != DBNull.Value
                    ? DateTime.Parse(r["WatchedAt"].ToString())
                    : (DateTime?)null;
            }
            else
            {
                film.Rating = 0;
                film.IsLiked = false;
                film.WatchedAt = null;
            }

            // UI’ye bas
            isLiked = film.IsLiked;
            currentRating = film.Rating;
        }

        private void UpdateWatchedUI()
        {
            picWatched.ImageLocation = film.IsWatched
                ? Path.Combine(Application.StartupPath, "Assets", "film_filled.png")
                : Path.Combine(Application.StartupPath, "Assets", "film_empty.png");
        }

        private void picWatched_MouseEnter(object sender, EventArgs e)
        {
            if (!film.IsWatched)
            {
                picWatched.ImageLocation =
                    Path.Combine(Application.StartupPath, "Assets", "film_hover.png");
            }
        }

        private void picWatched_MouseLeave(object sender, EventArgs e)
        {
            UpdateWatchedUI();
        }

        private void SaveLikeToDatabase()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                INSERT INTO UserFilmStatus (UserId, FilmId, IsLiked)
                VALUES (@u, @f, @l)
                ON CONFLICT(UserId, FilmId)
                DO UPDATE SET IsLiked = excluded.IsLiked;", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
            cmd.Parameters.AddWithValue("@f", film.Id);
            cmd.Parameters.AddWithValue("@l", isLiked ? 1 : 0);
            cmd.ExecuteNonQuery();
        }


        private void picLike_Click(object sender, EventArgs e)
        {
            isLiked = !isLiked;
            film.IsLiked = isLiked;

            picLike.ImageLocation = isLiked
                ? Path.Combine(Application.StartupPath, "Assets", "heart_filled.png")
                : Path.Combine(Application.StartupPath, "Assets", "heart_empty.png");

            SaveLikeToDatabase();
        }

        private void picLike_MouseEnter(object sender, EventArgs e)
        {
            if (!isLiked)
            {
                picLike.ImageLocation =
                    Path.Combine(Application.StartupPath, "Assets", "heart_hover.png");
            }
        }

        private void picLike_MouseLeave(object sender, EventArgs e)
        {
            picLike.ImageLocation = isLiked
                ? Path.Combine(Application.StartupPath, "Assets", "heart_filled.png")
                : Path.Combine(Application.StartupPath, "Assets", "heart_empty.png");
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            var frm = new FormComment(film, CurrentUser.Id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CheckUserComment();
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            new FormSelectList(film.Id).ShowDialog();
        }

        private void picWatched_Click(object sender, EventArgs e)
        {
            using var con = DB.GetConnection();
            con.Open();

            if (!film.IsWatched)
            {
                film.WatchedAt = DateTime.Now;

                var cmd = new SQLiteCommand(@"
                    INSERT INTO UserFilmStatus (UserId, FilmId, WatchedAt)
                    VALUES (@u, @f, @w)
                    ON CONFLICT(UserId, FilmId)
                    DO UPDATE SET WatchedAt = excluded.WatchedAt;", con);

                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
                cmd.Parameters.AddWithValue("@f", film.Id);
                cmd.Parameters.AddWithValue("@w", film.WatchedAt.Value.ToString("yyyy-MM-dd HH:mm"));
                cmd.ExecuteNonQuery();
            }
            else
            {
                film.WatchedAt = null;

                var cmd = new SQLiteCommand(@"
                    INSERT INTO UserFilmStatus (UserId, FilmId, WatchedAt)
                    VALUES (@u, @f, NULL)
                    ON CONFLICT(UserId, FilmId)
                    DO UPDATE SET WatchedAt = NULL;", con);

                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
                cmd.Parameters.AddWithValue("@f", film.Id);
                cmd.ExecuteNonQuery();
            }

            UpdateWatchedUI();
        }

    }
}
