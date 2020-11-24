using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask
{
    abstract class Animal
    {
        private int x, y;
        public Animal(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void SetXY(int x, int y) {
            this.x = x;
            this.y = y;
        }
       
        public int GetY() {
            return y;
        }
        public int GetX() {
            return x;
        }
     

        public  void Step() {
            int newX = 0, newY = 0;
            int x = GetX();
            int y = GetY();
           Thread.Sleep(1);
            var rand = new Random();
            int step = rand.Next(0,10);
            if (step == 1)
            {
                newX = x -1;
                newY = y - 1;
            }
            if (step == 2)
            {
                newX = x;
                newY = y - 1;
            }
            if (step == 3)
            {
                newX = x + 1;
                newY = y - 1;
            }
            if (step == 4)
            {
                newX = x - 1;
                newY = y;
            }
            if (step == 5)
            {
                newX = x;
                newY = y;
            }
            if (step == 6)
            {
                newX = x + 1;
                newY = y;
            }
            if (step == 7)
            {
                newX = x - 1;
                newY = y + 1;
            }
            if (step == 8)
            {
                newX = x;
                newY = y + 1;
            }
            if (step == 9)
            {
                newX = x + 1;
                newY = y + 1;
            }

            if (newX > 20) { newX = 20; }
            if (newX < 1) { newX = 2; }
            if (newY > 20) { newY = 20; }
            if (newY < 1) { newY = 2; }

            
            SetXY(newX, newY);
        }
        public Object CheckNeighbors<T>(T Animal, int x, int y)
        {
            if (Math.Abs(GetX() - x) <= 1 && Math.Abs(GetY() - y) <= 1)
            {
                return Animal;
            }
            return null;
        }


    }
}
