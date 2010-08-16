using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficSim
{
    public partial class SimForm : Form
    {
        public int HLane;
        public int VLane;
        public double HProb;
        public double VProb;
        private PictureBox[] picboxes;

        public SimForm()
        {
            InitializeComponent();
        }

        public SimForm(int HLane, int VLane, double HProb, double VProb)
        {
            InitializeComponent();
            this.HLane = HLane;
            this.VLane = VLane;
            this.HProb = HProb;
            this.VProb = VProb;
            DrawLanes();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private PictureBox[] CreatePictures(Image pic, int numpic)
        {
            picboxes = new PictureBox[numpic];

            for (int i = 0; i < numpic; i++)
            {
                picboxes[i] = new PictureBox();
                picboxes[i].Parent = this;
                picboxes[i].Location = new Point(Width / 2, Height / 2);
                picboxes[i].Image = pic;
                picboxes[i].SizeMode = PictureBoxSizeMode.AutoSize;
            }
            return picboxes;
        }

        private void DrawLanes()
        {
            Image pic = Image.FromFile("VLane.bmp");
            PictureBox[] vLanes = CreatePictures(pic, VLane);

            int position = (Width / 2) - vLanes.Length * pic.Width / 2;
            foreach (PictureBox lane in vLanes)
            {
                lane.Location = new Point(position, (Height / 2) - (pic.Height / 2));
                position += pic.Width;
            }

            pic = Image.FromFile("HLane.bmp");
            PictureBox[] hLanes = CreatePictures(pic, HLane);

            position = (Height / 2) - hLanes.Length * pic.Height / 2;
            foreach (PictureBox lane in hLanes)
            {
                lane.Location = new Point((Width / 2) - (pic.Width / 2), position);
                position += pic.Height;
            }
        }

    }
}
