using System.Collections.Generic;
using Task2;

Console.WriteLine("Enter n");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter m");
int m = Convert.ToInt32(Console.ReadLine());

int[,] matrix = new int[n, m];

ColorMatrix colorMatrix = new ColorMatrix();
colorMatrix.FindColor(n, m, matrix);
