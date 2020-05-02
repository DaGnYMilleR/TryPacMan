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
        CreatureCommand Act(int x, int y);
        bool DeadInConflict(ICreature conflictedObject);
    }
}
