using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class FirstFloorHallwayTwo : Room {


        const string roomName = "FirstFloorHallway";

        //since the hallway has 2 parts, if user is in the first section
        //value will be true, if they're in the second section, it'll be fasle
        bool firstSection = true;

        
        public FirstFloorHallwayTwo()
            : base(roomName)
        {
            description = "The hallway on the first floor is dimly lit, " +
                "with flickering torches casting long, dancing shadows.\n" +
                "The stone walls are damp and the air is heavy with the scent of mildew.\n" +
                "Behind you is the crumbling hole where the floor of the hallway once was.";
            
            //both the first and second sections have valid east and west exits
            exits.Add("EAST", "Library");
            exits.Add("WEST", "Armory");
            exits.Add("BACKWARDS", "FirstFloorHallwayOne");
        }

    }
}