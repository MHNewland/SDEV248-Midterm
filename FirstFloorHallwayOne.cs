using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class FirstFloorHallwayOne : Room {


        const string roomName = "FirstFloorHallway";

        //since the hallway has 2 parts, treat them like separate rooms
        bool firstSection = true;
        FirstFloorHallwayTwo ffh2;


        public FirstFloorHallwayOne()
            : base(roomName)
        {
            description = "The hallway on the first floor is dimly lit, " +
                "with flickering torches casting long, dancing shadows.\n" +
                "The stone walls are damp and the air is heavy with the scent of mildew.\n" +
                "The carpet, threadbare and faded, runs along the center of the hallway.";

            //add exit directions and room names available
            exits.Add("EAST", "DiningRoom");
            exits.Add("WEST", "Kitchen");
            exits.Add("FORWARD", "FirstFloorHallwayTwo");
            exits.Add("EXIT", "");
        }
    }
}