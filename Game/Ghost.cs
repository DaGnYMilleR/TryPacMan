namespace Game
{
    class Ghost : ICreature
    {
        public virtual string Direction { get=> throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public virtual CreatureCommand Act(int x, int y, Game game)
        {
            throw new System.NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            throw new System.NotImplementedException();
        }

        public virtual int GetDrawingPriority()
        {
            throw new System.NotImplementedException();
        }

        public virtual string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }
    }
}