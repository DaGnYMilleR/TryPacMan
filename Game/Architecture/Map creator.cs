using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map_creator
    {
        public static List<ICreature>[,] CreateMap(string map, string sep)
        {

            var rows = map.Split(new[] { sep }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<ICreature>[rows[0].Length, rows.Length];
            for (var i = 0; i < rows[0].Length; i++)
                for (var j = 0; j < rows.Length; j++)
                {
                    result[i, j] = CreateCreatureBySymbol(rows[j][i], i, j);
                }
            return result;
        }

        public static List<ICreature> CreateCreatureBySymbol(char symb, int x, int y)
        {
            switch (symb)
            {
                case 'W':
                    return new List<ICreature> { new Wall() };
                case ' ':
                    return new List<ICreature>();
                case 'E':
                    return new List<ICreature> { new Energizer() };
                case 'C':
                    return new List<ICreature> { new Bonus() };
                case 'P':
                    Game.startPositions["Pinky"] = new Point(x, y);
                    return new List<ICreature> { new Pinky(Directions.Nothing) };
                case 'K':
                    Game.startPositions["Klaid"] = new Point(x, y);
                    return new List<ICreature> { new Klaid(Directions.Right) };
                case 'I':
                    Game.startPositions["Inky"] = new Point(x, y);
                    return new List<ICreature> { new Inky(Directions.Right) };
                case 'B':
                    Game.startPositions["Blinky"] = new Point(x, y);
                    return new List<ICreature> { new Blinky(Directions.Nothing) };
                case 'F':
                    Game.PointsAtLevel++;
                    return new List<ICreature> { new Fruit() };
                case 'S':
                    Game.startPositions["PackMan"] = new Point(x, y);
                    return new List<ICreature> { new PackMan(Directions.Right) };
                case 'D':
                    Game.DoorPosition = new Point(x, y);
                    Game.IsDoorClosed = true;
                    return new List<ICreature> { new Door() };
                case '0':
                    Game.teleports.AddTeleport(new Point(x, y));
                    return new List<ICreature>();
                default:
                    throw new Exception($"Wrong symbol! {symb} at x: {x}, y: {y}");
            }
        }
    }
}