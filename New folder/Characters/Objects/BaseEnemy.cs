using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm    
{
    class BaseEnemy: Character
    {
        
        public BaseEnemy()
        {
            maxHP = 2;
            hp = 2;
            melee = 0;
            ranged = 0;
            block = 0;
        }
    }
}
