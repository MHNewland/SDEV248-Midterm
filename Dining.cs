using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Dining:Room
    {
        //store each room that this room connects to
        FirstFloorHallwayOne ffh1;


        public Dining()
            : base("Dining")
        {
            if (RoomManager.Instance.GetRoom("Dining") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("FirstFloorHallwayOne");
            ffh1 = checkRoom != null ? (FirstFloorHallwayOne)checkRoom : new FirstFloorHallwayOne();




            description = "You enter the dining room. The long, wooden table\n"+
                          "is rotting and the high-backed chairs are falling apart.\n"+
                          "The fireplace is cold and filled with soot.";

            //add exit directions and room names available
            exits.Add("WEST", ffh1);
        }
    }
}
