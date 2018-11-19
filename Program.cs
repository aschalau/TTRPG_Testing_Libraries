using System;
using System.Collections.Generic;
using DiceLib;
using CharacterLib;
using RaceLib;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////
            // DiceLib //
            /////////////
            Console.WriteLine("-------------------------------\n\tTesting DiceLib\n-------------------------------");

            Console.WriteLine("==========\n50 / 50\n==========");

            List<bool> all_fifty_fifty_rolls = new List<bool>();
            DiceLib.Dice die = new DiceLib.Dice();

            for(int i = 0; i < 10; i++)
            {
                int temp = die.Roll();
                Console.WriteLine("50 / 50 result: {0}", temp);
                all_fifty_fifty_rolls.Add(temp == 0 ? true : false);
            }
            
            Console.WriteLine("\n==========\nd4 Rolls\n==========");

            List<int> all_d4_rolls = new List<int>();
            DiceLib.Dice die4 = new DiceLib.Dice(4);

            for(int i = 0; i < 10; i++)
            {
                int temp = die4.Roll();
                Console.WriteLine("d4 result: {0}", temp);
                all_d4_rolls.Add(temp);
            }

            Console.WriteLine("\n==========\nd12 Rolls\n==========");

            List<int> all_d12_rolls = new List<int>();
            DiceLib.Dice die12 = new DiceLib.Dice(12);

            for(int i = 0; i < 10; i++)
            {
                int temp = die12.Roll();
                Console.WriteLine("d12 result: {0}", temp);
                all_d12_rolls.Add(temp);
            }

            Console.WriteLine("\n==========\nd100 Rolls\n==========");

            List<int> all_d100_rolls = new List<int>();
            DiceLib.Dice die100 = new DiceLib.Dice(100);

            for(int i = 0; i < 10; i++)
            {
                int temp = die100.Roll();
                Console.WriteLine("d100 result: {0}", temp);
                all_d100_rolls.Add(temp);
            }

            Console.WriteLine("\n==========\nPulling From Rolls\n==========");
            Console.WriteLine("And a result for the 50 / 50: {0}\n" +
                              "And a result for the d4: {1}\n" +
                              "And a result for d12: {2}\n" +
                              "And a result for d100: {3}", 
                              all_fifty_fifty_rolls[1], 
                              all_d4_rolls[1], 
                              all_d12_rolls[1],
                              all_d100_rolls[1]);

            Console.WriteLine("\n==========\nRoll Average\n==========");
            Console.WriteLine("=== d8 x10 ===");

            DiceLib.Dice avg = new DiceLib.Dice(8);
            double return_average = avg.RollAverage(avg, 10);

            Console.WriteLine("{0} returned from class method.", return_average);
            Console.WriteLine("{0} returned value rounded.", Math.Round(return_average));

            Console.WriteLine("\n=== d20 x100 ===");

            DiceLib.Dice avg2 = new DiceLib.Dice(20);

            double return_average2 = avg.RollAverage(avg2, 100);

            Console.WriteLine("{0} returned from class method.", return_average2);
            Console.WriteLine("{0} returned value rounded.", Math.Round(return_average2));

            Console.WriteLine("\n==========\nStandard Points\n==========");

            DiceLib.Dice standard = new DiceLib.Dice();
            List<int> standard_stats = standard.StandardStatPoints();

            foreach(int i in standard_stats)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Here is how you can find and use items in the middle of a list");
            Console.WriteLine("13 is in position: {0}", standard_stats.IndexOf(13));

            Console.WriteLine("Here is how you can find and use items in the beginning of a list");
            Console.WriteLine("15 is in position: {0}", standard_stats.IndexOf(15));


            Console.WriteLine("Here is how you can find and use items in the end of a list");
            Console.WriteLine("8 is in position: {0}", standard_stats.IndexOf(8));

            Console.WriteLine("\n==========\nRoll Four d6 and Take Top Three\n==========");

            DiceLib.Dice fd6 = new DiceLib.Dice(6);
            int stat_score_fd6 = fd6.RollFourD6TakeTopThree(fd6);

            Console.WriteLine("Top three of four added: {0}", stat_score_fd6);

            Console.WriteLine("\nPress [ENTER] to continue or [CRTL] + [C] to stop.");
            Console.Read();
            // Console.Clear();

            //////////////////
            // CharacterLib //
            //////////////////

            Console.WriteLine("------------------------------------\n\tTesting CharacterLib\n------------------------------------");
            Console.WriteLine("Creating a character and printing out the base stats:");

            Character character = new Character();
            List<Character> stat_list = new List<Character>();
            stat_list.Add(character);

            Console.WriteLine("STRENGTH stat is: {0}", stat_list[0].strength);
            Console.WriteLine("DEXTERITY stat is: {0}", stat_list[0].dexterity);
            Console.WriteLine("CONSTITUTION stat is: {0}", stat_list[0].constitution);
            Console.WriteLine("INTELLIGENCE stat is: {0}", stat_list[0].intelligence);
            Console.WriteLine("WISDOM stat is: {0}", stat_list[0].wisdom);
            Console.WriteLine("CHARISMA stat is: {0}", stat_list[0].charisma);

            Console.WriteLine("\nWhat happens if I do this? {0}", stat_list[0]);
            Console.WriteLine("What happens if I do THIS?! {0}", stat_list);

            Console.WriteLine("\nPress [ENTER] to continue!");
            Console.Read();

            Console.WriteLine("==========\nAssigning Strength 50\n==========");

            character.strength = 50;
            
            Console.WriteLine("Strength is: {0}", character.strength);
            
            Console.WriteLine("\n==========\nAssigning Intelligence 500\n==========");
            
            character.intelligence = 500;
            
            Console.WriteLine("Intelligence is: {0}", character.intelligence);
            
            Console.WriteLine("\n==========\nWisdom should still be unassigned\n==========");
            Console.WriteLine("Wisdom is: {0}", character.wisdom);

            Console.WriteLine("\nPress [ENTER] to continue or [CTRL] + [C] to stop.");
            Console.Read();
            // Console.Clear();

            //////////////////////////////////////////
            // Bringing Character and Dice together //
            //////////////////////////////////////////

            Console.WriteLine("----------------------------------------------------------\n\tBringing ChacacterLib and DiceLib together\n----------------------------------------------------------");

            DiceLib.Dice d6 = new DiceLib.Dice(6);
            List<int> stat_score = new List<int>();

            Console.WriteLine("\nRolling for the stats...");

            for(int i = 0; i < 6; i++)
            {
                stat_score.Add(d6.RollFourD6TakeTopThree(d6));
            }

            stat_score.Sort();

            Console.WriteLine("Rolled stats are:");

            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine(stat_score[i]);
            }

            Console.WriteLine("\nPress [ENTER] to continue or [CTRL] + [C] to stop.");
            Console.Read();
            // Console.Clear();

            ///////////////////////////////////////////////
            // Selecting and adding the roll to the stat //
            ///////////////////////////////////////////////
            Console.WriteLine("Lets put the rolled stats to the character:\n");
            
            // TODO: probably can be moved somewhere else
            Dictionary<string, string> stat_menu = new Dictionary<string, string>{
                {"str", "Strength"},
                {"dex", "Dexterity"},
                {"con", "Constitution"},
                {"int", "Intelligence"},
                {"wis", "Wisdom"},
                {"cha", "Charisma"},
            };

            while(stat_score.Count > 0)
            {
                Console.WriteLine("Id  - Stat Score");
                Console.WriteLine("-----------------");

                foreach(int s in stat_score)
                {
                    Console.WriteLine("[{0}] - {1}", stat_score.IndexOf(s), s);
                }

                Console.Write("\nSelection: ");
                string stat_selection = Console.ReadLine();
                int stat_number;
                Int32.TryParse(stat_selection, out stat_number);
                
                // validation
                // TODO: probably can be broken off into its' own thing
                if(stat_number > stat_score.Count - 1)
                {
                    // Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nWRONG! PLEASE SELECT A VALID CHOICE!\n\n");
                    Console.ResetColor();
                    continue;
                }

                Console.Write("\nYour selection was {0}: ", stat_number);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("{0}\n", stat_score[stat_number]);
                Console.ResetColor();

                Console.Write("Which stat do you want to put ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0}", stat_score[stat_number]);
                Console.ResetColor();
                Console.WriteLine(" to?\n");
                Console.WriteLine("Stat  - Description");
                Console.WriteLine("---------------------");
                
                foreach(KeyValuePair<string, string> kvp in stat_menu)
                {
                    Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                }

                Console.Write("\nSelection: ");
                string character_selection = Console.ReadLine().ToLower().Trim();

                // validation
                // TODO: probably can be borken off into its' own thing
                if(!stat_menu.ContainsKey(character_selection))
                {
                    // Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n{0} has either been used already or never existed.  Please try again.\n\n", character_selection);
                    Console.ResetColor();
                    continue;
                }

                switch(character_selection)
                {
                    case "str":
                        character.strength = stat_score[stat_number];
                        break;
                    case "dex":
                        character.dexterity = stat_score[stat_number];
                        break;
                    case "con":
                        character.constitution = stat_score[stat_number];
                        break;
                    case "int":
                        character.intelligence = stat_score[stat_number];
                        break;
                    case "wis":
                        character.wisdom = stat_score[stat_number];
                        break;
                    case "cha":
                        character.charisma = stat_score[stat_number];
                        break;
                }

                Console.WriteLine("\nCharacter's stats are now:");
                Console.WriteLine("str is: {0}", character.strength);
                Console.WriteLine("dex is: {0}", character.dexterity);
                Console.WriteLine("con is: {0}", character.constitution);
                Console.WriteLine("int is: {0}", character.intelligence);
                Console.WriteLine("wis is: {0}", character.wisdom);
                Console.WriteLine("cha is: {0}\n", character.charisma);
                // Console.WriteLine("\n\n");

                // remove the stat number from the selection
                stat_score.RemoveAt(stat_number);
                stat_menu.Remove(character_selection);
            }

            Console.WriteLine("==========\nCharacter's stats and modifiers\n==========");

            Console.WriteLine("Strength is: {0}", character.strength);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.strength));

            Console.WriteLine("Dexterity is: {0}", character.dexterity);
            Console.WriteLine("Modifier is:  {0}\n", character.AbilityModifiers(character.dexterity));

            Console.WriteLine("Constitution is: {0}", character.constitution);
            Console.WriteLine("Modifier is:     {0}\n", character.AbilityModifiers(character.constitution));

            Console.WriteLine("Intelligence is: {0}", character.intelligence);
            Console.WriteLine("Modifier is:     {0}\n", character.AbilityModifiers(character.intelligence));

            Console.WriteLine("Wisdom is:   {0}", character.wisdom);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.wisdom));

            Console.WriteLine("Charisma is: {0}", character.charisma);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.charisma));
            
            Console.WriteLine("\nPress [ENTER] to continue or [CTRL] + [C] to stop.");
            Console.Read();
            // Console.Clear();

            /////////////////
            // Adding Race //
            /////////////////
            Console.WriteLine("-------------------------------\n\tTesting RaceLib\n-------------------------------");
            
            Dictionary<string, string> race_menu = new Dictionary<string, string>
            {
                {"dwa", "Dwarf"},
                {"elf", "Elf"},
                {"hal", "Halfling"},
                {"hum", "Human"},
                {"dra", "Dragonborn"},
                {"gno", "Gnome"},
                {"hel", "Half-Elf"},
                {"hor", "Half-Orc"},
                {"tie", "Tiefling"},
            };

            bool race_flag = true;
            string race_selection = "";
            while(race_flag)
            {
                Console.WriteLine("\nChoose what RACE you'd like to be:");
                Console.WriteLine("\nId  - Main Race");
                Console.WriteLine("-----------------");

                foreach(KeyValuePair<string, string> kvp in race_menu)
                {
                    Console.WriteLine("[{0}] - {1}", kvp.Key, kvp.Value);
                }

                Console.Write("\nSelection: ");
                race_selection = Console.ReadLine().ToLower().Trim();

                // validation
                // TODO: probably can be broken off into its' own thing
                if(!race_menu.ContainsKey(race_selection))
                {
                    // Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n{0} is not a valid race.  Please try again.\n\n", race_selection);
                    Console.ResetColor();
                    continue;
                }

                race_flag = false;
            }

            Console.WriteLine("\n==========\nAdding Race Modifiers to Character\n==========");
            // TODO: These need to be cleaned up and done better
            switch(race_selection)
            {
                case "dwa":
                    Dwarf dwarf = new Dwarf();
                    character.strength += dwarf.RaceModifiers();
                    break;
                case "elf":
                    Elf elf = new Elf();
                    character.dexterity += elf.RaceModifiers();
                    break;
                case "hal":
                    Halfling halfling = new RaceLib.Halfling();
                    character.dexterity += halfling.RaceModifiers();
                    break;
                case "hum":
                    Human human = new Human();
                    character.strength += human.RaceModifiers();
                    character.dexterity += human.RaceModifiers();
                    character.constitution += human.RaceModifiers();
                    character.intelligence += human.RaceModifiers();
                    character.wisdom += human.RaceModifiers();
                    character.charisma += human.RaceModifiers();
                    break;
                case "dra":
                    Dragonborn dragonborn = new Dragonborn();
                    character.strength += dragonborn.RaceModifiers();
                    character.strength += dragonborn.RaceModifiers();
                    character.charisma += dragonborn.RaceModifiers();
                    break;
                case "gno":
                    Gnome gnome = new Gnome();
                    character.intelligence += gnome.RaceModifiers();
                    break;
                case "hel":
                    Half_Elf half_elf = new Half_Elf();
                    character.strength += half_elf.RaceModifiers();
                    character.strength += half_elf.RaceModifiers();
                    character.charisma += half_elf.RaceModifiers();
                    character.charisma += half_elf.RaceModifiers();
                    break;
                case "hor":
                    Half_Orc half_orc = new Half_Orc();
                    character.constitution += half_orc.RaceModifiers();
                    break;
                case "tie":
                    Tiefling tiefling = new Tiefling();
                    character.intelligence += tiefling.RaceModifiers();
                    character.charisma += tiefling.RaceModifiers();
                    character.charisma += tiefling.RaceModifiers();
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nCharacter's stats are now: ");
            Console.WriteLine("- str is: {0}", character.strength);
            Console.WriteLine("- dex is: {0}", character.dexterity);
            Console.WriteLine("- con is: {0}", character.constitution);
            Console.WriteLine("- int is: {0}", character.intelligence);
            Console.WriteLine("- wis is: {0}", character.wisdom);
            Console.WriteLine("- cha is: {0}\n", character.charisma);
            // Console.WriteLine("\n\n");

            Console.WriteLine("==========\nCharacter's stats and modifiers\n==========");

            Console.WriteLine("Strength is: {0}", character.strength);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.strength));

            Console.WriteLine("Dexterity is: {0}", character.dexterity);
            Console.WriteLine("Modifier is:  {0}\n", character.AbilityModifiers(character.dexterity));

            Console.WriteLine("Constitution is: {0}", character.constitution);
            Console.WriteLine("Modifier is:     {0}\n", character.AbilityModifiers(character.constitution));

            Console.WriteLine("Intelligence is: {0}", character.intelligence);
            Console.WriteLine("Modifier is:     {0}\n", character.AbilityModifiers(character.intelligence));

            Console.WriteLine("Wisdom is:   {0}", character.wisdom);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.wisdom));

            Console.WriteLine("Charisma is: {0}", character.charisma);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.charisma));
            
            Console.WriteLine("\nPress [ENTER] to continue or [CTRL] + [C] to stop.");
            Console.Read();

            Console.WriteLine("==========\nAdding the SUBRACES\n==========");

            Dictionary<string[], string> subrace_menu = new Dictionary<string[], string>
            {
                {new string[] {"hil", "Hill"}, "dwa"},
                {new string[] {"mou", "Mountain",}, "dwa"},
                {new string[] {"dro", "Drow"}, "elf"},
                {new string[] {"hig", "High"}, "elf"},
                {new string[] {"woo", "Wood"}, "elf"},
                {new string[] {"lig", "Lightfoot"}, "hal"},
                {new string[] {"sto", "Stout"}, "hal"},
                {new string[] {"for", "Forest"}, "gno"},
                {new string[] {"roc", "Rock"}, "gno"},
            };

            string [] has_subrace_races = {"dwa", "elf", "hal", "gno"};
            bool subrace_flag = (Array.Exists(has_subrace_races, sr => sr.Equals(race_selection)) ? true : false);
            string subrace_selection = "";

            while(subrace_flag)
            {
                Console.WriteLine("\nChoose what SUB RACE you'd like to be:");
                Console.WriteLine("\nId  - Sub Race");
                Console.WriteLine("-----------------");

                foreach(KeyValuePair<string[], string> kvp in subrace_menu)
                {
                    // only show the subraces that match a main race
                    if(kvp.Value == race_selection)
                    {
                        Console.WriteLine("[{0}] - {1} for {2}", kvp.Key[0], kvp.Key[1], race_menu[race_selection]);
                    }
                }

                Console.Write("\nSelection: ");
                subrace_selection = Console.ReadLine().ToLower().Trim();

                // validation
                // TODO: probably can be broken off into its' own thing
                // if(!subrace_menu.ContainsKey(subrace_selection))
                // {
                //     Console.Clear();
                //     Console.ForegroundColor = ConsoleColor.Red;
                //     Console.WriteLine("\n\n{0} is not a valid race.  Please try again.\n\n", subrace_selection);
                //     Console.ResetColor();
                //     continue;
                // }

                subrace_flag = false;
            }

            Console.WriteLine("\n==========\nAdding Subrace Modifiers to Character\n==========");
    
            switch(subrace_selection)
            {
                case "hil":
                    RaceLib.HillDwarf hill_dwarf = new RaceLib.HillDwarf();
                    character.wisdom += hill_dwarf.RaceModifiers();
                    break;
                case "mou":
                    RaceLib.MountainDwarf mountain_dwarf = new RaceLib.MountainDwarf();
                    character.strength += mountain_dwarf.RaceModifiers();
                    break;
                case "dro":
                    RaceLib.Drow drow = new RaceLib.Drow();
                    character.charisma += drow.RaceModifiers();
                    break;
                case "hig":
                    RaceLib.High high_elf = new RaceLib.High();
                    character.intelligence += high_elf.RaceModifiers();
                    break;
                case "woo":
                    RaceLib.Wood wood_elf = new RaceLib.Wood();
                    character.wisdom += wood_elf.RaceModifiers();
                    break;
                case "lig":
                    RaceLib.Lightfoot lightfoot_halfling = new RaceLib.Lightfoot();
                    character.charisma += lightfoot_halfling.RaceModifiers();
                    break;
                case "sto":
                    RaceLib.Stout stout_halfling = new RaceLib.Stout();
                    character.constitution += stout_halfling.RaceModifiers();
                    break;
                case "for":
                    RaceLib.Forest forest_gnome = new RaceLib.Forest();
                    character.dexterity += forest_gnome.RaceModifiers();
                    break;
                case "roc":
                    RaceLib.Rock rock_gnome = new RaceLib.Rock();
                    character.constitution += rock_gnome.RaceModifiers();
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nCharacter's stats are now: ");
            Console.WriteLine("- str is: {0}", character.strength);
            Console.WriteLine("- dex is: {0}", character.dexterity);
            Console.WriteLine("- con is: {0}", character.constitution);
            Console.WriteLine("- int is: {0}", character.intelligence);
            Console.WriteLine("- wis is: {0}", character.wisdom);
            Console.WriteLine("- cha is: {0}\n", character.charisma);
            // Console.WriteLine("\n\n");

            Console.WriteLine("==========\nCharacter's stats and modifiers\n==========");

            Console.WriteLine("Strength is: {0}", character.strength);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.strength));

            Console.WriteLine("Dexterity is: {0}", character.dexterity);
            Console.WriteLine("Modifier is:  {0}\n", character.AbilityModifiers(character.dexterity));

            Console.WriteLine("Constitution is: {0}", character.constitution);
            Console.WriteLine("Modifier is:     {0}\n", character.AbilityModifiers(character.constitution));

            Console.WriteLine("Intelligence is: {0}", character.intelligence);
            Console.WriteLine("Modifier is:     {0}\n", character.AbilityModifiers(character.intelligence));

            Console.WriteLine("Wisdom is:   {0}", character.wisdom);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.wisdom));

            Console.WriteLine("Charisma is: {0}", character.charisma);
            Console.WriteLine("Modifier is: {0}\n", character.AbilityModifiers(character.charisma));
            
            Console.WriteLine("\nPress [ENTER] to continue or [CTRL] + [C] to stop.");
            Console.Read();

            Console.WriteLine("END");
        }
    }
}
