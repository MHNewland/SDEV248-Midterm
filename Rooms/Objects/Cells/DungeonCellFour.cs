using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class DungeonCellFour : Room
    {
        // Store connecting rooms
        DungeonCells dc;

        const string roomName = "DungeonCellFour";

        public DungeonCellFour()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonCellFour") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonCells");
            dc = checkRoom != null ? (DungeonCells)checkRoom : new DungeonCells();

            enemy = new BaseEnemy();

            description = "The silence is broken only by the occasional drip of water from a hidden leak.\n" +
                          "Sometimes, if you listen closely, \n" +
                          "you can hear faint echoes of anguished whispers—the remnants of forgotten souls trapped in this desolate cell";

            // Exits from the Warden's Office        
            exits.Add("BACK", dc);
        }
    }
}
