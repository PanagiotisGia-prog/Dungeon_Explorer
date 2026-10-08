using Spectre.Console;

namespace DungeonExplorer
{
    internal class Program
    {
        public static void Main(string[] _)
        {
            MainMenu.DisplayTitle();
            Console.WriteLine("");
            Guide.Instructions();
            Console.WriteLine("");
            Difficulty difficulty = DifficultySelection();
            Console.Clear();
            Game.Initialize(difficulty);
        }

        /// <summary>
        /// Shows the list of difficulties the player can choose from.
        /// </summary>
        /// <returns>The <see cref="Difficulty"/> the player chose.</returns>
        public static Difficulty DifficultySelection()
        {
            bool chosenDifficulty = false;

            Difficulty difficulty = Difficulty.Easy;

            AnsiConsole.MarkupLine("Choose a difficulty:\n[darkturquoise]1. Easy[/]\n[seagreen2]2. Normal[/]\n[yellow]3. Hard[/]\n[orangered1]4. Extreme[/]\n[darkred]5. Ultimate[/]");

            while (!chosenDifficulty)
            {
                string chooseDifficulty = (Console.ReadLine() ?? string.Empty).ToLower().Trim();

                switch (chooseDifficulty)
                {
                    case "1":
                    case "easy":
                        difficulty = Difficulty.Easy;
                    break;

                    case "2":
                    case "normal":
                        difficulty = Difficulty.Normal;
                    break;

                    case "3":
                    case "hard":
                        difficulty = Difficulty.Hard;
                    break;

                    case "4":
                    case "extreme":
                        difficulty = Difficulty.Extreme;
                    break;

                    case "5":
                    case "ultimate":
                        difficulty = Difficulty.Ultimate;
                    break;

                    default:
                        Console.WriteLine("Invalid choice!");
                    continue;
                }

                chosenDifficulty = true;
            }
            
            return difficulty;
        }
    }
}