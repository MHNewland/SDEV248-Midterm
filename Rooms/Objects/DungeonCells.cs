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

        private int pages;

        const string roomName = "Cells";

        public DungeonCells()
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

            enemy = new BaseEnemy();

            description = "The dungeon lies deep within the bowels of obsidian spire, \n" +
                          "its cold stone walls echoing with the cries of the condemned. " +
                          "A narrow, torch-lit corridor leads to a heavy iron door, rusted and pitted from years of use. \n" +
                          "Beyond it lies a grim chamber divided into six cells, each barely large enough for a single occupant.\n";

            // Exits from the Warden's Office        
            exits.add("WEST", DungeonOffice)
            exits.add("Cell 1", DungeonCellOne)
            exits.add("Cell 2", DungeonCellTwo)
            exits.add("Cell 3", DungeonCellThree)
            exits.add("Cell 4", DungeonCellFour)
            exits.add("Cell 5", DungeonCellFive)
            exits.add("Cell 6", DungeonCellSix)
        }

        switch (pages)
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
    }
}