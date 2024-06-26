using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class FirstFloorHallwayOne : Room {

        //store each room that this room connects to
        DungeonOffice doffice;
        Kitchen kitchen;
        Dining dining;

        public FirstFloorHallwayOne()
            : base("FirstFloorHallwayOne")
        {
            if(RoomManager.Instance.GetRoom("FirstFloorHallwayOne") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("DungeonOffice");
            doffice = checkRoom != null ? (DungeonOffice)checkRoom : new DungeonOffice();

            checkRoom = RoomManager.Instance.GetRoom("Kitchen");
            kitchen = checkRoom != null ? (Kitchen)checkRoom : new Kitchen();

            checkRoom = RoomManager.Instance.GetRoom("dining");
            dining = checkRoom != null ? (Dining)checkRoom : new Dining();


            description = "The hallway on the first floor is dimly lit, " +
                          "with flickering torches casting long, dancing shadows.\n" +
                          "The stone walls are damp and the air is heavy with the scent of mildew.\n" +
                          "The carpet, threadbare and faded, runs along the center of the hallway.";

            //add exit directions and room names available
            exits.Add("WEST", kitchen);
            exits.Add("FORWARD", doffice);
            exits.Add("EAST", dining); 
        }
    }
}