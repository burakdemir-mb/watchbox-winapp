namespace watchbox
{
    partial class FormFilmDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilmDetail));
            picCover = new PictureBox();
            panelFilmDetail = new Panel();
            picWatched = new PictureBox();
            btnAddToList = new Button();
            txtFilmDescription = new RichTextBox();
            btnComment = new Button();
            btnClearRating = new Button();
            picStar5 = new PictureBox();
            picStar4 = new PictureBox();
            picStar3 = new PictureBox();
            picStar2 = new PictureBox();
            picStar1 = new PictureBox();
            picLike = new PictureBox();
            lblYear = new Label();
            lblGenre = new Label();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            panelFilmDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWatched).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLike).BeginInit();
            SuspendLayout();
            // 
            // picCover
            // 
            picCover.Location = new Point(12, 12);
            picCover.Name = "picCover";
            picCover.Size = new Size(217, 302);
            picCover.SizeMode = PictureBoxSizeMode.Zoom;
            picCover.TabIndex = 0;
            picCover.TabStop = false;
            // 
            // panelFilmDetail
            // 
            panelFilmDetail.Controls.Add(picWatched);
            panelFilmDetail.Controls.Add(btnAddToList);
            panelFilmDetail.Controls.Add(txtFilmDescription);
            panelFilmDetail.Controls.Add(btnComment);
            panelFilmDetail.Controls.Add(btnClearRating);
            panelFilmDetail.Controls.Add(picStar5);
            panelFilmDetail.Controls.Add(picStar4);
            panelFilmDetail.Controls.Add(picStar3);
            panelFilmDetail.Controls.Add(picStar2);
            panelFilmDetail.Controls.Add(picStar1);
            panelFilmDetail.Controls.Add(picLike);
            panelFilmDetail.Controls.Add(lblYear);
            panelFilmDetail.Controls.Add(lblGenre);
            panelFilmDetail.Controls.Add(lblTitle);
            panelFilmDetail.Controls.Add(picCover);
            panelFilmDetail.Dock = DockStyle.Left;
            panelFilmDetail.Location = new Point(0, 0);
            panelFilmDetail.Name = "panelFilmDetail";
            panelFilmDetail.Size = new Size(563, 390);
            panelFilmDetail.TabIndex = 1;
            // 
            // picWatched
            // 
            picWatched.Cursor = Cursors.Hand;
            picWatched.Location = new Point(468, 30);
            picWatched.Name = "picWatched";
            picWatched.Size = new Size(32, 32);
            picWatched.TabIndex = 20;
            picWatched.TabStop = false;
            picWatched.Click += picWatched_Click;
            picWatched.MouseEnter += picWatched_MouseEnter;
            picWatched.MouseLeave += picWatched_MouseLeave;
            // 
            // btnAddToList
            // 
            btnAddToList.Location = new Point(242, 355);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(133, 23);
            btnAddToList.TabIndex = 19;
            btnAddToList.Text = "Bu Filmi Listeye Ekle";
            btnAddToList.UseVisualStyleBackColor = true;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // txtFilmDescription
            // 
            txtFilmDescription.BorderStyle = BorderStyle.None;
            txtFilmDescription.Location = new Point(242, 151);
            txtFilmDescription.Name = "txtFilmDescription";
            txtFilmDescription.ReadOnly = true;
            txtFilmDescription.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtFilmDescription.Size = new Size(296, 198);
            txtFilmDescription.TabIndex = 18;
            txtFilmDescription.Text = "";
            // 
            // btnComment
            // 
            btnComment.Location = new Point(381, 355);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(157, 23);
            btnComment.TabIndex = 17;
            btnComment.Text = "Yorum Yap";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
            // 
            // btnClearRating
            // 
            btnClearRating.Location = new Point(66, 358);
            btnClearRating.Name = "btnClearRating";
            btnClearRating.Size = new Size(108, 23);
            btnClearRating.TabIndex = 16;
            btnClearRating.Text = "Puanı Sıfırla";
            btnClearRating.UseVisualStyleBackColor = true;
            btnClearRating.Click += btnClearRating_Click;
            // 
            // picStar5
            // 
            picStar5.Cursor = Cursors.Hand;
            picStar5.Location = new Point(180, 320);
            picStar5.Name = "picStar5";
            picStar5.Size = new Size(32, 32);
            picStar5.TabIndex = 15;
            picStar5.TabStop = false;
            picStar5.Click += Star_Click;
            picStar5.MouseLeave += Star_MouseLeave;
            picStar5.MouseMove += Star_MouseMove;
            // 
            // picStar4
            // 
            picStar4.Cursor = Cursors.Hand;
            picStar4.Location = new Point(142, 320);
            picStar4.Name = "picStar4";
            picStar4.Size = new Size(32, 32);
            picStar4.TabIndex = 14;
            picStar4.TabStop = false;
            picStar4.Click += Star_Click;
            picStar4.MouseLeave += Star_MouseLeave;
            picStar4.MouseMove += Star_MouseMove;
            // 
            // picStar3
            // 
            picStar3.Cursor = Cursors.Hand;
            picStar3.Location = new Point(104, 320);
            picStar3.Name = "picStar3";
            picStar3.Size = new Size(32, 32);
            picStar3.TabIndex = 13;
            picStar3.TabStop = false;
            picStar3.Click += Star_Click;
            picStar3.MouseLeave += Star_MouseLeave;
            picStar3.MouseMove += Star_MouseMove;
            // 
            // picStar2
            // 
            picStar2.Cursor = Cursors.Hand;
            picStar2.Location = new Point(66, 320);
            picStar2.Name = "picStar2";
            picStar2.Size = new Size(32, 32);
            picStar2.TabIndex = 12;
            picStar2.TabStop = false;
            picStar2.Click += Star_Click;
            picStar2.MouseLeave += Star_MouseLeave;
            picStar2.MouseMove += Star_MouseMove;
            // 
            // picStar1
            // 
            picStar1.Cursor = Cursors.Hand;
            picStar1.Location = new Point(28, 320);
            picStar1.Name = "picStar1";
            picStar1.Size = new Size(32, 32);
            picStar1.TabIndex = 11;
            picStar1.TabStop = false;
            picStar1.Click += Star_Click;
            picStar1.MouseLeave += Star_MouseLeave;
            picStar1.MouseMove += Star_MouseMove;
            // 
            // picLike
            // 
            picLike.Cursor = Cursors.Hand;
            picLike.Location = new Point(506, 30);
            picLike.Name = "picLike";
            picLike.Size = new Size(32, 32);
            picLike.TabIndex = 10;
            picLike.TabStop = false;
            picLike.Click += picLike_Click;
            picLike.MouseEnter += picLike_MouseEnter;
            picLike.MouseLeave += picLike_MouseLeave;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(242, 114);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(37, 15);
            lblYear.TabIndex = 4;
            lblYear.Text = "{year}";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(242, 73);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(45, 15);
            lblGenre.TabIndex = 2;
            lblGenre.Text = "{genre}";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTitle.Location = new Point(235, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(90, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "{title}";
            // 
            // FormFilmDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 390);
            Controls.Add(panelFilmDetail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormFilmDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormFilmDetail_Load;
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            panelFilmDetail.ResumeLayout(false);
            panelFilmDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picWatched).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLike).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picCover;
        private Panel panelFilmDetail;
        private Label lblYear;
        private Label lblGenre;
        private Label lblTitle;
        private PictureBox picLike;
        private PictureBox picStar1;
        private PictureBox picStar5;
        private PictureBox picStar4;
        private PictureBox picStar3;
        private PictureBox picStar2;
        private Button btnClearRating;
        private Button btnComment;
        private RichTextBox txtFilmDescription;
        private Button btnAddToList;
        private PictureBox picWatched;
    }
}