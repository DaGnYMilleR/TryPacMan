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
            var goal = FindGoal(Game.PackMansPosition, Game.BlinkysPosition);
            var movement = FindAct(x, y, goal, new Point(Game.MapWidth, Game.MapHeight));
            Game.KlaidPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
        }

        public Point FindGoal(Point pacmansPos, Point blinkysPos)
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