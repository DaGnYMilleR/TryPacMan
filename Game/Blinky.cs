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
        private string Image = "BlinkyUp.png";

        public override CreatureCommand Act(int x, int y)
        {
            var goal = Game.PackMansPosition;
            var movement = FindAct(x, y, goal, new Point(Game.MapWidth, 0));
            Game.BlinkysPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
        }


        public override string GetImageFileName()
        {
            if (Game.IsMonsterStyle)
                return BlueMonsters;
            switch (CurrentDirection)
            {
                case Directions.Up:
                    Image = "BlinkyUp.png";
                    break;
                case Directions.Right:
                    Image = "BlinkyRight.png";
                    break;
                case Directions.Down:
                    Image = "BlinkyDown.png";
                    break;
                case Directions.Left:
                    Image = "BlinkyLeft.png";
                    break;
            }
            return Image;
        }
    }
}