using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{

    class Torch : Item
    {

        public Torch() : base("Torch", "A thick wooden stick wrapped in cloth, can be used as a <torch>", "Lights up the room when lit",true, true)
        {
            
        }

        public override void Use(Player player)
        {
            DungeonOffice doffice = (DungeonOffice) RoomManager.Instance.GetRoom("DungeonOffice");
            if (doffice.torchLit)
            {
                Console.WriteLine("You're torch is already lit.\n");
                    return;
            }

            if (RoomManager.Instance.currentRoom.GetType().Name.ToUpper() == "DUNGEONCELLS")
            {
                Console.WriteLine("You light your torch off the eternal flame.");
                doffice.torchLit = true;
                doffice.LightRoom();
            }
        }
    }
}