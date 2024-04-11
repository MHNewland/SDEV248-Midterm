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

        private string code;

        public bool storeUnlocked = false;

        public DungeonStorage()
            : base(roomName)
        {
            if (RoomManager.Instance.GetRoom("DungeonStorage") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            // Checking for all surrounding rooms
            checkRoom = RoomManager.Instance.GetRoom("DungeonOffice");
            doffice = checkRoom != null ? (DungeonOffice)checkRoom : new DungeonOffice();

            description = "Iron bound chests and wooden crates are stacked haphazardly, \n" +
                          "each filled with the spoils of conquest or the personal effects of prisoners long forgotten. \n" +
                          "The air is musty, heavy with the scent of rust and decay.\n" +
                          "There is red writing on the wall which reads, say the code to reveal the exit.";

            // Exits from the storage room        
            exits.Add("NORTH", doffice);
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public void SayCode()
        {
            Console.WriteLine("Say the code:");
            code = Console.ReadLine();
            DungeonOffice doffice = (DungeonOffice)RoomManager.Instance.GetRoom("DungeonOffice");

            if (code.ToUpper() == "LIBRARY")
            {
                doffice.secretEntrance = true;
                doffice.AddSecretExit();
            }
        }
    }
}