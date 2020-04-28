using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CreatureCommand
    {
        public double DeltaX;
        public double DeltaY;
        public ICreature TransformTo;
        
        public static CreatureCommand operator * (CreatureCommand command, double a)
        {
            return new CreatureCommand { DeltaX = command.DeltaX * a, DeltaY = command.DeltaY * a, TransformTo = command.TransformTo };
        }

    }
}
