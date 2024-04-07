using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class FirstFloorHallwayTwo : Room {



        //store each room that this room connects to
        FirstFloorHallwayOne ffh1;
        SecondFloorHallway sfh;


        public FirstFloorHallwayTwo()
            : base("FirstFloorHallwayTwo")
        {

            if (RoomManager.Instance.GetRoom("FirstFloorHallwayTwo") != null)
            {
                return;
            }
            RoomManager.Instance.createdRooms.Add(this);

            description = "The hallway on the first floor is dimly lit, " +
                "with flickering torches casting long, dancing shadows.\n" +
                "The stone walls are damp and the air is heavy with the scent of mildew.\n" +
                "Behind you is the crumbling hole where the floor of the hallway once was.";

            checkRoom = RoomManager.Instance.GetRoom("FirstFloorHallwayOne");
            ffh1 =  checkRoom != null ? (FirstFloorHallwayOne)checkRoom : new FirstFloorHallwayOne();

            checkRoom = RoomManager.Instance.GetRoom("SecondFloorHallway");
            sfh = checkRoom != null ? (SecondFloorHallway)checkRoom : new SecondFloorHallway();


            //both the first and second sections have valid east and west exits
            //exits.Add("EAST", "Library");
            //exits.Add("WEST", "Armory");
            exits.Add("BACKWARDS", ffh1);
            exits.Add("UPSTAIRS", sfh);
        }

    }
}