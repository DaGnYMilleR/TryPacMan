using System.Drawing;

namespace Game
{
    public class CreatureAnimation
    {
        private CreatureCommand command;
        private ICreature creature;
        public Point Location;
        public Point TargetLogicalLocation;

        internal CreatureCommand Command { get => command; set => command = value; }
        internal ICreature Creature { get => creature; set => creature = value; }
    }
}