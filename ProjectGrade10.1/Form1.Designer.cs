namespace ProjectGrade10._1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convexHullAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDefinitionAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorChangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusChangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMenuItem1, this.convexHullAlgorithmToolStripMenuItem, this.colorChangerToolStripMenuItem, this.radiusChangerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.triangleToolStripMenuItem, this.squareToolStripMenuItem, this.circleToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(83, 24);
            this.toolStripMenuItem1.Text = "TopMenu";
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // convexHullAlgorithmToolStripMenuItem
            // 
            this.convexHullAlgorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.jarvisAlgorithmToolStripMenuItem, this.byDefinitionAlgorithmToolStripMenuItem});
            this.convexHullAlgorithmToolStripMenuItem.Name = "convexHullAlgorithmToolStripMenuItem";
            this.convexHullAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.convexHullAlgorithmToolStripMenuItem.Text = "Convex hull algorithm";
            // 
            // jarvisAlgorithmToolStripMenuItem
            // 
            this.jarvisAlgorithmToolStripMenuItem.Name = "jarvisAlgorithmToolStripMenuItem";
            this.jarvisAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.jarvisAlgorithmToolStripMenuItem.Text = "Jarvis algorithm";
            this.jarvisAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.jarvisAlgorithmToolStripMenuItem_Click);
            // 
            // byDefinitionAlgorithmToolStripMenuItem
            // 
            this.byDefinitionAlgorithmToolStripMenuItem.Name = "byDefinitionAlgorithmToolStripMenuItem";
            this.byDefinitionAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.byDefinitionAlgorithmToolStripMenuItem.Text = "ByDefinition algorithm";
            this.byDefinitionAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.byDefinitionAlgorithmToolStripMenuItem_Click);
            // 
            // colorChangerToolStripMenuItem
            // 
            this.colorChangerToolStripMenuItem.Name = "colorChangerToolStripMenuItem";
            this.colorChangerToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.colorChangerToolStripMenuItem.Text = "Color Changer";
            this.colorChangerToolStripMenuItem.Click += new System.EventHandler(this.colorChangerToolStripMenuItem_Click);
            // 
            // radiusChangerToolStripMenuItem
            // 
            this.radiusChangerToolStripMenuItem.Name = "radiusChangerToolStripMenuItem";
            this.radiusChangerToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.radiusChangerToolStripMenuItem.Text = "Radius Changer";
            this.radiusChangerToolStripMenuItem.Click += new System.EventHandler(this.radiusChangerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem byDefinitionAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorChangerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convexHullAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisAlgorithmToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem radiusChangerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;

        #endregion
    }
}