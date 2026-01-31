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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLgnUsername.Text.Trim();
            string password = txtLgnPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Kullanýcý adý ve þifre boþ olamaz.");
                return;
            }

            using (var con = DB.GetConnection())
            {
                con.Open();

                var existsCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", con);
                existsCmd.Parameters.AddWithValue("@u", username);
                long exists = (long)existsCmd.ExecuteScalar();

                if (exists == 0)
                {
                    MessageBox.Show("Böyle bir hesap yok. Lütfen kayýt olun.");
                    return;
                }

                var cmd = new SQLiteCommand("SELECT Id FROM Users WHERE Username=@u AND Password=@p", con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    CurrentUser.Id = Convert.ToInt32(result);
                    CurrentUser.Username = username;

                    FormMain main = new FormMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanýcý adý veya þifre yanlýþ.");
                }
            }
        }

        public void ResetFields()
        {
            txtLgnUsername.Clear();
            txtLgnPassword.Clear();
            txtLgnUsername.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            DB.EnsureDatabase();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
