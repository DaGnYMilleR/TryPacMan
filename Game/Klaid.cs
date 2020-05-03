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
        private string Image = "KlaidUp.png";
        public override CreatureCommand Act(int x, int y)
        {
            var goal = GetGoal(x, y);
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
                    var movement1 = FindPath( x, y, new Point(-1, Game.MapHeight));
                    var movementWithSpeed1 = GetMovementBySpeed(movement1, speed, x, y);
                    if (movementWithSpeed1 != null)
                        return movementWithSpeed1;
                    break;

                case MonsterBehavior.frightened:
                    var movement2 = FrightenedAlgorithm( x, y);
                    var movementWithSpeed2 = GetMovementBySpeed( movement2, speed, x, y);
                    if (movementWithSpeed2 != null)
                        return movementWithSpeed2;
                    break;

                default:
                    return new CreatureCommand();
            }
            return new CreatureCommand();
        }
        public static Point GetGoal(int x, int y)
        {
            if (Math.Sqrt(GetDistanceSquare(new Point(x, y), Game.PackMansPosition)) > 8)
                return Game.PackMansPosition;
            else
                return new Point(0, Game.MapHeight - 1);
        }


        public override string GetImageFileName()
        {
            if (Game.IsMonsterStyle)
                return BlueMonsters;
            switch (CurrentDirection)
            {
                case Directions.Up:
                    Image = "KlaidUp.png";
                    break;
                case Directions.Right:
                    Image = "KlaidRight.png";
                    break;
                case Directions.Down:
                    Image = "KlaidDown.png";
                    break;
                case Directions.Left:
                    Image = "KlaidLeft.png";
                    break;
            }
            return Image;
        }
    }
}