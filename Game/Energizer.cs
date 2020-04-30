using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Energizer : ICreature
    {
        public Directions CurrentDirection { get; set; }

        public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            if(conflictedObject is PackMan)
            {
                game.Score += 50;
                game.IsMonsterStyle = true;
                return true;
            }
            return false;
        }

        public int GetDrawingPriority() => 1;

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
