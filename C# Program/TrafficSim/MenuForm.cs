using System;
using System.Windows.Forms;

namespace TrafficSim
{
    public partial class MenuForm : Form
    {
        private SimForm simulation;
        private const int HLaneMax = 3;
        private const int VLaneMax = 4;
        private const int HProbMax = 1;
        private const int VProbMax = 1;
        private const int CycleMax = 10;

        public MenuForm()
        {
            InitializeComponent();

        }

        private void SimButton_Click(object sender, EventArgs e)
        {

            if (HLaneBox.Text == "" || VLaneBox.Text == "" || HProbBox.Text == "" || VProbBox.Text == "" || CycleBox.Text == "")
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

            int Cycles = IntCheck(CycleBox.Text);
            if (Cycles <= 0 || Cycles > CycleMax)
            {
                MessageBox.Show("Please enter a number of cycles between 1 and " + CycleMax);
                return;
            }

            Hide();
            simulation = new SimForm(hLaneInt,vLaneInt,hProbDoub,vProbDoub,Cycles);
            simulation.Owner = this;
            simulation.Show();
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
