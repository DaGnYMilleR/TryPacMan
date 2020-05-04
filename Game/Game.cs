using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Game
{
    class Game
    {
        public static string MapPacman = @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WFFFFFFFFFFFFWWWFFFFFFFFFFFFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WEWWWWFWWWWWFWWWFWWWWWFWWWWEW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WFFFFFFFFFFFFFFFFFFFFFFFFFFFW
WFWWWWFWWFWWWWWWWWWFWWFWWWWFW
WFFFFFFWWFFFFWWWFFFFWWFFFFFFW
WWWWWWFWWWWW WWW WWWWWFWWWWWW
     WFWWWWW WWW WWWWWFW     
     WFWWW    B    WWWFW     
     WFWWW WWWDWWW WWWFW     
WWWWWWFWWW WWPIKWW WWWFWWWWWW
      FF   WWWWWWW   FF      
WWWWWWFWW           WWFWWWWWW
     WFWW WWWWWWWWW WWFW     
     WFWW WWWWWWWWW WWFW     
WWWWWWFWW WWWWWWWWW WWFWWWWWW
WFFFFFFFFFFFFWWWFFFFFFFFFFFFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WEFFWWFFFFFFFFFFFFFFFFFWWFFEW
WWWFWWFWWFWWWWWWWWWFWWFWWFWWW
WWWFWWFWWFWWWWWWWWWFWWFWWFWWW
WFFFFFFWWFFFFWWWFFFFWWFFFFFFW
WFWWWWWWWWWWFWWWFWWWWWWWWWWFW
WFWWWWWWWWWWFWWWFWWWWWWWWWWFW
W             S             W
WWWWWWWWWWWWWWWWWWWWWWWWWWWWW
";
        public static Point LeftTeleport { get => new Point(-1, 13); }
        public static Point RightTeleport { get => new Point(29, 13); }

        public static Dictionary<Point, Point> Teleports = new Dictionary<Point, Point>()
        {
            { LeftTeleport, new Point(28, 13) },
            { RightTeleport, new Point(0, 13) }
        };

        public static int PointsAtLevel = 212;
        public static Point PackMansPosition { get; set; }
        public static Point PackManStartPosition = new Point(14, 27);
        public static Point BlinkysPosition { get; set; } // 14, 10
        public static Point PinkyPosition { get; set; } // 13, 12
        public static Point KlaidPosition { get; set; } // 15, 12
        public static Point InkyPosition { get; set; } //14, 12
        public static Dictionary<int, Point> StartPositionGhosts = new Dictionary<int, Point>
        {{1, new Point(13, 12) },
        { 2, new Point(14, 10) },
        { 3, new Point(15, 12)} ,
        { 4, new Point(14, 12)}};
        public static int Score;
        public static int CountEnergizer;
        public static int CountBonus;

        public static MonsterBehavior CurrentBehavior;
        public static ICreature[,] Map;

        public static int PointsEated;
        public static bool IsMonsterStyle;
        internal static Keys KeyPressed;

        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static Directions PacMansDirection;
        public static int GameLives;

        public static bool CanMoveToLeft(int x, int y) => x - 1 >= 0 && !(Map[x - 1, y] is Wall);

        public static bool CanMoveToRight(int x, int y) => x + 1 < MapWidth && !(Map[x + 1, y] is Wall);

        public static bool CanMoveToDown(int x, int y) => y + 1 < MapHeight && !(Map[x, y + 1] is Wall);

        public static bool CanMoveToUp(int x, int y) => y - 1 >= 0 && !(Map[x, y - 1] is Wall);

        public static bool InBounds(Point point)
        {
            var rect = new Rectangle(0, 0, MapWidth, MapHeight);
            return rect.Contains(point);
        }
        public static void CreateMap(string MapPacman)
        {
            Map = Map_creator.CreateMap(MapPacman);
            GameLives = 3;
        }

    }
}
