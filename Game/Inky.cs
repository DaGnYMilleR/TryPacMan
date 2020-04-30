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
        public override CreatureCommand Act(int x, int y, Game game)
        {
            var goal = game.PackMansPosition;
            var speed = ChangeSpeed(game);

            switch (game.CurrentBehavior)
            {
                case MonsterBehavior.chase:
                    var movement = FindPath(game, x, y, goal);
                    var movementWithSpeed = GetMovementBySpeed(game, movement, speed, x, y);
                    if (movementWithSpeed != null)
                        return movementWithSpeed;
                    break;

                case MonsterBehavior.scatter:
                    var movement1 = FindPath(game, x, y, new Point(game.MapWidth - 1, 0));
                    var movementWithSpeed1 = GetMovementBySpeed(game, movement1, speed, x, y);
                    if (movementWithSpeed1 != null)
                        return movementWithSpeed1;
                    break;

                case MonsterBehavior.frightened:
                    var movement2 = FrightenedAlgorithm(game, x, y);
                    var movementWithSpeed2 = GetMovementBySpeed(game, movement2, speed, x, y);
                    if (movementWithSpeed2 != null)
                        return movementWithSpeed2;
                    break;

                default:
                    return new CreatureCommand();
            }
            return new CreatureCommand();
        }

        public Point FindGoal(Point pacmansPos, Point blinkysPos, Game game)
        {
            throw new Exception(); 
        }


        public override int GetDrawingPriority() => 3;


        public override string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
