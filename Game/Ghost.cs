using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game
{
    class Ghost : ICreature
    {
        public const int mapDiagonalSize = 900;
        public string BlueMonsters = "GhostIsMonsterStyle.png";
        public static Point[] possibleMoves = new Point[] { new Point(1, 0), new Point(0, -1), new Point(-1, 0), new Point(0, 1) };
        public Directions CurrentDirection { get; set; }

        public virtual CreatureCommand Act(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject)
                        => conflictedObject is PackMan && Game.IsMonsterStyle;

        public int GetDrawingPriority() => 4;
      

        public virtual string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public CreatureCommand FindPath(int x, int y, Point goal) // принимает начальную позицию и цель. Возвращает следующую точку и обновляет CurrDir
        {
            var oppositeDirecrion = Direction.GetOppositeDirection(CurrentDirection);
            var oppositePoint = Direction.directions[oppositeDirecrion];
            var minDist = mapDiagonalSize;
            var result = new Point();
            foreach (var neighbor in GetNeighbors(new Point(x, y)))
            {
                var distSquare = GetDistanceSquare(neighbor, goal);
                var movement = new Point(neighbor.X - x, neighbor.Y - y);
                if (distSquare <= minDist && movement != oppositePoint)
                {
                    minDist = distSquare;
                    result = movement;
                }
            }
            if (result.X == 28)
                CurrentDirection = Directions.Left;
            else if (result.X == -28)
                CurrentDirection = Directions.Right;
            else
                CurrentDirection = Direction.reversedDirections[result];

            return new CreatureCommand { DeltaX = result.X, DeltaY = result.Y };
        }

        protected static int GetDistanceSquare(Point start, Point goal)
        {
            var width = start.X - goal.X;
            var height = start.Y - goal.Y;

            return width * width + height * height;
        }

        protected static IEnumerable<Point> GetNeighbors(Point point)
        {
            foreach (var newPoint in possibleMoves)
            {
                var neighbor = point.Add(newPoint);
                if (neighbor == Game.LeftTeleport || neighbor == Game.RightTeleport)
                    yield return Game.Teleports[neighbor];
                if (CanMoveTo(neighbor))
                    yield return neighbor;
            }
        }

        public static CreatureCommand GetMovementBySpeed(CreatureCommand movement, int speed, int x, int y)// возвращает точку, позволяет избежать ошибки выхода за массив
        {
            for (var i = speed; i >= 0; i--)
            {
                var tryToMove = movement * i;
                if (CanMoveTo(new Point(x + tryToMove.DeltaX, y + tryToMove.DeltaY)))
                    return tryToMove;
            }
            return null;
        }

        public CreatureCommand FrightenedAlgorithm(int x, int y) // алгоритм режима испуга. Принимает x, y. Возвращает след точку, обновляет CurrDir
        {
            var rnd = new Random();
            while (true)
            {
                var newX = rnd.Next(-1, 2);
                var newY = rnd.Next(-1, 2);
                if ((newX != newY) && (newX == 0 || newY == 0))
                {
                    var newPoint = new Point(x + newX, y + newY);
                    if (Game.Teleports.ContainsKey(newPoint))
                    {
                        var movement = Game.Teleports[newPoint];
                        return new CreatureCommand { DeltaX = movement.X, DeltaY = movement.Y };
                    }
                    if (CanMoveTo(newPoint)
                        && Direction.reversedDirections[new Point(newX, newY)] != Direction.GetOppositeDirection(CurrentDirection))
                    {
                        CurrentDirection = Direction.reversedDirections[new Point(newX, newY)];
                        return new CreatureCommand { DeltaX = newX, DeltaY = newY };
                    }
                }
            }
        }

        public static Point GetNCellsBeforePoint(Point point, Directions dir, int n)
        {
            var vector = Direction.directions[dir];

            for (var i = n; i > 0; i--)
            {
                var move = vector.Multiply(i);
                var newPoint = point.Add(move);
                if (Game.InBounds(newPoint) && !(Game.Map[newPoint.X, newPoint.Y] is Wall))
                    return newPoint;
            }
            return point;
        }

        public static bool CanMoveTo(Point point)
        {
            return Game.InBounds(point) && !(Game.Map[point.X, point.Y] is Wall);
        }

        public static int ChangeSpeed() // FIX values // изменяет скорость
        {
            if (Game.PointsEated == 0)
                return 1;
            double relation = (double)Game.PointsAtLevel / Game.PointsEated;

            if (relation > 2)
                return 1;

            if (relation > 1.3)
                return 2;
            return 3;
        }
    }
}