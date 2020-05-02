using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Fruit : ICreature
    {
        public Directions CurrentDirection { get; set; }
        private string Image = "Fruit.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is PackMan)
            {
                Game.Score += 10;
                return true;
            }
            return false;
        }

        public int GetDrawingPriority() => 2;


        public string GetImageFileName() => Image;
    }
}
