using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Armory : Room
    {
        //store each room that this room connects to
        FirstFloorHallwayTwo ffh2;


        public Armory()
            : base("Armory")
        {
            if (RoomManager.Instance.GetRoom("Armory") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("FirstFloorHallwayTwo");
            ffh2 = checkRoom != null ? (FirstFloorHallwayTwo)checkRoom : new FirstFloorHallwayTwo();

            items.Add(new Sword());


            description = "You enter an armory. It's a chilling reminder of the castle’s violent past.Rusty" +
                          " weapons hang haphazardly on the stone walls, and a thick layer of dust covers" +
                          " the worn wooden benches. The air is heavy with the smell of old metal and decay.";

            enemy = new Boss();

            //add exit directions and room names available
            exits.Add("WEST", ffh2);
        }
    }
}
