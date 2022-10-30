using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Filatov_Vladyslav_Serhiyovych
{
    class RectangularMatrices
    {
        public void VerticalSnake(int n, int m, int[,] matrix)
        {
            int num = 1;
            bool downDirection = true;
            for (int j = 0; j < m; j++)
            {
                if (downDirection)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = num++;
                    }
                }
                else
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        matrix[i, j] = num++;
                    }
                }
                downDirection = !downDirection;
            }

            for (int i = 0; i < n; i++)
            {
               for(int j = 0; j < m; j++)
                   Console.Write(" " + matrix[i, j] + " ");
               Console.WriteLine();
            }
        }

        public void DiagonalSnake(int n, int[,] matrix)
        {

            int num = 1;
            for (int d = 1 - n; d <= n - 1; d++)
            {
                for (int i = 0; i < n; i++)
                {
                    int j = i - d;

                    if (j < 0 || j >= n)
                        continue;
                    if (((d + n + 1) & 1) > 0) 
                        matrix[i, n - 1 - j] = num++;
                    else
                        matrix[n - 1 - j, i] = num++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(" " + matrix[i, j] + " ");
                Console.WriteLine();
            }

        }

        public void SpiralSnake(int n, int m, int[,] matrix)
        {
            int top = 0;
            int left = 0;
            int bottom = matrix.GetLength(0) - 1;
            int right = matrix.GetLength(1) - 1;

            int direction = 0;
            int num = 1;

            while (right >= left && bottom >= top)
            {
                if (direction == 0)
                {
                    for (int i = top; i <= bottom; i++, num++)
                        matrix[i, left] = num;
                    left++;
                }
                else if (direction == 1)
                {
                    for (int i = left; i <= right; i++, num++)
                        matrix[bottom, i] = num;
                    bottom--;
                }
                else if (direction == 2)
                {
                    for (int i = bottom; i >= top; i--, num++)
                        matrix[i, right] = num;
                    right--;
                }
                else if (direction == 3) 
                {
                    for (int i = right; i >= left; i--, num++)
                        matrix[top, i] = num;
                    top++;
                }

                direction = (direction + 1) % 4;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(" " + matrix[i, j] + " ");
                Console.WriteLine();
            }

        }
    }
}