using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Rooftop : Room
    {
        //store each room that this room connects to
        SecondFloorHallway sfh;


        public Rooftop()
            : base("Rooftop")
        {
            if (RoomManager.Instance.GetRoom("Rooftop") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            enemy = new Boss();

            description = "The rooftop exudes an unsettling aura.\n" +
             "stretching out like a desolate wasteland.\n" +
             "Cracked tiles, their glaze faded, form a jagged mosaic underfoot.\n" +
              "Once vibrant banners now hang in tatters, their colors bleached by time and neglect. \n" +
              "Skulls—perhaps adorn the corners, their hollow sockets staring into eternity. \n" +
              "Damaged remains of armour lie scatter apon the floor, and the air smells of damp earth and decay.\n" +
              "the silence is oppressive. \n" +
              "A lone, twisted gargoyle perches at the edge, its stony gaze fixed on the abyss beyond.\n" +
              "The wind keens mournfully through the gaps in the parapets, and the moon casts elongated shadows across the empty expanse.";

            //add exit directions and room names available
            exits.Add("BACK", sfh);
        }
    }
}