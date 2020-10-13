using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using textAdventure.Commands;

namespace textAdventure
{
    class Program
    {
        private static string input;
        public static Character chara;
        public static Command[] allCommands = { new AskCommand(), new DiagnoseCommand(), new DropCommand(), new ExamineCommand(), new HelpCommand(), new HitCommand(), new InventoryCommand(), new LookCommand(), new MoveCommand(), new OpenCommand(), new OptionsCommand(), new PutCommand(), new ReadCommand(), new ShowCommand(), new SleepCommand(), new SneakCommand(), new StealCommand(), new TakeCommand(), new UseCommand(), new WaitCommand() };

        static void Main(string[] args)
        {
            Console.Title = "Game I";
            // Pregame();
            SetHeading("Tutorial");
            while(true)
            {
                GetInput();
                DecipherCommands();
            }
        }

        static void DecipherCommands()
        {
            foreach (string str in input.ToLower().Split(new String[] { "then", "." }, StringSplitOptions.None).ToArray())
            {
                string action = str.Trim().ToLower();

                // if the user enters a bunch of spaces
                if (action.Equals(""))
                    continue;

                KeyValuePair<Command, string> pair = GetCommand(action);
                if (pair.Key != null)
                {
                    // removes the action from the command
                    action = action.Replace(pair.Value, "").Trim();

                    // if (not too little input and not too much input)
                    if (!(pair.Key.GetCmdParameters() != null && action.Equals("")) && !(pair.Key.GetCmdParameters() == null && !action.Equals("")))
                    {
                        // checks if another action is not in the 
                        // same input after original action is removed
                        if (GetCommand(action).Equals(new KeyValuePair<Command, string>(null, null)))
                        {
                            Console.WriteLine("Executed command: " + pair.Value);
                            pair.Key.Execute(action);
                        }
                        else
                            Console.WriteLine("Invalid entry! (Are you sure you're not using \"and\" to separate out your commands?)");
                    }
                    else
                    {
                        Console.Write("Invalid command use!\nFormat: >> " + pair.Value);
                        if (pair.Key.GetCmdParameters() != null)
                            foreach (string param in pair.Key.GetCmdParameters())
                                Console.WriteLine(" " + param);
                    }
                }
                else
                    Console.WriteLine("\"" + action + "\" is not a valid command.");
            }
        }

        /*
         * Returns a KeyValuePair containing the command along
         * with the trigger word they matched with
         */
        private static KeyValuePair<Command, string> GetCommand(string action)
        {
            foreach (Command cmd in allCommands)
                foreach (String trigger in cmd.GetTriggerWords())
                    foreach (String str in action.Split(' '))
                        if (str.Equals(trigger))
                            return new KeyValuePair<Command, string>(cmd, trigger);
            return new KeyValuePair<Command, string>(null, null);
        }

        static void Pregame()
        {
            bool isGettingName = true, isGettingRace = true;
            string name = "", race = "";

            SetHeading("Pregame");

            Console.WriteLine("Hello! Welcome to your brand new world! Adventure, questing, fighting, dungeoning all await you in this fantasy realm! There are a couple of necessary bits of information you're off on your way!");
            while (isGettingName)
            {
                Console.WriteLine("What is your name?");
                GetInput();
                name = input;
                Console.WriteLine("Are you sure your name is \'" + name + "\'? You can change this later if you'd like.");
                GetInput();
                switch (input.ToLower())
                {
                    default:
                        Console.WriteLine("I'll take that as a no.");
                        break;
                    case "yes":
                    case "y":
                        Console.WriteLine("So it is! Your name is now \'" + name + "\'!");
                        isGettingName = false;
                        break;
                    case "n":
                    case "no":
                        break;
                }
            }

            while (isGettingRace)
            {
                bool raceIsValid = true;

                Console.WriteLine("What race would you like to be? Currently, races have no outcome on your stats but this is subject to change. The following is the current list of races: "
                    + "Human, Ogre, Elf, Dwarf, Gnome, Avian, Orc, Custom");
                GetInput();
                race = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
                
                switch(race.ToLower())
                {
                    default:
                        Console.WriteLine("That is not a valid race! If you'd like to enter your own race, please type \'Custom\' first!");
                        raceIsValid = false;
                        break;
                    case "human":
                    case "ogre":
                    case "elf":
                    case "dwarf":
                    case "gnome":
                    case "avian":
                    case "orc":
                        Console.WriteLine("You have set your race to be \'" + race + "\'. Is this correct?");
                        GetInput();
                        break;
                    case "custom":
                        Console.WriteLine("Custom race selected! Input the name of the race you would like.");
                        GetInput();
                        race = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
                        Console.WriteLine("You have set your race to be \'" + race + "\'. Is this correct?");
                        GetInput();
                        break;
                }

                if (raceIsValid)
                {
                    switch (input.ToLower())
                    {
                        default:
                            Console.WriteLine("I'll take that as a no.");
                            break;
                        case "yes":
                        case "y":
                            Console.WriteLine("So it is! Your race is now \'" + race + "\'!");
                            isGettingRace = false;
                            break;
                        case "n":
                        case "no":
                            break;
                    }
                }
            }
            chara = new Character(name, race);
        }

        static void SetHeading(string title)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            // Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.WindowTop);
            Console.Write(title);
            for (int i = 0; i < Console.WindowWidth - title.Length; i++)
                Console.Write(" ");
            Console.ResetColor();
        }

        static void GetInput()
        {
            Console.Write("\n>> ");
            input = Console.ReadLine();
        }
    }
}