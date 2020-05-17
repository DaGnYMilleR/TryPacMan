using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Game
{
    public class GameState
    {
        public const int ElementSize = 24;
        public List<CreatureAnimation> Animations = new List<CreatureAnimation>();

        public void BeginAct()
        {
            Animations.Clear();
            for (var x = 0; x < Game.MapWidth; x++)
            {
                for (var y = 0; y < Game.MapHeight; y++)
                {
                        if (Game.GameLives <= 0 || Game.Win)
                        {

                            var creature = Game.Map[x, y].FirstOrDefault();

                            if (creature == null) continue;

                            Animations.Add(
                                new CreatureAnimation
                                {
                                    Command = new CreatureCommand(),
                                    Creature = creature,
                                    Location = new Point(x * ElementSize, y * ElementSize),
                                    TargetLogicalLocation = new Point(x, y),
                                    CreaturesName = creature.GetType().Name,
                                    CreaturesDirection = creature.CurrentDirection
                                });

                        }
                        else
                        {
                            foreach (var creature in Game.Map[x, y])
                            {
                                if(x == 14 && y == 11 && !Game.IsDoorClosed && creature is Door)        
                                {
                                    Game.Map[14, 11] = new List<ICreature>();
                                    continue;
                                }

                                if (creature == new List<ICreature>() || creature == null) continue;
                                var command = creature.Act(x, y);

                                if (x + command.DeltaX < 0 || x + command.DeltaX >= Game.MapWidth || y + command.DeltaY < 0 ||
                                    y + command.DeltaY >= Game.MapHeight)
                                    throw new Exception($"The object {creature.GetType()} falls out of the game field");

                                Animations.Add(
                                    new CreatureAnimation
                                    {
                                        Command = command,
                                        Creature = creature,
                                        Location = new Point(x * ElementSize, y * ElementSize),
                                        TargetLogicalLocation = new Point(x + command.DeltaX, y + command.DeltaY),
                                        CreaturesName = creature.GetType().Name,
                                        CreaturesDirection = creature.CurrentDirection
                                    });
                                
                            }
                        }
                    }
            }

            Animations = Animations.OrderBy(z => Priorities.GetDrawingPriority(z.CreaturesName)).ToList();
        }

        public void EndAct()
        {
            var creaturesPerLocation = GetCandidatesPerLocation();
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                {
                    Game.Map[x, y] = SelectWinnerCandidatePerLocation(creaturesPerLocation, x, y);
                }
        }

        //private static void SelectWinnerCandidatePerLocation2(List<CreatureAnimation> animations, int x, int y)
        //{
        //    var creatures = new List<ICreature>();
        //    foreach (var e in animations)
        //    {
        //        if (new Point(x, y) == new Point( e.TargetLogicalLocation.X, e.TargetLogicalLocation.Y))
        //        creatures.Add(e.Creature);
        //    }
        //    foreach (var candidate in creatures)
        //        foreach (var rival in creatures)
        //            if (rival != candidate && candidate.DeadInConflict(rival))
        //                animations.Remove(candidate);
        //}

        private static List<ICreature> SelectWinnerCandidatePerLocation(List<ICreature>[,] creatures, int x, int y)
        {
                var candidates = creatures[x, y];
                var aliveCandidates = candidates.ToList();
            foreach (var candidate in candidates)
                foreach (var rival in candidates)
                    if (rival != candidate && candidate.DeadInConflict(rival))
                    {

                        aliveCandidates.Remove(candidate);
                        if (candidate is Ghost)
                        {
                            var coord = Game.startPositions[candidate.GetType().Name];
                            Game.Map[coord.X, coord.Y].Add(candidate);
                            Console.WriteLine(Game.namesGhosts[candidate.GetType().Name]);
                            Game.AddDeadGhost(candidate.GetType().Name);
                            
                        }
                    }

                return aliveCandidates.OrderBy(s => Priorities.GetDrawingPriority(s.GetType().Name)).ToList();
            
        }
       

        private List<ICreature>[,] GetCandidatesPerLocation()
        {
            var creatures = new List<ICreature>[Game.MapWidth, Game.MapHeight];
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    creatures[x, y] = new List<ICreature>();
            foreach (var e in Animations)
            {
                var x = e.TargetLogicalLocation.X;
                var y = e.TargetLogicalLocation.Y;
                creatures[x, y].Add(e.Creature);
            }

            return creatures;
        }
    }
}
