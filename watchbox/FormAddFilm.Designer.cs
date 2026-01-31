namespace watchbox
{
    partial class FormAddFilm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFilm));
            txtTitle = new TextBox();
            picCover = new PictureBox();
            btnSelectCover = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            openFileDialog1 = new OpenFileDialog();
            cmbGenre = new ComboBox();
            cmbYear = new ComboBox();
            btnDelete = new Button();
            txtFilmDescription = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(99, 244);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 0;
            // 
            // picCover
            // 
            picCover.Location = new Point(99, 26);
            picCover.Name = "picCover";
            picCover.Size = new Size(127, 188);
            picCover.TabIndex = 3;
            picCover.TabStop = false;
            // 
            // btnSelectCover
            // 
            btnSelectCover.Location = new Point(232, 166);
            btnSelectCover.Name = "btnSelectCover";
            btnSelectCover.Size = new Size(98, 48);
            btnSelectCover.TabIndex = 4;
            btnSelectCover.Text = "Kapak Fotoğrafı Seç";
            btnSelectCover.UseVisualStyleBackColor = true;
            btnSelectCover.Click += btnSelectCover_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(168, 493);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(249, 493);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 247);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 7;
            label1.Text = "Film Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 294);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 8;
            label2.Text = "Film Yılı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 341);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 9;
            label3.Text = "Film Türü";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(99, 338);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(121, 23);
            cmbGenre.TabIndex = 10;
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(99, 291);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(121, 23);
            cmbYear.TabIndex = 11;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 493);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(81, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Bu Filmi Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtFilmDescription
            // 
            txtFilmDescription.Location = new Point(99, 380);
            txtFilmDescription.Multiline = true;
            txtFilmDescription.Name = "txtFilmDescription";
            txtFilmDescription.Size = new Size(235, 89);
            txtFilmDescription.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 383);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 14;
            label4.Text = "Film Açıklaması";
            // 
            // FormAddFilm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 528);
            Controls.Add(label4);
            Controls.Add(txtFilmDescription);
            Controls.Add(btnDelete);
            Controls.Add(cmbYear);
            Controls.Add(cmbGenre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnSelectCover);
            Controls.Add(picCover);
            Controls.Add(txtTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddFilm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormAddFilm_Load;
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private PictureBox picCover;
        private Button btnSelectCover;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private ComboBox cmbGenre;
        private ComboBox cmbYear;
        private Button btnDelete;
        private TextBox txtFilmDescription;
        private Label label4;
    }
}