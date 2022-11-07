using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class ColorMatrix
    {
        public void FindColor(int n, int m, int[,] matrix)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    // константу треба винести як параметр
                    matrix[i, j] = r.Next(10);
// роздрук лишній.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(" " + matrix[i, j] + " ");
                Console.WriteLine();
            }

            var empty = (-1, -1);


            (int, int)[,] foundLines = new (int x, int y)[n, m];


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    foundLines[i, j] = empty;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (foundLines[i, j] == (empty))
                    {
                        int xend = i, yend = j;
                        int count = 0;
// лишній цикл
                        while (xend < n && yend < m && matrix[xend, yend] == matrix[i, j])
                        {
                            foundLines[xend, yend] = (i, j);
                            (xend, yend) = (xend + 0, yend + 1);
                            count++;
                        }

                        if (count == 1)
                            foundLines[i, j] = (empty);
                    }
                }
            }

            int maxLen = 0;
            var lines = new HashSet<(int color, int length, (int x1, int y1) start, (int x2, int y2) end)>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    maxLength(foundLines[i, j], (i, j), matrix);
            }

            void maxLength((int i, int j) start, (int i, int j) end, int[,] matrix)
            {               
                if (start == (-1, -1))
                    return;

                var length = Math.Max(end.i - start.i, end.j - start.j);
                if (length > maxLen)
                {
                    maxLen = length;
                    lines.Clear();
                    lines.Add((matrix[start.i, start.j], length, start, end));
                }

                if (length == maxLen)
                    lines.Add((matrix[start.i, start.j], length, start, end));              
            }

            foreach (var line in lines)
                Console.WriteLine($"Колiр {line.color}, довжина {line.length + 1}, початок {line.start}, кiнець {line.end}.");
        }      
    }
}
