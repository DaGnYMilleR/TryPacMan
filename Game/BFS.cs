using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BFS
    {
        public static IEnumerable<Point> GetNeighbors(Point point)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                {
                    if (i != j && (i == 0 || j == 0))
                        yield return new Point { X = point.X + i, Y = point.Y + j };
                }
        }

        public static bool IsPointCorrect(Point point)
                            => Game.InBounds(point)
                                && !(Game.Map[point.X, point.Y] is Wall);


        public static SinglyLinkedList<Point> FindPaths(Game game, Point start, Point goal, Point addToVisited)
        {
            var visited = new HashSet<Point>() { addToVisited };
            var queue = new Queue<SinglyLinkedList<Point>>();
            queue.Enqueue(new SinglyLinkedList<Point>(start));
            visited.Add(start);
            while (queue.Count != 0)
            {
                var currentPoint = queue.Dequeue();
                if (goal == currentPoint.Value)
                    return currentPoint;
                if (!IsPointCorrect(currentPoint.Value))
                    continue;

                foreach (var neighbor in GetNeighbors(currentPoint.Value))
                {
                    var currNeighbor = neighbor;

                    if (Game.Teleports.ContainsKey(neighbor))
                        currNeighbor = Game.Teleports[neighbor];

                    if (visited.Contains(currNeighbor))
                        continue;
                    visited.Add(currNeighbor);
                    queue.Enqueue(new SinglyLinkedList<Point>(currNeighbor, currentPoint));
                }

            }
            return null;
        }
    }
}