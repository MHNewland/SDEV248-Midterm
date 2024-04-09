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

        const string roomName = "Storage";

        bool firstEntrance = true;
        bool secretEntrance = false;

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

            description = "Iron bound chests and wooden crates are stacked haphazardly, \n" +
                          "each filled with the spoils of conquest or the personal effects of prisoners long forgotten. \n" +
                          "The air is musty, heavy with the scent of rust and decay.";

            // Exits from the Warden's Office        
            exits.add("NORTH", DungeonOffice)
        }
    }
}