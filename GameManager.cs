using System;

namespace SDEV248Midterm
{
    public class GameManager
    {
        public static void Main(string[] args)
        {
            FirstFloorHallway firstFloorHallway = new FirstFloorHallway();

            Console.WriteLine(firstFloorHallway);
            Console.WriteLine(firstFloorHallway.GetExits());
            while (true) { }
        }
    }
}