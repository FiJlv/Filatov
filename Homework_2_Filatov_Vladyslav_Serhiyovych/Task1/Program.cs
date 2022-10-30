using Homework_2_Filatov_Vladyslav_Serhiyovych;
using System;
using System.Drawing;

RectangularMatrices rectangularMatrices = new RectangularMatrices();

Console.WriteLine("Enter n");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter m");
int m = Convert.ToInt32(Console.ReadLine());

int[,] matrix1 = new int[n, m];
int[,] matrix2 = new int[n, n];

Console.WriteLine("Vertical snake");
rectangularMatrices.VerticalSnake(n, m, matrix1);
Console.WriteLine("Diagonal snake");
rectangularMatrices.DiagonalSnake(n, matrix2);
Console.WriteLine("Spiral snake");
rectangularMatrices.SpiralSnake(n, m, matrix1);

