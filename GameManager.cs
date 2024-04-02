using System;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class GameManager
    {


        public static void Main(string[] args)
        {
            List<string> travelWords = new List<string> { "GO", "WALK", "MOVE" };
            List<string> actionWords = new List<string> { "GRAB", "LOOK", "USE" };

            //Instantiate first room
            FirstFloorHallwayOne firstFloorHallwayOne = new FirstFloorHallwayOne();

            Room currentRoom;
            currentRoom = firstFloorHallwayOne;
            bool validInput;
            string playerInput;
            string[] playerInputArray;

#region Gameplay loop
            while (true) {
                //get description of the room
                Console.WriteLine(currentRoom.ToString());
                //display items

                //display exits
                Console.WriteLine($"Valid exits are {currentRoom.GetExits()}");

#region input validation
                validInput = false;
                do{
                    //read input from player
                    //expectetd input should be "action direction/item"
                    playerInput = Console.ReadLine().ToUpper();
                    playerInputArray = playerInput.Split(' ');

                    //if the player tried to type out more than 2 words
                    //display invalid input and prompt for input again
                    if(playerInputArray.Length > 2) {
                        Console.WriteLine("Invalid Input format. Please type an action in the form of <action> <direction/item>");
                        //skips the rest of the loop and starts it over.
                        continue;
                    }

                    //Travel
                    if(travelWords.Contains(playerInputArray[0])){
                        Console.WriteLine("traveling");
                        if (currentRoom.GetExits().Contains(playerInputArray[1]))
                        {
                            currentRoom = currentRoom.GetRoom(playerInputArray[1]);
                        }
                        else
                        {
                            //invalid direction
                            Console.WriteLine("Invalid Direction");
                            continue;
                        }
                    //action
                    }else if(actionWords.Contains(playerInputArray[0])){

                        Console.WriteLine("doing action");
                    }
                    //invalid word
                    else
                    {
                        Console.WriteLine("invalid input");
                        continue;
                    }

                    validInput = true;



                }while(!validInput);

#endregion
                //if direction, get new room and continue
                //if action, describe result of action
            }
#endregion
        }
    }
}