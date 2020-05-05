using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class ImageHandler
    {
        static bool tick;
        static readonly string[] monsters = new string[] { "Blinky", "Inky", "Klaid", "Pinky" };

        public static Dictionary<string, Dictionary<Directions, string>> images = new Dictionary<string, Dictionary<Directions, string>>
        {
            { "Blinky", new Dictionary<Directions, string>() { { Directions.Up, "BlinkyUp.png" },
                                                               { Directions.Down, "BlinkyDown.png" },
                                                               { Directions.Left, "BlinkyLeft.png" },
                                                               { Directions.Right, "BlinkyRight.png" },
                                                               { Directions.Nothing, "BlinkyRight.png" }} },
            { "Inky", new Dictionary<Directions, string>() { { Directions.Up, "InkyUp.png" },
                                                               { Directions.Down, "InkyDown.png" },
                                                               { Directions.Left, "InkyLeft.png" },
                                                               { Directions.Right, "InkyRight.png" },
                                                               { Directions.Nothing, "InkyRight.png" }} },
            { "Klaid", new Dictionary<Directions, string>() { { Directions.Up, "KlaidUp.png" },
                                                               { Directions.Down, "KlaidDown.png" },
                                                               { Directions.Left, "KlaidLeft.png" },
                                                               { Directions.Right, "KlaidRight.png" },
                                                               { Directions.Nothing, "KlaidRight.png" }} },
            { "Pinky", new Dictionary<Directions, string>() { { Directions.Up, "PinkyUp.png" },
                                                               { Directions.Down, "PinkyDown.png" },
                                                               { Directions.Left, "PinkyLeft.png" },
                                                               { Directions.Right, "PinkyRight.png" },
                                                               { Directions.Nothing, "PinkyRight.png" }} },
            { "Bonus", new Dictionary<Directions, string>() { { Directions.Nothing, "Bonus.png" } } },
            { "Energizer", new Dictionary<Directions, string>() { { Directions.Nothing, "Energizer.png" } } },
            { "Fruit", new Dictionary<Directions, string>() { { Directions.Nothing, "Fruit.png" } } },
            { "Wall", new Dictionary<Directions, string>() { { Directions.Nothing, "Wall.png" } } },
            { "Door", new Dictionary<Directions, string>() { { Directions.Nothing, "Door.png" } } }
        };

        public static string GetImage(string name, Directions direction)
        {
            if(name == "PackMan")
                return GetPackMansImage(direction);

            if (Game.IsMonsterStyle && monsters.Contains(name))
                return "GhostIsMonsterStyle.png";

            try
            {
                return images[name][direction];
            }
            catch
            {
                throw new Exception($"Key not found. Name: {name}, Dir: {direction}");
            }
        }

        static string GetPackMansImage(Directions dir)
        {
            tick = !tick;
            switch (dir)
            {
                case Directions.Up:
                    if (tick == true)
                        return "Pacman 1 1.png";
                    else
                        return "Pacman 1 2.png";
                case Directions.Right:
                    if (tick == true)
                        return "Pacman 2 1.png";
                    else
                        return "Pacman 2 2.png";
                case Directions.Down:
                    if (tick == true)
                        return "Pacman 3 1.png";
                    else
                        return "Pacman 3 2.png";
                case Directions.Left:
                    if (tick == true)
                        return "Pacman 4 1.png";
                    else
                        return "Pacman 4 2.png";
            }
            throw new Exception("Wrong direction");
        }

    }
}
