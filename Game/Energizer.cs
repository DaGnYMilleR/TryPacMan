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
        private string Image = "Energizer.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if(conflictedObject is PackMan)
            {
                Game.Score += 50;
                Game.IsMonsterStyle = true;
                return true;
            }
            return false;
        }

        public int GetDrawingPriority() => 1;

        public string GetImageFileName() => Image;
    }
}
