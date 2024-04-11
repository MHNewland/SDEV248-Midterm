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
        DungeonCellTwo d2;
        DungeonCellThree d3;
        DungeonCellFour d4;
        DungeonCellFive d5;
        DungeonCellSix d6;

        public int pages;

        bool[] pages_grabbed = new bool[] { false, false, false, false };

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

            checkRoom = RoomManager.Instance.GetRoom("DungeonCellOne");
            d1 = checkRoom != null ? (DungeonCellOne)checkRoom : new DungeonCellOne();

            checkRoom = RoomManager.Instance.GetRoom("DungeonCellTwo");
            d2 = checkRoom != null ? (DungeonCellTwo)checkRoom : new DungeonCellTwo();

            checkRoom = RoomManager.Instance.GetRoom("DungeonCellThree");
            d3 = checkRoom != null ? (DungeonCellThree)checkRoom : new DungeonCellThree();
        
            checkRoom = RoomManager.Instance.GetRoom("DungeonCellFour");
            d4 = checkRoom != null ? (DungeonCellFour)checkRoom : new DungeonCellFour();

            checkRoom = RoomManager.Instance.GetRoom("DungeonCellFive");
            d5 = checkRoom != null ? (DungeonCellFive)checkRoom : new DungeonCellFive();

            checkRoom = RoomManager.Instance.GetRoom("DungeonCellSix");
            d6 = checkRoom != null ? (DungeonCellSix)checkRoom : new DungeonCellSix();

            items.Add(new Potion());

            description = "The dungeon lies deep within the bowels of obsidian spire, \n" +
                          "its cold stone walls echoing with the cries of the condemned. " +
                          "The chamber is lit by an eternal flame and divided into six cells, each barely large enough for a single occupant.\n";

            // Exits from the Warden's Office        
            exits.Add("WEST", doffice);
            exits.Add("CELL1", d1);
            exits.Add("CELL2", d2);
            exits.Add("CELL3", d3);
            exits.Add("CELL4", d4);
            exits.Add("CELL5", d5);
            exits.Add("CELL6", d6);
        }

        public void PageCount()
        {
            foreach (Item item in RoomManager.Instance.player.inventory)
            {
                if (item.itemName == "Page")
                {
                    pages += 1;
                }
            }

            switch (pages)
            {
                case 1:
                    if (!pages_grabbed[0])
                    {
                        description += "\nA";
                        pages_grabbed[0] = true;
                    }
                    break;
                case 2:
                    if (!pages_grabbed[1])
                    {
                        description += "<-";
                        pages_grabbed[1] = true;
                    }
                    break;
                case 3:
                    if (!pages_grabbed[2])
                    {
                        description += "3";
                        pages_grabbed[2] = true;
                    }
                    break;
                case 4:
                    if (!pages_grabbed[3])
                    {
                        description += "ifyoxov";
                        pages_grabbed[3] = true;
                    }
                    break;
                default:
                    break;
            }
            pages = 0;
        }
    }
}