using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Teleports
    {
        public static List<Point> teleports;
        public static  Dictionary<Point, Point> EntranceExitPairs = new Dictionary<Point, Point>();
        public static Point Entrance;
        public static Point Exit;


        public static void AddTeleport(Point point)
        {
            if (teleports.Count >= 2)
                throw new Exception("Only two teleports on the map)");
            if (teleports.Count == 0)
            {
                Entrance = point;
                teleports.Add(point);
                return;
            }
            Exit = point;
            teleports.Add(point);
            EntranceExitPairs.Add(Entrance, Exit);
            EntranceExitPairs.Add(Exit, Entrance);
        }
    }
}
