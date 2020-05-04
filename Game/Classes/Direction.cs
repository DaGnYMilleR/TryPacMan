using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game
{
    static class Direction
    {
        public static Dictionary<Directions, Point> directions = new Dictionary<Directions, Point>
        {
            { Directions.Left, new Point(-1, 0) },
            { Directions.Right, new Point(1, 0) },
            { Directions.Up, new Point(0, -1) },
            { Directions.Down, new Point(0, 1) },
            { Directions.Nothing, new Point(0, 0) }
        };

        public static Dictionary<Point, Directions> reversedDirections = new Dictionary<Point, Directions>
        {
            { new Point(-1, 0), Directions.Left },
            { new Point(1, 0), Directions.Right },
            { new Point(0, -1), Directions.Up },
            { new Point(0, 1), Directions.Down },
            { new Point(0, 0), Directions.Nothing }
        };

        public static Directions GetOppositeDirection(Directions dir)
        {
            var point = directions[dir];
            var a = point.Multiply(-1);
            return reversedDirections[a];
        }
    }

    public static class PointExtenshions
    {
        public static Point Multiply(this Point point, int a)
        {
            return new Point(point.X * a, point.Y * a);
        }

        public static Point Add(this Point point, Point otherPoint)
        {
            return new Point(point.X + otherPoint.X, point.Y + otherPoint.Y);
        }
    }

}