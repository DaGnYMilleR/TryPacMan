﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Energizer : ICreature
    {
        public Directions CurrentDirection { get; set; }
        private string Image = "Energizer.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if(conflictedObject is PackMan)
            {
                Game.Score += 50;
                Game.IsMonsterStyle = true;
                Game.CountEnergizer++;
                MonserStyleOn();
                return true;
            }
            return false;
        }
        private static async void MonserStyleOn()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(8000);
                if (Game.CountEnergizer == 1)
                    Game.IsMonsterStyle = false;
                else
                    Game.CountEnergizer--;
            });
        }

        public int GetDrawingPriority() => 3;

        public string GetImageFileName() => Image;
    }
}
