using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map_creator
    {
        public static ICreature[,] CreateMap(string map)
        {
            var rows = map.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var i = 0; i < rows[0].Length; i++)
                for (var j = 0; j < rows.Length; j++)
                {
                    result[i, j] = CreateCreatureBySymbol(rows[j][i]);
                }
            return result;
        }
        
        public static ICreature CreateCreatureBySymbol(char symb)
        {
            switch (symb)
            {
                case 'W': 
                    return new Wall();
                case ' ': 
                    return null;
                case 'E':
                    return new Energizer();
                case 'C':
                    return new Bonus();
                case 'P':
                    return new Pinky(Directions.Right);
                case 'K':
                    return new Klaid(Directions.Right);
                case 'I':
                    return new Inky(Directions.Right);
                case 'B':
                    return new Blinky(Directions.Right);
                case 'F':
                    return new Fruit();
                case 'S':
                    return new PackMan();
                case 'D':
                    return new Door();
                default:
                    throw new Exception("Wrong symbol!");
            }
        }
    }
}
