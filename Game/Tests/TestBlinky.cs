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
            Game.Map = Map_creator.CreateMap(@"
    
    
    
B   ");
            Game.PackMansPosition = new Point(3, 0);
            Game.CurrentBehavior = MonsterBehavior.chase;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var blinkyPos = new Point(0, 3);
            var blinky = new Blinky(Directions.Right);
            for (var i = 0; i < 6; i++)
            {
                var a = blinky.Act(blinkyPos.X, blinkyPos.Y);
                blinkyPos.X += a.DeltaX;
                blinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(Game.PackMansPosition, blinkyPos);

        }

        [Test]
        public void SimpleTest()
        {
            Game.Map = Map_creator.CreateMap(Game.MapPacman);
            var blinky = new Blinky(Directions.Left);
            var blinkyPos = new Point(14, 10);
            Game.PackMansPosition = new Point(14, 27);
            var result = new List<Point>() { blinkyPos };
            while (blinkyPos != Game.PackMansPosition)
            {
                var move = blinky.Act(blinkyPos.X, blinkyPos.Y);
                blinkyPos.X += move.DeltaX;
                blinkyPos.Y += move.DeltaY;
                result.Add(blinkyPos);
            }
            Assert.IsNotEmpty(result);
            Assert.AreEqual(46, result.Count);
        }

        [Test]
        public void TestScatterMode()
        {
            var game = new Game();
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
W    W
W    W
W    W
WB   W
WWWWWW");
            Game.PackMansPosition = new Point(4, 1);
            Game.CurrentBehavior = MonsterBehavior.scatter;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var blinkyPos = new Point(1, 4);
            var blinky = new Blinky(Directions.Right);
            for (var i = 0; i < 6; i++)
            {
                var a = blinky.Act(blinkyPos.X, blinkyPos.Y);
                blinkyPos.X += a.DeltaX;
                blinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(Game.PackMansPosition, blinkyPos);
        }

        [Test]
        public void TestFrightenedMode()
        {
            Game.Map = Map_creator.CreateMap(@"
    
    
    
B   ");
            Game.PackMansPosition = new Point(3, 0);
            Game.CurrentBehavior = MonsterBehavior.frightened;
            var blinkyPos = new Point(0, 3);
            var blinky = new Blinky(Directions.Right);
            var res = new List<CreatureCommand>();
            for (var i = 0; i < 6; i++)
            {
                var a = blinky.Act(blinkyPos.X, blinkyPos.Y);
                blinkyPos.X += a.DeltaX;
                blinkyPos.Y += a.DeltaY;
                res.Add(a);
            }
            Assert.IsNotEmpty(res);
            Assert.AreEqual(res.Count, 6);

        }
    }
}