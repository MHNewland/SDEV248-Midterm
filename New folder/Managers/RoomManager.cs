using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    public class RoomManager
    {
        private static RoomManager instance;

        public List<Room> createdRooms = new List<Room>();

        private RoomManager(){}


        public static RoomManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new RoomManager();
                return instance;
            }
        }

        public List<Room> GetCreatedRooms()
        {
            return createdRooms;
        }

        public Room GetRoom(string room)
        {
            foreach (Room r in createdRooms)
            {
                if (r.roomName == room)
                {
                    return r;
                }
            }
            return null;
        }

    }
}
