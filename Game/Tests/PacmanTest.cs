using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    [TestFixture]
    class PacmanTest
    {
        [Test]
        public void TestSteps()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
WS   W
W    W
WWWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Game.PacMansDirection = Directions.Right;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var PacmanPos = new Point(1, 1);
            var pacman = new PackMan(Directions.Right);
            for (var i = 0; i < 3; i++)
            {
                var a = pacman.Act(PacmanPos.X, PacmanPos.Y);
                PacmanPos.X += a.DeltaX;
                PacmanPos.Y += a.DeltaY;

            }
            Assert.AreEqual(new Point(4,1), PacmanPos);

        }


        [Test]
        public void WallTest()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWWW
WS W  W
WWWWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Game.PacMansDirection = Directions.Right;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var PacmanPos = new Point(1, 1);
            var pacman = new PackMan(Directions.Right);
            for (var i = 0; i < 3; i++)
            {
                var a = pacman.Act(PacmanPos.X, PacmanPos.Y);
                PacmanPos.X += a.DeltaX;
                PacmanPos.Y += a.DeltaY;

            }
            Assert.AreEqual(new Point(2,1), PacmanPos);
        }

        [Test]
        public void TestPacmanPositionGame()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
WS   W
W    W
W    W
W    W
WWWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Game.PacMansDirection = Directions.Right;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var PacmanPos = new Point(1, 1);
            var pacman = new PackMan(Directions.Right);
            for (var i = 0; i < 3; i++)
            {
                var a = pacman.Act(PacmanPos.X, PacmanPos.Y);
                PacmanPos.X += a.DeltaX;
                PacmanPos.Y += a.DeltaY;

            }
            Assert.AreEqual(Game.PackMansPosition, PacmanPos);
        }
        public void TestCurrentDirectionGame()
        {
            Game.Map = Map_creator.CreateMap(@"
WWWWWW
WS   W
W    W
W    W
W    W
WWWWWW");
            Game.PackMansPosition = new Point(1, 1);
            Game.PacMansDirection = Directions.Right;
            Game.PointsAtLevel = 7;
            Game.PointsEated = 2;
            var PacmanPos = new Point(1, 1);
            var pacman = new PackMan(Directions.Right);
            for (var i = 0; i < 3; i++)
            {
                var a = pacman.Act(PacmanPos.X, PacmanPos.Y);
                PacmanPos.X += a.DeltaX;
                PacmanPos.Y += a.DeltaY;

            }
            pacman.CurrentDirection = Directions.Down;
            for (var i = 0; i < 3; i++)
            {
                var a = pacman.Act(PacmanPos.X, PacmanPos.Y);
                PacmanPos.X += a.DeltaX;
                PacmanPos.Y += a.DeltaY;

            }
            Assert.AreEqual(new Point(4,4), PacmanPos);
            Assert.AreEqual(Game.PacMansDirection, Directions.Down);
        }

        [Test]
        public void TestClashGhost()
        {
            Game.CreateMap(TestGhost.Map);
            var blinky = new Blinky(Directions.Nothing);
            var pacman = new PackMan(Directions.Right);
            Assert.AreEqual(pacman.DeadInConflict(blinky), true);
            Game.IsMonsterStyle = true;
            Assert.AreEqual(pacman.DeadInConflict(blinky), false);


        }

        //[Test]
        //public void TestTelepotMainMap()
        //{
        //    Game.Map = Map_creator.CreateMap(TestGhost.Map);
        //    var pacman = new PackMan(Directions.Right);
        //    Game.PackMansPosition = new Point( Game.RightTeleport.X - 1, Game.RightTeleport.Y);
        //    var coord = pacman.Act(Game.PackMansPosition.X, Game.PackMansPosition.Y);
        //    Assert.AreEqual(new Point(coord.DeltaX, coord.DeltaY), new Point(-Game.MapWidth + 1, 0));
        //}
    }
}
