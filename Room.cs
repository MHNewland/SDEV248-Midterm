using System.Collections.Generic;

namespace SDEV248Midterm {
    public abstract class Room {
        //name of the room
        private string roomName;

        //description that gets told to the player
        protected string description;

        //Dictionary of direction and room name
        protected Dictionary<string, string> exits;

        //list of items in the room
        protected List<Item> items;

        public Room(string roomName)
        {
            this.roomName = roomName;
            exits = new Dictionary<string, string>();
            items = new List<Item>();
        }

        //printing the room.ToString() should print the description 
        public override string ToString()
        {
            return (description);
        }


        //all rooms should treat getting the exit list the same
        public string GetExits()
        {
            string exitStr = string.Join(", ", exits.Keys);
            //string exitStr = "";
            //foreach (string exit in exits.Keys)
            //{
            //    exitStr += exit + ", ";
            //}

            ////get rid of the last comma and space
            //exitStr = exitStr.Substring(0, exitStr.Length - 2);
            return exitStr;
        }
    }
}