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
    class TestKlaid
    {
        [Test]
        public void TestSteeps()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWW
WS KW
W   W
W   W
WWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            Game.CurrentBehavior = MonsterBehavior.chase;

            var klaidPos = new Point(3, 1);
            var klaid = new Klaid(Directions.Left);
            for (var i = 0; i < 4; i++)
            {
                var a = klaid.Act(klaidPos.X, klaidPos.Y);
                klaidPos.X += a.DeltaX;
                klaidPos.Y += a.DeltaY;

            }
            Assert.AreEqual(new Point(1,3), klaidPos);

        }

        [Test]
        public void TestFindGoal()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWWWWWWWWWWWW
W              W
W    S         W
W              W
W             KW
WWWWWWWWWWWWWWWW");
            Game.PackMansPosition = new Point(5, 2);
            Assert.AreEqual(Klaid.GetGoal(14, 4), Game.PackMansPosition);
            Assert.AreEqual(Klaid.GetGoal(5, 3), new Point (0, Game.MapHeight - 1));
        }


        [Test]
        public void SimpleTest()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWWWWWWWWWWWW
W              W
W    S         W
W              W
W           K  W
WWWWWWWWWWWWWWWW");
            Game.PackMansPosition = new Point(5, 2);
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            Game.CurrentBehavior = MonsterBehavior.chase;

            var klaidPos = new Point(12, 4);
            var klaid = new Klaid(Directions.Right);

            var result = new List<Point>() { klaidPos };
            for (var i = 0; i < 10; i++)
            {
                var move = klaid.Act(klaidPos.X, klaidPos.Y);
                klaidPos.X += move.DeltaX;
                klaidPos.Y += move.DeltaY;
                result.Add(klaidPos);
            }
            Assert.IsNotEmpty(result);
            Assert.AreEqual(new Point(3 , 3), klaidPos);
            for (var i = 0; i < 2; i++)
            {
                var move = klaid.Act(klaidPos.X, klaidPos.Y);
                klaidPos.X += move.DeltaX;
                klaidPos.Y += move.DeltaY;
                result.Add(klaidPos);
            }
            Assert.AreEqual(new Point(2, 4), klaidPos);
            for (var i = 0; i < 2; i++)
            {
                var move = klaid.Act(klaidPos.X, klaidPos.Y);
                klaidPos.X += move.DeltaX;
                klaidPos.Y += move.DeltaY;
                result.Add(klaidPos);
            }
            Assert.AreEqual(new Point(1, 3), klaidPos);
        }

        [Test]
        public void TestScatterMode()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
W   KW
W    W
W    W
W    W
WWWWWW");
            Game.CurrentBehavior = MonsterBehavior.scatter;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var klaidPos = new Point(4, 1);
            var klaid = new Klaid(Directions.Left);
            for (var i = 0; i < 6; i++)
            {
                var a = klaid.Act(klaidPos.X, klaidPos.Y);
                klaidPos.X += a.DeltaX;
                klaidPos.Y += a.DeltaY;

            }
            Assert.AreEqual(new Point(1, Game.MapHeight - 2), klaidPos);
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
            var klaidPos = new Point(0, 3);
            var klaid = new Klaid(Directions.Right);
            var res = new List<CreatureCommand>();
            for (var i = 0; i < 6; i++)
            {
                var a = klaid.Act(klaidPos.X, klaidPos.Y);
                klaidPos.X += a.DeltaX;
                klaidPos.Y += a.DeltaY;
                res.Add(a);
            }
            Assert.IsNotEmpty(res);
            Assert.AreEqual(res.Count, 6);

        }
    }
}