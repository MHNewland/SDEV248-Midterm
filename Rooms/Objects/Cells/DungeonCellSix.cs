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
        DungeonCells dc;

        const string roomName = "DungeonCellSix";

        public DungeonOffice()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonCellSix") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonCells");
            doffice = checkRoom != null ? (DungeonCells)checkRoom : new DungeonCells();

            item.Add(new Page());

            description = "The silence is broken only by the occasional drip of water from a hidden leak.\n" +
                          "Sometimes, if you listen closely, \n" +
                          "you can hear faint echoes of anguished whispers�the remnants of forgotten souls trapped in this desolate cell";

            // Exits from the Warden's Office        
            exits.add("BACK", dc)
        }
    }
}