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
    public partial class FormCreateList : Form
    {
        private ListItem editingList = null;

        public FormCreateList()
        {
            InitializeComponent();
        }
        public FormCreateList(ListItem list)
        {
            InitializeComponent();
            editingList = list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Liste adı boş olamaz.");
                return;
            }

            using (var con = DB.GetConnection())
            {
                con.Open();

                // aynı isim kontrolü (edit modunda kendisi hariç)
                var checkCmd = new SQLiteCommand(@"
                    SELECT COUNT(*) FROM Lists 
                    WHERE UserId=@u AND Name=@n AND (@id IS NULL OR Id<>@id)", con);

                checkCmd.Parameters.AddWithValue("@u", CurrentUser.Id);
                checkCmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                checkCmd.Parameters.AddWithValue("@id",
                    editingList == null ? (object)DBNull.Value : editingList.Id);

                long count = (long)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    var result = MessageBox.Show(
                        "Bu isimde bir listen zaten var.\nYine de kaydedilsin mi?",
                        "Uyarı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                if (editingList == null)
                {
                    var confirm = MessageBox.Show(
                        "Bu liste oluşturulsun mu?",
                        "Liste Oluştur",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm != DialogResult.Yes)
                        return;
                }

                if (editingList == null)
                {
                    // ✅ ADD
                    var cmd = new SQLiteCommand(@"
                INSERT INTO Lists (Name, Description, IsPublic, UserId, CreatedAt)
                VALUES (@n, @d, @p, @u, @c)", con);

                    cmd.Parameters.AddWithValue("@c",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    cmd.Parameters.AddWithValue("@u", CurrentUser.Id);
                    cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", chkPublic.Checked ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // ✅ UPDATE
                    var cmd = new SQLiteCommand(@"
                UPDATE Lists
                SET Name=@n, Description=@d, IsPublic=@p
                WHERE Id=@id", con);

                    cmd.Parameters.AddWithValue("@id", editingList.Id);
                    cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", chkPublic.Checked ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormCreateList_Load(object sender, EventArgs e)
        {
            if (editingList == null)
            {
                // ADD MODE
                lblCreateList.Text = "Liste Oluşturma";
                btnSave.Text = "Oluştur";
                btnDeleteList.Visible = false;
            }
            else
            {
                // EDIT MODE
                lblCreateList.Text = "Liste Güncelleme";

                txtName.Text = editingList.Name;
                txtDescription.Text = editingList.Description;
                chkPublic.Checked = editingList.IsPublic;

                btnSave.Text = "Güncelle";
                btnDeleteList.Visible = true;
            }
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Liste silinsin mi?",
                "Onay",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            using (var con = DB.GetConnection())
            {
                con.Open();

                new SQLiteCommand(
                    "DELETE FROM ListFilms WHERE ListId=@l", con)
                { Parameters = { new SQLiteParameter("@l", editingList.Id) } }
                .ExecuteNonQuery();

                new SQLiteCommand(
                    "DELETE FROM Lists WHERE Id=@l", con)
                { Parameters = { new SQLiteParameter("@l", editingList.Id) } }
                .ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
