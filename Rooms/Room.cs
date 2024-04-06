using System.Collections.Generic;
using System;

namespace SDEV248Midterm {
    public abstract class Room {
        //name of the room
        public string roomName { private set; get; }

        //description that gets told to the player
        protected string description;

        //Dictionary of direction and room name
        protected Dictionary<string, Room> exits;

        //list of items in the room
        protected List<Item> items;

        //If the room has an enemy
        protected Character enemy;

        //room being checked if it exists
        protected Room checkRoom;

        protected int visits;

        public Room(string roomName)
        {
            this.roomName = roomName;
            exits = new Dictionary<string, Room>();
            items = new List<Item>();
            visits = 0;
            enemy = null;
        }

        /// <summary>
        /// Description of the room
        /// </summary>
        /// <returns>string description</returns>
        public override string ToString()
        {
            visits++;
            //return ($"{description}\nVisits: {visits}");
            return ($"{description}");
        }

        /// <summary>
        /// Gets the valid exit directions for the room 
        /// and concatenates them into a string separated by commas
        /// </summary>
        /// <returns> string exits</returns>
        public string GetExits()
        {
            string exitStr = string.Join(", ", exits.Keys);

            return exitStr;
        }


        /// <summary>
        /// Gets the room corresponding to the exit direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Room direction</returns>
        public Room GetRoom(string direction)
        {
            return exits[direction];
        }

        /// <summary>
        /// Searches room's items and returns it if found
        /// </summary>
        /// <param name="itemStr"></param>
        /// <returns>Item if found null if not.</returns>
        public bool TryGetItem(string itemStr, out Item item)
        {
            item = null;
            foreach(Item i in items)
            {
                if(i.itemName.ToUpper() == itemStr.ToUpper())
                {
                    item = i;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// removes item from the room.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(string item)
        {
            foreach (Item i in items)
            {
                if (i.itemName.ToUpper() == item.ToUpper())
                {
                    items.Remove(i);
                    return;
                }
            }
            Console.WriteLine($"Item {item} not found in room {roomName}");
        }

        /// <summary>
        /// removes item from the room.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        /// <summary>
        /// returns the list of items as a string separated by commas
        /// </summary>
        /// <returns>string</returns>
        public string GetItems()
        {
            return string.Join(", ", items);
        }

        public bool TryGetEnemy(out Character enemyChar, out bool alive)
        {
            enemyChar = null;
            alive = false;
            if(enemy == null) return false;

            enemyChar = enemy;
            alive = enemy.hp > 0;
            return true;
        }
    }
}