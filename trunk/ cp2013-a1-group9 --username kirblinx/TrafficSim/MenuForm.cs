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
    public partial class MenuForm : Form
    {
        private SimForm simulation;
        private const int HLaneMax = 4;
        private const int VLaneMax = 4;
        private const int HProbMax = 1;
        private const int VProbMax = 1;

        public MenuForm()
        {
            InitializeComponent();

        }

        private void SimButton_Click(object sender, EventArgs e)
        {

            if (HLaneBox.Text == "" || VLaneBox.Text == "" || HProbBox.Text == "" || VProbBox.Text == "")
            {
                MessageBox.Show("Please enter values into each box");
                return;
            }

            int hLaneInt = IntCheck(HLaneBox.Text);
            if (hLaneInt <= 0 || hLaneInt > HLaneMax)
            {
                MessageBox.Show("Please enter a horizontal lane value between 1 and " + HLaneMax);
                return;
            }

            int vLaneInt = IntCheck(VLaneBox.Text);
            if (vLaneInt <= 0 || vLaneInt > VLaneMax)
            {
                MessageBox.Show("Please enter a vertical lane value between 1 and " + VLaneMax);
                return;
            }

            double hProbDoub = DoubleCheck(HProbBox.Text);
            if (hProbDoub < 0 || hProbDoub > HProbMax)
            {
                MessageBox.Show("Please enter a horizontal lane probability value between 0 and " + HProbMax);
                return;
            }

            double vProbDoub = DoubleCheck(VProbBox.Text);
            if (vProbDoub < 0 || vProbDoub > VProbMax)
            {
                MessageBox.Show("Please enter a vertical lane probability value between 0 and " + VProbMax);
                return;
            }

            //simulation = new SimForm(HLaneBox.Text,VLaneBox.Text,HProbBox.Text,VProbBox.Text);
            simulation = new SimForm(hLaneInt,vLaneInt,hProbDoub,vProbDoub);
            simulation.Owner = this;
            simulation.Show();
            Hide();
        }

        private int IntCheck(string value)
        {
            int number;
            try
            {
                number = int.Parse(value);
            }
            catch(Exception)
            {
                number = -1;
            }
            return number;
        }

        private double DoubleCheck(string value)
        {
            double number;
            try
            {
                number = double.Parse(value);
            }
            catch (Exception)
            {
                number = -1;
            }
            return number;
        }


    }
}
