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
                Await();
            }
            return new CreatureCommand();
        }

        public override bool DeadInConflict(ICreature conflictedObject) => false;

        private static async void Await()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                lock (Game.Map)
                {
                    if (Game.Map[14, 11].FirstOrDefault() != null || Game.Map[14, 11].FirstOrDefault() is Door)
                    {
                        // Сюда он заходит спокойно
                        // Interlocked.Exchange(ref Game.Map[14, 11], new List<ICreature>());//
                        //Game.Map[14, 11].Clear();
                        Game.IsDoorClosed = false;
                        //Game.Map = Game.UpdateMapCell(14, 11);//
                        //if (Game.Map[14, 11].Count == 0)
                        //    Console.WriteLine("here");
                        //if (Game.Map[14, 11].FirstOrDefault() != null)
                          //  Game.Map[14, 11].RemoveAt(0);
                    }
                    Game.Map[14, 11] = new List<ICreature>() { new Door() };
                }
            });
        }
    }
}
