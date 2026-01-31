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
using System.Windows.Forms.DataVisualization.Charting;

namespace watchbox
{
    public partial class FormProfile : Form
    {
        int currentChartIndex = 0;
        int currentListIndex = 0;
        public FormProfile()
        {
            InitializeComponent();
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            lblUsername.Text = CurrentUser.Username;

            currentListIndex = 0;
            LoadCurrentList();
            LoadRecentCovers();

            currentChartIndex = 0;
            LoadCurrentChart();
            ShowDecadeChart();
        }

        private void ShowDecadeChart()
        {
            DataTable dt = FetchDecadeData();

            chartMain.Series.Clear();
            chartMain.ChartAreas.Clear();
            chartMain.Legends.Clear();
            chartMain.Titles.Clear();

            var area = new ChartArea("ChartArea1");
            area.AxisX.Title = "Kuşak";
            area.AxisY.Title = "İzlenen Film Sayısı";
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.Minimum = 0;
            area.AxisY.Interval = 1;

            area.AxisX.LabelStyle.Enabled = true;

            chartMain.ChartAreas.Add(area);

            var series = new Series("İzlenen");
            series.ChartType = SeriesChartType.Column;

            series.XValueType = ChartValueType.String;
            series.IsXValueIndexed = true;

            series.ChartArea = "ChartArea1";

            series.IsValueShownAsLabel = true;

            foreach (DataRow row in dt.Rows)
            {
                string decade = row["Decade"].ToString();
                int count = Convert.ToInt32(row["Count"]);

                int idx = series.Points.AddXY(decade, count);

                if (count == 0)
                    series.Points[idx].Label = "";
            }

            chartMain.Series.Add(series);

            chartMain.Invalidate();
        }


        private void LoadCurrentList()
        {
            lstProfile.Items.Clear();

            if (currentListIndex == 0)
            {
                lblListTitle.Text = "🕒 En Son İzlediğin Filmler";
                LoadRecentlyWatchedList();
            }
            else if (currentListIndex == 1)
            {
                lblListTitle.Text = "❤️ En Son Beğendiğin Filmler";
                LoadLikedFilmsList();
            }
            else if (currentListIndex == 2)
            {
                lblListTitle.Text = "📋 Oluşturduğun Listeler";
                LoadUserLists();
            }

            btnPrevList.Visible = currentListIndex > 0;
            btnNextList.Visible = currentListIndex < 2;
        }

        private void btnPrevList_Click(object sender, EventArgs e)
        {
            if (currentListIndex > 0)
            {
                currentListIndex--;
                LoadCurrentList();
            }
        }

        private void btnNextList_Click(object sender, EventArgs e)
        {
            if (currentListIndex < 2)
            {
                currentListIndex++;
                LoadCurrentList();
            }
        }

