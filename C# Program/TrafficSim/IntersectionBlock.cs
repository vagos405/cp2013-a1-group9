using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    class IntersectionBlock : PictureBox
    {
        public IntersectionBlock(Control parentForm)
        {
            Parent = parentForm;
            Image pic = Image.FromFile("Block.bmp");
            Image = pic;
        }

        public void Stretch()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
