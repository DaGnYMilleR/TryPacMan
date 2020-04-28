using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Blinky : ICreature
    {
        public Directions CurrentDirection { get; private set; }

        public CreatureCommand Act(int x, int y, Game game)
        {
            var goal = game.PackMansPosition;
            var speed = ChangeSpeed(game);

            switch (game.CurrentBehavior)
            {
                case MonsterBehavior.chase:
                    return FindPath(game, x, y, goal) * speed;

                case MonsterBehavior.scatter:
                    return FindPath(game, x, y, new Point(game.MapWidth + 1, -1)) * speed;

                case MonsterBehavior.frightened:
                    return FrightenedAlgorithm(game, x, y, goal);

                default:
                    return new CreatureCommand();
            }
        }

        public CreatureCommand FindPath(Game game, int x, int y, Point goal)
        {
            var nextPoint = BFS.FindPaths(game, new Point(x, y), goal, CurrentDirection);
            var movement = new Point(nextPoint.X - x, nextPoint.Y - y);
            CurrentDirection =  GetDirection(x, y, nextPoint.X, nextPoint.Y);

            return new CreatureCommand { DeltaX = movement.X, DeltaY = movement.Y };
        }


        CreatureCommand FrightenedAlgorithm(Game game, int x, int y, Point goal)
        {
            var rnd = new Random();
            while (true)
            {
                var newX = rnd.Next(-1, 2);
                var newY = rnd.Next(-1, 2);
                if ((newX != newY) && (newX == 0 || newY == 0))
                {
                    var direction = GetDirection(x, y, newX, newY);
                    if (CanMoveTo(newX, newY, game) && direction != OppositeDirection())
                    {
                        CurrentDirection = direction;
                        return new CreatureCommand { DeltaX = newX, DeltaY = newY };
                    }
                }
            }

        }

        public bool CanMoveTo(int x, int y, Game game)
        {
            return !(game.Map[x, y] is Wall);
        }

        Directions GetDirection(int x, int y, int newX, int newY)
        {
            var dir = CurrentDirection;
            if (x > newX)
                dir = Directions.Left;
            else if (x < newX)
                dir = Directions.Right;
            else if (y > newY)
                dir = Directions.Down;
            else
                dir = Directions.Up;
            return dir;
        }

        public Directions OppositeDirection()
        {
            switch(CurrentDirection)
            {
                case Directions.Down:
                    return Directions.Up;
                case Directions.Up:
                    return Directions.Down;
                case Directions.Right:
                    return Directions.Left;
                case Directions.Left:
                    return Directions.Right;
                default:
                    throw new Exception("It`s can`t to be!");
            }
        }

        public double ChangeSpeed(Game game) // FIX values
        {
            double relation = (double)game.PointsAtLevel / game.PointsEated;

            if (GarbidgeFix_.DoubleComparerFirstGreater(relation, 2))
                return 1;

            if (GarbidgeFix_.DoubleComparerFirstGreater(1.3, relation))
                return 2;
            return 3;
        }

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            if (conflictedObject is PackMan && game.IsMonsterStyle)
                return true;
            return false;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
