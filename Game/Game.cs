using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Game
    {
        public static Teleport teleports = new Teleport();

        public static int PointsAtLevel;
        public static Point PackMansPosition { get; set; }
        public static Point PackManStartPosition = new Point(14, 27);
        public static Point BlinkysPosition { get; set; }
        public static Point PinkyPosition { get; set; }
        public static Point KlaidPosition { get; set; }
        public static Point InkyPosition { get; set; }

        public static Dictionary<string, Point> startPositions = new Dictionary<string, Point>()
        {
            { "Blinky", new Point() },
            { "Inky", new Point() },
            { "Pinky", new Point() },
            { "Klaid", new Point() },
            { "PackMan", new Point() }
        };

        public static Audio Audio = new Audio();


        public static Point PrevPositionPacman;
        public static int Score;
        public static int CountEnergizer;
        public static int CountBonus;

        public static MonsterBehavior CurrentBehavior;
        public static volatile List<ICreature> [,] Map;

        public static int PointsEated;
        public static bool IsMonsterStyle;
        internal static Keys KeyPressed;

        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static Directions PacMansDirection;
        public static int GameLives;

        public static bool CanMoveToLeft(int x, int y) => x - 1 >= 0 && !(Map[x - 1, y].FirstOrDefault() is Wall);

        public static bool CanMoveToRight(int x, int y) => x + 1 < MapWidth && !(Map[x + 1, y].FirstOrDefault() is Wall);

        public static bool CanMoveToDown(int x, int y) => y + 1 < MapHeight && !(Map[x, y + 1].FirstOrDefault() is Wall);

        public static bool CanMoveToUp(int x, int y) => y - 1 >= 0 && !(Map[x, y - 1].FirstOrDefault() is Wall);

        public static bool InBounds(Point point)
        {
            var rect = new Rectangle(0, 0, MapWidth, MapHeight);
            return rect.Contains(point);
        }

        public static bool IsDoorClosed = true;

        public static void CreateMap(string MapPacman)
        {
            teleports = new Teleport();
            Map = Map_creator.CreateMap(MapPacman, "\r\n");
            GameLives = 3;
        }
        
        public static void Reloge()
        {
            Map[KlaidPosition.X, KlaidPosition.Y] = new List<ICreature>();
            Map[BlinkysPosition.X, BlinkysPosition.Y] = new List<ICreature>();
            Map[InkyPosition.X, InkyPosition.Y] = new List<ICreature>();
            Map[PinkyPosition.X, PinkyPosition.Y] = new List<ICreature>();
            Map[PackMansPosition.X, PackMansPosition.Y] = new List<ICreature>();
            Map[startPositions["Blinky"].X, startPositions["Blinky"].Y].Add(new Blinky(Directions.Right));
            Map[startPositions["Inky"].X, startPositions["Inky"].Y].Add(new Inky(Directions.Right));
            Map[startPositions["Pinky"].X, startPositions["Pinky"].Y].Add(new Pinky(Directions.Right));
            Map[startPositions["Klaid"].X, startPositions["Klaid"].Y].Add(new Klaid(Directions.Right));
            Map[startPositions["PackMan"].X, startPositions["PackMan"].Y].Add(new PackMan(Directions.Right));
        }
        private static ICreature GetItem(List<ICreature> list)
        {
            foreach (var item in list)
                if (item is Ghost)
                    return item;
            return list[list.Count - 1];
        }

        public static List<ICreature>[,] UpdateMapCell(int x, int y)
        {
            Console.WriteLine("Up");
            //Map[x, y] = new List<ICreature>();
            var res = new List<ICreature>[MapWidth, MapHeight];
            for (var i = 0; i < MapWidth; i++)
                for(var j = 0; j < MapHeight; j ++)
                {
                    if (i == x && j == y)
                        res[i, j] = new List<ICreature>();
                    else
                    {
                        res[i, j] = Map[i, j];
                    }
                }
            for (var i = 0; i < MapWidth; i++)
            {
                for (var j = 0; j < MapHeight; j++)
                {
                    if (i == 14 && j == 11)
                        Console.Write("!!!!!!!!!");
                    if (res[i, j].FirstOrDefault() == null)
                        Console.Write($"empty ");
                    else
                        Console.Write(res[i, j].FirstOrDefault().ToString() + "  ");
                }
                Console.WriteLine();
            }

            return res;
            
        }

    }
}