using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class SecondFloorHallway : Room {

        //store each room that this room connects to
        Laboratory laboratory;
        LaboratoryStorageRoom laboratoryStorageRoom;
        FirstFloorHallwayTwo ffh2;
        Rooftop rooftop;

        public SecondFloorHallway()
            : base("SecondFloorHallway")
        {
            if(RoomManager.Instance.GetRoom("SecondFloorHallway") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("FirstFloorHallwayTwo");
            ffh2 = checkRoom != null ? (FirstFloorHallwayTwo)checkRoom : new FirstFloorHallwayTwo();

            checkRoom = RoomManager.Instance.GetRoom("Labrotory");
            laboratory = checkRoom != null ? (Laboratory)checkRoom : new Laboratory();

            checkRoom = RoomManager.Instance.GetRoom("LaboratoryStorageRoom");
            laboratoryStorageRoom = checkRoom != null ? (LaboratoryStorageRoom)checkRoom : new LaboratoryStorageRoom();

            checkRoom = RoomManager.Instance.GetRoom("Rooftop");
            rooftop = checkRoom != null ? (Rooftop)checkRoom : new Rooftop();

            description = "The hallway on the second floor is dimly lit with an overwelming sent of death and decay, " +
                          "You stand in the south end of a halway with a singular torch near a stairwell to the north .\n" +
                          "A ominus glow comes from the room on west west .\n" +
                          "A smell of chemicals and rot come fills your lungs .\n" +
                          "You hear rustling in the room to the east.";

            //add exit directions and room names available
            exits.Add("WEST", laboratory);
            exits.Add("UPSTAIRS", rooftop);
            exits.Add("EAST", laboratoryStorageRoom);
            exits.Add("DOWNSTAIRS", ffh2);        
        }
    }
}