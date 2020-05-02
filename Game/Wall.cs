using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Wall : ICreature
    {
        private string Image = "Wall.png";
        public Directions CurrentDirection { get; set; }

        public virtual CreatureCommand Act(int x, int y) => new CreatureCommand();

        public virtual bool DeadInConflict(ICreature conflictedObject) => false;

        public virtual int GetDrawingPriority() => 1;

        public virtual string GetImageFileName() => Image;
    }

    class Door : Wall
    {
        private string Image = "Door.png";

        public override CreatureCommand Act(int x, int y) => new CreatureCommand();

        public override bool DeadInConflict(ICreature conflictedObject) => false;

        public override int GetDrawingPriority() => 9;

        public override string GetImageFileName() => Image;
    }
}
