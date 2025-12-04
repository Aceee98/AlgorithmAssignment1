namespace FinalAssignment_Algorithms
{
    partial class Form1
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
            this.LoadMapButton = new System.Windows.Forms.Button();
            this.AlgorithmDropDown = new System.Windows.Forms.ComboBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LoadMapButton
            // 
            this.LoadMapButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LoadMapButton.Location = new System.Drawing.Point(82, 480);
            this.LoadMapButton.Name = "LoadMapButton";
            this.LoadMapButton.Size = new System.Drawing.Size(113, 23);
            this.LoadMapButton.TabIndex = 0;
            this.LoadMapButton.Text = "Load Map";
            this.LoadMapButton.UseVisualStyleBackColor = false;
            this.LoadMapButton.Click += new System.EventHandler(this.LoadMapButton_Click);
            // 
            // AlgorithmDropDown
            // 
            this.AlgorithmDropDown.FormattingEnabled = true;
            this.AlgorithmDropDown.Items.AddRange(new object[] {
            "BFS",
            "DFS",
            "HillClimb",
            "BestFirst",
            "Dijkstra"});
            this.AlgorithmDropDown.Location = new System.Drawing.Point(399, 480);
            this.AlgorithmDropDown.Name = "AlgorithmDropDown";
            this.AlgorithmDropDown.Size = new System.Drawing.Size(121, 24);
            this.AlgorithmDropDown.TabIndex = 1;
            this.AlgorithmDropDown.Text = "Select Algorithm";
            this.AlgorithmDropDown.SelectedIndexChanged += new System.EventHandler(this.AlgorithmDropDown_SelectedIndexChanged);
            // 
            // RunButton
            // 
            this.RunButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.RunButton.Location = new System.Drawing.Point(747, 480);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Start";
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // MapPanel
            // 
            this.MapPanel.AutoScroll = true;
            this.MapPanel.Location = new System.Drawing.Point(230, 40);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(422, 378);
            this.MapPanel.TabIndex = 3;
            this.MapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MapPanel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.MapPanel);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.AlgorithmDropDown);
            this.Controls.Add(this.LoadMapButton);
            this.Name = "Form1";
            this.Text = "Algorithms Assignment";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadMapButton;
        private System.Windows.Forms.ComboBox AlgorithmDropDown;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Panel MapPanel;
    }
}

