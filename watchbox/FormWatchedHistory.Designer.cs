namespace watchbox
{
    partial class FormWatchedHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWatchedHistory));
            dgvWatched = new DataGridView();
            btnClose = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvWatched).BeginInit();
            SuspendLayout();
            // 
            // dgvWatched
            // 
            dgvWatched.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWatched.Location = new Point(12, 27);
            dgvWatched.Name = "dgvWatched";
            dgvWatched.Size = new Size(776, 386);
            dgvWatched.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(697, 419);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Kapat";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "İzlediğin Filmler";
            // 
            // FormWatchedHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(dgvWatched);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormWatchedHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormWatchedHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWatched).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvWatched;
        private Button btnClose;
        private Label label1;
    }
}