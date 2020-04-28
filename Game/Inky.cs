using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Inky : ICreature
    {
        public CreatureCommand Act(int x, int y, Game game)
        {
            throw new NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            throw new NotImplementedException();
        }

        public int GetDrawingPriority()
        {
            throw new NotImplementedException();
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
