using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Wall : ICreature
    {
        public Directions CurrentDirection { get; set; } = Directions.Nothing;

        public virtual CreatureCommand Act(int x, int y) => new CreatureCommand();

        public virtual bool DeadInConflict(ICreature conflictedObject) => false;

        public virtual int GetDrawingPriority() => 1;
    }

    class Door : Wall
    {
        public override CreatureCommand Act(int x, int y) => new CreatureCommand();

        public override bool DeadInConflict(ICreature conflictedObject) => false;

        public override int GetDrawingPriority() => 9;
    }
}
