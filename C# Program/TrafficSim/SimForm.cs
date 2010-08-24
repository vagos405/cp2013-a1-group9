using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficSim
{
    public partial class SimForm : Form
    {
        private int HLane;
        private int VLane;
        private double HProb;
        private double VProb;

        private int Cycles;
        private int noOfCyclesDone;
        private const int GreenTime = 8;
        private const int YellowTime = 2;

        private Intersection Section;
        private static Random random;

        public SimForm()
        {
            InitializeComponent();
        }

        public SimForm(int HLane, int VLane, double HProb, double VProb, int Cycles)
        {
            InitializeComponent();
            this.HLane = HLane;
            this.VLane = VLane;
            this.HProb = HProb;
            this.VProb = VProb;
            this.Cycles = Cycles;
            CyclesBox.Text = Cycles.ToString();
            Section = new Intersection(this,HLane,VLane);
            Section.SendToBack();
            random = new Random();
            noOfCyclesDone = 0;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }


        private void CycleButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cycles = int.Parse(CyclesBox.Text);
                if (Cycles > 10 || Cycles < 0)
                {
                    throw new Exception();
                }
                for (int i = 0; i < Cycles; i++)
                {
                    Sequence();
                    Refresh();
                    System.Threading.Thread.Sleep(200);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a number of cycles between 1 and 10");
                return;
            }

        }

        private void Sequence()
        {
            Console.WriteLine(noOfCyclesDone);
            if (noOfCyclesDone == GreenTime)
            {
                Section.ChangeLights();
            }
            else if (noOfCyclesDone == (GreenTime + YellowTime))
            {
                Section.ChangeLights();
            }
            else if (noOfCyclesDone > (GreenTime + YellowTime))
            {
                noOfCyclesDone = 0;
                Section.ChangeLights();
            }

            
            for (int i=0; i < Section.Roads[0].Lanes.Length; i++)
            {
                foreach (Car car in Section.Roads[0].Lanes[i].Cars)
                {
                    bool collided = false;
                    foreach (Car car2 in Section.Roads[0].Lanes[i].Cars)
                    {
                        if (car2 != car)
                        {
                            if (car.CheckifCollision(car2.Bounds))
                            {
                                collided = true;
                            }
                        }
                    }

                    if ((Section.Lights[0].Colour == "Red" || Section.Lights[0].Colour == "Yellow") && (car.Location.X + car.Width - 5) < Section.Roads[1].Location.X)
                    {
                        Section.Roads[1].BringToFront();
                        if (car.CheckifCollision(Section.Roads[1].Bounds))
                        {
                            collided = true;
                        }
                        if (!collided)
                        {
                            car.Move();
                        }
                    }
                    else
                    {
                        car.Move();
                    }
                }
            }

            //Vertical Lane
            for (int i = 0; i < Section.Roads[1].Lanes.Length; i++)
            {
                foreach (Car car in Section.Roads[1].Lanes[i].Cars)
                {
                    
                    bool collided = false;
                    foreach (Car car2 in Section.Roads[1].Lanes[i].Cars)
                    {
                        if (car2 != car)
                        {
                            if (car.CheckifCollision(car2.Bounds))
                            {
                                collided = true;
                            }
                        }
                    }

                    if ((Section.Lights[1].Colour == "Red" || Section.Lights[1].Colour == "Yellow") && (car.Location.Y > Section.Roads[0].Location.Y + Section.Roads[0].Height))
                    {
                        Section.Roads[0].BringToFront();
                        if (car.CheckifCollision(Section.Roads[0].Bounds))
                        {
                            collided = true;
                        }
                        if (!collided)
                        {
                            car.Move();
                        }
                    }
                    else
                    {
                        car.Move();
                    }
                }
            }
            if (random.Next(1, 100) <= HProb * 100)
            {
                Section.Roads[0].Lanes[random.Next(0, HLane)].CreateNewCar();
            }
            if (random.Next(1, 100) <= VProb * 100)
            {
                Section.Roads[1].Lanes[random.Next(0, VLane)].CreateNewCar();
            }
            
                    

            ++noOfCyclesDone;

            /*
            ChangeLights();

            //Move the cars);
            foreach (Car car in Cars)
            {
                bool willCollide;
                // For the Horizontal Lanes
                if (car.Direction == 'H')
                {
                    //Check if moving will collide with another car
                    willCollide = WillCollide(car, car.Direction);

                    //Check if the cars are before a red light
                    if ((lights[0].Colour == "Red" || lights[0].Colour == "Yellow") && (car.Location.X + car.Width - pixelGap) < Section.block.Location.X)
                    {
                        // If the car isn't going to cross the lights
                        if (car.Location.X + (car.Width * 2) >= Section.block.Location.X)
                        {}
                        else
                        {
                            if (!willCollide) { car.Location = new Point(car.Location.X + car.Width + pixelGap, car.Location.Y); }
                        }
                    }
                    else
                    {
                        if (!willCollide) { car.Location = new Point(car.Location.X + car.Width + pixelGap, car.Location.Y); }
                    }
                        
                }
                else if (car.Direction == 'V')
                {
                    //Check if moving will collide with another car
                    willCollide = WillCollide(car, car.Direction);

                    //Check if the cars are before a red light
                    if ((lights[1].Colour == "Red" || lights[1].Colour == "Yellow") && car.Location.Y + 5 > Section.block.Location.Y + Section.block.Height)
                    {
                        // If the car isn't going to cross the lights
                        if (car.Location.Y - car.Height <= Section.block.Location.Y + Section.block.Height)
                        {}
                        else
                        {
                            if (!willCollide) { car.Location = new Point(car.Location.X, car.Location.Y - car.Height - pixelGap); }
                        }
                    }
                    else
                        if (!willCollide) { car.Location = new Point(car.Location.X, car.Location.Y - car.Height - pixelGap); }
                }
            }


            //Delete cars if they have gone off screen
            Cars.RemoveAll(usedCar => usedCar.Location.Y < (0 - usedCar.Height));
            Cars.RemoveAll(usedCar => usedCar.Location.X > Width);
            label1.Text = Cars.Count.ToString();

            addNewCars();

            ++noOfCyclesDone;
             
        }
             */
        }
    }
}
