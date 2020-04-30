using System;
using System.Drawing;
using System.Linq;

namespace Game
{
    class Ghost : ICreature
    {
        public Directions CurrentDirection { get; set; }

        public virtual CreatureCommand Act(int x, int y, Game game)
        {
            throw new System.NotImplementedException();
        }
        
        public bool DeadInConflict(ICreature conflictedObject, Game game)
                        => conflictedObject is PackMan && game.IsMonsterStyle;

        public virtual int GetDrawingPriority()
        {
            throw new System.NotImplementedException();
        }

        public virtual string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }

        public CreatureCommand FindPath(Game game, int x, int y, Point goal) // принимает начальную позицию и цель. Возвращает следующую точку и обновляет CurrDir
        {
            var path = BFS.FindPaths(game, new Point(x, y), goal, CurrentDirection).ToList();
            if (path == null)
                throw new Exception($"Not path found for {GetType().Name}");
            var nextPoint = path[path.Count - 2];
            var movement = new Point(nextPoint.X - x, nextPoint.Y - y);
            CurrentDirection = Direction.reversedDirections[movement];

            return new CreatureCommand { DeltaX = movement.X, DeltaY = movement.Y };
        }

        public static CreatureCommand GetMovementBySpeed(Game game, CreatureCommand movement, int speed, int x, int y)// возвращает точку, позволяет избежать ошибки выхода за массив
        {
            for (var i = speed; i >= 0; i--)
            {
                var tryToMove = movement * i;
                if (game.InBounds(new Point(x + tryToMove.DeltaX, y + tryToMove.DeltaY)))
                    return movement;
            }
            return null;
        }

        public CreatureCommand FrightenedAlgorithm(Game game, int x, int y) // алгоритм режима испуга. Принимает x, y. Возвращает след точку, обновляет CurrDir
        {
            var rnd = new Random();
            while (true)
            {
                var newX = rnd.Next(-1, 2);
                var newY = rnd.Next(-1, 2);
                if ((newX != newY) && (newX == 0 || newY == 0))
                {
                    if (CanMoveTo(x + newX, y + newY, game)
                        && Direction.reversedDirections[new Point(newX, newY)] != Direction.GetOppositeDirection(CurrentDirection))
                    {
                        CurrentDirection = Direction.reversedDirections[new Point(newX, newY)];
                        return new CreatureCommand { DeltaX = newX, DeltaY = newY };
                    }
                }
            }
        }


        public bool CanMoveTo(int x, int y, Game game)
        {
            return game.InBounds(new Point(x, y)) && !(game.Map[x, y] is Wall);
        }

        public int ChangeSpeed(Game game) // FIX values // изменяет скорость
        {
            double relation = (double)game.PointsAtLevel / game.PointsEated;

            if (relation > 2)
                return 1;

            if (relation > 1.3)
                return 2;
            return 3;
        }
    }
}