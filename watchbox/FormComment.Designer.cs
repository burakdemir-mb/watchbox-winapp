namespace watchbox
{
    partial class FormComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComment));
            lblFilmTitle = new Label();
            txtNote = new RichTextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            lblDate = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblFilmTitle
            // 
            lblFilmTitle.AutoSize = true;
            lblFilmTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblFilmTitle.Location = new Point(6, 18);
            lblFilmTitle.Name = "lblFilmTitle";
            lblFilmTitle.Size = new Size(77, 32);
            lblFilmTitle.TabIndex = 0;
            lblFilmTitle.Text = "{title}";
            // 
            // txtNote
            // 
            txtNote.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtNote.Location = new Point(12, 85);
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtNote.Size = new Size(305, 250);
            txtNote.TabIndex = 1;
            txtNote.Text = "";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(119, 375);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Yorumu Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(242, 375);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 4;
            label1.Text = "Yorumunuz:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 338);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(38, 15);
            lblDate.TabIndex = 5;
            lblDate.Text = "{date}";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 375);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Yorumu Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // FormComment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 408);
            Controls.Add(btnDelete);
            Controls.Add(lblDate);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNote);
            Controls.Add(lblFilmTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormComment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormComment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFilmTitle;
        private RichTextBox txtNote;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label lblDate;
        private Button btnDelete;
    }
}