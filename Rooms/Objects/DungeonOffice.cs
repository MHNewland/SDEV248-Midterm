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

        public bool torchLit = false;
        public bool secretEntrance = false;

        public DungeonOffice()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonOffice") != null)
            {
                DungeonOffice dungOff = (DungeonOffice)RoomManager.Instance.GetRoom("DungeonOffice");
                dungOff.AddSecretExit();
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonCells");
            dc = checkRoom != null ? (DungeonCells)checkRoom : new DungeonCells();
              
            checkRoom = RoomManager.Instance.GetRoom("DungeonStorage");
            dstore = checkRoom != null ? (DungeonStorage)checkRoom : new DungeonStorage();

            checkRoom = RoomManager.Instance.GetRoom("DungeonStairs");
            dstair = checkRoom != null ? (Library)checkRoom : new Library();

            items.Add(new Torch()); 

            description = "You have fallen into a dark and damp pit, into a puddle of black, slick goo.\n" +
                          "The only source of light shines from the hole in the ceiling you just feel from." +

            // Exits from the Warden's Office        
            exits.add("EAST", dc)
            exits.add("SOUTH", dstore)

        }

        public void AddSecretExit()
        {
            if (torchLit)
            {
                description = "The Warden’s office lies forgotten, its grandeur lost to dust and cobwebs. Maps and weapons are relics of the past, \n" +
                                       "and the once-warm hearth is now cold, leaving the room silent and forlorn.\n" +
                                       "The entire floor is covered in what looks to be an inky, black oil.";
            }

            if (secretEntrance)
            {
                exits.Add("NORTH", library);
            }
        }



}
}