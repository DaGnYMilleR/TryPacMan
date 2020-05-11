using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Game
{
    public class PacManWindow : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly GameState gameState;
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private int tickCount;
        private int tickCount2;
        private int tickCount3;


        public PacManWindow(DirectoryInfo imagesDirectory = null)
        {
            gameState = new GameState();
            ClientSize = new Size(
                GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight + GameState.ElementSize);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += ScatterModeController;
            timer.Tick += TimerTick;
            timer.Tick += OpenDoor;
            timer.Tick += Reloge;
            timer.Start();
        }

        //private void Wined(object sender, EventArgs args)
        //{
        //    if (Game.PointsAtLevel == Game.PointsEated)


        //}
        private void Reloge(object sender, EventArgs args) => Game.Respawn();

        private void OpenDoor(object sender, EventArgs args)
        {
            if(tickCount3 == 100)
            {
                Game.Map[11, 14] = new List<ICreature>();
                Game.Map = Game.UpdateMapCell(0, 0);
                Game.Map[14, 11] = new List<ICreature>();
                Game.Map[0, 0] = new List<ICreature>();
            }
            if (tickCount3 == 150)
            {
                Game.IsDoorClosed = true;
                Game.Map[14, 11] = new List<ICreature>() { new Door() };
            }
            tickCount3++;
            Invalidate();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Pacman";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);
            Game.KeyPressed = e.KeyCode;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
            Game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, GameState.ElementSize);
            e.Graphics.FillRectangle(
                Brushes.Black, 0, 0, GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight);
            foreach (var a in gameState.Animations)
                e.Graphics.DrawImage(bitmaps[ImageHandler.GetImage(a.CreaturesName, a.CreaturesDirection)], a.Location);
            e.Graphics.ResetTransform();
            e.Graphics.DrawString(Game.Score.ToString(), new Font("Arial", 16), Brushes.Green, 0, 0);
            var c = bitmaps[ImageHandler.GetImage("live", Directions.Nothing)];
            for (var i = 0; i < Game.GameLives; i++)
                e.Graphics.DrawImage(c, new Point(100 + i * 20, 10));
        }

        private void TimerTick(object sender, EventArgs args)
        {
            if (tickCount == 0) gameState.BeginAct();
            foreach (var e in gameState.Animations)
                e.Location = new Point(e.Location.X + 1 * e.Command.DeltaX, e.Location.Y + 1 * e.Command.DeltaY);
            if (tickCount == 7)
                gameState.EndAct();
            tickCount++;
            if (tickCount == 8) tickCount = 0;
            Invalidate();
        }

        private void ScatterModeController(object sender, EventArgs args)
        {
            if (!(Game.CurrentBehavior == MonsterBehavior.frightened))
            {
                if (tickCount2 == 0)
                {
                    Game.CurrentBehavior = MonsterBehavior.scatter;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " on");
                }
                if (tickCount2 == 700)
                {
                    Game.CurrentBehavior = MonsterBehavior.chase;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " off");
                }

                if (tickCount2 == 2700)
                {
                    Game.CurrentBehavior = MonsterBehavior.scatter;
                    
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " on");
                }
                if (tickCount2 == 3400)
                {
                    Game.CurrentBehavior = MonsterBehavior.chase;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " off");
                }

                if (tickCount2 == 5400)
                {
                    Game.CurrentBehavior = MonsterBehavior.scatter;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " on");
                }
                if (tickCount2 == 5900)
                {
                    Game.CurrentBehavior = MonsterBehavior.chase;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " off");
                }

                if (tickCount2 == 7900)
                {
                    Game.CurrentBehavior = MonsterBehavior.scatter;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " on");
                }
                if (tickCount2 == 8400)
                {
                    Game.CurrentBehavior = MonsterBehavior.chase;
                    Console.WriteLine(MonsterBehavior.scatter.ToString() + " off");
                    tickCount2 = 0;
                }
                tickCount2++; 
            }
            Invalidate();
        }
    }
}