using System;
using System.Collections;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class LaboratoryStorageRoom : Room
    {

        //store each room that this room connects to
        SecondFloorHallway Sfh;


        public LaboratoryStorageRoom()
        : base("LaboratoryStorageRoom")
        {
            if (RoomManager.Instance.GetRoom("LaboratoryStorageRoom") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);
            checkRoom = RoomManager.Instance.GetRoom("SecondFloorHallway");
            Sfh = checkRoom != null ? (SecondFloorHallway)checkRoom : new SecondFloorHallway();

            description = "The air is thick with the scent of dried herbs and ancient incantations.\n" +
             "As you step across the threshold, the wooden door creaks, echoing through the dimly lit chamber.\n" +
            "A rat scurys out the room \n" +
            "The flickering candle flames cast elongated shadows on the stone walls, revealing faded alchemical symbols etched into the rough surface." +
            "\nWooden shelves line the walls, sagging under the weight of glass jars and clay pots.\n" +
            "Each container holds a secret ingredient\n" +
            "Cobwebs cling to the jars, their contents long abandoned ";

            items.Add(new Potion());

            //add exit directions and room names available
            exits.Add("WEST", Sfh);
        }
    }
}
