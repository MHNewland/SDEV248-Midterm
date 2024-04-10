using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    public abstract class Equipment : Item
    {
        public Equipment(string name, string description, string effect) : base(name, description, effect, false) { }

        public override void Use(Player player)
        {
            if (player.equippedItem != null)
            {
                Console.WriteLine($"Do you want to replace {player.equippedItem} with {itemName}? (Y/N)");
            }
            else
            {
                Console.WriteLine($"Do you want to equip the {itemName}? (Y/N)");
            }

            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine($"Equipped {itemName}");
                player.EquipItem(this);
            }
        }
    }
}
