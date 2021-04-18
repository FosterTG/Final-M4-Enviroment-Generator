using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment_Generator
{

    // **************************************************
    //
    // Title: Environment Generator
    // Description: This Application allowis its user to get 
    // a description of a enviroment based on teh users input.
    // Application Type: Console
    // Authors: Gilmore, Foster
    // Dated Created: 4/13/2021 
    // Last Modified: 4//18/2021
    //
    // **************************************************

    class Program
    {

        static void Main(string[] args)
        {
            SetTheme();


            IntroductionMenuScreen();
            EnviromentMenu();
            ClosingScreen();


        }

        #region Introduction Screen
        /// <summary>
        /// *****************************************************************
        /// *                     Introduction Screen                       *
        /// *****************************************************************
        /// </summary>
        private static void IntroductionMenuScreen()
        {
            DisplayScreenHeader("Enviroment Generator");

            Console.WriteLine("\tWelcome to the Enviroment Generator!");

            DisplayContinuePrompt();
        }
        #endregion

        #region Enviroment Screen
        /// <summary>
        /// *****************************************************************
        /// *                     Enviroment Menu Screen                    *
        /// *****************************************************************
        /// </summary>
        /// 

        private static void EnviromentMenu()
        {

            var userRegionChoice = new (string Trait, string Range)[6];
            var userSeasonChoice = new (string Trait, int Modifier)[6];

            (int Temprature,
            string Humidity,
            string Wind,
            string Rain,
            string Snow) finalValues = (0, "", "", "", "");


            string menuChoice;
            bool quitApplication = false;
            do
            {
                DisplayScreenHeader("Enviroment Generator Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Guide");
                Console.WriteLine("\tb) New Enviroment");
                Console.WriteLine("\tc) Display Enviroment");

                Console.WriteLine("\td) Exit");


                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        GuideMenu();
                        break;
                    case "b":
                        // Get Region
                        userRegionChoice = GetRegionChoice();
                        // Get Season
                        userSeasonChoice = GetSeasonChoice();
                        // Evaluating Final Values 
                        finalValues = GetFinalValues(userRegionChoice, userSeasonChoice);
                        break;

                    case "c":
                        // Display Enviroment
                        DisplayEnviromentMenu(finalValues, userRegionChoice, userSeasonChoice);

                        break;
                    case "d":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }




        /// <summary>
        /// *****************************************************************
        /// *                     Guide Screen                              *
        /// *****************************************************************
        /// </summary>
        private static void GuideMenu()
        {
            DisplayScreenHeader("Guide Menu");

            Console.WriteLine("\tStep 1");
            Console.WriteLine("Slecet new enviroment in the enviroment menu screen");
            Console.WriteLine("\tStep 2");
            Console.WriteLine("Select a region that best fits your desired enviroment");
            Console.WriteLine("\tStep 3");
            Console.WriteLine("Select a season for your enviroment");
            Console.WriteLine("\tStep 4");
            Console.WriteLine("Select display enviroment in the enviroment menu screen");


            DisplayContinuePrompt();
        }
        #endregion

        #region Region Select

        private static (string Trait, string Range)[] GetRegionChoice()
        {
            var userRegionChoice = new (string Trait, string Range)[6];
            string menuChoice;
            bool quitApplication = false;
            var TundraRegion = new (string Trait, string Range)[6]
            {
                ("Tundra",          "None"),
                ("Temprature",     "low"),
                ("Humidity",       "low"),
                ("wind",          "high"),
                ("Rain",           "low"),
                ("Snow",           "med")
            };
            var ArticRegion = new (string Trait, string Range)[6]
            {
                ("Artic",           "None"),
                ("Temprature", "Very low"),
                ("Humidity",        "low"),
                ("wind",            "med"),
                ("Rain",        "verylow"),
                ("Snow",           "high")
            };
            var ForestRegion = new (string Trait, string Range)[6]
            {
                ("Forest",           "None"),
                ("Temprature",      "med"),
                ("Humidity",        "med"),
                ("wind",            "med"),
                ("Rain",            "med"),
                ("Snow",            "low")
            };
            var DesertRegion = new (string Trait, string Range)[6]
            {
                ("Desert",        "None"),
                ("Temprature",  "veryhigh"),
                ("Humidity", "verylow"),
                ("wind",         "low"),
                ("Rain",     "verylow"),
                ("Snow",     "verylow")
            };
            var TropicalRegion = new (string Trait, string Range)[6]
            {
                ("Tropical",           "None"),
                ("Temprature", "veryhigh"),
                ("Humidity",        "med"),
                ("wind",            "med"),
                ("Rain",           "high"),
                ("Snow",           "no")
            };

            do
            {
                DisplayScreenHeader("Region Select");

                Console.WriteLine();
                Console.WriteLine("\tEach region displayed here has their own climate charactoristics");
                Console.WriteLine("\tThese will drasticly effect your final enviroment.");
                Console.WriteLine();
                //
                // get user menu choice
                //
                Console.WriteLine("\t        -----     a) Tundra");
                Console.WriteLine("\t      --  --- -   b) Forest");
                Console.WriteLine("\t     ---   --  -  c) Desert");
                Console.WriteLine("\t      -- - -- -   d) Tropical");
                Console.WriteLine("\t        - ---     e) Artic");
                Console.WriteLine("\t                  f) Exit Region Menu");
                menuChoice = Console.ReadLine().ToLower();
                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        userRegionChoice = TundraRegion;
                        Console.WriteLine("\tSelected Tundra Region");
                        DisplayContinuePrompt();
                        quitApplication = true;
                        break;

                    case "b":
                        userRegionChoice = ForestRegion;
                        Console.WriteLine("\tSelected Forest Region");
                        DisplayContinuePrompt();
                        quitApplication = true;
                        break;

                    case "c":
                        userRegionChoice = DesertRegion;
                        Console.WriteLine("\tSelected Desert Region");
                        DisplayContinuePrompt();
                        quitApplication = true;
                        break;

                    case "d":
                        userRegionChoice = TropicalRegion;
                        Console.WriteLine("\tSelected Tropical Region");
                        DisplayContinuePrompt();
                        quitApplication = true;
                        break;

                    case "e":
                        userRegionChoice = ArticRegion;
                        Console.WriteLine("\tSelected Artic Region");
                        DisplayContinuePrompt();
                        quitApplication = true;
                        break;

                    case "f":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);

            return userRegionChoice;

        }

        #endregion

        #region Season Select

        private static (string Trait, int Modifier)[] GetSeasonChoice()
        {
            DisplayScreenHeader("Season Menu");

            string menuChoice;
            bool quitApplication = false;
            var userSeasonChoice = new (string Trait, int Modifier)[4];
            var SpringSetting = new (string Trait, int Modifier)[4]
            {
                ("Spring",            0),
                ("Temprature",        5),
                ("Rain",             30),
                ("Snow",             10)
            };
            var SummerSetting = new (string Trait, int Modifier)[4]
            {
                ("Summer",             0 ),
                ("Temprature",        15),
                ("Rain",             20),
                ("Snow",              0)
            };
            var FallSetting = new (string Trait, int Modifier)[4]
            {
                ("Fall",             0),
                ("Temprature",       -10),
                ("Rain",             10),
                ("Snow",             30)
            };
            var WinterSetting = new (string Trait, int Modifier)[4]
            {
                ("Winter",         0),
                ("Temprature",   10),
                ("Rain", 5),
                ("Snow", 50)
            };

            Console.WriteLine();
            Console.WriteLine("\tEach Season displayed here has their own weather modifiers");
            Console.WriteLine("\tThese will slightly effect your final enviroment.");
            Console.WriteLine();
            do
            {

                //
                // get user menu choice
                //
                Console.WriteLine("\t a) Spring");
                Console.WriteLine("\t b) Summer");
                Console.WriteLine("\t c) Fall");
                Console.WriteLine("\t d) Winter");
                Console.WriteLine("\t e) Exit Region Menu");
                menuChoice = Console.ReadLine().ToLower();
                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        userSeasonChoice = SpringSetting;
                        quitApplication = true;
                        break;
                    case "b":
                        userSeasonChoice = SummerSetting;
                        quitApplication = true;
                        break;
                    case "c":
                        userSeasonChoice = FallSetting;
                        quitApplication = true;
                        break;
                    case "d":
                        userSeasonChoice = WinterSetting;
                        quitApplication = true;
                        break;
                    case "e":
                        quitApplication = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);


            Console.WriteLine($"\tSelected Season: {userSeasonChoice[0].Trait}");

            DisplayContinuePrompt();

            return userSeasonChoice;
        }

        #endregion

        #region Evaluations
        private static (
            int Temprature,
            string Humidity,
            string Wind,
            string Rain,
            string Snow) GetFinalValues((string Trait, string Range)[] userRegionChoice, (string Trait, int Modifier)[] userSeasonChoice)
        {
            (int Temprature,
            string Humidity,
            string Wind,
            string Rain,
            string Snow) finalValues = (0, "", "", "", "");

            Random r = new Random();
            int num;
            // Evaluateing Temprature
            switch (userRegionChoice[1].Range)
            {
                case "verylow":
                    num = r.Next(0, 10);
                    finalValues.Temprature = num + userSeasonChoice[1].Modifier;
                    break;
                case "low":
                    num = r.Next(30, 50);
                    finalValues.Temprature = num + userSeasonChoice[1].Modifier;
                    break;
                case "med":
                    num = r.Next(40, 60);
                    finalValues.Temprature = num + userSeasonChoice[1].Modifier;
                    break;
                case "high":
                    num = r.Next(61, 81);
                    finalValues.Temprature = num + userSeasonChoice[1].Modifier;
                    break;
                case "veryhigh":
                    num = r.Next(81, 110);
                    finalValues.Temprature = num + userSeasonChoice[1].Modifier;
                    break;
            }
            // Evaluateing Humidity
            switch (userRegionChoice[2].Range)
            {
                case "verylow":
                    finalValues.Humidity = "dry";
                    break;
                case "low":
                    finalValues.Humidity = "light";
                    break;
                case "med":
                    finalValues.Humidity = "comfortable";
                    break;
                case "high":
                    finalValues.Humidity = "heavy";
                    break;
                case "veryhigh":
                    finalValues.Humidity = "drenching";
                    break;

            }
            // Evaluateing Wind
            switch (userRegionChoice[3].Range)
            {
                case "verylow":
                    finalValues.Wind = "still";
                    break;

                case "low":
                    finalValues.Wind = "low";
                    break;

                case "med":
                    finalValues.Wind = "breezing";
                    break;
                case "high":
                    finalValues.Wind = "high";
                    break;
                case "veryhigh":
                    finalValues.Wind = "roaring";
                    break;

            }
            // Evaluateing Rain
            switch (userRegionChoice[4].Range)
            {
                case "verylow":
                    finalValues.Rain = "no rain";
                    break;
                case "low":
                    finalValues.Rain = "light rain";
                    break;
                case "med":
                    finalValues.Rain = "rain patches";
                    break;
                case "high":
                    finalValues.Rain = "heavy rain";
                    break;
                case "veryhigh":
                    finalValues.Rain = "pouring";
                    break;

            }
            // Evaluateing Snow
            switch (userRegionChoice[5].Range)
            {
                case "verylow":
                    finalValues.Snow = "no snow";
                    break;
                case "low":
                    finalValues.Snow = "flaking snow";
                    break;
                case "med":
                    finalValues.Snow = "mediocar snow";
                    break;
                case "high":
                    finalValues.Snow = "heavy snow";
                    break;
                case "veryhigh":
                    finalValues.Snow = "blizzard snow";
                    break;

            }


            return finalValues;
        }



        #endregion

        #region Display Enviroment

        private static void DisplayEnviromentMenu((int Temprature, string Humidity, string Wind, string Rain, string Snow) finalValues, (string Trait, string Range)[] userRegionChoice, (string Trait, int Modifier)[] userSeasonChoice)
        {

            DisplayScreenHeader("Enviroment Descriptions");



            Console.WriteLine($"The Temprature in this {userRegionChoice[0].Trait} Region during the {userSeasonChoice[0].Trait} is about {finalValues.Temprature} degrees");
            Console.WriteLine($"The Humidity is {finalValues.Humidity}, along with a {finalValues.Wind} wind. ");
            if (userSeasonChoice[0].Trait == "Summer" || userSeasonChoice[0].Trait == "Spring")
            {
                Console.Write($"Along with {finalValues.Rain}. ");
            }
            if (userSeasonChoice[0].Trait == "Winter" || userSeasonChoice[0].Trait == "Fall")
            {
                Console.Write($"Along with {finalValues.Snow}. ");
            }



            DisplayContinuePrompt();
            Console.WriteLine();

            switch (userRegionChoice[0].Trait)
            {
                case "Arctic":
                    Console.WriteLine("\tThe Arctic Landscape is remote with very few signs of life. " +
                        "Large hills surround you, but their size is hard to distinguish." +
                        "Snow covers everything in sight and varies in depth." +
                        "Icebergs can be seen on some bodies of water around you. ");
                    break;
                case "Tundra":
                    Console.WriteLine("The Tundra Landscape is rocky with mountains in the distance, " +
                        "there are rivers and streams that look cold to the touch. " +
                        "There are patches of wooded areas have evergreens, " +
                        "moss, and small shrubs that where likely to survive harsh winters.");
                    break;
                case "Forest":
                    Console.WriteLine("The Forest is lively with plant life everywhere, there are small hills and meadows areas." +
                        "The forest floor is covered with leaves and sprouting plants along with trees that have fallen." +
                        "You would be sources of bugs and ticks in the tall grass however " +
                        "on nice days the, sounds and smells are relaxing. ");
                    break;
                case "Desert":
                    Console.WriteLine("The Desert landscape is a hot scorched landscape with very little life," +
                        "however not for lack of heat. Rock and sand fill the area around you and the dunes " +
                        "look like waves in the distance. With no clouds in the sky with very few overhangings. " +
                        "There is water in the distance, or is there? ");
                    break;
                case "Tropical":
                    Console.WriteLine("The Tropical landscape is mostly open oceans with few islands like the one your on now, " +
                        "the plant life is flush and now two plants look the same, " +
                        "you can hear waves of the saltwater ocean in the distance, " +
                        "along with the dark and eerie noises coming from underneath the canopy. ");
                    break;

            }

            DisplayContinuePrompt();

        }



        #endregion

        #region Closing Screen
        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        private static void ClosingScreen()
        {

            DisplayScreenHeader("Closing Enviroment Generator");

            Console.WriteLine();
            Console.WriteLine("\tThank you for using the Enviroment Generator");

            DisplayContinuePrompt();
        }
        #endregion

        #region USER INTERFACE

        // Sets theme of Menus 
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }




        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress a key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
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
    }
}

        #endregion
