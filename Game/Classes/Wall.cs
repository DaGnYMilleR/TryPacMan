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
            if (deleted)
            {
                deleted = !deleted;
                //Console.WriteLine("Door, " + deleted.ToString());
                Await();
            }
            return new CreatureCommand();
        }

        public override bool DeadInConflict(ICreature conflictedObject) => false;

        private void Await()
        {
            //Console.WriteLine("here");
            Task.Run(() =>
            {
                //Console.WriteLine("me to");
                Thread.Sleep(1000);
                //Console.WriteLine("number 2");
                if (Game.Map[14, 11].FirstOrDefault() != null || Game.Map[14, 11].FirstOrDefault() is Door)
                // Game.Map[14, 11].RemoveAt(0);
                {
                  //  Console.WriteLine(Game.Map[14, 11].FirstOrDefault().ToString() + " 1");
                    //Interlocked.Exchange(ref Game.Map[14, 11], new List<ICreature>());
                    Game.Map[14, 11].RemoveAt(0);
                    //Console.WriteLine(Game.Map[14, 11].FirstOrDefault().ToString() + " 2");
                }
            });
        }
    }
}
