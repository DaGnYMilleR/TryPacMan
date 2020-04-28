using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Game
    {

        public int PointsAtLevel;
        public static Keys KeyPressed;
        public Point PackMansPosition { get; private set; }
        public int Score;


        public MonsterBehavior CurrentBehavior;
        public static ICreature[,] Map;

        public int PointsEated;
        public bool IsMonsterStyle;

        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static void CreateMap()
        {
            Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrainSackGoldMonster);
        }


        public bool CanMoveToLeft(int x, int y) => x - 1 >= 0 && !(Map[x - 1, y] is Wall);

        public bool CanMoveToRight(int x, int y) => x + 1 < MapWidth && !(Map[x + 1, y] is Wall);

        public bool CanMoveToDown(int x, int y) => y + 1 < MapHeight && !(Map[x, y + 1] is Wall);

        public bool CanMoveToUp(int x, int y) => y - 1 >= 0 && !(Map[x, y - 1] is Wall);

    }
}
