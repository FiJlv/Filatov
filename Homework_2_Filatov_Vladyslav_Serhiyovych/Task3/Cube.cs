using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Cube
    {
        private int[,,] cube;
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
        public string CheckForThroughHoles()
        {
            for (int k = 0; k < cube.GetLength(2); k++)
            {
                for (int i = 0; i < cube.GetLength(0); i++)
                {
                    bool throughHole = true;

                    for (int j = 0; j < cube.GetLength(1); j++)
                    {
                        if (cube[i, j, k] == 1)
                        {
                            throughHole = false;
                            break;
                        }
                    }
                    if (throughHole)
                        return "There is a through hole";
                }
            }

            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    bool throughHole = true;

                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        if (cube[i, j, k] == 1)
                        {
                            throughHole = false;
                            break;
                        }
                    }
                    if (throughHole)
                        return "There is a through hole";
                }
            }

            for (int j = 0; j < cube.GetLength(1); j++)
            {
                for (int k = 0; k < cube.GetLength(2); k++)
                {
                    bool throughHole = true;

                    for (int i = 0; i < cube.GetLength(0); i++)
                    {
                        if (cube[i, j, k] == 1)
                        {
                            throughHole = false;
                            break;
                        }
                    }
                    if (throughHole)
                        return "There is a through hole";
                }
            }
            return "There isn't a through hole";
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
