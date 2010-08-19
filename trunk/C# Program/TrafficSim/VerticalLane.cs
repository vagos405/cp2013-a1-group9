using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    class VerticalLane : PictureBox
    {
        public VerticalLane()
        {
            Parent = SimForm.ActiveForm;
            Image pic = Image.FromFile("Lane.bmp");
            Image = pic;
            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public VerticalLane(Control parentForm)
        {
            Parent = parentForm;
            Image pic = Image.FromFile("Lane.bmp");
            Image = pic;
            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
