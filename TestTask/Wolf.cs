using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Wolf : FemaleWolf
    {
        public Wolf(int x,int y) : base(x, y){
          
        }
        public bool СhaseForFemaleWolf(int x, int y)
        {
            int xWolf = GetX();
            int yWolf = GetY();
            if (xWolf == x && yWolf == y)
            {
                if (xWolf + 2 > 20) { xWolf = 20; }
                if (xWolf + 2 < 1) { xWolf = 1; }
                if (yWolf + 2 > 20) { yWolf = 20; }
                if (yWolf + 2 < 1) { yWolf = 1; }
                SetXY(xWolf + 2, yWolf + 2);
                return true;
            }
            else
            {
                if (xWolf < x) { xWolf++; }
                if (yWolf < y) { yWolf++; }
                if (xWolf > x) { xWolf--; }
                if (yWolf > y) { yWolf--; }
                SetXY(xWolf, yWolf);

            }
            return false;
        }
       
    } 
}
