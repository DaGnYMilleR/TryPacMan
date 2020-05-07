using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Bonus : ICreature
    {
        public Directions CurrentDirection { get; set; } = Directions.Nothing;

        public CreatureCommand Act(int x, int y)
        {
            BonusOff();
            return new CreatureCommand();
        }
        private static async void BonusOff()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(8000);
                if (Game.CountBonus == 1)
                    if (Game.Map[14, 14].FirstOrDefault() != null)
                        Game.Map[14, 14].RemoveAt(0);
                Game.CountBonus--;
            });
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is PackMan)
            {
                Game.Score += 100;
                return true;
            }
            return false;
        }
    }
}