namespace watchbox
{
    partial class FormMovies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMovies));
            labelMovies = new Label();
            btnSearch = new Button();
            lstFilms = new ListBox();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddFilm = new Button();
            picCover = new PictureBox();
            btnEdit = new Button();
            cmbFilterYear = new ComboBox();
            cmbFilterGenre = new ComboBox();
            lblRating = new Label();
            lblLike = new Label();
            btnAddToList = new Button();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            SuspendLayout();
            // 
            // labelMovies
            // 
            labelMovies.AutoSize = true;
            labelMovies.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelMovies.Location = new Point(12, 9);
            labelMovies.Name = "labelMovies";
            labelMovies.Size = new Size(289, 42);
            labelMovies.TabIndex = 2;
            labelMovies.Text = "Film Yönetimi";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(119, 301);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Film Ara";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lstFilms
            // 
            lstFilms.FormattingEnabled = true;
            lstFilms.ItemHeight = 15;
            lstFilms.Location = new Point(316, 239);
            lstFilms.Name = "lstFilms";
            lstFilms.Size = new Size(301, 124);
            lstFilms.TabIndex = 5;
            lstFilms.SelectedIndexChanged += lstFilms_SelectedIndexChanged;
            lstFilms.DoubleClick += lstFilms_DoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(43, 124);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(258, 23);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 106);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 9;
            label1.Text = "Film Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 162);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 10;
            label2.Text = "Film Yılı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 219);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 11;
            label3.Text = "Film Türü";
            // 
            // btnAddFilm
            // 
            btnAddFilm.Location = new Point(542, 403);
            btnAddFilm.Name = "btnAddFilm";
            btnAddFilm.Size = new Size(75, 23);
            btnAddFilm.TabIndex = 12;
            btnAddFilm.Text = "Film Ekle";
            btnAddFilm.UseVisualStyleBackColor = true;
            btnAddFilm.Click += btnAddFilm_Click;
            // 
            // picCover
            // 
            picCover.Location = new Point(381, 12);
            picCover.Name = "picCover";
            picCover.Size = new Size(165, 226);
            picCover.TabIndex = 13;
            picCover.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(316, 403);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(99, 23);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Filmi Düzenle";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // cmbFilterYear
            // 
            cmbFilterYear.FormattingEnabled = true;
            cmbFilterYear.Location = new Point(43, 180);
            cmbFilterYear.Name = "cmbFilterYear";
            cmbFilterYear.Size = new Size(121, 23);
            cmbFilterYear.TabIndex = 15;
            cmbFilterYear.SelectedIndexChanged += cmbFilterYear_SelectedIndexChanged;
            // 
            // cmbFilterGenre
            // 
            cmbFilterGenre.FormattingEnabled = true;
            cmbFilterGenre.Location = new Point(45, 237);
            cmbFilterGenre.Name = "cmbFilterGenre";
            cmbFilterGenre.Size = new Size(121, 23);
            cmbFilterGenre.TabIndex = 16;
            cmbFilterGenre.SelectedIndexChanged += cmbFilterGenre_SelectedIndexChanged;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblRating.Location = new Point(552, 185);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(46, 15);
            lblRating.TabIndex = 17;
            lblRating.Text = "{rating}";
            lblRating.Visible = false;
            // 
            // lblLike
            // 
            lblLike.AutoSize = true;
            lblLike.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblLike.Location = new Point(552, 208);
            lblLike.Name = "lblLike";
            lblLike.Size = new Size(40, 15);
            lblLike.TabIndex = 18;
            lblLike.Text = "{liked}";
            lblLike.Visible = false;
            // 
            // btnAddToList
            // 
            btnAddToList.Location = new Point(45, 403);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(151, 23);
            btnAddToList.TabIndex = 19;
            btnAddToList.Text = "Filmi Listeye Ekle";
            btnAddToList.UseVisualStyleBackColor = true;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // FormMovies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 450);
            Controls.Add(btnAddToList);
            Controls.Add(lblLike);
            Controls.Add(lblRating);
            Controls.Add(cmbFilterGenre);
            Controls.Add(cmbFilterYear);
            Controls.Add(btnEdit);
            Controls.Add(picCover);
            Controls.Add(btnAddFilm);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(lstFilms);
            Controls.Add(btnSearch);
            Controls.Add(labelMovies);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMovies";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormMovies_Load;
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMovies;
        private Button btnSearch;
        private ListBox lstFilms;
        private TextBox txtSearch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAddFilm;
        private PictureBox picCover;
        private Button btnEdit;
        private ComboBox cmbFilterYear;
        private ComboBox cmbFilterGenre;
        private Label lblRating;
        private Label lblLike;
        private Button btnAddToList;
    }
}