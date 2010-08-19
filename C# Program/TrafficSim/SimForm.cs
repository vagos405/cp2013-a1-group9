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
        private int ActiveLight;

        private Intersection Section;
        private List<Car> Cars;
        private static Random random;
        private TrafficLight[] lights;

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
            Cars = new List<Car>();
            random = new Random();
            CreateLights();
            noOfCyclesDone = 0;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void CreateLights()
        {
            lights = new TrafficLight[2];
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i] = new TrafficLight(this);
                lights[i].BringToFront();
            }
            lights[0].setColour("Red");
            lights[0].Rotate();
            lights[0].Location = new Point(Section.vLanes[0].Location.X - lights[0].Width - 20, Section.hLanes[0].Location.Y - lights[0].Height - 20);
            lights[1].Location = new Point(Section.vLanes[0].Location.X - lights[0].Width - 20, Section.hLanes[Section.hLanes.Length - 1].Location.Y + Section.hLanes[0].Height + 20);
            ActiveLight = 1;
        }


        private void CycleButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cycles = int.Parse(CyclesBox.Text);
                if (Cycles > 10 || Cycles <= 0)
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

        private void ChangeLights()
        {
            Console.WriteLine(noOfCyclesDone);
            //Check if you need to change the lights);
            if (noOfCyclesDone == GreenTime)
            {
                lights[ActiveLight].setColour("Yellow");
            }
            else if (noOfCyclesDone == (GreenTime + YellowTime))
            {
                lights[ActiveLight].setColour("Red");
            }
            else if (lights[ActiveLight].Colour == "Red")
            {
                noOfCyclesDone = 0;
                if (ActiveLight == 0)
                {
                    ActiveLight = 1;
                }
                else
                {
                    ActiveLight = 0;
                }
                lights[ActiveLight].setColour("Green");
            }

        }

        private void Sequence()
        {
            ChangeLights();

            //Move the cars);
            foreach (Car car in Cars)
            {
                bool canMove = true;
                // For the Horizontal Lanes
                if (car.Direction == 'H')
                {
                    //Check if moving will collide with another car
                    foreach (Car car2 in Cars)
                    {
                        if (car != car2)
                        {
                            if (car2.Location.X - (car.Location.X + car.Width) <= 7  && car2.Location.X - (car.Location.X + car.Width) >= 0 && car.Location.Y == car2.Location.Y)
                            {
                                canMove = false;
                            }
                        }
                    }
                    

                    //Check if the cars are before a red light
                    if ((lights[0].Colour == "Red" || lights[0].Colour == "Yellow") && (car.Location.X + car.Width - 5) < Section.block.Location.X)
                    {
                        // If the car isn't going to cross the lights
                        if (car.Location.X + (car.Width * 2) >= Section.block.Location.X)
                        {}
                        else
                        {
                            if (canMove) { car.Location = new Point(car.Location.X + car.Width + 5, car.Location.Y); }
                        }
                    }
                    else
                    {
                        if (canMove) { car.Location = new Point(car.Location.X + car.Width + 5, car.Location.Y); }
                    }
                        
                }
                else if (car.Direction == 'V')
                {
                    //Check if moving will collide with another car
                    foreach (Car car2 in Cars)
                    {
                        if (car != car2)
                        {
                            if (car.Location.Y - (car2.Location.Y + car2.Height) <= 7 && car.Location.Y - (car2.Location.Y + car2.Height) >= 0 && car.Location.X == car2.Location.X)
                            {
                                canMove = false;
                            }
                        }
                    }

                    //Check if the cars are before a red light
                    if ((lights[1].Colour == "Red" || lights[1].Colour == "Yellow") && car.Location.Y + 5 > Section.block.Location.Y + Section.block.Height)
                    {
                        // If the car isn't going to cross the lights
                        if (car.Location.Y - car.Height <= Section.block.Location.Y + Section.block.Height)
                        {}
                        else
                        {
                            if (canMove) { car.Location = new Point(car.Location.X, car.Location.Y - car.Height - 5);}
                        }
                    }
                    else
                        if (canMove) { car.Location = new Point(car.Location.X, car.Location.Y - car.Height - 5); }
                }
            }


            //Delete cars if they have gone off screen
            Cars.RemoveAll(usedCar => usedCar.Location.Y < (0 - usedCar.Height));
            Cars.RemoveAll(usedCar => usedCar.Location.X > Width);
            label1.Text = Cars.Count.ToString();

            addNewCars();

            ++noOfCyclesDone;
        }

        //Create new cars if probability allows and put on a random lane
        public void addNewCars()
        {
            if (random.Next(1, 100) <= VProb * 100)
            {
                Car newCar = new Car(this);
                newCar.Direction = 'V';
                newCar.BringToFront();
                newCar.Location = new Point((Section.vLanes[random.Next(0, VLane)].Location.X + 15), (Height - newCar.Height - 36));
                Cars.Add(newCar);
            }

            if (random.Next(1, 100) <= HProb * 100)
            {
                Car newCar = new Car(this);
                newCar.Direction = 'H';
                newCar.BringToFront();
                int randomNumber = random.Next(0, HLane);
                newCar.Location = new Point(0, Section.hLanes[randomNumber].Location.Y + 15);
                newCar.Rotate();
                Cars.Add(newCar);
            }
        }
    }
}
