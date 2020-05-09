using System;
using System.Drawing;

namespace Game
{
    class Pinky : Ghost
    {       
        public Pinky(Directions dir)
        {
            CurrentDirection = dir;
        }

        public override CreatureCommand Act(int x, int y)
        {
            var goal = GetGoal();
            var movement = FindAct(x, y, goal, new Point(-1, -1));
            Game.PinkyPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
        }

        public static Point GetGoal() => GetNCellsBeforePoint(Game.PackMansPosition, Game.PacMansDirection, 4);
    }
}
