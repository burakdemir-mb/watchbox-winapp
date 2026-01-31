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
    public partial class FormComment : Form
    {
        FilmItem film;
        int userId;
        int noteId = -1;

        public FormComment(FilmItem filmItem, int userId)
        {
            InitializeComponent();
            film = filmItem;
            this.userId = userId;
        }

        private void FormComment_Load(object sender, EventArgs e)
        {
            lblFilmTitle.Text = $"{film.Title} ({film.Year})";

            using (var con = DB.GetConnection())
            {
                con.Open();

                using (var cmd = new SQLiteCommand(
                    "SELECT Id, Note, CreatedAt, UpdatedAt FROM FilmNotes WHERE FilmId=@f AND UserId=@u", con))
                {
                    cmd.Parameters.AddWithValue("@f", film.Id);
                    cmd.Parameters.AddWithValue("@u", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            noteId = Convert.ToInt32(reader["Id"]);
                            txtNote.Text = reader["Note"].ToString();

                            string date = reader["UpdatedAt"] != DBNull.Value
                                ? reader["UpdatedAt"].ToString()
                                : reader["CreatedAt"].ToString();

                            lblDate.Text = "Son düzenleme: " + date;

                            btnSave.Text = "Yorumu Güncelle";
                            btnDelete.Visible = true;
                        }
                        else
                        {
                            btnSave.Text = "Yorum Kaydet";
                            lblDate.Text = "";
                            btnDelete.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Yorum boş olamaz.");
                return;
            }

            using (var con = DB.GetConnection())
            {
                con.Open();
                SQLiteCommand cmd;

                if (noteId == -1)
                {
                    cmd = new SQLiteCommand(@"
                        INSERT INTO FilmNotes (FilmId, UserId, Note, CreatedAt)
                        VALUES (@f, @u, @n, @d)", con);

                    cmd.Parameters.AddWithValue("@d",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                }
                else
                {
                    cmd = new SQLiteCommand(@"
                        UPDATE FilmNotes SET
                        Note=@n,
                        UpdatedAt=@d
                        WHERE Id=@id", con);

                    cmd.Parameters.AddWithValue("@id", noteId);
                    cmd.Parameters.AddWithValue("@d",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                }

                cmd.Parameters.AddWithValue("@f", film.Id);
                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@n", txtNote.Text);

                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yorum silinsin mi?",
                "Onay", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(
                    "DELETE FROM FilmNotes WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", noteId);

                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
