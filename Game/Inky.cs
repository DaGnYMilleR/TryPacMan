using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Inky : Ghost
    {
        public Inky(Directions dir)
        {
            CurrentDirection = dir;
        }
        private string Image = "InkyUp.png";
        public override CreatureCommand Act(int x, int y)
        {
            var speed = ChangeSpeed();

            switch (Game.CurrentBehavior)
            {
                case MonsterBehavior.chase:
                    var goal = FindGoal(Game.PackMansPosition, Game.BlinkysPosition);
                    var movement = FindPath(x, y, goal);
                    var movementWithSpeed = GetMovementBySpeed(movement, speed, x, y);
                    if (movementWithSpeed != null)
                        return movementWithSpeed;
                    break;

                case MonsterBehavior.scatter:
                    var movement1 = FindPath(x, y, new Point(Game.MapWidth - 2, Game.MapHeight - 2));
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

        public Point FindGoal(Point pacmansPos, Point blinkysPos) //придумать красивое решение
        {
            var twoCellsBeforePacman = Get2CellsBeforePacman(pacmansPos);
            var width = twoCellsBeforePacman.X - blinkysPos.X;
            var height = twoCellsBeforePacman.Y - blinkysPos.Y;

            var result = new Point(twoCellsBeforePacman.X + width, twoCellsBeforePacman.Y + height);
            if (Game.InBounds(result) && !(Game.Map[result.X, result.Y] is Wall))
                return result;
            return twoCellsBeforePacman;
        }

        public Point Get2CellsBeforePacman(Point pacmanPos) => GetNCellsBeforePoint(pacmanPos, Game.PacMansDirection, 2);

        public override int GetDrawingPriority() => 3;


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