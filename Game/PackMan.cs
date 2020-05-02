﻿using System;
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
        public Directions CurrentDirection { get; set; }
        private bool Tick;

        public CreatureCommand Act(int x, int y)
        {
            GetDirection();
            if (Game.LeftTeleport == new Point(x - 1, y) && CurrentDirection == Directions.Left)
                return new CreatureCommand { DeltaX = 28, DeltaY = 0 };
            if (Game.RightTeleport == new Point(x + 1, y) && CurrentDirection == Directions.Right)
                return new CreatureCommand { DeltaX = -28, DeltaY = 0 };
            switch (CurrentDirection)
            {
                case Directions.Up:
                    if (Game.CanMoveToUp(x, y))
                        return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
                    break;
                case Directions.Down:
                    if (Game.CanMoveToDown(x, y))
                        return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                    break;
                case Directions.Left:
                    if (Game.CanMoveToLeft(x, y))
                        return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
                    break;
                case Directions.Right:
                    if (Game.CanMoveToRight(x, y))
                        return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
                    break;
            }
            return new CreatureCommand { DeltaX = Direction.directions[CurrentDirection].X,
                DeltaY = Direction.directions[CurrentDirection].Y };
        }



        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Ghost && !Game.IsMonsterStyle;
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
                    if (CurrentDirection != Directions.Down)
                    {
                        CurrentDirection = Directions.Up;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
                case Keys.Down:
                    if (CurrentDirection != Directions.Up)
                    {
                        CurrentDirection = Directions.Down;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
                case Keys.Left:
                    if (CurrentDirection != Directions.Right)
                    {
                        CurrentDirection = Directions.Left;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
                case Keys.Right:
                    if (CurrentDirection != Directions.Left)
                    {
                        CurrentDirection = Directions.Right;
                        Game.PacMansDirection = CurrentDirection;
                    }
                    break;
            }
        }


    }
}

