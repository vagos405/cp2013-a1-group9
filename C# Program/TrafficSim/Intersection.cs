using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    class Intersection : Panel
    {
        public VerticalLane[] vLanes;
        public HorizontalLane[] hLanes;
        public IntersectionBlock block;
        private int HLane;
        private int VLane;

        public Intersection(Control parentForm, int HLane, int VLane)
        {
            Parent = parentForm;
            this.HLane = HLane;
            this.VLane = VLane;
            DrawLanes();
        }

        public void DrawLanes()
        {
            int position;

            //Create the Vertical Lanes
            vLanes = new VerticalLane[VLane];
            for (int i = 0; i < vLanes.Length; i++)
            {
                vLanes[i] = new VerticalLane(this);
                position = (Parent.Width / 2) - (VLane * vLanes[i].Image.Width / 2) + (vLanes[i].Image.Width * (i));
                vLanes[i].Location = new Point(position, (Parent.Height/2) - (vLanes[i].Image.Height/2));
            }

            //Create the Horizontal Lanes
            hLanes = new HorizontalLane[HLane];
            for (int i = 0; i < hLanes.Length; i++)
            {
                hLanes[i] = new HorizontalLane(this);
                position = (Parent.Height / 2) - (HLane * hLanes[i].Image.Height / 2) + (hLanes[i].Image.Height * (i));
                hLanes[i].Location = new Point((Parent.Width/2) - (hLanes[i].Image.Width/2), position);
            }

            //Create the Intersection Block in the Middle
            block = new IntersectionBlock(this);
            block.Location = new Point((Parent.Width / 2) - (VLane * vLanes[0].Image.Width / 2), (Parent.Height / 2) - (HLane * hLanes[0].Image.Height / 2));
            block.Width = VLane * vLanes[0].Image.Width;
            block.Height = HLane * hLanes[0].Image.Height;
            block.BackColor = Color.Black;
            block.BringToFront();

            //Set the panel to fit the intersection in it
            Height = vLanes[0].Height;
            Width = hLanes[0].Width;
        }
    }
}
