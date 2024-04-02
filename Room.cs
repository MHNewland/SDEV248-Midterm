using System.Collections.Generic;

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

        //room being checked if it exists
        protected Room checkRoom;

        protected int visits;

        public Room(string roomName)
        {
            this.roomName = roomName;
            exits = new Dictionary<string, Room>();
            items = new List<Item>();
            visits = 0;
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
    }
}