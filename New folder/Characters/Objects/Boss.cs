using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm

{
    class Boss : Character
    {
        public Boss() {
            maxHP = 5;
            hp = 5;
            melee = 1;
            block = 2;
            ranged = 5;
        }
    }
}
