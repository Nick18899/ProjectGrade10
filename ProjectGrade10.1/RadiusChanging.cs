using System;
using System.Windows.Forms;

namespace ProjectGrade10._1
{
    public partial class RadiusChanging : Form
    {
        private Rad rad;
        public OnClose close;
        
        public RadiusChanging()
        {
            InitializeComponent();
        }
        
        public RadiusChanging(Rad radiusChange, OnClose cl, int defaultR)
        {
            InitializeComponent();
            rad = radiusChange;
            close = cl;
            //ScrollBar.Value = defaultR;
            trackBar.Value = defaultR;
        }
       /* public void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            rad(ScrollBar.Value);
        }
        */
        private void RadiusChanging_FormClosing(object sender, FormClosingEventArgs e)
        {
            close();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            rad(trackBar.Value);
        }
    }
}