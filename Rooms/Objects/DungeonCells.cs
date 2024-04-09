using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class DungeonStorage : Room
    {
        // Store connecting rooms
        DungeonOffice doffice;

        const string roomName = "Cells";

        public DungeonOffice()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonOffice") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonOffice");
            doffice = checkRoom != null ? (DungeonOffice)checkRoom : new DungeonOffice();

            description = "";

            // Exits from the Warden's Office        
            exits.add("WEST", DungeonOffice)
        }
    }
}