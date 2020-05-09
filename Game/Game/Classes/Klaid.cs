using System;
using System.Drawing;

namespace Game
{
    class Klaid : Ghost
    {
        public Klaid(Directions dir)
        {
            CurrentDirection = dir;
        }
        public override CreatureCommand Act(int x, int y)
        {
            var goal = GetGoal(x, y);
            var movement = FindAct(x, y, goal, new Point(-1, Game.MapHeight));
            Game.KlaidPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
        }

        public static Point GetGoal(int x, int y)
        {
            if (Math.Sqrt(GetDistanceSquare(new Point(x, y), Game.PackMansPosition)) > 8)
                return Game.PackMansPosition;
            return new Point(0, Game.MapHeight - 1);
        }
    }
}