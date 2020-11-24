using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class MapControl
    {
        private  int CountRabbits { get; set; }
        private  int CountWolfs { get; set; }
        private  int CountFemaleWolfs { get; set; }


        private  List<Rabbit> Rabbits;
        private  List<Wolf> Wolfs;
        private  List<FemaleWolf> FemaleWolfs;

        public MapControl(int countRabbits, int countWolfs, int countFemaleWolfs)
        {
            
            Rabbits = new List<Rabbit>(countRabbits);
            Wolfs = new List<Wolf>(countWolfs);
            FemaleWolfs = new List<FemaleWolf>(countFemaleWolfs);
            CountRabbits = countRabbits;
            CountWolfs = countWolfs;
            CountFemaleWolfs = countFemaleWolfs;
        }
        public List<Rabbit> GetRabbits()
        {
            return Rabbits;
        }
        public List<Wolf> GetWolfs()
        {
            return Wolfs;
        }
        public List<FemaleWolf> GetFemaleWolfs()
        {
            return FemaleWolfs;
        }

        public void InitializationRabbits() {
            var rand = new Random(9);
            int x = 0;
            int y = 0;
            for (int i=0; i< CountRabbits; i++) {
                x = rand.Next(1, 21);
                y = rand.Next(1, 21);
                Rabbit newRabbit = new Rabbit(x, y);
                if (!Rabbits.Contains(newRabbit))
                {
                    Rabbits.Add(newRabbit);
                }
                else
                {
                    i--;
                }
            
            }
           

        }
        public void InitializationWolfs()
        {
            var rand = new Random(50);
            int x = 0;
            int y = 0;
            for (int i = 0; i < CountWolfs; i++)
            {
                x = rand.Next(1, 21);
                y = rand.Next(1, 21);
                Wolf newWolf = new Wolf(x, y);
                if (!Wolfs.Contains(newWolf))
                {
                    Wolfs.Add(newWolf);   
                }
                else
                {
                    i--;
                }

            }

        }
        public void InitializationFemaleWolfs()
        {
            var rand = new Random(21);
            int x = 0;
            int y = 0;
            for (int i = 0; i < CountFemaleWolfs; i++)
            {
                x = rand.Next(1, 21);
                y = rand.Next(1, 21);
                FemaleWolf newFemaleWolf = new FemaleWolf(x, y);
                if (!FemaleWolfs.Contains(newFemaleWolf))
                {
                    FemaleWolfs.Add(newFemaleWolf);

                }
                else
                {
                    i--;
                }

            }

        }
        public bool IsFree(int x, int y, int [,] FieldArray)
        {
            if (x >= 0 && x < 20 && y >= 0 && y < 20)
                if (FieldArray[x, y] == 0)
                    return true;
            return false;
        }




    }
}
