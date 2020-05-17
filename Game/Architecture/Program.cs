using System;
using System.Windows.Forms;
using System.IO;

namespace Game
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var map = new StreamReader(@"Maps\Map1.txt");
           // Console.WriteLine("Map readen");
            Game.CreateMap(map.ReadToEnd());
            Application.Run(new PacManWindow());
        }
    }
}