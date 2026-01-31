namespace watchbox
{
    partial class FormSelectList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectList));
            lstLists = new ListBox();
            btnAdd = new Button();
            btnCreateList = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lstLists
            // 
            lstLists.FormattingEnabled = true;
            lstLists.ItemHeight = 15;
            lstLists.Location = new Point(29, 58);
            lstLists.Name = "lstLists";
            lstLists.Size = new Size(297, 349);
            lstLists.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(221, 426);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Listeye Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCreateList
            // 
            btnCreateList.Location = new Point(40, 426);
            btnCreateList.Name = "btnCreateList";
            btnCreateList.Size = new Size(102, 23);
            btnCreateList.TabIndex = 2;
            btnCreateList.Text = "Liste Oluştur";
            btnCreateList.UseVisualStyleBackColor = true;
            btnCreateList.Click += btnCreateList_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 40);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 3;
            label1.Text = "Listeleriniz:";
            // 
            // FormSelectList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 470);
            Controls.Add(label1);
            Controls.Add(btnCreateList);
            Controls.Add(btnAdd);
            Controls.Add(lstLists);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSelectList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormSelectList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstLists;
        private Button btnAdd;
        private Button btnCreateList;
        private Label label1;
    }
}