using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class SecondFloorHallwayOne : Room {

        //store each room that this room connects to
        SecondFloorHallwayTwo sfh2;
        LabrotoryLabrotory;
        LabrotoryStorageRomm LabrotoryStorageRomm;

        public LabrotoryStorageRomm()
            : base("LabrotoryStorageRomm")
        {
            if(RoomManager.Instance.GetRoom("LabrotoryStorageRomm") != null)
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


            description = "The hallway on the second floor is dimly lit with an overwelming sent of death and decay, " +
                          "You stand in the south end of a halway with a singular torch near a stairwell to the north .\n" +
                          "A ominus glow comes from the room on west west .\n" +
                          "A smell of chemicals and rot come fills your lungs .\n" +
                          "You hear rustling in the room to the east."

            //add exit directions and room names available
            exits.Add("WEST", Labrotory);
            exits.Add("NORTH", Rooftop);
            exits.Add("EAST", LabrotoryStorageRomm); 
            exits.Add("South", FirstFloorHallwayOne)        }
    }
}