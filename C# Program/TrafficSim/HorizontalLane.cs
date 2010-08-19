using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficSim
{
    class HorizontalLane : PictureBox
    {
        public HorizontalLane()
        {
            Parent = SimForm.ActiveForm;
            Image pic = Image.FromFile("Lane.bmp");
            Image = pic;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public HorizontalLane(Control parentForm)
        {
            Parent = parentForm;
            Image pic = Image.FromFile("Lane.bmp");
            Image = pic;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

    }
}
