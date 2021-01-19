using System.ComponentModel;

namespace ProjectGrade10._1
{
    partial class RadiusChanging
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Yu Gothic UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label.Location = new System.Drawing.Point(1, 29);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(281, 103);
            this.label.TabIndex = 1;
            this.label.Text = "Move slider for choosing tops\' radius";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(0, 115);
            this.trackBar.Maximum = 40;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(281, 56);
            this.trackBar.TabIndex = 2;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // RadiusChanging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.label);
            this.Name = "RadiusChanging";
            this.Text = "RadiusChanging";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadiusChanging_FormClosing);
            ((System.ComponentModel.ISupportInitialize) (this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TrackBar trackBar;

        #endregion
    }
}