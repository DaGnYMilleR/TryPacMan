using System.Drawing;

namespace Game
{
    class Pinky : Ghost
    {
        public override string Direction { get => Direction; set => throw new System.NotImplementedException(); }
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