using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{

    class PackMan : ICreature
    {

        public string Direction { get => Direction; set => GetDirection(Direction); }

        public CreatureCommand Act(int x, int y, Game game)
        {
            switch (Direction)
            {
                case "Up":
                    if (y > 0 && !(Game.Map[x, y - 1] is Wall))
                        return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
                    break;
                case "Down":
                    if (y < Game.MapHeight - 1 && !(Game.Map[x, y + 1] is Wall))
                        return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                    break;
                case "Left":
                    if (x > 0 && !(Game.Map[x - 1, y] is Wall))
                        return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
                    break;
                case "Right":
                    if (x < Game.MapWidth - 1 && !(Game.Map[x + 1, y] is Wall))
                        return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
                    break;
            }
            return new CreatureCommand();
        }

        

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            return conflictedObject is Ghost && !game.IsMonsterStyle;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public string GetDirection(string curDirection)
        {
            switch (Game.KeyPressed)
            {
                case Keys.Up:
                    return "Up";
                case Keys.Down:
                        return "Down";
                case Keys.Left:
                        return "Left";
                case Keys.Right:
                        return "Right";
            }
            return curDirection;
        }


    }
}

