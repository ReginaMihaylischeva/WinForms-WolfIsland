using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class FemaleWolf : Animal
    {
        public FemaleWolf(int x, int y) : base(x, y) {
            score = 1;
        }
        private double score;
      
        void SetScore(double score)
        {
            this.score = score;
        }
        public double GetScore()
        {

            return Math.Round(score, 1);
        }
        void AddPoints()
        {
            score += 1;
        }
        void RemovePoints()
        {
            score -= 0.1;
        }
        public bool СhaseForRabbit(int x, int y)
        {
            int xWolf = GetX();
            int yWolf = GetY();
            if (xWolf == x && yWolf == y)
            {
                Eat();
                return true;
            }
            else
            {
                if (xWolf < x) { xWolf++; }
                if (yWolf < y) { yWolf++; }
                if (xWolf > x) { xWolf--; }
                if (yWolf > y) { yWolf--; }
                SetXY(xWolf, yWolf);
                RemovePoints();
            }
            return false;
        }
     
        public void Eat()
        {
            AddPoints();
          
        }

      


    }
}
