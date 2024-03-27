using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class FirstFloorHallway : Room {

        const string roomName = "FirstFloorHallway";
        public FirstFloorHallway()
            : base(roomName)
        {
            description = "The hallway on the first floor is dimly lit, " +
                "with flickering torches casting long, dancing shadows.\n" +
                "The stone walls are damp and the air is heavy with the scent of mildew.\n" +
                "The carpet, threadbare and faded, runs along the center of the hallway.";
            exits.Add("EAST");
            exits.Add("WEST");
            exits.Add("FORWARD");
        }

        public string GetExits()
        {
            string exitStr = "";
            foreach (string exit in exits)
            {
                exitStr += exit + ", ";
            }
            //get rid of the last comma and space
            exitStr = exitStr.Substring(0, exitStr.Length - 2);
            return exitStr;
        }

    }
}