using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace watchbox
{
    public partial class FormWatchedHistory : Form
    {
        public FormWatchedHistory()
        {
            InitializeComponent();
        }

        private void FormWatchedHistory_Load(object sender, EventArgs e)
        {
            LoadWatchedGrid();
            SetupGridStyle();
        }

        private void LoadWatchedGrid()
        {
            using var con = DB.GetConnection();
            con.Open();

            var cmd = new SQLiteCommand(@"
                SELECT 
                    f.Title      AS [Film Adı],
                    f.Year       AS [Yıl],
                    f.Genre      AS [Tür],
                    s.WatchedAt  AS [İzlenme Zamanı]
                FROM Films f
                JOIN UserFilmStatus s ON s.FilmId = f.Id
                WHERE s.UserId = @u AND s.WatchedAt IS NOT NULL
                ORDER BY datetime(s.WatchedAt) DESC;", con);

            cmd.Parameters.AddWithValue("@u", CurrentUser.Id);

            var dt = new DataTable();
            using var da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);

            dgvWatched.DataSource = dt;
        }

        private void SetupGridStyle()
        {
            dgvWatched.ReadOnly = true;
            dgvWatched.AllowUserToAddRows = false;
            dgvWatched.AllowUserToDeleteRows = false;
            dgvWatched.AllowUserToResizeRows = false;

            dgvWatched.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWatched.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWatched.MultiSelect = false;

            dgvWatched.RowHeadersVisible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

