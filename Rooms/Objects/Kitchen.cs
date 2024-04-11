using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Kitchen : Room
    {
        //store each room that this room connects to
        FirstFloorHallwayOne ffh1;


        public Kitchen()
            : base("Kitchen")
        {
            if (RoomManager.Instance.GetRoom("Kitchen") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("FirstFloorHallwayOne");
            ffh1 = checkRoom != null ? (FirstFloorHallwayOne)checkRoom : new FirstFloorHallwayOne();

            description = "You enter the kitchen and see it is in a state of disarray.\n" +
                          "Pots and pans are scattered around, and the smell of decay is strong.\n"+
                          "The old stone oven is cracked and blackened.";

            //add exit directions and room names available
            exits.Add("EAST", ffh1);
        }
    }
}
