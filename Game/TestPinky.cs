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
        public void TestSteeps()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWW
WS  W
W   W
WP  W
WWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            Game.CurrentBehavior = MonsterBehavior.chase;
            
            var pinkyPos = new Point(1, 3);
            var pinky = new Blinky(Directions.Right);
            for (var i = 0; i < 2; i++)
            {
                var a = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += a.DeltaX;
                pinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(Game.PackMansPosition, pinkyPos);

        }

        [Test]
        public void TestFindGoal()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWWWWWWWWWWWW
W              W
W    S         W
W              W
W              W
WWWWWWWWWWWWWWWW");
            Game.PackMansPosition = new Point(5, 2);
            Assert.AreEqual(Pinky.GetGoal(), new Point(1,1));
        }

        [Test]
        public void TestFindGoal1()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWWWWWWWWWWWW
WS             W
W              W
W              W
W              W
WWWWWWWWWWWWWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Assert.AreEqual(Pinky.GetGoal(), new Point(1, 1));
        }

        [Test]
        public void SimpleTest() //?
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWWWWWWWWWWWW
W              W
W    S         W
W              W
W           P  W
WWWWWWWWWWWWWWWW");
            Game.PackMansPosition = new Point(5, 2);
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            Game.CurrentBehavior = MonsterBehavior.chase;

            var pinkyPos = new Point(12, 4);
            var pinky = new Blinky(Directions.Right);

            var result = new List<Point>() { pinkyPos };
            for (var i = 0; i < 10; i++)
            {
                var move = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += move.DeltaX;
                pinkyPos.Y += move.DeltaY;
                result.Add(pinkyPos);
            }
            Assert.IsNotEmpty(result);
            Assert.AreEqual(new Point(4,2), pinkyPos);

        }

        [Test]
        public void TestScatterMode()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
W    W
W    W
W    W
W   PW
WWWWWW");
            Game.PackMansPosition = new Point(4, 1);
            Game.CurrentBehavior = MonsterBehavior.scatter;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var pinkyPos = new Point(4, 1);
            var pinky = new Pinky(Directions.Left);
            for (var i = 0; i < 7; i++)
            {
                var a = pinky.Act(pinkyPos.X, pinkyPos.Y);
                pinkyPos.X += a.DeltaX;
                pinkyPos.Y += a.DeltaY;

            }
            Assert.AreEqual(new Point(1,1), pinkyPos);
        }

        [Test]
        public void TestFrightenedMode()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
W    W
W    W
WP   W
WWWWWW");
            Game.PackMansPosition = new Point(3, 0);
            Game.CurrentBehavior = MonsterBehavior.frightened;
            var pinkyPos = new Point(0, 3);
            var pinky = new Pinky(Directions.Right);
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