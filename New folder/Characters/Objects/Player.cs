using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    public class Player: Character
    {

        public Item equippedItem { private set; get; }


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
                        block = 3;
                        ranged = 5;
                    }
                    break;
                //Attack
                case 2:
                    {
                        maxHP = 4;
                        hp = 4;
                        melee = 5;
                        block = 1;
                        ranged = 3;
                    }
                    break;
                //Defense
                case 3:
                    {
                        maxHP = 5;
                        hp = 5;
                        melee = 3;
                        block = 5;
                        ranged = 0;
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
        //public void UseItem(string item)
        //{
        //    //check if item is in inventory
        //    foreach (Item i in inventory)
        //    {
        //        if (i.itemName.ToUpper() == item.ToUpper())
        //        {
        //            if (i.usable)
        //            {
        //                i.Use(this);
        //                inventory.Remove(i);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Item is not usable");
        //            }

        //            //item was found, stop the loop
        //            break;
        //        }
        //    }
        //    Console.WriteLine($"Item \"{item}\" not found");
        //}

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
            Console.WriteLine($"Inventory:\n");
            foreach (Item i in inventory)
            {
                Console.WriteLine($"{i.itemName}");
                Console.WriteLine($"  -Description: {i.description}");
                Console.WriteLine($"  -Effect: {i.effect}");
                Console.WriteLine($"  -Usable in combat: {i.usable}");
            }
        }


        /// <summary>
        /// adds item to inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        /// <summary>
        /// Searches player's inventory for an item and returns it if found
        /// </summary>
        /// <param name="itemStr"></param>
        /// <returns>Item if found null if not.</returns>
        public bool TryGetItem(string itemStr, out Item item)
        {
            item = null;
            foreach (Item i in inventory)
            {
                if (i.itemName.ToUpper() == itemStr.ToUpper())
                {
                    item = i;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackType"> 1. melee, 2. ranged, 3. block</param>
        /// <returns></returns>
        public int GetDamage(string attackType)
        {
            //no item equipped.
            if (equippedItem == null) return 1;

            switch (attackType)
            {
                case "1":
                    if(equippedItem.itemName.ToUpper() == "SWORD")
                        return 2;
                    break;
                case "2":
                    if (equippedItem.itemName.ToUpper() == "BOW")
                        return 2;
                    break;
                default:
                    break;
            }
            return 1;
        }
    }
}
