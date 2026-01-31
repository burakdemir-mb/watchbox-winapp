namespace watchbox
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnProfile = new Button();
            btnLists = new Button();
            btnMovies = new Button();
            btnLogout = new Button();
            labelWatchbox = new Label();
            lblWelcome = new Label();
            label1 = new Label();
            picSuggest1 = new PictureBox();
            picSuggest2 = new PictureBox();
            picSuggest3 = new PictureBox();
            lstRecentlyWatched = new ListBox();
            label2 = new Label();
            btnExit = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picSuggest1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSuggest2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSuggest3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(44, 110);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(140, 23);
            btnProfile.TabIndex = 0;
            btnProfile.Text = "Profilim";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLists
            // 
            btnLists.Location = new Point(44, 149);
            btnLists.Name = "btnLists";
            btnLists.Size = new Size(140, 23);
            btnLists.TabIndex = 1;
            btnLists.Text = "Listelerim";
            btnLists.UseVisualStyleBackColor = true;
            btnLists.Click += btnLists_Click;
            // 
            // btnMovies
            // 
            btnMovies.Location = new Point(44, 187);
            btnMovies.Name = "btnMovies";
            btnMovies.Size = new Size(140, 23);
            btnMovies.TabIndex = 2;
            btnMovies.Text = "Filmler";
            btnMovies.UseVisualStyleBackColor = true;
            btnMovies.Click += btnMovies_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(44, 374);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 23);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Çıkış Yap";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // labelWatchbox
            // 
            labelWatchbox.AutoSize = true;
            labelWatchbox.Font = new Font("Verdana", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            labelWatchbox.Location = new Point(233, -1);
            labelWatchbox.Name = "labelWatchbox";
            labelWatchbox.Size = new Size(214, 42);
            labelWatchbox.TabIndex = 5;
            labelWatchbox.Text = "Watchbox";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(12, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(138, 15);
            lblWelcome.TabIndex = 6;
            lblWelcome.Text = "Hoş geldiniz, {username}";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(254, 72);
            label1.Name = "label1";
            label1.Size = new Size(148, 17);
            label1.TabIndex = 7;
            label1.Text = "Bugünün Film Önerileri";
            // 
            // picSuggest1
            // 
            picSuggest1.Cursor = Cursors.Hand;
            picSuggest1.Location = new Point(256, 106);
            picSuggest1.Name = "picSuggest1";
            picSuggest1.Size = new Size(128, 180);
            picSuggest1.SizeMode = PictureBoxSizeMode.Zoom;
            picSuggest1.TabIndex = 8;
            picSuggest1.TabStop = false;
            picSuggest1.Click += picSuggest_DoubleClick;
            // 
            // picSuggest2
            // 
            picSuggest2.Cursor = Cursors.Hand;
            picSuggest2.Location = new Point(401, 106);
            picSuggest2.Name = "picSuggest2";
            picSuggest2.Size = new Size(128, 180);
            picSuggest2.SizeMode = PictureBoxSizeMode.Zoom;
            picSuggest2.TabIndex = 9;
            picSuggest2.TabStop = false;
            picSuggest2.Click += picSuggest_DoubleClick;
            // 
            // picSuggest3
            // 
            picSuggest3.Cursor = Cursors.Hand;
            picSuggest3.Location = new Point(544, 106);
            picSuggest3.Name = "picSuggest3";
            picSuggest3.Size = new Size(128, 180);
            picSuggest3.SizeMode = PictureBoxSizeMode.Zoom;
            picSuggest3.TabIndex = 10;
            picSuggest3.TabStop = false;
            picSuggest3.Click += picSuggest_DoubleClick;
            // 
            // lstRecentlyWatched
            // 
            lstRecentlyWatched.FormattingEnabled = true;
            lstRecentlyWatched.ItemHeight = 15;
            lstRecentlyWatched.Location = new Point(254, 342);
            lstRecentlyWatched.Name = "lstRecentlyWatched";
            lstRecentlyWatched.Size = new Size(418, 94);
            lstRecentlyWatched.TabIndex = 11;
            lstRecentlyWatched.DoubleClick += lstRecentlyWatched_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(254, 322);
            label2.Name = "label2";
            label2.Size = new Size(129, 17);
            label2.TabIndex = 12;
            label2.Text = "Son İzlediğin Filmler";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(44, 413);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(140, 23);
            btnExit.TabIndex = 13;
            btnExit.Text = "Uygulamayı Kapat";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.watchbox_icon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(453, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 448);
            Controls.Add(pictureBox1);
            Controls.Add(btnExit);
            Controls.Add(label2);
            Controls.Add(lstRecentlyWatched);
            Controls.Add(picSuggest3);
            Controls.Add(picSuggest2);
            Controls.Add(picSuggest1);
            Controls.Add(label1);
            Controls.Add(lblWelcome);
            Controls.Add(labelWatchbox);
            Controls.Add(btnLogout);
            Controls.Add(btnMovies);
            Controls.Add(btnLists);
            Controls.Add(btnProfile);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Activated += FormMain_Activated;
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)picSuggest1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSuggest2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSuggest3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProfile;
        private Button btnLists;
        private Button btnMovies;
        private Button btnLogout;
        private Label labelWatchbox;
        private Label lblWelcome;
        private Label label1;
        private PictureBox picSuggest1;
        private PictureBox picSuggest2;
        private PictureBox picSuggest3;
        private ListBox lstRecentlyWatched;
        private Label label2;
        private Button btnExit;
        private PictureBox pictureBox1;
    }
}