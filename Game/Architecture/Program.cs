using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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