using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Sword: Item
    {
        bool usable;

        public Sword(string description, bool usable): base(description, usable)
        {
           
        }
    }
}
