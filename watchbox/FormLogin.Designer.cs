namespace watchbox
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            labelWatchbox = new Label();
            txtLgnUsername = new TextBox();
            txtLgnPassword = new TextBox();
            labelUsername = new Label();
            labelPassword = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            groupBoxLgnPage = new GroupBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBoxLgnPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelWatchbox
            // 
            labelWatchbox.AutoSize = true;
            labelWatchbox.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelWatchbox.Location = new Point(21, 29);
            labelWatchbox.Name = "labelWatchbox";
            labelWatchbox.Size = new Size(214, 42);
            labelWatchbox.TabIndex = 0;
            labelWatchbox.Text = "Watchbox";
            // 
            // txtLgnUsername
            // 
            txtLgnUsername.Location = new Point(73, 146);
            txtLgnUsername.Name = "txtLgnUsername";
            txtLgnUsername.Size = new Size(100, 23);
            txtLgnUsername.TabIndex = 1;
            // 
            // txtLgnPassword
            // 
            txtLgnPassword.Location = new Point(73, 213);
            txtLgnPassword.Name = "txtLgnPassword";
            txtLgnPassword.PasswordChar = '*';
            txtLgnPassword.Size = new Size(100, 23);
            txtLgnPassword.TabIndex = 2;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(73, 128);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(73, 15);
            labelUsername.TabIndex = 3;
            labelUsername.Text = "Kullanıcı Adı";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(73, 195);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(30, 15);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Şifre";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(87, 257);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Giriş Yap";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(87, 378);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // groupBoxLgnPage
            // 
            groupBoxLgnPage.Controls.Add(pictureBox1);
            groupBoxLgnPage.Controls.Add(label1);
            groupBoxLgnPage.Controls.Add(labelWatchbox);
            groupBoxLgnPage.Controls.Add(btnRegister);
            groupBoxLgnPage.Controls.Add(txtLgnUsername);
            groupBoxLgnPage.Controls.Add(btnLogin);
            groupBoxLgnPage.Controls.Add(txtLgnPassword);
            groupBoxLgnPage.Controls.Add(labelPassword);
            groupBoxLgnPage.Controls.Add(labelUsername);
            groupBoxLgnPage.Location = new Point(12, 12);
            groupBoxLgnPage.Name = "groupBoxLgnPage";
            groupBoxLgnPage.Size = new Size(256, 407);
            groupBoxLgnPage.TabIndex = 7;
            groupBoxLgnPage.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.watchbox_icon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(104, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 360);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 7;
            label1.Text = "Yeni Kullanıcı mısınız?";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 450);
            Controls.Add(groupBoxLgnPage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            FormClosing += FormLogin_FormClosing;
            Load += FormLogin_Load;
            groupBoxLgnPage.ResumeLayout(false);
            groupBoxLgnPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelWatchbox;
        private TextBox txtLgnUsername;
        private TextBox txtLgnPassword;
        private Label labelUsername;
        private Label labelPassword;
        private Button btnLogin;
        private Button btnRegister;
        private GroupBox groupBoxLgnPage;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
