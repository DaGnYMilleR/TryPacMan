using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CreatureCommand
    {
        public int DeltaX;
        public int DeltaY;
        
        public static CreatureCommand operator * (CreatureCommand command, int a)
        {
            return new CreatureCommand { DeltaX = command.DeltaX * a, DeltaY = command.DeltaY * a };
        }

    }
}
