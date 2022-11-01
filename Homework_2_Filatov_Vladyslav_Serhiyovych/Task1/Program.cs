using Homework_2_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Drawing;

RectangularMatrices rectangularMatrices = new RectangularMatrices();

Console.WriteLine("Enter n");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter m");
int m = Convert.ToInt32(Console.ReadLine());

int[,] matrix = new int[n, m];

Console.WriteLine("Vertical snake");
rectangularMatrices.VerticalSnake(n, m, matrix);
Console.WriteLine("Diagonal snake");
rectangularMatrices.DiagonalSnake(n, matrix);
Console.WriteLine("Spiral snake");
rectangularMatrices.SpiralSnake(n, m, matrix);

