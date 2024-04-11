using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{

    class Torch : Equipment
    {

        public Torch() : base("Key", "It's old and rusted")
        {

        }

        public void Use(Player player)
        {
            DungeonOffice doffice = (DungeonOffice)RoomManager.Instance.GetRoom("DungeonOffice");

            if (RoomManager.Instance.currentRoom.GetType().Name.ToUpper() == "DUNGEONCELLS")
            {
                console.WriteLine("You unlock the door to watch seems to be a storage room.")
                doffice.storeUnlocked = true;
            }
        }
    }
}