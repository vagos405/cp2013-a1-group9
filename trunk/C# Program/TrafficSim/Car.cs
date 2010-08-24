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
            BringToFront();
        }

        public void Rotate()
        {
            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Width = Image.Width;
            Height = Image.Height;
        }

        public void Move()
        {
            if (Direction == 'H')
            {
                Location = new Point(Location.X + Width + 5, Location.Y);
            }
            if (Direction == 'V')
            {
                Location = new Point(Location.X, Location.Y - Height - 5);
            }
        }

        public bool CheckifCollision(Rectangle bounds)
        {
            Rectangle futureCar;
            if (Direction == 'H')
            {
                futureCar = new Rectangle(Location.X + Width + 5, Location.Y, Width, Height);
            }
            else if (Direction == 'V')
            {
                futureCar = new Rectangle(Location.X, Location.Y - Height - 5, Width, Height);
            }
            else
            {
                futureCar = new Rectangle();
            }

            return futureCar.IntersectsWith(bounds);
        }

    }
}
