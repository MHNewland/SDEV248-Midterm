using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Player: Character
    {

        Item equippedItem;


        public Player(int charChoice)
        {
            switch (charChoice)
            {
                //Ranged
                case 1:
                    {
                        maxHP = 3;
                        hp = 3;
                        melee = 2;
                        shield = 3;
                        bow = 5;
                    }
                    break;
                //Attack
                case 2:
                    {
                        maxHP = 4;
                        hp = 4;
                        melee = 5;
                        shield = 1;
                        bow = 3;
                    }
                    break;
                //Defense
                case 3:
                    {
                        maxHP = 5;
                        hp = 5;
                        melee = 3;
                        shield = 5;
                        bow = 0;
                    }
                    break;
                default:
                    break;
            }
            equippedItem = null;
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

        /// <summary>
        /// Sets the current equipped item to the provided item.
        /// </summary>
        /// <param name="item"></param>
        public void EquipItem(Item item)
        {
            equippedItem = item;
        }

        /// <summary>
        /// Displays the player's inventory with item description and if the item is usable
        /// </summary>
        public void ViewInventory()
        {
            Console.Clear();
            Console.WriteLine($"Inventory:\n");
            foreach (Item i in inventory)
            {
                Console.WriteLine($"{i.itemName}");
                Console.WriteLine($"  -Description: {i.description}");
                Console.WriteLine($"  -Usable: {i.usable}");
            }
            Console.WriteLine("\n Press any key to return to the main menu...");
            Console.ReadKey();
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }
    }
}
