using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        int countRabbit=0;
        int CountWolf = 0;
        int CountFemaleWolfs = 0;
        MapControl Model;

        private List<Rabbit> Rabbits;
        private List<Wolf> Wolfs;
        private List<FemaleWolf> FemaleWolfs;

        Panel[,] panels = new Panel[20,20];
        public int[,] FieldArray = new int[20, 20];


        public Form1()
        {
            InitializeComponent();
            InitGame();

        }
        public void ClearField()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    FieldArray[i, j] = 0;
                }
        }

       
     
        private void UpdatePanels()
        {
              for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    if (FieldArray[i, j] == 3)
                        panels[i,j].BackColor = Color.Black;//Rabbit
                    else if (FieldArray[i, j] == 1)
                        panels[i, j].BackColor = Color.Green;//Wolf
                    else if (FieldArray[i, j] == 2)
                        panels[i, j].BackColor = Color.Red;//FemaleWolfs
                    else if (FieldArray[i, j] == 0)
                        panels[i, j].BackColor = Color.White;
                    else if (FieldArray[i, j] == 4)
                        panels[i, j] .BackColor = Color.Blue;//Rabbit+Wolf || Wolf+FemaleWolfs || Rabbit+FemaleWolfs || Wolf+Wolf || FemaleWolfs+FemaleWolfs
                }
            ClearField();
        }

        private void InitGame()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    panels[i, j] = new Panel
                    {
                        Parent = Field,
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Width = 20,
                        Height = 20,
                        Top = i * 20,
                        Left = j * 20,
                    };
                }
        }

        private void Print() {
            foreach (Rabbit Rabbit in Rabbits)
            {
                FieldArray[Rabbit.GetX()-1, Rabbit.GetY()-1] = 3;
            }

            foreach (Wolf Wolf in Wolfs)
            {
                FieldArray[Wolf.GetX()-1, Wolf.GetY()-1] = 1;
            }
            foreach (FemaleWolf femaleWolf in FemaleWolfs)
            {
            
                FieldArray[femaleWolf.GetX()-1, femaleWolf.GetY()-1] = 2;
            }
        
        }
        private void PrintScore() {
            label4.Text = "";
            label5.Text = "";
            foreach (FemaleWolf femaleWolf in FemaleWolfs)
            {
              label4.Text +=  femaleWolf.GetScore();
              label4.Text += "\r\n";
            }
            foreach (Wolf Wolf in Wolfs)
            {
                label5.Text += Wolf.GetScore();
                label5.Text += "\r\n";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Object rabbitNeighbor = null;
            Object femaleWolfNeighbor = null;
        

           
                for (int i = 0; i < Wolfs.Count(); i++)//Wolf
                {
                    if (Wolfs[i].GetScore() <= 0)
                    {
                        Wolfs.Remove(Wolfs[i]);

                    }
                    else
                    {
                        foreach (Rabbit rabbit in Rabbits)
                        {
                            rabbitNeighbor = Wolfs[i].CheckNeighbors<Rabbit>(rabbit, rabbit.GetX(), rabbit.GetY());
                            if (rabbitNeighbor != null)
                            {
                                bool caughtКabbit = Wolfs[i].СhaseForRabbit(rabbit.GetX(), rabbit.GetY());
                                if (caughtКabbit)
                                {
                                    Rabbits.Remove(rabbit);
                                    FieldArray[rabbit.GetX() - 1, rabbit.GetY() - 1] = 4;
                                }
                                break;
                            }
                        }
                        if (rabbitNeighbor == null)
                        {
                            foreach (FemaleWolf femaleWolf in FemaleWolfs)
                            {
                                femaleWolfNeighbor = Wolfs[i].CheckNeighbors<FemaleWolf>(femaleWolf, femaleWolf.GetX(), femaleWolf.GetY());
                                if (femaleWolfNeighbor != null)
                                {
                                    bool birth = Wolfs[i].СhaseForFemaleWolf(femaleWolf.GetX(), femaleWolf.GetY());
                                    if (birth)
                                    {
                                        var rand = new Random();
                                        int x = rand.Next(1, 21);
                                        int y = rand.Next(1, 21);

                                        for (int j = 0; j < CountWolf; j++)
                                        {
                                            while (Wolfs[i].GetX() == x && Wolfs[i].GetY() == y)
                                            {
                                                x = rand.Next(1, 21);
                                                y = rand.Next(1, 21);
                                            }

                                        }
                                        Wolfs.Add(new Wolf(x, y));


                                    }
                                    break;

                                }
                            }
                        }
                        if (femaleWolfNeighbor == null && rabbitNeighbor == null)
                        {


                            Wolfs[i].Step();
                            for (int j = 0; j < Wolfs.Count(); j++)
                            {
                                if ((j != i))
                                {
                                    while (Wolfs[j].GetX() == Wolfs[i].GetX() && Wolfs[j].GetY() == Wolfs[i].GetY())
                                    {
                                        Wolfs[i].Step();
                                    }
                                }
                            }

                        }
                    }

                }

                foreach (Wolf Wolf in Wolfs)
                {
                    if (FieldArray[Wolf.GetX() - 1, Wolf.GetY() - 1] == 1)
                    {
                        FieldArray[Wolf.GetX() - 1, Wolf.GetY() - 1] = 4;
                    }
                    else
                    {
                        FieldArray[Wolf.GetX() - 1, Wolf.GetY() - 1] = 1;
                    }
                }


                rabbitNeighbor = null;

                for (int i = 0; i < FemaleWolfs.Count(); i++)//FemaleWolfs
                {
                    if (FemaleWolfs[i].GetScore() <= 0)
                    {
                        FemaleWolfs.Remove(FemaleWolfs[i]);

                    }
                    else
                    {
                        foreach (Rabbit rabbit in Rabbits)
                        {
                            rabbitNeighbor = FemaleWolfs[i].CheckNeighbors<Rabbit>(rabbit, rabbit.GetX(), rabbit.GetY());
                            if (rabbitNeighbor != null)
                            {
                                bool caughtКabbit = FemaleWolfs[i].СhaseForRabbit(rabbit.GetX(), rabbit.GetY());


                                if (caughtКabbit)
                                {
                                    Rabbits.Remove(rabbit);
                                    FieldArray[rabbit.GetX() - 1, rabbit.GetY() - 1] = 4;
                                }
                                break;
                            }
                        }


                        if (rabbitNeighbor == null)
                        {
                            bool Empty = false;
                            while (!Empty)
                            {
                                FemaleWolfs[i].Step();
                                for (int j = 0; j < FemaleWolfs.Count(); j++)
                                {
                                    if ((j != i))
                                    {
                                        while (FemaleWolfs[j].GetX() == FemaleWolfs[i].GetX() && FemaleWolfs[j].GetY() == FemaleWolfs[i].GetY())
                                        {
                                            FemaleWolfs[i].Step();
                                        }
                                    }
                                }
                                Empty = Model.IsFree(FemaleWolfs[i].GetX(), FemaleWolfs[i].GetY(), FieldArray);
                            }
                        }
                    }
                }


                foreach (FemaleWolf femaleWolf in FemaleWolfs)
                {
                    if (FieldArray[femaleWolf.GetX() - 1, femaleWolf.GetY() - 1] == 1 || FieldArray[femaleWolf.GetX() - 1, femaleWolf.GetY() - 1] == 4 || FieldArray[femaleWolf.GetX() - 1, femaleWolf.GetY() - 1] == 2)
                    {
                        FieldArray[femaleWolf.GetX() - 1, femaleWolf.GetY() - 1] = 4;
                    }
                    else
                    {
                        FieldArray[femaleWolf.GetX() - 1, femaleWolf.GetY() - 1] = 2;

                    }

                }





                for (int i = 0; i < Rabbits.Count(); i++)//Rabbits
                {

                    bool Empty = false;
                    while (!Empty)
                    {
                        Rabbits[i].Step();
                        for (int j = 0; j < Rabbits.Count(); j++)
                        {
                            if ((j != i))
                            {

                                while (Rabbits[j].GetX() == Rabbits[i].GetX() && Rabbits[j].GetY() == Rabbits[i].GetY())
                                {
                                    Rabbits[i].Step();
                                }
                            }
                        }
                        Empty = Model.IsFree(Rabbits[i].GetX(), Rabbits[i].GetY(), FieldArray);
                    }
                    if (Rabbits[i].Birth())
                    {
                        var rand = new Random();
                        int x = rand.Next(1, 21);
                        int y = rand.Next(1, 21);

                        for (int j = 0; j < countRabbit; j++)
                        {
                            while (Rabbits[i].GetX() == x && Rabbits[i].GetY() == y)
                            {
                                x = rand.Next(1, 21);
                                y = rand.Next(1, 21);
                            }

                        }
                        Rabbits.Add(new Rabbit(x, y));
                    }
                }

                foreach (Rabbit Rabbit in Rabbits)
                {
                    if (FieldArray[Rabbit.GetX() - 1, Rabbit.GetY() - 1] == 1 || FieldArray[Rabbit.GetX() - 1, Rabbit.GetY() - 1] == 2 || FieldArray[Rabbit.GetX() - 1, Rabbit.GetY() - 1] == 4)
                    {
                        FieldArray[Rabbit.GetX() - 1, Rabbit.GetY() - 1] = 4;
                    }
                    else
                    {
                        FieldArray[Rabbit.GetX() - 1, Rabbit.GetY() - 1] = 3;

                    }
                }

                CountWolf = Wolfs.Count();
                countRabbit = Rabbits.Count();
                UpdatePanels();
                PrintScore();
                PrintCount();
                label11.Text = "";
                if (Rabbits.Count() > 400)
                {
                    label11.Text += "Rabbits - win";
                    label11.Text += "\r\n";
                    label11.Text += "please click initialization";
                    ClearField();

                }
                if (Rabbits.Count() == 0)
                {
                    label11.Text += "Wolfs and  FemaleWolfs - win";
                    label11.Text += "\r\n";
                    label11.Text += "please click initialization";
                    ClearField();
                }

            
        }
    
        private void PrintCount() {

            label9.Text = "";
            label9.Text += Rabbits.Count();
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
             countRabbit = int.Parse(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CountWolf = int.Parse(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CountFemaleWolfs = int.Parse(textBox3.Text);
            CountWolf = int.Parse(textBox2.Text);
            countRabbit = int.Parse(textBox1.Text);
            Model = new MapControl(countRabbit, CountWolf, CountFemaleWolfs);
            Model.InitializationWolfs();
            Model.InitializationFemaleWolfs();
            Model.InitializationRabbits();
            Rabbits = Model.GetRabbits();
            Wolfs = Model.GetWolfs();
            FemaleWolfs = Model.GetFemaleWolfs();
            Print();
            UpdatePanels();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
