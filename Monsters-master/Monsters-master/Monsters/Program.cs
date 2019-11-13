using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++\\
    //                                                   \\
    // Title: Monsters                                   \\
    // Description: Demonstration of classes and objects \\
    // Author: Velis, John & Post, Jacob                 \\
    // Dated Created: 11/11/2019                         \\
    // Last Modified:                                    \\
    //                                                   \\
    //+++++++++++++++++++++++++++++++++++++++++++++++++++\\  
    class Program
    {
        static void Main(string[] args)
        {
            //+++++++++++++++++++++++++\\
            // Initialize Monster List \\
            //+++++++++++++++++++++++++\\

            List<Monster> monsters = InitializeMonsterList();

            //+++++++++++\\
            // Call Menu \\
            //+++++++++++\\

            DisplayMenuScreen(monsters);
        }

        static void DisplayMenuScreen(List<Monster> monsters)
        {
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //++++++++++++++++++++++\\
                // Get User Menu Choice \\
                //++++++++++++++++++++++\\
                Console.WriteLine("a) List All Monsters");
                Console.WriteLine("b) View a Monster");
                Console.WriteLine("c) Add Monster");
                Console.WriteLine("d) Delete a Monster");
                Console.WriteLine("e) Update a Monster");
                Console.WriteLine("f) ");
                Console.WriteLine("q) Quit");
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayAllMonsters(monsters);
                        break;

                    case "b":
                        DisplayViewMonster(monsters);
                        break;

                    case "c":
                        DisplayAddMonster(monsters);
                        break;

                    case "d":
                        DisplayDeleteMonster(monsters);
                        break;

                    case "e":
                        DisplayUpdateMonster(monsters);
                        break;

                    case "f":

                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }


            } while (!quitApplication);
        }

        static void DisplayDeleteMonster(List<Monster> monsters) 
        {
            string monsterName;            
            Monster selectedMonster = null;
            bool validResponse = false;

            do
            {
                DisplayScreenHeader("Delete Monster");

                //++++++++++++++++++++\\
                // List Monster Names \\
                //++++++++++++++++++++\\

                Console.WriteLine("\tList of Monsters");
                foreach (Monster monster in monsters)
                {
                    Console.WriteLine(monster.Name);
                }
                Console.WriteLine();

                //+++++++++++++++++++++++++++++++\\
                // User Select A monster to View \\
                //+++++++++++++++++++++++++++++++\\

                Console.Write("Enter a Monster's Name:");
                monsterName = Console.ReadLine().Trim();

                //++++++++++++++++++++\\
                // Get Monster Object \\
                //++++++++++++++++++++\\

                foreach (Monster monster in monsters)
                {
                    if (monster.Name == monsterName)
                    {
                        selectedMonster = monster;
                        validResponse = true;
                        break;
                    }
                }


                //+++++++++++++++++++++++++\\
                // Feedback For Wrong Name \\
                //+++++++++++++++++++++++++\\

                if (!validResponse)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Monster Name.");
                    DisplayContinuePrompt();
                }

            } while (!validResponse);

            //++++++++++++++++\\
            // Delete Monster \\
            //++++++++++++++++\\

            if (selectedMonster != null)
            {
                monsters.Remove(selectedMonster);
                Console.WriteLine();
                Console.WriteLine($"\t {selectedMonster.Name} has been deleted.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{monsterName} was not found.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayUpdateMonster(List<Monster> monsters)
        {
            string monsterName;
            string monsterChange;
            Monster selectedMonster = null;
            bool validResponse = false;

            do
            {
                DisplayScreenHeader("Delete Monster");

                //++++++++++++++++++++\\
                // List Monster Names \\
                //++++++++++++++++++++\\

                Console.WriteLine("\tList of Monsters");
                foreach (Monster monster in monsters)
                {
                    Console.WriteLine(monster.Name);
                }
                Console.WriteLine();

                //+++++++++++++++++++++++++++++++\\
                // User Select A monster to View \\
                //+++++++++++++++++++++++++++++++\\

                Console.Write("Enter a Monster's Name:");
                monsterName = Console.ReadLine().Trim();

                //++++++++++++++++++++\\
                // Get Monster Object \\
                //++++++++++++++++++++\\

                foreach (Monster monster in monsters)
                {
                    if (monster.Name == monsterName)
                    {
                        selectedMonster = monster;
                        validResponse = true;
                        break;
                    }
                }


                //+++++++++++++++++++++++++\\
                // Feedback For Wrong Name \\
                //+++++++++++++++++++++++++\\

                if (!validResponse)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Monster Name.");
                    DisplayContinuePrompt();
                }

            } while (!validResponse);

            //++++++++++++++++\\
            // Update Monster \\
            //++++++++++++++++\\

            if (selectedMonster != null)
            {
                Console.WriteLine("\tWhat would you like to change about the monster [name, age, attitude]");
                monsterChange = Console.ReadLine().ToLower().Trim();
                switch (monsterChange)
                {
                    case "name":
                        Console.WriteLine();
                        Console.WriteLine("\tWhat would you like the new name to be?");
                        selectedMonster.Name = Console.ReadLine();
                        break;

                    case "age":
                        Console.WriteLine();
                        Console.WriteLine("\tWhat would you like the new age to be?");
                        int.TryParse(Console.ReadLine(), out int monsterAge);
                        selectedMonster.Age = monsterAge;
                        break;

                    case "attitude":
                        Console.WriteLine("\tEnter the Monsters Attitude:");
                        Enum.TryParse(Console.ReadLine(), out Monster.EmotionalState attitude);
                        selectedMonster.Attitude = attitude;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{monsterName} was not found.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayViewMonster(List<Monster> monsters)
        {
            string monsterName;
            Monster monsterToView = null;

            DisplayScreenHeader("Find a Monster");

            //++++++++++++++++++++\\
            // List Monster Names \\
            //++++++++++++++++++++\\

            Console.WriteLine("\tList of Monsters");
            foreach (Monster monster in monsters)
            {
                Console.WriteLine(monster.Name);
            }
            Console.WriteLine();
            //+++++++++++++++++++++++++++++++\\
            // User Select A monster to View \\
            //+++++++++++++++++++++++++++++++\\

            Console.Write("Enter a Monster's Name:");
            monsterName = Console.ReadLine().Trim();

            //+++++++++++++\\
            // Get Monster \\
            //+++++++++++++\\

            foreach (Monster monster in monsters)
            {
                if (monster.Name == monsterName)
                {
                    monsterToView = monster;
                    break;
                }
            }
            //monsterToView = monsters.FirstOrDefault(m => m.Name == monsterName);

            //++++++++++++++++++++++++\\
            // Display Monster Detail \\
            //++++++++++++++++++++++++\\
            MonsterInfo(monsterToView);

            DisplayContinuePrompt();
        }

        static List<Monster> InitializeMonsterList()
        {
            List<Monster> monsters = new List<Monster>();

            //+++++++++++++++++++++++++++++++++++\\
            // Create (Instantiate) New Monsters \\
            //+++++++++++++++++++++++++++++++++++\\
            Monster Phil = new Monster();
            Monster Joe = new Monster();

            //+++++++++++++++++++++++++++\\
            // Update Monster Properties \\
            //+++++++++++++++++++++++++++\\

            Phil.Name = "Phil";
            Phil.Age = 274;
            Phil.Attitude = Monster.EmotionalState.bored;

            Joe.Name = "Joe";
            Joe.Age = 700;
            Joe.Attitude = Monster.EmotionalState.angry;

            //++++++++++++++\\
            // Call Methods \\
            //++++++++++++++\\

            //++++++++++++++++++++++++++\\
            // Add Monsters To the List \\
            //++++++++++++++++++++++++++\\

            monsters.Add(Phil);
            monsters.Add(Joe);

            DisplayMenuScreen(monsters);

            return monsters;
        }

        static void MonsterInfo(Monster monster)
        {
            Console.WriteLine("\t************************************************");
            Console.WriteLine($"\tName:{monster.Name}\tAge:{monster.Age}\tAttitude:{monster.Attitude}");
            Console.WriteLine("\t************************************************");
            Console.WriteLine();
        }

        static void DisplayAddMonster(List<Monster> monsters)
        {
            Monster newMonster = new Monster();
            
            DisplayScreenHeader("Add A New Monster");


            //+++++++++++++++++++++++++++++\\
            // Get Monster Props from User \\
            //+++++++++++++++++++++++++++++\\
            Console.WriteLine("\tEnter the Monsters Name:");
            newMonster.Name = Console.ReadLine();

            Console.WriteLine("\tEnter Monsters Age:");
            int.TryParse(Console.ReadLine(), out int age);
            newMonster.Age = age;

            Console.WriteLine("\tEnter the Monsters Attitude:");
            Enum.TryParse(Console.ReadLine(), out Monster.EmotionalState attitude);
            newMonster.Attitude = attitude;

            //++++++++++++++++++++\\
            // Echo Monster Props \\
            //++++++++++++++++++++\\
            Console.WriteLine("\tMonster Properties");

            MonsterInfo(newMonster);

            DisplayContinuePrompt();

            monsters.Add(newMonster);
        }

        static void DisplayAllMonsters(List<Monster> monsters)
        {
            DisplayScreenHeader("All Monsters");

            foreach (Monster monster in monsters)
            {
                MonsterInfo(monster);
            }

            DisplayContinuePrompt();
        }

        #region HELPER METHODS

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Calculator");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Calculator!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
