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
            var goal = GetGoal();
            var movement = FindAct(x, y, goal, new Point(-1, -1));
            Game.PinkyPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
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