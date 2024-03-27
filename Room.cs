using System.Collections.Generic;

namespace SDEV248Midterm {
    public abstract class Room {
        private string roomName;
        protected string description;
        protected List<string> exits;
        protected List<Item> items;

        public Room(string roomName)
        {
            this.roomName = roomName;
            exits = new List<string>();
            items = new List<Item>();
        }

        public override string ToString()
        {
            return (description);
        }
    }
}