using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Fruit : ICreature
    {
        public Directions CurrentDirection { get; set; } = Directions.Nothing;

        public CreatureCommand Act(int x, int y)
        {
            if (Game.PointsEated >= 70)
            {
                Game.Map[14, 14].Add(new Bonus());
                Game.PointsEated = 0;
                Game.CountBonus++;
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is PackMan)
            {
                Game.Score += 10;
                Game.PointsEated++;
                Game.Audio.Play();
                return true;
            }
            return false;
        }

        public int GetDrawingPriority() => 2;
    }
}