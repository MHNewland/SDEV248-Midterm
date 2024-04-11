using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class DungeonCellTwo : Room
    {
        // Store connecting rooms
        DungeonCells dc;

        const string roomName = "DungeonCellTwo";

        public DungeonCellTwo()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonCellTwo") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonCells");
            dc = checkRoom != null ? (DungeonCells)checkRoom : new DungeonCells();

            items.Add(new Page());

            description = "The silence is broken only by the occasional drip of water from a hidden leak.\n" +
                          "Sometimes, if you listen closely, \n" +
                          "you can hear faint echoes of anguished whispers—the remnants of forgotten souls trapped in this desolate cell";

            // Exits from the Warden's Office        
            exits.Add("BACK", dc);
        }
    }
}
