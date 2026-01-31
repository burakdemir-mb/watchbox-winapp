namespace watchbox
{
    partial class FormRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            labelRegUsername = new Label();
            labelRegPassword = new Label();
            labelWatchbox = new Label();
            btnRegister = new Button();
            groupBoxReg = new GroupBox();
            pictureBox1 = new PictureBox();
            groupBoxReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(80, 159);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(80, 239);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 1;
            // 
            // labelRegUsername
            // 
            labelRegUsername.AutoSize = true;
            labelRegUsername.Location = new Point(80, 141);
            labelRegUsername.Name = "labelRegUsername";
            labelRegUsername.Size = new Size(73, 15);
            labelRegUsername.TabIndex = 2;
            labelRegUsername.Text = "Kullanıcı Adı";
            // 
            // labelRegPassword
            // 
            labelRegPassword.AutoSize = true;
            labelRegPassword.Location = new Point(80, 221);
            labelRegPassword.Name = "labelRegPassword";
            labelRegPassword.Size = new Size(30, 15);
            labelRegPassword.TabIndex = 3;
            labelRegPassword.Text = "Şifre";
            // 
            // labelWatchbox
            // 
            labelWatchbox.AutoSize = true;
            labelWatchbox.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelWatchbox.Location = new Point(30, 34);
            labelWatchbox.Name = "labelWatchbox";
            labelWatchbox.Size = new Size(214, 42);
            labelWatchbox.TabIndex = 4;
            labelWatchbox.Text = "Watchbox";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(93, 336);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegReg_Click;
            // 
            // groupBoxReg
            // 
            groupBoxReg.Controls.Add(pictureBox1);
            groupBoxReg.Controls.Add(txtPassword);
            groupBoxReg.Controls.Add(btnRegister);
            groupBoxReg.Controls.Add(txtUsername);
            groupBoxReg.Controls.Add(labelWatchbox);
            groupBoxReg.Controls.Add(labelRegUsername);
            groupBoxReg.Controls.Add(labelRegPassword);
            groupBoxReg.Location = new Point(12, 12);
            groupBoxReg.Name = "groupBoxReg";
            groupBoxReg.Size = new Size(275, 426);
            groupBoxReg.TabIndex = 6;
            groupBoxReg.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.watchbox_icon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(118, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 450);
            Controls.Add(groupBoxReg);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            groupBoxReg.ResumeLayout(false);
            groupBoxReg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label labelRegUsername;
        private Label labelRegPassword;
        private Label labelWatchbox;
        private Button btnRegister;
        private GroupBox groupBoxReg;
        private PictureBox pictureBox1;
    }
}