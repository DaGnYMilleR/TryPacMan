using System;
using System.Windows.Forms;

namespace Game
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
        Game.CreateMap(Game.MapPacman);
            Application.Run(new PacManWindow());
        }
    }
}