        private void LoadRecentlyWatchedList()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                SELECT f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                       s.Rating, s.IsLiked, s.WatchedAt
                FROM Films f
                JOIN UserFilmStatus s ON s.FilmId = f.Id
                WHERE s.UserId=@u AND s.WatchedAt IS NOT NULL
                ORDER BY datetime(s.WatchedAt) DESC
                LIMIT 20", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);


            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lstProfile.Items.Add(new FilmItem
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Title = r["Title"].ToString(),
                    Year = Convert.ToInt32(r["Year"]),
                    Genre = r["Genre"].ToString(),
                    CoverPath = r["CoverPath"]?.ToString(),
                    Description = r["FilmDescription"]?.ToString(),
                    Rating = r["Rating"] != DBNull.Value ? Convert.ToDouble(r["Rating"]) : 0,
                    IsLiked = r["IsLiked"] != DBNull.Value && Convert.ToInt32(r["IsLiked"]) == 1,
                    WatchedAt = r["WatchedAt"] != DBNull.Value ? DateTime.Parse(r["WatchedAt"].ToString()) : null
                });
            }
        }


        private void LoadLikedFilmsList()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                SELECT f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                       s.Rating, s.IsLiked, s.WatchedAt
                FROM Films f
                JOIN UserFilmStatus s ON s.FilmId = f.Id
                WHERE s.UserId=@u AND s.IsLiked = 1
                ORDER BY datetime(s.WatchedAt) DESC, f.Id DESC
                LIMIT 20", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);


            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lstProfile.Items.Add(new FilmItem
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Title = r["Title"].ToString(),
                    Year = Convert.ToInt32(r["Year"]),
                    Genre = r["Genre"].ToString(),
                    CoverPath = r["CoverPath"]?.ToString(),
                    Description = r["FilmDescription"]?.ToString(),
                    Rating = r["Rating"] != DBNull.Value ? Convert.ToDouble(r["Rating"]) : 0,
                    IsLiked = true,
                    WatchedAt = r["WatchedAt"] != DBNull.Value ? DateTime.Parse(r["WatchedAt"].ToString()) : null
                });
            }
        }
        private void LoadUserLists()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                SELECT * FROM Lists
                WHERE UserId=@u
                ORDER BY Id DESC", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lstProfile.Items.Add(new ListItem
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Name = r["Name"].ToString(),
                    Description = r["Description"]?.ToString(),
                    IsPublic = Convert.ToInt32(r["IsPublic"]) == 1
                });
            }
        }

        private void lstProfile_DoubleClick(object sender, EventArgs e)
        {
            if (lstProfile.SelectedItem is FilmItem film)
            {
                using var frm = new FormFilmDetail(film);
                frm.ShowDialog();

                RefreshProfileUI();
            }
            else if (lstProfile.SelectedItem is ListItem list)
            {
                using var frm = new FormListDetail(list);
                frm.ShowDialog();

                RefreshProfileUI();
            }
        }

        private void LoadRecentCovers()
        {
            var films = new List<FilmItem>();

            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                SELECT f.Id, f.Title, f.Year, f.Genre, f.CoverPath, f.FilmDescription,
                       s.Rating, s.IsLiked, s.WatchedAt
                FROM Films f
                JOIN UserFilmStatus s ON s.FilmId = f.Id
                WHERE s.UserId=@u AND s.WatchedAt IS NOT NULL
                ORDER BY datetime(s.WatchedAt) DESC
                LIMIT 3", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);


            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                films.Add(new FilmItem
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

            SetCover(picRecent1, films.Count > 0 ? films[0] : null);
            SetCover(picRecent2, films.Count > 1 ? films[1] : null);
            SetCover(picRecent3, films.Count > 2 ? films[2] : null);
        }

        private void SetCover(PictureBox pic, FilmItem film)
        {
            if (film == null)
            {
                pic.Visible = false;
                pic.Tag = null;
                return;
            }

            pic.Visible = true;
            pic.ImageLocation = CoverHelper.GetCover(film.CoverPath);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Tag = film;
        }


        private void picRecent_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic && pic.Tag is FilmItem film)
            {
                using var frm = new FormFilmDetail(film);
                frm.ShowDialog();

                RefreshProfileUI();
            }
        }

        private void LoadCurrentChart()
        {
            if (currentChartIndex == 0)
            {
                lblChartTitle.Text = "🎞 Film Kuşakları";
                ShowDecadeChart();
            }
            else
            {
                lblChartTitle.Text = "🎬 Türlere Göre İzlenen Filmler";
                LoadGenreChart();
            }

            btnPrev.Visible = currentChartIndex > 0;
            btnNext.Visible = currentChartIndex < 1;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentChartIndex > 0)
            {
                currentChartIndex--;
                LoadCurrentChart();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentChartIndex < 1)
            {
                currentChartIndex++;
                LoadCurrentChart();
            }
        }
        private DataTable FetchDecadeData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Decade", typeof(string));
            dt.Columns.Add("Count", typeof(int));

            dt.Rows.Add("70'ler", 0);
            dt.Rows.Add("80'ler", 0);
            dt.Rows.Add("90'lar", 0);
            dt.Rows.Add("2000'ler", 0);
            dt.Rows.Add("2010'lar", 0);
            dt.Rows.Add("2020'ler", 0);

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT f.Year
                    FROM Films f
                    JOIN UserFilmStatus s ON s.FilmId = f.Id
                    WHERE s.UserId=@u AND s.WatchedAt IS NOT NULL", con);

                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);


                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    if (r["Year"] == DBNull.Value) continue;

                    int year = Convert.ToInt32(r["Year"]);
                    string decade =
                        (year >= 1970 && year < 1980) ? "70'ler" :
                        (year >= 1980 && year < 1990) ? "80'ler" :
                        (year >= 1990 && year < 2000) ? "90'lar" :
                        (year >= 2000 && year < 2010) ? "2000'ler" :
                        (year >= 2010 && year < 2020) ? "2010'lar" :
                        "2020'ler";

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Decade"].ToString() == decade)
                        {
                            row["Count"] = (int)row["Count"] + 1;
                            break;
                        }
                    }
                }
            }

            return dt;
        }
        private void LoadGenreChart()
        {
            chartMain.Series.Clear();
            chartMain.ChartAreas.Clear();
            chartMain.Legends.Clear();
            chartMain.Titles.Clear();

            var area = new ChartArea("ChartArea1");
            chartMain.ChartAreas.Add(area);

            var series = new Series("Türler")
            {
                ChartType = SeriesChartType.Pie
            };

            series.ChartArea = "ChartArea1";

            chartMain.Legends.Add(new Legend());
            series.LegendText = "#VALX";

            series.Label = "#PERCENT{P0}\n#VALY";

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT f.Genre, COUNT(*) AS Cnt
                    FROM Films f
                    JOIN UserFilmStatus s ON s.FilmId = f.Id
                    WHERE s.UserId=@u AND s.WatchedAt IS NOT NULL
                    GROUP BY f.Genre
                    ORDER BY Cnt DESC", con);

                cmd.Parameters.AddWithValue("@u", CurrentUser.Id);


                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    string genre = r["Genre"]?.ToString() ?? "Bilinmiyor";
                    int cnt = Convert.ToInt32(r["Cnt"]);

                    series.Points.AddXY(genre, cnt);
                }
            }

            chartMain.Series.Add(series);
            chartMain.Invalidate();
        }

        public void RefreshProfileUI()
        {
            LoadCurrentList();
            LoadRecentCovers();
            LoadCurrentChart();
        }

        private void btnWatchedTable_Click(object sender, EventArgs e)
        {
            using var frm = new FormWatchedHistory();
            frm.ShowDialog();
        }
    }
}
