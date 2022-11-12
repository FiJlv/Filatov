using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Cube
    {
        int[,,] cube;
        public void CreateCube(int x, int y, int z)
        {
            cube = new int[x, y, z];

            Random r = new Random();

            for (int k = 0; k < cube.GetLength(2); k++)
            {
                for (int i = 0; i < cube.GetLength(0); i++)
                {
                    for (int j = 0; j < cube.GetLength(1); j++)
                    {
                        cube[i, j, k] = r.Next(2);
                    }
                }
            }
        }

        public void DisplayCube()
        {
            for (int k = 0; k < cube.GetLength(2); k++)
            {
                for (int i = 0; i < cube.GetLength(0); i++)
                {
                    for (int j = 0; j < cube.GetLength(1); j++)
                    {
                        Console.Write($"{cube[i, j, k]}\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
