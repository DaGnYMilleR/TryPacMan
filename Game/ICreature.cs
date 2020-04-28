﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICreature
    {
        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y, Game game);
        bool DeadInConflict(ICreature conflictedObject, Game game);
        string Direction {get; set;}
    }
}
