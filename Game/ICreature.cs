using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICreature
    {
        Directions CurrentDirection { get; set; }
        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y, Game game);
        bool DeadInConflict(ICreature conflictedObject, Game game);
        System.Drawing.Point GetNCellBeforePacman(System.Drawing.Point point, Game game, Direction dir, int n);
    }
}
