using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Potion : Item
    {
        public Potion() : base("Potion", "A flask containing a red liquid, likely a <potion>.", "Heals the player for 1 HP", true, true) { }

        public override void Use(Player player)
        {
            Console.WriteLine("You quickly drink the potion and feel refreshed.");
            Console.WriteLine("The potion healed you for 1 HP.");
            player.TakeDamage(-1);
        }
    }
}
