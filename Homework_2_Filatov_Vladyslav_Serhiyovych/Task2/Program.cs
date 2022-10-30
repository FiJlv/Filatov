using System.Collections.Generic;

Console.WriteLine("Enter n");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter m");
int m = Convert.ToInt32(Console.ReadLine());

int[,] matrix = new int[n, m];

Random r = new Random();
for (int i = 0; i < n; i++)
    for (int j = 0; j < m; j++)
        matrix[i, j] = r.Next(10);

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write(" " + matrix[i, j] + " ");
    Console.WriteLine();
}

(int, int)[,] foundLines = new (int x, int y)[n, m];

var empty = (-1, -1);

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
        maxLength(foundLines[i, j], (i, j));     
}

void maxLength((int i, int j) start, (int i, int j) end)
{
    if (start == (empty)) 
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