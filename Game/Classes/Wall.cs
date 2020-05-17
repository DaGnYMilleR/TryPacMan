using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Wall : ICreature
    {
        public Directions CurrentDirection { get; set; } = Directions.Nothing;
        public virtual CreatureCommand Act(int x, int y) => new CreatureCommand();

        public virtual bool DeadInConflict(ICreature conflictedObject) => false;
    }

    class Door : Wall
    {
        private static bool deleted = true;
        public override CreatureCommand Act(int x, int y)
        {
            //if (deleted)
            //{
            //    deleted = !deleted;
            //    Await();
            //}
            return new CreatureCommand();
        }

        public override bool DeadInConflict(ICreature conflictedObject) => false;

        private static async void Await()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                    if (Game.Map[14, 11].FirstOrDefault() != null || Game.Map[14, 11].FirstOrDefault() is Door)
                    {
                        Game.IsDoorClosed = false;

                    }
            });
        }
    }
}
