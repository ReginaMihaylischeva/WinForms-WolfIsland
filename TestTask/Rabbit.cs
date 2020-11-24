using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Rabbit : Animal
    {
        public Rabbit(int x, int y) : base(x,y) { }
       
        public  bool Birth() {
            var rand = new Random();
            int birth = rand.Next(1, 6);
            if (birth==2) { return true; }
            return false;
        }

    }
}
