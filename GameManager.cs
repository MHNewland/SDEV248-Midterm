using System;
using System.Collections.Generic;

namespace SDEV248Midterm
{
    public class GameManager
    {
        const string fullBlock = "\u2588";
        const string emptyBlock = "\u2591";

        public static void Main(string[] args)
        {
            bool exit = false;
            string option;

            Console.WriteLine("Write out introduction paragraph");


            do
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Play game.");
                Console.WriteLine("2. How to play.");
                Console.WriteLine("3. Exit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        HowToPlay();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter the number of your option.");
                        break;
                }

            } while (!exit);

        }

        static void StartGame()
        {
            Console.Clear();
            Room currentRoom;

            List<string> travelWords = new List<string> { "GO", "WALK", "MOVE" };
            List<string> actionWords = new List<string> { "GRAB", "LOOK", "USE" };

            //Instantiate first room
            currentRoom = new FirstFloorHallwayOne();

            Player player;
            string playerInput;
            bool invalidInput;
            string[] playerInputArray;

            int playerChoice;
            do
            {
                invalidInput = false;
                Console.WriteLine("Choose your character");
                Console.WriteLine("1. Ranged");
                Console.WriteLine("  HP: 3");
                Console.WriteLine("  Melee: 2");
                Console.WriteLine("  Shield: 3");
                Console.WriteLine("  Bow: 5");

                Console.WriteLine("2. Attack");
                Console.WriteLine("  HP: 4");
                Console.WriteLine("  Melee: 5");
                Console.WriteLine("  Shield: 1");
                Console.WriteLine("  Bow: 3");

                Console.WriteLine("3. Defense");
                Console.WriteLine("  HP: 5");
                Console.WriteLine("  Melee: 3");
                Console.WriteLine("  Shield: 5");
                Console.WriteLine("  Bow: 0");

                if (!int.TryParse(Console.ReadLine(), out playerChoice))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please enter the number of your option.");
                    invalidInput = true;
                }
                else
                {
                    if (playerChoice < 0 || playerChoice > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid option. Please try again.");
                        invalidInput = true;
                    }
                }


            } while (invalidInput);


            player = new Player(playerChoice);

            //Test player health bar
            //player.TakeDamage(2);

            Console.WriteLine("Put instroduction paragraph here");

            while (true)
            {

                //Clear previous screen
                Console.Clear();

                //Show player stats
                Console.Write("Health: [ ");
                for (int hp = 0; hp < player.GetMaxHP(); hp++)
                {
                    if (hp < player.GetHP())
                    {
                        Console.Write(fullBlock + " ");
                    }
                    else
                    {
                        Console.Write(emptyBlock + " ");
                    }
                }
                Console.Write("]");
                Console.WriteLine();

                //get description of the room
                Console.WriteLine(currentRoom.ToString());
                //display items

                //display exits
                Console.WriteLine($"Valid exits are {currentRoom.GetExits()}");

                #region input validation
                invalidInput = false;
                do
                {
                    //read input from player
                    //expectetd input should be "action direction/item"
                    playerInput = Console.ReadLine().ToUpper();
                    playerInputArray = playerInput.Split(' ');

                    //if the player tried to type out more than 2 words
                    //display invalid input and prompt for input again
                    if (playerInputArray.Length > 2)
                    {
                        Console.WriteLine("Invalid Input format. Please type an action in the form of <action> <direction/item>");
                        //skips the rest of the loop and starts it over.
                        continue;
                    }

                    //Travel
                    if (travelWords.Contains(playerInputArray[0]))
                    {
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
                    }
                    else if (actionWords.Contains(playerInputArray[0]))
                    {

                        Console.WriteLine("doing action");
                    }
                    //invalid word
                    else
                    {
                        Console.WriteLine("invalid input");
                        continue;
                    }

                    invalidInput = true;



                } while (!invalidInput);

                #endregion
                //if direction, get new room and continue
                //if action, describe result of action
            }
        }


        static void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("In this game, combat is determined by a combination of RNG and a format similar to Rock/Papper/Scissors.");
            Console.WriteLine("During combat, both the player and the enemy choose an attack type.");
            Console.WriteLine("  -Ranged attacks beat blocking.");
            Console.WriteLine("  -Blocking beats melee attacks.");
            Console.WriteLine("  -Melee attacks beat ranged attacks.");
            Console.WriteLine("Then the player and enemy roll a number 1-10.");
            Console.WriteLine("If you win the Rock/Paper/Scissors portion, you can add your bonus to the RNG roll.");
            Console.WriteLine("The one that has the lowest number takes 1 damage.");
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}