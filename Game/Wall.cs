using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Wall : ICreature
    {
        public Directions CurrentDirection { get; set; }

        public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject, Game game) => false;

        public int GetDrawingPriority() => 1;

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
