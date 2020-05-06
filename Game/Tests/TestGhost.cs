using NUnit.Framework;
using System.Drawing;

namespace Game
{
    [TestFixture]
    class TestGhost
    {
        public static string Map = @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WFFFFFFFFFFFFWWWFFFFFFFFFFFFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WEWWWWFWWWWWFWWWFWWWWWFWWWWEW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WFFFFFFFFFFFFFFFFFFFFFFFFFFFW
WFWWWWFWWFWWWWWWWWWFWWFWWWWFW
WFFFFFFWWFFFFWWWFFFFWWFFFFFFW
WWWWWWFWWWWW WWW WWWWWFWWWWWW
     WFWWWWW WWW WWWWWFW     
     WFWWW      B  WWWFW     
     WFWWW WWWDWWW WWWFW     
WWWWWWFWWW WWPIKWW WWWFWWWWWW
0     FF   WWWWWWW   FF     0
WWWWWWFWW      S    WWFWWWWWW
     WFWW WWWWWWWWW WWFW     
     WFWW WWWWWWWWW WWFW     
WWWWWWFWW WWWWWWWWW WWFWWWWWW
WFFFFFFFFFFFFWWWFFFFFFFFFFFFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WFWWWWFWWWWWFWWWFWWWWWFWWWWFW
WEFFWWFFFFFFFFFFFFFFFFFWWFFEW
WWWFWWFWWFWWWWWWWWWFWWFWWFWWW
WWWFWWFWWFWWWWWWWWWFWWFWWFWWW
WFFFFFFWWFFFFWWWFFFFWWFFFFFFW
WFWWWWWWWWWWFWWWFWWWWWWWWWWFW
WFWWWWWWWWWWFWWWFWWWWWWWWWWFW
W             S             W
WWWWWWWWWWWWWWWWWWWWWWWWWWWWW
";
        [Test]
        public void FindPathTest()
        {
            Game.CreateMap(Map);
            var blinky = new Blinky(Directions.Left);
            var bPos = new Point(14, 10);
            var pacPos = new Point(14, 27);
            var count = 0;
            while (bPos != pacPos)
            {
                var move = blinky.FindPath(bPos.X, bPos.Y, pacPos);
                bPos.X += move.DeltaX;
                bPos.Y += move.DeltaY;
                count++;
            }
            Assert.AreEqual(45, count);
            Assert.AreEqual(Directions.Right, blinky.CurrentDirection);
            Assert.AreEqual(pacPos, bPos);
        }

        [Test]
        public void TestTeleports1()
        {
            Game.CreateMap(Map);
            var blinky = new Blinky(Directions.Left);
            var start = new Point(1, 13);
            var goal = new Point(27, 13);
            var count = 0;
            while (start != goal)
            {
                var move = blinky.FindPath(start.X, start.Y, goal);
                start.X += move.DeltaX;
                start.Y += move.DeltaY;
                count++;
            }
            Assert.AreEqual(3, count);
            Assert.AreEqual(Directions.Left, blinky.CurrentDirection);
            Assert.AreEqual(start, goal);
        }

        [Test]
        public void TestTeleports2()
        {
            Game.CreateMap(Map);
            var blinky = new Blinky(Directions.Right);
            var start = new Point(27, 13);
            var goal = new Point(1, 13);
            var count = 0;
            while (start != goal)
            {
                var move = blinky.FindPath(start.X, start.Y, goal);
                start.X += move.DeltaX;
                start.Y += move.DeltaY;
                count++;
            }
            Assert.AreEqual(3, count);
            Assert.AreEqual(Directions.Right, blinky.CurrentDirection);
            Assert.AreEqual(start, goal);
        }

        [Test]
        public void TestGetMovementBySpeed()
        {
            Game.CreateMap(Map);
            var x = 27;
            var y = 27;
            var move = new CreatureCommand() { DeltaX = 1, DeltaY = 0 };
            var a = Ghost.GetMovementBySpeed(move, 4, x, y);
            Assert.AreEqual(0, a.DeltaX);
            x = 26;
            a = Ghost.GetMovementBySpeed(move, 3, x, y);
            Assert.AreEqual(1, a.DeltaX);
            x = 29;
            move = new CreatureCommand() { DeltaX = 1, DeltaY = 0 };
            a = Ghost.GetMovementBySpeed(move, 3, x, y);
            Assert.AreEqual(null, a);

        }

        [Test]
        public void TestChangeSpeed()
        {
            Game.PointsAtLevel = 10;
            Game.PointsEated = 2;
            Assert.AreEqual(1, Ghost.ChangeSpeed());
            Game.PointsEated = 9;
            Assert.AreEqual(3, Ghost.ChangeSpeed());
        }
    }
}