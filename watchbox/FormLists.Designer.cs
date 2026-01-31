namespace watchbox
{
    partial class FormLists
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLists));
            labelLists = new Label();
            lstLists = new ListBox();
            btnAddList = new Button();
            labelListShow = new Label();
            btnOpenList = new Button();
            SuspendLayout();
            // 
            // labelLists
            // 
            labelLists.AutoSize = true;
            labelLists.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelLists.Location = new Point(26, 9);
            labelLists.Name = "labelLists";
            labelLists.Size = new Size(299, 42);
            labelLists.TabIndex = 1;
            labelLists.Text = "Liste Yönetimi";
            // 
            // lstLists
            // 
            lstLists.FormattingEnabled = true;
            lstLists.ItemHeight = 15;
            lstLists.Location = new Point(52, 96);
            lstLists.Name = "lstLists";
            lstLists.Size = new Size(229, 304);
            lstLists.TabIndex = 2;
            lstLists.DoubleClick += lstLists_DoubleClick;
            // 
            // btnAddList
            // 
            btnAddList.Location = new Point(35, 415);
            btnAddList.Name = "btnAddList";
            btnAddList.Size = new Size(132, 23);
            btnAddList.TabIndex = 3;
            btnAddList.Text = "Liste Ekle";
            btnAddList.UseVisualStyleBackColor = true;
            btnAddList.Click += btnCreateList_Click;
            // 
            // labelListShow
            // 
            labelListShow.AutoSize = true;
            labelListShow.Location = new Point(35, 78);
            labelListShow.Name = "labelListShow";
            labelListShow.Size = new Size(62, 15);
            labelListShow.TabIndex = 4;
            labelListShow.Text = "Listeleriniz";
            // 
            // btnOpenList
            // 
            btnOpenList.Location = new Point(179, 415);
            btnOpenList.Name = "btnOpenList";
            btnOpenList.Size = new Size(132, 23);
            btnOpenList.TabIndex = 9;
            btnOpenList.Text = "Listeyi Aç";
            btnOpenList.UseVisualStyleBackColor = true;
            btnOpenList.Click += btnOpenList_Click;
            // 
            // FormLists
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 450);
            Controls.Add(btnOpenList);
            Controls.Add(labelListShow);
            Controls.Add(lstLists);
            Controls.Add(labelLists);
            Controls.Add(btnAddList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLists";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormLists_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLists;
        private ListBox lstLists;
        private Button btnAddList;
        private Label labelListShow;
        private Button btnOpenList;
    }
}