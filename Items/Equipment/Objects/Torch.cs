using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{

    class Torch : Equipment
    {

        public Torch() : base("Torch", "A thick wooden stick wrapped in cloth")
        {
            
        }

        public void Use(Player player)
        {
            DungeonOffice doffice = (DungeonOffice) RoomManager.Instance.GetRoom("DungeonOffice");
            if (doffice.torchLit)
            {
                console.WriteLine("You're torch is already lit.\n")
                    break;
            }

            if (RoomManager.Instance.currentRoom.GetType().Name.ToUpper() == "DUNGEONCELLS")
            {
                console.WriteLine("You light your torch off the eternal flame.")
                doffice.torchLit = true;
            }
        }
    }
}