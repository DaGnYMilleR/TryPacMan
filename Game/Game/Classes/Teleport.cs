using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Teleport : ICreature
    {
        public List<Point> teleports = new List<Point>();
        public Dictionary<Point, Point> EntranceExitPairs = new Dictionary<Point, Point>();
        public Point Entrance;
        public Point Exit;

        public Teleport()
        {
            teleports = new List<Point>();
        }

        public Teleport(Point point)
        {
            Entrance = point;
            teleports.Add(point);
        }

        public Directions CurrentDirection { get; set; }

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public void AddTeleport(Point point)
        {
            if (teleports.Count > 2)
                throw new Exception("third teleport?");
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

        public bool DeadInConflict(ICreature conflictedObject) => false;
    }
}