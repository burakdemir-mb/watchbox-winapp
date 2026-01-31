using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace watchbox
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegReg_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.");
                return;
            }

            using (var con = DB.GetConnection())
            {
                con.Open();

                // Kullanıcı adı var mı?
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@u";
                SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@u", username);

                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor.");
                    return;
                }

                // Kayıt ekle
                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@u, @p)";
                SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@u", username);
                insertCmd.Parameters.AddWithValue("@p", password);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt başarılı! Giriş yapabilirsiniz.");
                this.Close();
            }
        }
    }
}
