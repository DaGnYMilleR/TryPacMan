using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Inky : Ghost
    {
        public Inky(Directions dir)
        {
            CurrentDirection = dir;
        }
        private string Image= "InkyUp.png";
        private ImageList PacmanImages = new ImageList(); // Доделать добаваить все картинки м.ь. при инициализации разобраться с путем до картинки
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
                    var movement1 = FindPath(x, y, new Point(Game.MapWidth - 1, 0));
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

        public override int GetDrawingPriority() => 6;


        public override string GetImageFileName()
        {
            if (Game.IsMonsterStyle)
                return BlueMonsters;
            switch (CurrentDirection)
            {
                case Directions.Up:
                    Image = "InkyUp.png";
                    break;
                case Directions.Right:
                    Image = "InkyRight.png";
                    break;
                case Directions.Down:
                    Image = "InkyDown.png";
                    break;
                case Directions.Left:
                    Image = "InkyLeft.png";
                    break;
            }
            return Image;
        }
    }
}
