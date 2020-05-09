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
        public Directions CurrentDirection { get; set; }
        public PackMan(Directions dir)
        {
            CurrentDirection = dir;
        }

        public CreatureCommand Act(int x, int y)
        {
            GetDirection(x, y);
            var currentPosition = new Point(x, y);
            Game.PrevPositionPacman = Game.PackMansPosition;
            if (Game.teleports.teleports.Contains(currentPosition))
            {
                var goal = Game.teleports.EntranceExitPairs[currentPosition];
                if ((goal == Game.teleports.Entrance && CurrentDirection == Directions.Right)
                    || (goal == Game.teleports.Exit && CurrentDirection == Directions.Left))
                {
                    var movement = new Point(goal.X - x, goal.Y - y);
                    Game.PackMansPosition = currentPosition.Add(goal);
                    return new CreatureCommand { DeltaX = movement.X, DeltaY = movement.Y };
                }
            }
            switch (CurrentDirection)
            {
                case Directions.Up:
                    if (Game.CanMoveToUp(x, y))
                        return Move(0, -1, currentPosition);
                    break;
                case Directions.Down:
                    if (Game.CanMoveToDown(x, y))
                        return Move(0, 1, currentPosition);
                    break;
                case Directions.Left:
                    if (Game.CanMoveToLeft(x, y))
                        return Move(-1, 0, currentPosition);
                    break;
                case Directions.Right:
                    if (Game.CanMoveToRight(x, y))
                        return Move(1, 0, currentPosition);
                    break;
            }
            return new CreatureCommand();
        }

        private static CreatureCommand Move(int x, int y, Point currentPosition)
        {
            Game.PackMansPosition = PointExtenshions.Add(currentPosition, new Point(x, y));
            return new CreatureCommand { DeltaX = x, DeltaY = y };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
                var pointBefore = Direction.directions[CurrentDirection];
                if ((conflictedObject is Ghost || IsGhost(Game.Map[pointBefore.X + Game.PackMansPosition.X, pointBefore.Y + Game.PackMansPosition.Y])) && !Game.IsMonsterStyle)
                {
                    Game.GameLives--;
                    Game.Reloge();
                    return true;

                }
            return false;
        }

        private static bool IsGhost(List<ICreature> list)
        {
            foreach (var item in list)
                if (item is Ghost)
                    return true;
            return false;
        }

        public void GetDirection(int x, int y)
        {
            lock (Game.Map)
            {
                switch (Game.KeyPressed)
                {
                    case Keys.Up:
                        if (!(Game.Map[x, y - 1].FirstOrDefault() is Wall))
                        {
                            CurrentDirection = Directions.Up;
                            Game.PacMansDirection = CurrentDirection;
                        }
                        break;
                    case Keys.Down:
                        if (!(Game.Map[x, y + 1].FirstOrDefault() is Wall))
                        {
                            CurrentDirection = Directions.Down;
                            Game.PacMansDirection = CurrentDirection;
                        }
                        break;
                    case Keys.Left:
                        if (x != 0 && !(Game.Map[x - 1, y].FirstOrDefault() is Wall))
                        {
                            CurrentDirection = Directions.Left;
                            Game.PacMansDirection = CurrentDirection;
                        }
                        break;
                    case Keys.Right:
                        if (x != Game.MapHeight - 1 && !(Game.Map[x + 1, y].FirstOrDefault() is Wall))
                        {
                            CurrentDirection = Directions.Right;
                            Game.PacMansDirection = CurrentDirection;
                        }
                        break;
                }
            }
        }


    }
}