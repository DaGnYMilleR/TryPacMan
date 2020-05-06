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

        public static int PointsAtLevel = 212;
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
            {"PackMan", new Point() }
        };
        public static Audio Audio = new Audio();


        public static Point PrevPositionPacman;
        public static int Score;
        public static int CountEnergizer;
        public static int CountBonus;

        public static MonsterBehavior CurrentBehavior;
        public static List<ICreature> [,] Map;

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

        public static void CreateMap(string MapPacman)
        {
            teleports = new Teleport();
            Map = Map_creator.CreateMap(MapPacman);
            GameLives = 3;
        }

    }
}