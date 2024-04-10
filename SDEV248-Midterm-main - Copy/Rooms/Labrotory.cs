using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV248Midterm
{
    class Labrotory : Room
    {
        //store each room that this room connects to
        SecondFloorHallway Sfh;


        public Labrotory()
            : base("Labrotory")
        {
            if (RoomManager.Instance.GetRoom("Labrotory") != null)
            {
                return;
            }

            RoomManager.Instance.createdRooms.Add(this);

            checkRoom = RoomManager.Instance.GetRoom("SecondFloorHallway");
            Sfh1 = checkRoom != null ? (SecondFloorHallway)checkRoom : new SecondFloorHallway();

            items.Add(new Potion());

            enemy = new BaseEnemy();

            description = "The air grows colder as you step deeper, and the flickering torches cast elongated, dancing shadows on the stone walls. " +
                          "The room hums with malevolence, its very essence tainted by dark magic. Cobwebs cling to the ceiling, and dust drifts lazily through the air. \n" +
                          "The scent of ancient tomes and burnt herbs lingers, hinting at forgotten rituals..\n" +
                          "In the center of the room lies a slab of weathered stone, stained with the residue of countless experiments. Shackles dangle from its sides.
                          " in the backgroung a monstrous contraption crackles with electricity, its jagged arcs illuminating the room intermittently..\n" +
                           "Rows of test tubes, beakers, and flasks contain bubbling concoctions \n" +
                           "Suspended from iron hooks, these vessels hold preserved organs, twisted creatures, and severed limbs.\n" +
                          "Piles of discarded abominations—failed homunculi, mutated vermin, and half-formed monstrosities—lurk in the corners. \n" +
                          " A massive, iron cauldron hangs over a perpetual flame";

            //add exit directions and room names available
            exits.Add("NORTH", Rooftop);
            exits.Add("EAST", LabrotoryStorageRomm); 
            exits.Add("South", FirstFloorHallwayOne)        }
        }
    }
}