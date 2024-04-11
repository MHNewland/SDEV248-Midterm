using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class DungeonCells : Room
    {
        // Store connecting rooms
        DungeonOffice doffice;
        DungeonCellOne d1;
        DungeonCellOne d1;
        DungeonCellOne d1;
        DungeonCellOne d1;
        DungeonCellOne d1;
        DungeonCellOne d1;

        public int pages;

        const string roomName = "DungeonCells";

        public DungeonCells()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonCells") != null)
            {
                DungeonCells dc = (DungeonCells)RoomManager.Instance.GetRoom("DungeonCells");
                dc.PageCount();
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonOffice");
            doffice = checkRoom != null ? (DungeonOffice)checkRoom : new DungeonOffice();

            item.Add(new Potion());

            description = "The dungeon lies deep within the bowels of obsidian spire, \n" +
                          "its cold stone walls echoing with the cries of the condemned. " +
                          "The chamber is lit by an eternal flame and divided into six cells, each barely large enough for a single occupant.\n";

            // Exits from the Warden's Office        
            exits.add("WEST", DungeonOffice)
            exits.add("Cell 1", DungeonCellOne)
            exits.add("Cell 2", DungeonCellTwo)
            exits.add("Cell 3", DungeonCellThree)
            exits.add("Cell 4", DungeonCellFour)
            exits.add("Cell 5", DungeonCellFive)
            exits.add("Cell 6", DungeonCellSix)
        }

        public void PageCount()
        {
            for (item in player.inventory.length())
            {
                if (item.itemName == "Page")
                {
                    pages += 1;
                }
            }

            switch (pages)
            {
                case 1:
                    description += "\nA";
                    break;
                case 2:
                    description += "<-";
                    break;
                case 3:
                    description += "3";
                    break;
                case 4:
                    description += "ifyoxov";
                    break;
                default:
                    break;
            }
            pages = 0;
        }
    }
}