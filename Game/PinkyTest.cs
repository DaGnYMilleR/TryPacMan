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
    class TestPinky
    {
        [Test]
        public void TestChaseMode()
        {
            Game.Map = Map_creator.CreateMap(@"
       
      P");
            Game.PackMansPosition = new Point(0, 0);
            Game.CurrentBehavior = MonsterBehavior.chase;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var pinkyPos = new Point(0, 3);
            var pinky = new Blinky(Directions.Right);
            for (var i = 0; i < 7; i++)
            {
                var a = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += a.DeltaX;
                pinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(Game.PackMansPosition, pinkyPos);

        }

        [Test]
        public void SimpleTest()
        {
            var pinky = new Blinky(Directions.Left);
            var pinkyPos = new Point(14, 10);
            Game.PackMansPosition = new Point(14, 27);
            var result = new List<Point>() { pinkyPos };
            while (pinkyPos != Game.PackMansPosition)
            {
                var move = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += move.DeltaX;
                pinkyPos.Y += move.DeltaY;
                result.Add(pinkyPos);
            }
            Assert.IsNotEmpty(result);
            Assert.AreEqual(46, result.Count);
        }

        [Test]
        public void TestScatterMode()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
W    W
W    W
W    W
WP   W
WWWWWW");
            Game.PackMansPosition = new Point(4, 1);
            Game.CurrentBehavior = MonsterBehavior.scatter;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var pinkyPos = new Point(1, 4);
            var pinky = new Blinky(Directions.Right);
            for (var i = 0; i < 6; i++)
            {
                var a = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += a.DeltaX;
                pinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(Game.PackMansPosition, pinkyPos);
        }

        [Test]
        public void TestFrightenedMode()
        {
            Game.Map = Map_creator.CreateMap(@"
    
    
    
B   ");
            Game.PackMansPosition = new Point(3, 0);
            Game.CurrentBehavior = MonsterBehavior.frightened;
            var pinkyPos = new Point(0, 3);
            var pinky = new Blinky(Directions.Right);
            var res = new List<CreatureCommand>();
            for (var i = 0; i < 6; i++)
            {
                var a = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += a.DeltaX;
                pinkyPos.Y += a.DeltaY;
                res.Add(a);
            }
            Assert.IsNotEmpty(res);
            Assert.AreEqual(res.Count, 6);

        }
    }
}