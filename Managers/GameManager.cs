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

            Console.WriteLine("Knight’s Quest: The Princess Rescue");
            Console.WriteLine();


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
            RoomManager.Instance.createdRooms.Clear();

            Console.Clear();
            Room currentRoom;

            List<string> travelWords = new List<string> { "GO", "WALK", "MOVE", "HEAD"};
            List<string> actionWords = new List<string> { "LOOK", "INSPECT", "GRAB", "GET", "TAKE", "USE"};
            List<string> inventoryActionWords = new List<string> { "OPEN", "VIEW" };
            List<string> inventoryNames = new List<string> { "BAG", "INVENTORY", "BACKPACK" };

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
                Console.WriteLine("1. Ranger");
                Console.WriteLine("   HP: 3");
                Console.WriteLine("   Melee: 2");
                Console.WriteLine("   Ranged: 5");
                Console.WriteLine("   Block: 3");
                Console.WriteLine();
                Console.WriteLine("2. Knight");
                Console.WriteLine("   HP: 4");
                Console.WriteLine("   Melee: 5");
                Console.WriteLine("   Ranged: 3");
                Console.WriteLine("   Block: 1");
                Console.WriteLine();
                Console.WriteLine("3. Palidin");
                Console.WriteLine("   HP: 5");
                Console.WriteLine("   Melee: 3");
                Console.WriteLine("   Ranged: 0");
                Console.WriteLine("   Block: 5");


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

            string playerTitle;
            switch (playerChoice)
            {
                case 1:
                    playerTitle = "Ranger";
                    break;
                case 2:
                    playerTitle = "Knight";
                    break;
                case 3:
                    playerTitle = "Paladin";
                    break;
                default:
                    playerTitle = "Warrior";
                    break;
            }

            Console.Clear();
            Console.WriteLine($"\"Welcome Noble {playerTitle}, you have been tasked by his royal highness to \nsave his beloved daughter from the evil sorcerer Trogdar."); 
            Console.WriteLine("He shall be found in his castle upon the highest peak south of the kingdom.");
            Console.WriteLine("\nGood luck and if you succeed you'll be rewarded handsomely.\"");
            Console.WriteLine("\nAs you finish reading the letter, you look up and see that apon the jagged peaks of");
            Console.WriteLine("the mountain, cloaked in perpetual mist and shrouded by ancient pines, stands a Obsidian Spire.");
            Console.WriteLine("Its twisted spires pierce the heavens like skeletal fingers, reaching for forbidden knowledge \nhidden among the stars.");
            Console.WriteLine("The castle is a nightmare in stone, its walls hewn from black obsidian, casting the fortress \ninto perpetual twilight.");
            Console.WriteLine("Gargoyles leer from every corner, their eyes glowing with malevolence. \nTheir wings are tattered, as if they’ve witnessed centuries of suffering.");
            Console.WriteLine("\nThe entrance is a massive iron gate, adorned with twisted runes that writhe \nlike serpents when touched.");
            Console.WriteLine("\nYou ready yourself as you enter.\n");

           PressAnyKey();
            #region main game loop
            while (true)
            {

                //Clear previous screen
                Console.Clear();


                //Show player stats
                Console.WriteLine($"Health: {ShowCharacterHealth(player)}");
                Console.WriteLine();

                //get description of the room
                Console.WriteLine(currentRoom.ToString());

                //if there is a living enemy in the room, go to combat
                if (currentRoom.TryGetEnemy(out Character enemyChar, out bool alive))
                {
                    if (alive)
                    {
                        //if thhe player dies during combat, quit the game
                        if (!EnterCombat(player, enemyChar))
                        {
                            return;
                        }
                        else {
                            //start the description of the room over.
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You see the enemy you defeated earlier");
                    }
                }

                //display items
                if (currentRoom.GetItems() != "") Console.WriteLine($"In the room, you see {currentRoom.GetItems()}");

                //display exits
                Console.WriteLine($"Valid exits are {currentRoom.GetExits()}");

                #region input validation
                invalidInput = false;
                do
                {
                    //read input from player
                    //expectetd input should be "action direction/item"
                    playerInput = Console.ReadLine().Trim().ToUpper();
                    playerInputArray = playerInput.Split(' ');

                    //if the player tried to type out more than 2 words
                    //display invalid input and prompt for input again
                    if (playerInputArray.Length != 2)
                    {
                        Console.WriteLine("Invalid Input format. Please type an action in the form of <action> <direction/item>");
                        //skips the rest of the loop and starts it over.
                        continue;
                    }

                    //Travel
                    if (travelWords.Contains(playerInputArray[0]))
                    {
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
                        if (currentRoom.TryGetItem(playerInputArray[1], out Item roomItem))
                        {


                            switch (playerInputArray[0])
                            {
                                case "LOOK":
                                case "INSPECT":
                                    Console.WriteLine(roomItem.description);
                                    PressAnyKey();
                                    break;
                                case "GRAB":
                                case "GET":
                                case "TAKE":
                                    Console.WriteLine($"You grab {roomItem} and add it to your inventory");
                                    currentRoom.RemoveItem(roomItem);
                                    player.AddItem(roomItem);
                                    Console.WriteLine("");
                                    PressAnyKey();
                                    break;
                                default:
                                    Console.WriteLine("Something went wrong");
                                    break;
                            }
                        }
                        else
                        {
                            if(player.TryGetItem(playerInputArray[1].ToUpper(), out Item playerItem)){
                                if (playerInputArray[0].ToUpper() == "USE")
                                {
   
                                    playerItem.Use(player);
                                    PressAnyKey();
                                }
                            }
                        }
                    }else if(inventoryActionWords.Contains(playerInputArray[0]) && inventoryNames.Contains(playerInputArray[1]))
                    {
                        Console.Clear();

                        player.ViewInventory();
                        PressAnyKey();
                    }
                    //invalid word
                    else
                    {
                        Console.WriteLine("Invalid Input. Please type an action in the form of <movement> <direction> or <action> <item>");
                        Console.WriteLine($"Valid movements are <{string.Join(", ",travelWords)}> and valid actions are <{string.Join(", ", actionWords)}>");
                        continue;
                    }

                    invalidInput = true;



                } while (!invalidInput);

                #endregion
                #endregion
            }
        }


        static void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("To navigate this game, the console will output a description of where the player is, what things there are to inspect, and valid exits.");
            Console.WriteLine("The player can enter their commands in the form of <movement> <direction> or <action> <item> and the game will describe what happens");
            Console.WriteLine("\nIn this game, combat is determined by a combination of RNG and a format similar to Rock/Papper/Scissors.");
            Console.WriteLine("During combat, both the player and the enemy choose an attack type.");
            Console.WriteLine("  -Melee attacks beat ranged attacks.");
            Console.WriteLine("  -Ranged attacks beat blocking.");
            Console.WriteLine("  -Blocking beats melee attacks.");
            Console.WriteLine("Then the player and enemy roll a number 1-10.");
            Console.WriteLine("If you win the Rock/Paper/Scissors portion, you can add your bonus to the RNG roll.");
            Console.WriteLine("The one that has the lowest number takes 1 damage (unless an item is equipped).");
            Console.WriteLine();
            PressAnyKey();
            Console.Clear();
        }

        static string ShowCharacterHealth(Character character)
        {
            string hpStr = "";
            hpStr +=("[ ");
            for (int hp = 0; hp < character.maxHP; hp++)
            {
                if (hp < character.hp)
                {
                    hpStr +=(fullBlock + " ");
                }
                else
                {
                    hpStr +=(emptyBlock + " ");
                }
            }
            hpStr +=("]");

            return hpStr;
        }

        /// <summary>
        /// simple way to prompt user to press a key to continue
        /// </summary>
        static void PressAnyKey()
        {
            Console.WriteLine("Press any key to conitnue");
            Console.ReadKey();
        }

        /// <summary>
        /// <para>enters combat for the player and an enemy.</para>
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <returns>true if the player is still alive, false if they are not.</returns>
        static bool EnterCombat(Player player, Character enemy)
        {
            Random rand = new Random();
            int playerRoll;
            int enemyRoll;
            int enemyAttack;
            string playerAttack;
            Console.WriteLine();
<<<<<<< HEAD
            Console.WriteLine("You encountered an enemy!");
=======
            if (enemy.GetType().Name == "BaseEnemy")
            {
                Console.WriteLine("You encouontered an enemy!");
            }
            else {
                Console.WriteLine("You have encountered Trogdor, the evil wizard");
            }
>>>>>>> 9e0cfdd1203670dd8c2d2d4db10113044121c488
            Console.WriteLine("Entering Combat...");
            PressAnyKey();

            bool skipRound;

            while (player.hp > 0 && enemy.hp > 0)
            {
                do {
                    skipRound = false;
                    Console.Clear();
                    Console.Write($"{"Player: " + ShowCharacterHealth(player),-30}{"Enemy: " + ShowCharacterHealth(enemy),0}");
                    Console.WriteLine();
                    Console.WriteLine("Choose an attack!");
                    Console.WriteLine($"{"Attack type",-15}{"Bonus for matchup win",0}");
                    Console.WriteLine($"{"  1. melee",-15}{"+" + player.melee,10}");
                    Console.WriteLine($"{"  2. ranged",-15}{"+" + player.ranged,10}");
                    Console.WriteLine($"{"  3. block and counter",-15}{"+" + player.block,10}");
                    Console.WriteLine($"{"  4. use item", -15}");
                    Console.WriteLine($"{"  5. View Inventory",15}");
                    playerAttack = Console.ReadLine();

                    enemyAttack = rand.Next(1, 3);

                    playerRoll = rand.Next(1, 10);
                    enemyRoll = rand.Next(1, 10);

                    switch (playerAttack){
                        case "1":
                            if (enemyAttack == 2) playerRoll += player.melee;
                            else if (enemyAttack == 3) enemyRoll += enemy.block;
                            break;
                        case "2":
                            if (enemyAttack == 3) playerRoll += player.ranged;
                            else if (enemyAttack == 1) enemyRoll += enemy.melee;
                            break;
                        case "3":
                            if (enemyAttack == 1) playerRoll += player.block;
                            else if (enemyAttack == 2) enemyRoll += enemy.ranged;
                            break;
                        case "4":
                            UseItemInCombat(player);
                            PressAnyKey();
                            skipRound = true;
                            continue;
                        case "5":
                            Console.Clear();
                            player.ViewInventory();
                            PressAnyKey();
                            skipRound = true;
                            continue;
                        default:
                            Console.WriteLine("Invalid option. Please enter the number of your choice.");
                            PressAnyKey();
                            skipRound = true;
                            break;

                    }
                }while (skipRound) ;
                
                if(playerRoll > enemyRoll)
                {
                    Console.WriteLine($"You hit the enemy for {player.GetDamage(playerAttack)} damage!");
                    enemy.TakeDamage(player.GetDamage(playerAttack));
                }else if (playerRoll < enemyRoll)
                {
                    Console.WriteLine("You were hit by the enemy!");
                    player.TakeDamage(1);
                }
                else
                {
                    Console.WriteLine("You hit each other at the same time.");
                    player.TakeDamage(1);
                    enemy.TakeDamage(player.GetDamage(playerAttack));
                }
                PressAnyKey();                
            }

            if(player.hp <= 0 && enemy.hp <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("You took each other out. The princess has no one to guide her out.");
                Console.WriteLine("Game Over");
                PressAnyKey();
                Console.Clear();
                return false;
            }
            else if(enemy.hp <=0)
            {
                Console.WriteLine();
                if (enemy.GetType().Name == "BaseEnemy")
                {
                    Console.WriteLine("You defeated the enemy in this room, congratulations!");
                }
                else if(enemy.GetType().Name == "Boss")
                {
                    Console.WriteLine("Congratulations! You have defeated Trogdor and saved the princess." +
                                      "You return victoriously and collect your reward from the king. " +
                                      "\nThank you for playing!");
                    return false;
                }
                PressAnyKey();
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You were defeated by the enemy...");
                Console.WriteLine("Game Over");
                PressAnyKey();
                Console.Clear();
                return false;
            }
        }

        static void UseItemInCombat(Player player)
        {

            Console.WriteLine("What item do you want to use?");
            player.ViewInventory();
            string playerItem = Console.ReadLine();
            
            if (playerItem.ToUpper() == "SWORD" ||
                playerItem.ToUpper() == "SHIELD" ||
                playerItem.ToUpper() == "BOW")
            {
                Console.WriteLine($"You cannot equip items during the battle.");
                PressAnyKey();
            }
            else
            {
                if (player.TryGetItem(playerItem, out Item itemToUse))
                {
                    Console.WriteLine($"Using {itemToUse.itemName}");

                    itemToUse.Use(player);
                }

            }
        }
    }
}