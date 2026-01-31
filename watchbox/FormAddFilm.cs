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
    public partial class FormAddFilm : Form
    {
        FilmItem editingFilm = null;
        string selectedCoverPath = null;
        public FormAddFilm()
        {
            InitializeComponent();
        }

        public FormAddFilm(FilmItem film)
        {
            InitializeComponent();
            editingFilm = film;
        }

        private void LoadYears()
        {
            int currentYear = DateTime.Now.Year;

            for (int y = currentYear; y >= 1950; y--)
            {
                cmbYear.Items.Add(y);
            }
        }

        /*private void LoadFilmData()
        {
            txtTitle.Text = editingFilm.Title;
            cmbYear.SelectedItem = editingFilm.Year;
            cmbGenre.SelectedItem = editingFilm.Genre;

            selectedCoverPath = editingFilm.CoverPath;

            picCover.ImageLocation =
                CoverHelper.GetCover(editingFilm.CoverPath);

            picCover.SizeMode = PictureBoxSizeMode.Zoom;

            btnSave.Text = "Güncelle";
            btnDelete.Visible = true;
        }*/
        private void LoadGenres()
        {
            cmbGenre.Items.AddRange(new string[]
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
        }

        private void UpdateFilm()
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                string query = @"
                    UPDATE Films SET
                    Title = @t,
                    Year = @y,
                    Genre = @g,
                    CoverPath = @c,
                    FilmDescription = @desc
                    WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@t", txtTitle.Text);
                cmd.Parameters.AddWithValue("@y", cmbYear.SelectedItem);
                cmd.Parameters.AddWithValue("@g", cmbGenre.SelectedItem);
                cmd.Parameters.AddWithValue("@c", selectedCoverPath);
                cmd.Parameters.AddWithValue("@desc", txtFilmDescription.Text);
                cmd.Parameters.AddWithValue("@id", editingFilm.Id);

                cmd.ExecuteNonQuery();
            }
        }

        private void AddFilm()
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                string query = @"
                    INSERT INTO Films (Title, Year, Genre, CoverPath, FilmDescription)
                    VALUES (@t, @y, @g, @c, @desc)";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@t", txtTitle.Text);
                cmd.Parameters.AddWithValue("@y", cmbYear.SelectedItem);
                cmd.Parameters.AddWithValue("@g", cmbGenre.SelectedItem);
                cmd.Parameters.AddWithValue("@c", selectedCoverPath);
                cmd.Parameters.AddWithValue("@desc", txtFilmDescription.Text);

                cmd.ExecuteNonQuery();
            }
        }
        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedCoverPath = ofd.FileName;
                picCover.ImageLocation = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
               cmbYear.SelectedItem == null ||
               cmbGenre.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (editingFilm == null)
                AddFilm();
            else
                UpdateFilm();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddFilm_Load(object sender, EventArgs e)
        {
            LoadGenres();
            LoadYears();

            picCover.SizeMode = PictureBoxSizeMode.Zoom;

            if (editingFilm == null)
            {
                // 🔵 ADD MODE
                selectedCoverPath = null;
                picCover.ImageLocation = CoverHelper.DefaultCoverPath;
                btnSave.Text = "Ekle";
                btnDelete.Visible = false;
                txtFilmDescription.Clear();
            }
            else
            {
                // 🟢 EDIT MODE
                txtTitle.Text = editingFilm.Title;
                cmbGenre.Text = editingFilm.Genre;
                cmbYear.Text = editingFilm.Year.ToString();

                txtFilmDescription.Text = editingFilm.Description;

                selectedCoverPath = editingFilm.CoverPath;
                picCover.ImageLocation = CoverHelper.GetCover(editingFilm.CoverPath);

                btnDelete.Visible = true;
                btnSave.Text = "Güncelle";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Film silinsin mi?", "Onay",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var con = DB.GetConnection())
                {
                    con.Open();
                    var cmd = new SQLiteCommand(
                        "DELETE FROM Films WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", editingFilm.Id);
                    cmd.ExecuteNonQuery();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
