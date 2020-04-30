using System.Drawing;

namespace Game
{
    class Klaid : Ghost
    {
        public Klaid(Directions dir)
        {
            CurrentDirection = dir;
        }
        public override CreatureCommand Act(int x, int y, Game game)
        {
            throw new System.NotImplementedException();
        }
        private static string GetDirection(Point previousPoint, Point currentPoint)
        {
            throw new System.NotImplementedException();
        }

        public override int GetDrawingPriority()
        {
            throw new System.NotImplementedException();
        }

        public override string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }
    }
}