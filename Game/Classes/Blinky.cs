using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Blinky : Ghost
    {
        public Blinky(Directions dir)
        {
            CurrentDirection = dir;
        }

        public override CreatureCommand Act(int x, int y)
        {
            var goal = Game.PackMansPosition;
            var movement = FindAct(x, y, goal, new Point(Game.MapWidth, 0));
            Game.BlinkysPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
        }

    }
}