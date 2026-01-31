namespace watchbox
{
    partial class FormProfile
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfile));
            lblUsername = new Label();
            chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblChartTitle = new Label();
            btnPrev = new Button();
            btnNext = new Button();
            label1 = new Label();
            lstProfile = new ListBox();
            picRecent1 = new PictureBox();
            picRecent2 = new PictureBox();
            picRecent3 = new PictureBox();
            btnPrevList = new Button();
            btnNextList = new Button();
            lblListTitle = new Label();
            btnWatchedTable = new Button();
            ((System.ComponentModel.ISupportInitialize)chartMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRecent1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRecent2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRecent3).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(625, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(67, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "{username}";
            // 
            // chartMain
            // 
            chartArea1.Name = "ChartArea1";
            chartMain.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartMain.Legends.Add(legend1);
            chartMain.Location = new Point(379, 70);
            chartMain.Name = "chartMain";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartMain.Series.Add(series1);
            chartMain.Size = new Size(300, 300);
            chartMain.TabIndex = 1;
            chartMain.Text = "chart1";
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Location = new Point(379, 52);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.RightToLeft = RightToLeft.No;
            lblChartTitle.Size = new Size(65, 15);
            lblChartTitle.TabIndex = 4;
            lblChartTitle.Text = "{chartTitle}";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(615, 44);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(29, 23);
            btnPrev.TabIndex = 5;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(650, 44);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(29, 23);
            btnNext.TabIndex = 6;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 7;
            label1.Text = "Profiliniz";
            // 
            // lstProfile
            // 
            lstProfile.FormattingEnabled = true;
            lstProfile.ItemHeight = 15;
            lstProfile.Location = new Point(12, 246);
            lstProfile.Name = "lstProfile";
            lstProfile.Size = new Size(346, 124);
            lstProfile.TabIndex = 9;
            lstProfile.DoubleClick += lstProfile_DoubleClick;
            // 
            // picRecent1
            // 
            picRecent1.Cursor = Cursors.Hand;
            picRecent1.Location = new Point(12, 52);
            picRecent1.Name = "picRecent1";
            picRecent1.Size = new Size(105, 151);
            picRecent1.SizeMode = PictureBoxSizeMode.Zoom;
            picRecent1.TabIndex = 10;
            picRecent1.TabStop = false;
            picRecent1.Click += picRecent_Click;
            // 
            // picRecent2
            // 
            picRecent2.Cursor = Cursors.Hand;
            picRecent2.Location = new Point(131, 52);
            picRecent2.Name = "picRecent2";
            picRecent2.Size = new Size(107, 151);
            picRecent2.SizeMode = PictureBoxSizeMode.Zoom;
            picRecent2.TabIndex = 11;
            picRecent2.TabStop = false;
            picRecent2.Click += picRecent_Click;
            // 
            // picRecent3
            // 
            picRecent3.Cursor = Cursors.Hand;
            picRecent3.Location = new Point(252, 52);
            picRecent3.Name = "picRecent3";
            picRecent3.Size = new Size(105, 151);
            picRecent3.SizeMode = PictureBoxSizeMode.Zoom;
            picRecent3.TabIndex = 12;
            picRecent3.TabStop = false;
            picRecent3.Click += picRecent_Click;
            // 
            // btnPrevList
            // 
            btnPrevList.Location = new Point(293, 220);
            btnPrevList.Name = "btnPrevList";
            btnPrevList.Size = new Size(29, 23);
            btnPrevList.TabIndex = 13;
            btnPrevList.Text = "<";
            btnPrevList.UseVisualStyleBackColor = true;
            btnPrevList.Click += btnPrevList_Click;
            // 
            // btnNextList
            // 
            btnNextList.Location = new Point(328, 220);
            btnNextList.Name = "btnNextList";
            btnNextList.Size = new Size(29, 23);
            btnNextList.TabIndex = 14;
            btnNextList.Text = ">";
            btnNextList.UseVisualStyleBackColor = true;
            btnNextList.Click += btnNextList_Click;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Location = new Point(12, 228);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(53, 15);
            lblListTitle.TabIndex = 15;
            lblListTitle.Text = "{listTitle}";
            // 
            // btnWatchedTable
            // 
            btnWatchedTable.Location = new Point(506, 5);
            btnWatchedTable.Name = "btnWatchedTable";
            btnWatchedTable.Size = new Size(112, 23);
            btnWatchedTable.TabIndex = 16;
            btnWatchedTable.Text = "İzleme Geçmişi";
            btnWatchedTable.UseVisualStyleBackColor = true;
            btnWatchedTable.Click += btnWatchedTable_Click;
            // 
            // FormProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 385);
            Controls.Add(btnWatchedTable);
            Controls.Add(lblListTitle);
            Controls.Add(btnNextList);
            Controls.Add(btnPrevList);
            Controls.Add(picRecent3);
            Controls.Add(picRecent2);
            Controls.Add(picRecent1);
            Controls.Add(lstProfile);
            Controls.Add(label1);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(lblChartTitle);
            Controls.Add(chartMain);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Watchbox";
            Load += FormProfile_Load;
            ((System.ComponentModel.ISupportInitialize)chartMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRecent1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRecent2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRecent3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private Label lblChartTitle;
        private Button btnPrev;
        private Button btnNext;
        private Label label1;
        private ListBox lstProfile;
        private PictureBox picRecent1;
        private PictureBox picRecent2;
        private PictureBox picRecent3;
        private Button btnPrevList;
        private Button btnNextList;
        private Label lblListTitle;
        private Button btnWatchedTable;
    }
}