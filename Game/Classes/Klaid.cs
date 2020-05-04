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
            var movement = FindAct(x, y, goal, new Point(-1, Game.MapHeight));
            Game.KlaidPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
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