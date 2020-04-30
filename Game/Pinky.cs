using System.Drawing;

namespace Game
{
    class Pinky : Ghost
    {
        private string Image;
        public Pinky(Directions dir)
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

        private static Point GetGoal()
        {


        }
    

        public override int GetDrawingPriority() => 4;

        public override string GetImageFileName() => Image;
    }
}
