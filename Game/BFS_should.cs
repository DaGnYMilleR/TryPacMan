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
    class BFS_should
    {
        [Test, Order(10)]
        public void ReturnNoPaths_WhenNoPathsToChests()
        {
            var game = new Game();


            var paths = BFS.FindPaths(game, new Point(1, 1), new Point(3, 5), new Point(1, 2)).ToList();
            Assert.IsNotEmpty(paths);
            Assert.AreEqual(paths.Last(), new Point(1, 1));
            Assert.AreEqual(paths[paths.Count - 2], new Point(2, 1));
        }

        [Test]
        public void TestEmpty()
        {
            var map = @"
WWWWW
WB  W
WWWWW
W   W
WWWWW";
            var game = new Game();
            Game.Map = Map_creator.CreateMap(map);
            var path = BFS.FindPaths(game, new Point(1, 1), new Point(3, 5), new Point(1, 2));
            Assert.AreEqual(path, null);
        }

        [Test]
        public void SimpleTest()
        {
            var map = @"
WWWWWW
WB   W
WWW  W
W    W
W  WWW
WWWWWW";
            var game = new Game();
            Game.Map = Map_creator.CreateMap(map);
            var points = new Point[] { new Point(1, 1), new Point(2, 1), new Point(2, 3), new Point(1, 4) };

            var path = BFS.FindPaths(game, new Point(1, 1), new Point(1, 4), new Point(1, 2)).ToList();
            for (var i = 0; i < 4; i++)
            {
                Assert.That(path.Contains(points[i]));
            }
        }

        public void SimpleTest2()
        {
            var map = @"
      
WB    
WWW   
W     
W  WW 
     ";
            var game = new Game();
            Game.Map = Map_creator.CreateMap(map);
            var points = new Point[] { new Point(1, 1), new Point(2, 1), new Point(2, 3), new Point(1, 4) };

            var path = BFS.FindPaths(game, new Point(1, 1), new Point(1, 4), new Point(1, 2)).ToList();
            for (var i = 0; i < 4; i++)
            {
                Assert.That(path.Contains(points[i]));
            }
        }


        [Test]
        public void TestGetNeighbors()
        {
            var point = BFS.GetNeighbors(new Point(5, 5)).ToList();
            Assert.AreEqual(new Point(4, 5), point[0]);
            Assert.That(point.Contains(new Point(5, 4)));
            Assert.That(point.Contains(new Point(5, 6)));
            Assert.That(point.Contains(new Point(6, 5)));
        }

        [Test]
        public void TestIscorrectPoint()
        {
            var game = new Game();

            var a = BFS.IsPointCorrect(new Point(3, 3));
            Assert.IsFalse(a);
            Assert.IsTrue(BFS.IsPointCorrect(new Point(1, 1)));
            Assert.IsFalse(BFS.IsPointCorrect(new Point(0, 0)));
            Assert.IsFalse(BFS.IsPointCorrect(new Point(-1, -1)));
        }

        [Test]
        public void FindPatheTest()
        {
            var game = new Game();
            var path = BFS.FindPaths(game, new Point(14, 10), new Point(14, 27), new Point(13, 10));
            foreach (var p in path)
            {
                Assert.That(!(Game.Map[p.X, p.Y] is Wall));
            }
            Assert.AreEqual(34, path.Length);
        }
    }
}