namespace PhotoOrganizerApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSourceFolder = new TextBox();
            btnStart = new Button();
            txtOutput = new TextBox();
            btnBrowse = new Button();
            btnOpenDestination = new Button();
            progressBar = new ProgressBar();
            lblPercentage = new Label();
            checkBoxYear = new CheckBox();
            checkBoxMonth = new CheckBox();
            checkBoxDay = new CheckBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 0;
            label1.Text = "Source Folder Path:";
            // 
            // txtSourceFolder
            // 
            txtSourceFolder.BackColor = Color.FromArgb(224, 224, 224);
            txtSourceFolder.Location = new Point(12, 29);
            txtSourceFolder.Name = "txtSourceFolder";
            txtSourceFolder.Size = new Size(579, 23);
            txtSourceFolder.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(64, 64, 64);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(12, 86);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.FromArgb(224, 224, 224);
            txtOutput.Location = new Point(12, 145);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Size = new Size(660, 305);
            txtOutput.TabIndex = 3;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(64, 64, 64);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(597, 29);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click_1;
            // 
            // btnOpenDestination
            // 
            btnOpenDestination.BackColor = Color.FromArgb(64, 64, 64);
            btnOpenDestination.Cursor = Cursors.Hand;
            btnOpenDestination.FlatAppearance.BorderSize = 0;
            btnOpenDestination.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnOpenDestination.ForeColor = Color.White;
            btnOpenDestination.Location = new Point(497, 456);
            btnOpenDestination.Name = "btnOpenDestination";
            btnOpenDestination.Size = new Size(175, 25);
            btnOpenDestination.TabIndex = 5;
            btnOpenDestination.Text = "Open Destination Folder";
            btnOpenDestination.UseVisualStyleBackColor = false;
            btnOpenDestination.Visible = false;
            btnOpenDestination.Click += btnOpenDestination_Click;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.FromArgb(224, 224, 224);
            progressBar.ForeColor = Color.Teal;
            progressBar.Location = new Point(12, 124);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(619, 15);
            progressBar.TabIndex = 6;
            // 
            // lblPercentage
            // 
            lblPercentage.AutoSize = true;
            lblPercentage.BackColor = Color.Transparent;
            lblPercentage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPercentage.ForeColor = Color.FromArgb(64, 64, 64);
            lblPercentage.Location = new Point(637, 124);
            lblPercentage.Name = "lblPercentage";
            lblPercentage.Size = new Size(24, 15);
            lblPercentage.TabIndex = 7;
            lblPercentage.Text = "0%";
            // 
            // checkBoxYear
            // 
            checkBoxYear.AutoSize = true;
            checkBoxYear.Location = new Point(177, 58);
            checkBoxYear.Name = "checkBoxYear";
            checkBoxYear.Size = new Size(48, 19);
            checkBoxYear.TabIndex = 8;
            checkBoxYear.Text = "Year";
            checkBoxYear.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonth
            // 
            checkBoxMonth.AutoSize = true;
            checkBoxMonth.Location = new Point(231, 58);
            checkBoxMonth.Name = "checkBoxMonth";
            checkBoxMonth.Size = new Size(62, 19);
            checkBoxMonth.TabIndex = 9;
            checkBoxMonth.Text = "Month";
            checkBoxMonth.UseVisualStyleBackColor = true;
            // 
            // checkBoxDay
            // 
            checkBoxDay.AutoSize = true;
            checkBoxDay.Location = new Point(299, 58);
            checkBoxDay.Name = "checkBoxDay";
            checkBoxDay.Size = new Size(46, 19);
            checkBoxDay.TabIndex = 10;
            checkBoxDay.Text = "Day";
            checkBoxDay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(150, 15);
            label2.TabIndex = 11;
            label2.Text = "Select the path structure:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(684, 491);
            Controls.Add(label2);
            Controls.Add(checkBoxDay);
            Controls.Add(checkBoxMonth);
            Controls.Add(checkBoxYear);
            Controls.Add(lblPercentage);
            Controls.Add(progressBar);
            Controls.Add(btnOpenDestination);
            Controls.Add(btnBrowse);
            Controls.Add(txtOutput);
            Controls.Add(btnStart);
            Controls.Add(txtSourceFolder);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "PhotoOrganizerApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSourceFolder;
        private Button btnStart;
        private TextBox txtOutput;
        private Button btnBrowse;
        private Button btnOpenDestination;
        private ProgressBar progressBar;
        private Label lblPercentage;
        private CheckBox checkBoxYear;
        private CheckBox checkBoxMonth;
        private CheckBox checkBoxDay;
        private Label label2;
    }
}