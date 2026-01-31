namespace watchbox
{
    partial class FormCreateList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateList));
            groupBox1 = new GroupBox();
            btnDeleteList = new Button();
            lblCreateList = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            labelListDescription = new Label();
            labelListName = new Label();
            txtName = new TextBox();
            chkPublic = new CheckBox();
            txtDescription = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeleteList);
            groupBox1.Controls.Add(lblCreateList);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(labelListDescription);
            groupBox1.Controls.Add(labelListName);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(chkPublic);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 416);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // btnDeleteList
            // 
            btnDeleteList.Location = new Point(15, 376);
            btnDeleteList.Name = "btnDeleteList";
            btnDeleteList.Size = new Size(75, 23);
            btnDeleteList.TabIndex = 13;
            btnDeleteList.Text = "Listeyi Sil";
            btnDeleteList.UseVisualStyleBackColor = true;
            btnDeleteList.Click += btnDeleteList_Click;
            // 
            // lblCreateList
            // 
            lblCreateList.AutoSize = true;
            lblCreateList.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblCreateList.Location = new Point(58, 19);
            lblCreateList.Name = "lblCreateList";
            lblCreateList.Size = new Size(193, 32);
            lblCreateList.TabIndex = 12;
            lblCreateList.Text = "Liste Oluşturma";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(217, 376);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(136, 376);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // labelListDescription
            // 
            labelListDescription.AutoSize = true;
            labelListDescription.Location = new Point(47, 142);
            labelListDescription.Name = "labelListDescription";
            labelListDescription.Size = new Size(91, 15);
            labelListDescription.TabIndex = 9;
            labelListDescription.Text = "Liste Açıklaması";
            // 
            // labelListName
            // 
            labelListName.AutoSize = true;
            labelListName.Location = new Point(47, 83);
            labelListName.Name = "labelListName";
            labelListName.Size = new Size(52, 15);
            labelListName.TabIndex = 8;
            labelListName.Text = "Liste Adı";
            // 
            // txtName
            // 
            txtName.Location = new Point(47, 101);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 5;
            // 
            // chkPublic
            // 
            chkPublic.AutoSize = true;
            chkPublic.Location = new Point(100, 284);
            chkPublic.Name = "chkPublic";
            chkPublic.Size = new Size(94, 19);
            chkPublic.TabIndex = 7;
            chkPublic.Text = "Herkese Açık";
            chkPublic.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(47, 160);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(207, 103);
            txtDescription.TabIndex = 6;
            // 
            // FormCreateList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 440);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormCreateList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormCreateList_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelListDescription;
        private Label labelListName;
        private TextBox txtName;
        private CheckBox chkPublic;
        private TextBox txtDescription;
        private Button btnCancel;
        private Button btnSave;
        private Label lblCreateList;
        private Button btnDeleteList;
    }
}