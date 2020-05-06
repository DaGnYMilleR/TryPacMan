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
        public override CreatureCommand Act(int x, int y)
        {
            var goal = FindGoal(Game.PackMansPosition, Game.BlinkysPosition);
            var movement = FindAct(x, y, goal, new Point(Game.MapWidth, Game.MapHeight));
            Game.InkyPosition.Add(new Point(movement.DeltaX, movement.DeltaY));
            return movement;
        }

        public Point FindGoal(Point pacmansPos, Point blinkysPos)
        {
            var twoCellsBeforePacman = Get2CellsBeforePacman(pacmansPos);
            var width = twoCellsBeforePacman.X - blinkysPos.X;
            var height = twoCellsBeforePacman.Y - blinkysPos.Y;

            var result = new Point(twoCellsBeforePacman.X + width, twoCellsBeforePacman.Y + height);
            if (Game.InBounds(result) && !(Game.Map[result.X, result.Y].FirstOrDefault() is Wall))
                return result;
            return twoCellsBeforePacman;
        }

        public override bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is PackMan && Game.IsMonsterStyle)
            {
                RespawnGhost(new Inky(Directions.Right));
                return true;
            }
            return false;
        }
        public Point Get2CellsBeforePacman(Point pacmanPos) => GetNCellsBeforePoint(pacmanPos, Game.PacMansDirection, 2);
    }
}