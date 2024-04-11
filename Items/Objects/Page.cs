using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{

    class Page : Item
    {

        public Page() : base("Page", "A torn <page> with writing on it","none",false,true)
        {

        }
        public override void Use(Player player)
        {
            Console.WriteLine(description);
        }
    }
}