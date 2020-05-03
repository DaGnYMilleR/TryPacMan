using System.Drawing;

namespace Game
{
    class Pinky : Ghost
    {
        private string Image = "PinkyUp.png";
        
        public Pinky(Directions dir)
        {
            CurrentDirection = dir;
        }

        public override CreatureCommand Act(int x, int y)
        {
            
            var speed = ChangeSpeed();

            switch (Game.CurrentBehavior)
            {
                case MonsterBehavior.chase:
                    var goal = GetGoal();
                    var movement = FindPath(x, y, goal);
                    var movementWithSpeed = GetMovementBySpeed(movement, speed, x, y);
                    if (movementWithSpeed != null)
                        return movementWithSpeed;
                    break;

                case MonsterBehavior.scatter:
                    var movement1 = FindPath( x, y, new Point(-1, -1));
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

        public static Point GetGoal()
        {
            var goal = GetNCellsBeforePoint(Game.PackMansPosition, Game.PacMansDirection, 4);
            return goal;
        }
    


        public override string GetImageFileName()
        {
            if (Game.IsMonsterStyle)
                return BlueMonsters;
            switch (CurrentDirection)
            {
                case Directions.Up:
                     Image = "PinkyUp.png";
                    break;
                case Directions.Right:
                    Image = "PinkyRight.png";
                    break;
                case Directions.Down:
                    Image = "PinkyDown.png";
                    break;
                case Directions.Left:
                    Image = "PinkyLeft.png";
                    break;
            }
            return Image;

        }
    }
}
