using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Priorities
    {
        static readonly List<string> LowLevelObjects = new List<string>() { "Wall", "Bonus", "Energizer", "Fruit", "Door" };
        static readonly List<string> HighLevelObjects = new List<string>() { "PackMan", "Blinky", "Inky", "Pinky", "Klaid" };

        public static int GetDrawingPriority(string name)
        {
            if (LowLevelObjects.Contains(name))
                return 1;
            if (HighLevelObjects.Contains(name))
                return 2;
            throw new Exception($"Wrong objects name {name}");
        }
    }
}