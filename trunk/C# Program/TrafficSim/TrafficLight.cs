using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    class TrafficLight : PictureBox
    {
        public string Colour;
        public int YellowTime;
        public int GreenTime;
        public bool Rotated;

        public TrafficLight(Control parentForm)
        {
            Parent = parentForm;
            Image pic = Image.FromFile("GreenLight.bmp");
            Image = pic;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void setColour(string colour)
        {
            if (colour == "Red")
            {
                Image = Image.FromFile("RedLight.bmp");
                Colour = "Red";
            }
            else if (colour == "Yellow")
            {
                Image = Image.FromFile("YellowLight.bmp");
                Colour = "Yellow";
            }
            else if (colour == "Green")
            {
                Image = Image.FromFile("GreenLight.bmp");
                Colour = "Green";
            }
            if (Rotated)
            {
                Rotate();
            }
        }

        public void Rotate()
        {
            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Width = Image.Width;
            Height = Image.Height;
            Rotated = true;
        }

    }
}
