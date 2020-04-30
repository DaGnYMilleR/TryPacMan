using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [TestFixture]
    class TestBlinky
    {
        [Test]
        public void TestChaseMode()
        {
            var game = new Game();
            game.Map = Map_creator.CreateMap(@"
    
    
    
G   ");
            game.PackMansPosition = new Point(3, 0);
            game.CurrentBehavior = MonsterBehavior.chase;
            game.PointsAtLevel = 7;
            game.PointsEated = 2;
            var blinkyPos = new Point(0, 3);
            var blinky = new Blinky(Directions.Right);
            for (var i = 0; i < 6; i++)
            {
                var a = blinky.Act(blinkyPos.X, blinkyPos.Y, game);
                blinkyPos.X += a.DeltaX;
                blinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(game.PackMansPosition, blinkyPos);

        }

        [Test]
        public void TestScatterMode()
        {
            var game = new Game();
            game.Map = Map_creator.CreateMap(@"
    
    
    
G   ");
            game.PackMansPosition = new Point(3, 0);
            game.CurrentBehavior = MonsterBehavior.scatter;
            game.PointsAtLevel = 7;
            game.PointsEated = 5;
            var blinkyPos = new Point(0, 3);
            var blinky = new Blinky(Directions.Right);
            for (var i = 0; i < 6; i++)
            {
                var a = blinky.Act(blinkyPos.X, blinkyPos.Y, game);
                blinkyPos.X += a.DeltaX;
                blinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(game.PackMansPosition, blinkyPos);
        }

        [Test]
        public void TestFrightenedMode()
        {
            var game = new Game();
            game.Map = Map_creator.CreateMap(@"
    
    
    
G   ");
            game.PackMansPosition = new Point(3, 0);
            game.CurrentBehavior = MonsterBehavior.frightened;
            var blinkyPos = new Point(0, 3);
            var blinky = new Blinky(Directions.Right);
            var res = new List<CreatureCommand>();
            for (var i = 0; i < 6; i++)
            {
                var a = blinky.Act(blinkyPos.X, blinkyPos.Y, game);
                blinkyPos.X += a.DeltaX;
                blinkyPos.Y += a.DeltaY;
                res.Add(a);
            }
            Assert.IsNotEmpty(res);
            Assert.AreEqual(res.Count, 6);

        }
    }
}
