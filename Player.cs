using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Player: Character
    {
        public Player(int charChoice)
        {
            switch (charChoice)
            {
                //Ranged
                case 1:
                    {
                        hp = 3;
                        melee = 2;
                        shield = 3;
                        bow = 5;
                    }
                    break;
                //Attack
                case 2:
                    {
                        hp = 4;
                        melee = 5;
                        shield = 1;
                        bow = 3;
                    }
                    break;
                //Defense
                case 3:
                    {
                        hp = 5;
                        melee = 3;
                        shield = 5;
                        bow = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// <para>checks through player's inventory and uses the item if it's usable</para>
        /// </summary>
        /// <param name="item"></param>
        public void UseItem(string item)
        {
            //check if item is in inventory
            foreach (Item i in inventory)
            {
                if (i.itemName.ToUpper() == item.ToUpper())
                {
                    if (i.usable)
                    {
                        i.Use();
                        inventory.Remove(i);
                    }
                    else
                    {
                        Console.WriteLine("Item is not usable");
                    }

                    //item was found, stop the loop
                    break;
                }
            }
            Console.WriteLine($"Item \"{item}\" not found");
        }
    }
}
