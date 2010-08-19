using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    class Car : PictureBox
    {
        public char Direction;

        public Car(Control parentForm)
        {
            Parent = parentForm;
            Image pic = Image.FromFile("Car.bmp");
            Image = pic;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void Rotate()
        {
            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Width = Image.Width;
            Height = Image.Height;
        }

    }
}
