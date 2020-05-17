using System.Drawing;

namespace Game
{
    public class CreatureAnimation
    {
        public Point Location;
        public Point TargetLogicalLocation;

        public string CreaturesName;
        public Directions CreaturesDirection;

        internal CreatureCommand Command { get; set; }
        internal ICreature Creature { get; set; }
    }
}