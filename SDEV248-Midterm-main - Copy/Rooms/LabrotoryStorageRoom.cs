using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class LabrotoryStorageRomm : Room {

        //store each room that this room connects to
        FirstFloorHallwayTwo ffh2;
            public SecondFloorHallwayOne()
            : base("SecondFloorHallwayOne")
        {
            if(RoomManager.Instance.GetRoom("SecondFloorHallwayOne") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);
 checkRoom = RoomManager.Instance.GetRoom("SecondFloorHallwayOne");
            Sfh2 = checkRoom != null ? (SecondFloorHallwayOne)checkRoom : new SecondFloorHallwayOne();

            checkRoom = RoomManager.Instance.GetRoom("Labrotory");
           Labrotory = checkRoom != null ? (Labrotory)checkRoom : new Labrotory();

            checkRoom = RoomManager.Instance.GetRoom("LabrotoryStorageRomm");
          LabrotoryStorageRomm = checkRoom != null ? (LabrotoryStorageRomm)checkRoom : new LabrotoryStorageRomm();


            description = "TThe air is thick with the scent of dried herbs and ancient incantations.\n" +
             "As you step across the threshold, the wooden door creaks, echoing through the dimly lit chamber.\n" +
            "A rat scurys out the room \n" +
            "The flickering candle flames cast elongated shadows on the stone walls, revealing faded alchemical symbols etched into the rough surface."\n" +
            "Wooden shelves line the walls, sagging under the weight of glass jars and clay pots.\n" +
            "Each container holds a secret ingredient\n" +
            "Cobwebs cling to the jars, their contents long abandoned " ;

            //add exit directions and room names available
            exits.Add("NORTH", Rooftop);
            exits.Add("WEST", Labrotory; 
            exits.Add("South", FirstFloorHallwayOne)        }
        }
        }
    }
}