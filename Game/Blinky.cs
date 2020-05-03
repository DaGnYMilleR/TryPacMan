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
            var speed = ChangeSpeed();

            switch (Game.CurrentBehavior)
            {
                case MonsterBehavior.chase:
                    var movement = FindPath(x, y, goal);
                    var movementWithSpeed = GetMovementBySpeed(movement, speed, x, y);
                    if (movementWithSpeed != null)
                        return movementWithSpeed;
                    break;

                case MonsterBehavior.scatter:
                    var movement1 = FindPath(x, y, new Point(Game.MapWidth, -1));
                    var movementWithSpeed1 = GetMovementBySpeed(movement1, speed, x, y);
                    if (movementWithSpeed1 != null)
                        return movementWithSpeed1;
                    break;

                case MonsterBehavior.frightened:
                    var movement2 = FrightenedAlgorithm(x, y);
                    var movementWithSpeed2 = GetMovementBySpeed(movement2, speed, x, y);
                    if (movementWithSpeed2 != null)
                        return movementWithSpeed2;
                    break;

                default:
                    return new CreatureCommand();
            }
            return new CreatureCommand();
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