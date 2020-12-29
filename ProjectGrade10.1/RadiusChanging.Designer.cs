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
            this.ScrollBar = new System.Windows.Forms.HScrollBar();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScrollBar
            // 
            this.ScrollBar.Location = new System.Drawing.Point(1, 187);
            this.ScrollBar.Maximum = 30;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(282, 30);
            this.ScrollBar.TabIndex = 0;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
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
            // RadiusChanging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ScrollBar);
            this.Name = "RadiusChanging";
            this.Text = "RadiusChanging";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadiusChanging_FormClosing);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.HScrollBar ScrollBar;

        #endregion
    }
}