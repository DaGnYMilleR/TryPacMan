using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{

    class PackMan : ICreature
    {

        public Directions CurrentDirection { get => CurrentDirection; set => GetDirection(); } 
        private string Image;
        private bool Tick;

        public CreatureCommand Act(int x, int y, Game game)
        {
            switch (CurrentDirection)
            {
                case Directions.Up:
                    if (game.CanMoveToUp(x, y))
                        return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
                    break;
                case Directions.Down:
                    if (game.CanMoveToDown(x, y))
                        return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                    break;
                case Directions.Left:
                    if (game.CanMoveToLeft(x, y))
                        return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
                    break;
                case Directions.Right:
                    if (game.CanMoveToRight(x, y))
                        return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
                    break;
            }
            return new CreatureCommand();
        }



        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            return conflictedObject is Ghost && !game.IsMonsterStyle;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            Tick = !Tick;
            switch (CurrentDirection)
            {
                case Directions.Up:
                    if (Tick == true)
                        return "Pacman 1 1.png";
                    else
                        return "Pacman 1 2.png";
                case Directions.Right:
                    if (Tick == true)
                        return "Pacman 2 1.png";
                    else
                        return "Pacman 2 2.png";
                case Directions.Down:
                    if (Tick == true)
                        return "Pacman 3 1.png";
                    else
                        return "Pacman 3 2.png";
                case Directions.Left:
                    if (Tick == true)
                        return "Pacman 4 1.png";
                    else
                        return "Pacman 4 2.png";
            }
            return "Pacman 0.png";

        }

        public void GetDirection()
        {
            switch (Game.KeyPressed)
            {
                case Keys.Up:
                    CurrentDirection = Directions.Up;
                    break;
                case Keys.Down:
                    CurrentDirection = Directions.Down;
                    break;
                case Keys.Left:
                    CurrentDirection = Directions.Left;
                    break;
                case Keys.Right:
                    CurrentDirection = Directions.Right;
                    break;
                default:
                    CurrentDirection = Directions.Nothing;
                    break;
            }
        }


    }
}

