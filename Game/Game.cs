using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Game
{
    class Game
    {
        private const string testMap = @"
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
        public int PointsAtLevel;
        public Point PackMansPosition { get; set; }
        public int Score;

        public MonsterBehavior CurrentBehavior;
        public ICreature[,] Map = Map_creator.CreateMap(testMap);

        public int PointsEated;
        public bool IsMonsterStyle;
        internal static Keys KeyPressed;

        public int MapWidth => Map.GetLength(0);
        public int MapHeight => Map.GetLength(1);

        public bool CanMoveToLeft(int x, int y) => x - 1 >= 0 && !(Map[x - 1, y] is Wall);

        public bool CanMoveToRight(int x, int y) => x + 1 < MapWidth && !(Map[x + 1, y] is Wall);

        public bool CanMoveToDown(int x, int y) => y + 1 < MapHeight && !(Map[x, y + 1] is Wall);

        public bool CanMoveToUp(int x, int y) => y - 1 >= 0 && !(Map[x, y - 1] is Wall);

        public bool InBounds(Point point)
        {
            var rect = new Rectangle(0, 0, MapWidth, MapHeight);
            return rect.Contains(point);
        }


    }
}
