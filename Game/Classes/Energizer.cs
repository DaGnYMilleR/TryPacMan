using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Energizer : ICreature
    {
        public Directions CurrentDirection { get; set; } = Directions.Nothing;

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if(conflictedObject is PackMan)
            {
                Game.Score += 50;
                Game.IsMonsterStyle = true;
                Game.CurrentBehavior = MonsterBehavior.frightened;
                Interlocked.Increment(ref Game.CountEnergizer);
                MonsterStyleOn();
                return true;
            }
            return false;
        }
        private static async void MonsterStyleOn()//  TODO class interlocked
        {
            await Task.Run(() =>
            {
                Thread.Sleep(8000);
                if (Game.CountEnergizer >= 1)
                {
                    Game.IsMonsterStyle = false;
                    Game.CurrentBehavior = MonsterBehavior.chase;
                }
                Interlocked.Decrement(ref Game.CountEnergizer);
            });
        }
    }
}
