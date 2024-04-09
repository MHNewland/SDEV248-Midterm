using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class DungeonOffice : Room
    {
        // Store connecting rooms
        DungeonCells dc;
        DungeonStorage dstore;
        DungeonStairs dstairs;


        const string roomName = "Warden's Office";

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
            checkRoom = RoomManager.Instance.GetRoom("DungeonCells");
            dc = checkRoom != null ? (DungeonCells)checkRoom : new DungeonCells();

            checkRoom = RoomManager.Instance.GetRoom("DungeonStorage");
            dstore = checkRoom != null ? (DungeonStorage)checkRoom : new DungeonStorage();

            checkRoom = RoomManager.Instance.GetRoom("DungeonStairs");
            dstair = checkRoom != null ? (Library)checkRoom : new Library();

            description = "You have fallen into a dark and damp pit, into a puddle of black, slick goo.\n" +
                          "The only source of light shines from the hole in the ceiling you just feel from." +

            // Exits from the Warden's Office        
            exits.add("EAST", DungeonCells)
            exits.add("SOUTH", DungeonStorage)
        }

        if (!firstEntrance)
        {
            DungeonOffice.ToString("The Warden’s office lies forgotten, its grandeur lost to dust and cobwebs. Maps and weapons are relics of the past, \n" +
                                   "and the once-warm hearth is now cold, leaving the room silent and forlorn.\n"
                                   "The entire floor is covered in what looks to be an inky, black oil.");
        }

        if (secretEntrance)
        {
            DungeonOffice.exits.add("NORTH", Library)
        }

    }
}