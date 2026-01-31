namespace watchbox
{
    partial class FormListDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListDetail));
            picCover = new PictureBox();
            lblListName = new Label();
            lstFilms = new ListBox();
            txtDescription = new RichTextBox();
            lblVisibility = new Label();
            btnRemoveFilm = new Button();
            label1 = new Label();
            btnAddFilm = new Button();
            btnEditList = new Button();
            lblRating = new Label();
            lblLike = new Label();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            SuspendLayout();
            // 
            // picCover
            // 
            picCover.Location = new Point(344, 12);
            picCover.Name = "picCover";
            picCover.Size = new Size(167, 254);
            picCover.TabIndex = 0;
            picCover.TabStop = false;
            // 
            // lblListName
            // 
            lblListName.AutoSize = true;
            lblListName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblListName.Location = new Point(8, 23);
            lblListName.Name = "lblListName";
            lblListName.Size = new Size(98, 25);
            lblListName.TabIndex = 1;
            lblListName.Text = "{listName}";
            // 
            // lstFilms
            // 
            lstFilms.FormattingEnabled = true;
            lstFilms.ItemHeight = 15;
            lstFilms.Location = new Point(12, 189);
            lstFilms.Name = "lstFilms";
            lstFilms.Size = new Size(312, 139);
            lstFilms.TabIndex = 2;
            lstFilms.SelectedIndexChanged += lstFilms_SelectedIndexChanged;
            lstFilms.DoubleClick += lstFilms_DoubleClick;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 51);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(312, 99);
            txtDescription.TabIndex = 3;
            txtDescription.Text = "";
            // 
            // lblVisibility
            // 
            lblVisibility.AutoSize = true;
            lblVisibility.Location = new Point(245, 33);
            lblVisibility.Name = "lblVisibility";
            lblVisibility.Size = new Size(58, 15);
            lblVisibility.TabIndex = 4;
            lblVisibility.Text = "{visibility}";
            // 
            // btnRemoveFilm
            // 
            btnRemoveFilm.Location = new Point(93, 334);
            btnRemoveFilm.Name = "btnRemoveFilm";
            btnRemoveFilm.Size = new Size(120, 23);
            btnRemoveFilm.TabIndex = 6;
            btnRemoveFilm.Text = "Seçilen Filmi Sil";
            btnRemoveFilm.UseVisualStyleBackColor = true;
            btnRemoveFilm.Click += btnRemoveFilm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 171);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 7;
            label1.Text = "Listendeki Filmler:";
            // 
            // btnAddFilm
            // 
            btnAddFilm.Location = new Point(12, 334);
            btnAddFilm.Name = "btnAddFilm";
            btnAddFilm.Size = new Size(75, 23);
            btnAddFilm.TabIndex = 8;
            btnAddFilm.Text = "Film Ekle";
            btnAddFilm.UseVisualStyleBackColor = true;
            btnAddFilm.Click += btnAddFilm_Click;
            // 
            // btnEditList
            // 
            btnEditList.Location = new Point(414, 334);
            btnEditList.Name = "btnEditList";
            btnEditList.Size = new Size(97, 23);
            btnEditList.TabIndex = 9;
            btnEditList.Text = "Listeyi Düzenle";
            btnEditList.UseVisualStyleBackColor = true;
            btnEditList.Click += btnEditList_Click;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Location = new Point(344, 269);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(46, 15);
            lblRating.TabIndex = 10;
            lblRating.Text = "{rating}";
            // 
            // lblLike
            // 
            lblLike.AutoSize = true;
            lblLike.Location = new Point(490, 269);
            lblLike.Name = "lblLike";
            lblLike.Size = new Size(40, 15);
            lblLike.TabIndex = 11;
            lblLike.Text = "{liked}";
            // 
            // FormListDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 371);
            Controls.Add(lblLike);
            Controls.Add(lblRating);
            Controls.Add(btnEditList);
            Controls.Add(btnAddFilm);
            Controls.Add(label1);
            Controls.Add(btnRemoveFilm);
            Controls.Add(lblVisibility);
            Controls.Add(txtDescription);
            Controls.Add(lstFilms);
            Controls.Add(lblListName);
            Controls.Add(picCover);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormListDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormListDetail_Load;
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCover;
        private Label lblListName;
        private ListBox lstFilms;
        private RichTextBox txtDescription;
        private Label lblVisibility;
        private Button btnRemoveFilm;
        private Label label1;
        private Button btnAddFilm;
        private Button btnEditList;
        private Label lblRating;
        private Label lblLike;
    }
}