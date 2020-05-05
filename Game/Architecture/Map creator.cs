using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map_creator
    {
        public static List<ICreature> [,] CreateMap(string map)
        {
            
            var rows = map.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<ICreature>[rows[0].Length, rows.Length];
            for (var i = 0; i < rows[0].Length; i++)
                for (var j = 0; j < rows.Length; j++)
                {
                    
                    result[i, j] = CreateCreatureBySymbol(rows[j][i]);
                }
            return result;
        }
        
        public static List<ICreature> CreateCreatureBySymbol(char symb)
        {
            switch (symb)
            {
                case 'W': 
                    return new List<ICreature> { new Wall() };
                case ' ':
                    return new List<ICreature>();
                case 'E':
                    return new List<ICreature> { new Energizer() };
                case 'C':
                    return new List<ICreature> { new Bonus() };
                case 'P':
                    return new List<ICreature> { new Pinky(Directions.Right) };
                case 'K':
                    return new List<ICreature> { new Klaid(Directions.Right) };
                case 'I':
                    return new List<ICreature> { new Inky(Directions.Right) };
                case 'B':
                    return new List<ICreature> { new Blinky(Directions.Right) };
                case 'F':
                    return new List<ICreature> { new Fruit() };
                case 'S':
                    return new List<ICreature> { new PackMan(Directions.Right) };
                case 'D':
                    return new List<ICreature> { new Door() };
                default:
                    throw new Exception("Wrong symbol!");
            }
        }
    }
}
