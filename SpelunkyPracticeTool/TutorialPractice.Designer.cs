namespace SpelunkyPracticeTool
{
    partial class TutorialPractice
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
            this.cbTimer = new System.Windows.Forms.CheckBox();
            this.nmLevel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nmHP = new System.Windows.Forms.NumericUpDown();
            this.nmBombs = new System.Windows.Forms.NumericUpDown();
            this.nmRopes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nmLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBombs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmRopes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTimer
            // 
            this.cbTimer.AutoSize = true;
            this.cbTimer.Checked = true;
            this.cbTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbTimer.Location = new System.Drawing.Point(28, 45);
            this.cbTimer.Name = "cbTimer";
            this.cbTimer.Size = new System.Drawing.Size(123, 24);
            this.cbTimer.TabIndex = 0;
            this.cbTimer.Text = "Tutorial Timer";
            this.cbTimer.UseVisualStyleBackColor = true;
            // 
            // nmLevel
            // 
            this.nmLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nmLevel.Location = new System.Drawing.Point(46, 75);
            this.nmLevel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmLevel.Name = "nmLevel";
            this.nmLevel.Size = new System.Drawing.Size(33, 23);
            this.nmLevel.TabIndex = 1;
            this.nmLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(85, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level";
            // 
            // nmHP
            // 
            this.nmHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nmHP.Location = new System.Drawing.Point(12, 12);
            this.nmHP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmHP.Name = "nmHP";
            this.nmHP.Size = new System.Drawing.Size(33, 23);
            this.nmHP.TabIndex = 1;
            this.nmHP.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nmBombs
            // 
            this.nmBombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nmBombs.Location = new System.Drawing.Point(76, 12);
            this.nmBombs.Name = "nmBombs";
            this.nmBombs.Size = new System.Drawing.Size(33, 23);
            this.nmBombs.TabIndex = 1;
            this.nmBombs.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nmRopes
            // 
            this.nmRopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nmRopes.Location = new System.Drawing.Point(137, 12);
            this.nmRopes.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmRopes.Name = "nmRopes";
            this.nmRopes.Size = new System.Drawing.Size(33, 23);
            this.nmRopes.TabIndex = 1;
            this.nmRopes.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // TutorialPractice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 115);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmRopes);
            this.Controls.Add(this.nmBombs);
            this.Controls.Add(this.nmHP);
            this.Controls.Add(this.nmLevel);
            this.Controls.Add(this.cbTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TutorialPractice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tutorial";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TutorialPractice_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nmLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBombs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmRopes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.NumericUpDown nmLevel;
        public System.Windows.Forms.CheckBox cbTimer;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nmHP;
        public System.Windows.Forms.NumericUpDown nmBombs;
        public System.Windows.Forms.NumericUpDown nmRopes;
    }
}