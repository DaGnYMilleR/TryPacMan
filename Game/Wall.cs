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

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;

        public int GetDrawingPriority() => 1;

        public string GetImageFileName() => Image;
    }

    class Door : ICreature
    {
        private string Image = "Door.png";
        public Directions CurrentDirection { get; set; }

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;

        public int GetDrawingPriority() => 9;

        public string GetImageFileName() => Image;
    }
}
