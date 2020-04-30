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
        public static IEnumerable<Point> GetNeighbors(Point point, Directions direction)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                {
                    if (i != j && (i == 0 || j == 0)
                        && Direction.reversedDirections[new Point(i, j)] != Direction.GetOppositeDirection(direction))
                        yield return new Point { X = point.X + i, Y = point.Y + j };
                }
        }
        
        public static bool IsPointCorrect(Game game, Point point)
                            => game.InBounds(point)
                                && !(game.Map[point.X, point.Y] is Wall);
        
        
        public static SinglyLinkedList<Point> FindPaths(Game game, Point start, Point goal, Directions direction) // FixDirection: направление нам нужно учитывать только на первой итерации
        {                                                                                                         // MayBeSolution: создать отдельный тип в enum и после первой итерации присваивать его
            var visited = new HashSet<Point>();                                                                   // -- Сделать enum nullable и проверять на null(но тогда по всему проекту value - точно нет)
            var queue = new Queue<SinglyLinkedList<Point>>();
            queue.Enqueue(new SinglyLinkedList<Point>(start));
            visited.Add(start);
            while (queue.Count != 0)
            {
                var currentPoint = queue.Dequeue();
                if (goal == currentPoint.Value)
                    return currentPoint;
                if (!IsPointCorrect(game, currentPoint.Value))
                    continue;
                foreach (var neighbor in GetNeighbors(currentPoint.Value, direction))
                {
                    if (visited.Contains(neighbor))
                        continue;
                    visited.Add(neighbor);
                    queue.Enqueue(new SinglyLinkedList<Point>(neighbor, currentPoint));
                }
            }
            return null;
        }
    }
}

