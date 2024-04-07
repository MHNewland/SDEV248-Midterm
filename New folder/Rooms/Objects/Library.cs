using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Library : Room
    {
        //store each room that this room connects to
        FirstFloorHallwayTwo ffh2;


        public Library()
            : base("Library")
        {
            if (RoomManager.Instance.GetRoom("Library") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("FirstFloorHallwayTwo");
            ffh2 = checkRoom != null ? (FirstFloorHallwayTwo)checkRoom : new FirstFloorHallwayTwo();




            description = "You enter the library. It's is filled with dusty, moth-eaten books.\n"+
                          "The wooden shelves creak ominously, and the once plush reading\n"+
                          "chairs are now torn and faded.";

            //add exit directions and room names available
            exits.Add("EAST", ffh2);
        }
    }
}
