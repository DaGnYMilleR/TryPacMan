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
        private const string MapPacman = @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WFFFFFFFFFFFFWWWFFFFFFFFFFFFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WCWWWWFWWWWWFWWWFWWWWWFWWWWCW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WFFFFFFFFFFFFFFFFFFFFFFFFFFFW
WFWWWWFWWFWWWWWWWWWFWWFWWWWFW
WFFFFFFWWFFFFWWWFFFFWWFFFFFFW
WWWWWWFWWWWW WWW WWWWWFWWWWWW
     WFWWWWW WWW WWWWWFW     
     WFWWW         WWWFW     
     WFWWW WWWOWWW WWWFW     
WWWWWWFWWW WW   WW WWWFWWWWWW
      FF   WWWWWWW   FF      
WWWWWWFWW           WWFWWWWWW
     WFWW WWWWWWWWW WWFW     
     WFWW WWWWWWWWW WWFW     
WWWWWWFWW WWWWWWWWW WWFWWWWWW
WFFFFFFFFFFFFWWWFFFFFFFFFFFFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WCFFWWFFFFFFFFFFFFFFFFFWWFFCW
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

        public static int PointsAtLevel;
        public static Point PackMansPosition { get; set; }
        public static Point BlinkysPosition { get; set; } // 14, 10
        public static int Score;

        public static MonsterBehavior CurrentBehavior;
        public static ICreature[,] Map = Map_creator.CreateMap(MapPacman);

        public static int PointsEated;
        public static bool IsMonsterStyle;
        internal static Keys KeyPressed;

        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static Directions PacMansDirection;

        public static bool CanMoveToLeft(int x, int y) => x - 1 >= 0 && !(Map[x - 1, y] is Wall);

        public static bool CanMoveToRight(int x, int y) => x + 1 < MapWidth && !(Map[x + 1, y] is Wall);

        public static bool CanMoveToDown(int x, int y) => y + 1 < MapHeight && !(Map[x, y + 1] is Wall);

        public static bool CanMoveToUp(int x, int y) => y - 1 >= 0 && !(Map[x, y - 1] is Wall);

        public static bool InBounds(Point point)
        {
            var rect = new Rectangle(0, 0, MapWidth, MapHeight);
            return rect.Contains(point);
        }


    }
}
