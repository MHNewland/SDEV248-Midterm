using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{

    class DungeonStorageKey : Item
    {

        public DungeonStorageKey() : base("Key", "An old and rusted <key>.", "opens a door", true, true)
        {

        }

        public override void Use(Player player)
        {
            DungeonOffice doffice = (DungeonOffice)RoomManager.Instance.GetRoom("DungeonOffice");

            if (RoomManager.Instance.currentRoom.GetType().Name.ToUpper() == "DUNGEONOFFICE")
            {
                Console.WriteLine("You unlock the door to which seems to be a storage room.");
                doffice.storeUnlocked = true;
                doffice.UnlockStoreRoom();
            }
        }
    }
}