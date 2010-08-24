using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    class Intersection : Panel
    {
        public Road[] Roads;
        public TrafficLight[] Lights;
        public IntersectionBlock block;
        public int ActiveLight;
        private int HLane;
        private int VLane;

        public Intersection(Control parentForm, int HLane, int VLane)
        {
            Parent = parentForm;
            Width = parentForm.Width;
            Height = parentForm.Height;
            this.HLane = HLane;
            this.VLane = VLane;
            DrawRoads();
            CreateLights();
        }

        public void DrawRoads()
        {
            Roads = new Road[2];
            Roads[0] = new Road(this, HLane, 'H');
            Roads[1] = new Road(this, VLane, 'V');

            //Create the Intersection Block in the Middle
            block = new IntersectionBlock(this);
            block.Location = new Point(Roads[1].Location.X, Roads[0].Location.Y);
            block.Width = Roads[1].Width;
            block.Height = Roads[0].Height;
            block.BackColor = Color.Black;
            block.SendToBack();
        }

        private void CreateLights()
        {
            Lights = new TrafficLight[2];
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i] = new TrafficLight(this);
                Lights[i].BringToFront();
            }
            Lights[0].setColour("Red");
            Lights[1].setColour("Green");
            Lights[0].Rotate();
            Lights[0].Location = new Point(Roads[1].Location.X - Lights[0].Width - 20, Roads[0].Location.Y - Lights[0].Height - 20);
            Lights[1].Location = new Point(Roads[1].Location.X - Lights[0].Width - 20, Roads[0].Location.Y + Roads[0].Height + 20);
            ActiveLight = 1;
        }

        public void ChangeLights()
        {
            if (Lights[ActiveLight].Colour == "Green")
            {
                Lights[ActiveLight].setColour("Yellow");
            }
            else if (Lights[ActiveLight].Colour == "Yellow")
            {
                Lights[ActiveLight].setColour("Red");
            }
            else if (Lights[ActiveLight].Colour == "Red")
            {
                if (ActiveLight == 0)
                {
                    ActiveLight = 1;
                }
                else
                {
                    ActiveLight = 0;
                }
                Lights[ActiveLight].setColour("Green");
            }

        }
    }
}
