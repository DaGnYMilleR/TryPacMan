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

        public static bool Reloge;

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
            Map = Map_creator.CreateMap(MapPacman, "\n");
            GameLives = 3;
        }

        public static List<ICreature>[,] UpdateMapCell(int x, int y)
        {
            Console.WriteLine("Up");
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

        public static void Respawn()
        {
            if (Reloge)
            {
                lock (Map)
                {
                    for (var x = 0; x < MapWidth; x++)
                    {
                        for (var y = 0; y < MapHeight; y++)
                        {
                            var creatures = Map[x, y];
                            Map[x, y] = new List<ICreature>();
                            if (new Point(x, y) == new Point(startPositions["Klaid"].X, startPositions["Klaid"].Y))
                                Map[x, y].Add(new Klaid(Directions.Right));
                            if (new Point(x, y) == new Point(startPositions["Blinky"].X, startPositions["Blinky"].Y))
                                Map[x, y].Add(new Blinky(Directions.Right));
                            if (new Point(x, y) == new Point(startPositions["Inky"].X, startPositions["Inky"].Y))
                                Map[x, y].Add(new Inky(Directions.Right));
                            if (new Point(x, y) == new Point(startPositions["Pinky"].X, startPositions["Pinky"].Y))
                                Map[x, y].Add(new Pinky(Directions.Right));
                            if (new Point(x, y) == new Point(startPositions["PackMan"].X, startPositions["PackMan"].Y))
                                Map[x, y].Add(new PackMan(Directions.Right));
                            foreach (var creature in creatures)
                            {
                                if (creature is Ghost || creature is PackMan)
                                    continue;
                                Map[x, y].Add(creature);
                            }

                        }
                    }
                    Reloge = false;
                }
            }
        }

    }
}