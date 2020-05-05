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
    class TestInky
    {
        [Test]
        public void TestGetNCells()
        {
            var inky = new Inky(Directions.Right);
            Game.PacMansDirection = Directions.Right;

            var pacPos = new Point(23, 24);
            Assert.AreEqual(new Point(25, 24), inky.Get2CellsBeforePacman(pacPos));
            pacPos.X = 26;
            Assert.AreEqual(new Point(27, 24), inky.Get2CellsBeforePacman(pacPos));
            pacPos.X = 27;
            Assert.AreEqual(new Point(27, 24), inky.Get2CellsBeforePacman(pacPos));

            Game.PacMansDirection = Directions.Down;
            pacPos = new Point(27, 23);
            Assert.AreEqual(new Point(27, 25), inky.Get2CellsBeforePacman(pacPos));
            pacPos.Y = 26;
            Assert.AreEqual(new Point(27, 27), inky.Get2CellsBeforePacman(pacPos));
            pacPos.Y = 27;
            Assert.AreEqual(new Point(27, 27), inky.Get2CellsBeforePacman(pacPos));

        }

        [Test]
        public void TestFindGoal()
        {
            Game.PacMansDirection = Directions.Right;
            var pacPos = new Point(8, 1);
            var blinkyPos = new Point(1, 10);
            var inky = new Inky(Directions.Right);

            var path = inky.FindGoal(pacPos, blinkyPos);
            Assert.AreEqual(new Point(10, 1), path);

            pacPos = new Point(5, 5);
            blinkyPos = new Point(3, 5);
            path = inky.FindGoal(pacPos, blinkyPos);
            Assert.AreEqual(new Point(11, 5), path);

            Game.PacMansDirection = Directions.Left;
            pacPos = new Point(13, 5);
            blinkyPos = new Point(15, 5);
            path = inky.FindGoal(pacPos, blinkyPos);
            Assert.AreEqual(new Point(7, 5), path);
        }
    }
}