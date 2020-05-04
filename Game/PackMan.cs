using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class PackMan : ICreature
    {
        public Directions CurrentDirection { get; set;}
        private bool Tick;
        private Point prevPoint;
        public PackMan(Directions dir)
        {
            CurrentDirection = dir;
        }

        public CreatureCommand Act(int x, int y)
        {
            var a = new Audio();
            GetDirection(x,y);
            if (Game.LeftTeleport == new Point(x - 1, y) && CurrentDirection == Directions.Left)
            {
                Game.PackMansPosition = PointExtenshions.Add(Game.RightTeleport, new Point(-1, 0));
                return new CreatureCommand { DeltaX = Game.MapWidth - 1, DeltaY = 0 };
            }
            if (Game.RightTeleport == new Point(x + 1, y) && CurrentDirection == Directions.Right)
            {
                Game.PackMansPosition = PointExtenshions.Add(Game.LeftTeleport, new Point(1, 0));
                return new CreatureCommand { DeltaX = -Game.MapWidth + 1, DeltaY = 0 };
            }
            switch (CurrentDirection)
            {
                case Directions.Up:
                    if (Game.CanMoveToUp(x, y))
                    {
                        Game.PackMansPosition = PointExtenshions.Add(new Point(x, y), new Point(0, -1));
                        return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
                    }
                    break;
                case Directions.Down:
                    if (Game.CanMoveToDown(x, y))
                    {
                        Game.PackMansPosition = PointExtenshions.Add(new Point(x, y), new Point(0, 1));
                        return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                    }
                    break;
                case Directions.Left:
                    if (Game.CanMoveToLeft(x, y))
                    {
                        Game.PackMansPosition = PointExtenshions.Add(new Point(x, y), new Point(-1, 0));
                        return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
                    }
                    break;
                case Directions.Right:
                    if (Game.CanMoveToRight(x, y))
                    {
                        Game.PackMansPosition = PointExtenshions.Add(new Point(x, y), new Point(1, 0));
                        return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
                    }
                    break;
            }
            return new CreatureCommand();
        }



        public bool DeadInConflict(ICreature conflictedObject)
        {
              if(conflictedObject is Ghost && !Game.IsMonsterStyle)
            {
                Game.GameLives--;
                return true;

            }
            return false;
        }

        public int GetDrawingPriority() => 10;

        public string GetImageFileName()
        {
            if (prevPoint != Game.PackMansPosition)
            {
                Tick = !Tick;
                prevPoint = Game.PackMansPosition;
            }
            
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

        public void GetDirection(int x, int y)
        {
            switch (Game.KeyPressed)
            {
                case Keys.Up:
                    if (!(Game.Map[x,y - 1] is Wall))
                        {
                    CurrentDirection = Directions.Up;
                        Game.PacMansDirection = CurrentDirection;
                         }
                    break;
                case Keys.Down:
                    if (!(Game.Map[x , y + 1] is Wall))
                    {
                        CurrentDirection = Directions.Down;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
                case Keys.Left:
                    if (x != 0 &&!(Game.Map[x - 1, y] is Wall))
                    {
                        CurrentDirection = Directions.Left;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
                case Keys.Right:
                    if (x != Game.MapHeight - 1 && !(Game.Map[x + 1, y] is Wall))
                    {
                        CurrentDirection = Directions.Right;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
            }
        }


    }
}

