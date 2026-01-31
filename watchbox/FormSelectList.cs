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
    public partial class FormSelectList : Form
    {
        int filmId;

        public FormSelectList(int filmId, int? preSelectedListId = null)
        {
            InitializeComponent();
            this.filmId = filmId;
        }

        private void LoadLists()
        {
            lstLists.Items.Clear();

            foreach (var list in ListRepository.GetUserLists(CurrentUser.Id))
            {
                lstLists.Items.Add(list);
            }
        }

        private void FormSelectList_Load(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstLists.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir liste seç.");
                return;
            }

            var list = (ListItem)lstLists.SelectedItem;

            using (var con = DB.GetConnection())
            {
                con.Open();

                var checkCmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM ListFilms WHERE ListId=@l AND FilmId=@f", con);
                checkCmd.Parameters.AddWithValue("@l", list.Id);
                checkCmd.Parameters.AddWithValue("@f", filmId);

                long exists = (long)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Bu film zaten bu listede.");
                    return;
                }

                var cmd = new SQLiteCommand(@"
                    INSERT INTO ListFilms (ListId, FilmId, AddedAt)
                    VALUES (@l, @f, @d)", con);

                cmd.Parameters.AddWithValue("@l", list.Id);
                cmd.Parameters.AddWithValue("@f", filmId);
                cmd.Parameters.AddWithValue("@d",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                cmd.ExecuteNonQuery();
            }
            
            MessageBox.Show(
                $"Film \"{list.Name}\" listesine eklendi 🎉",
                "Başarılı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            var frm = new FormCreateList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadLists();
            }
        }
    }
}
