using System;

string alphabet = "abcdefghijklmnopqrstuvwxyz";
string[,] grid = new string[26, 26];
ConsoleColor[] rgb = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green };

Random rand = new Random();
int holger_x = rand.Next(1, grid.GetLength(0));
int holger_y = rand.Next(1, grid.GetLength(1));


// Print koordinater på Y aksen
for (int y = 1; y < grid.GetLength(0); y++)
{
    grid[y, 0] = Convert.ToString(y).PadLeft(4);
}

for (int x = 0; x < grid.GetLength(0); x++)
{
    grid[0, x] = Convert.ToString(x).PadLeft(4);
}

for (int x = 1; x < grid.GetLength(0); x++)
{
    for (int y = 1; y < grid.GetLength(1); y++)
    {
        // Udfylder grid med en tilfældig værdi fra min alphabet string og returnerer en char.
        grid[x, y] = alphabet[rand.Next(0, alphabet.Length)].ToString().PadLeft(4);
    }
}

for (int x = 0; x < grid.GetLength(0); x++)
{
    for (int y = 0; y < grid.GetLength(1); y++)
    {
        Console.ForegroundColor = rgb[rand.Next(0, rgb.Length)];
        Console.Write(grid[x, y]);
        Thread.Sleep(1);
    }
    Console.WriteLine();

    grid[holger_x, holger_y] = "@".PadLeft(4);
}


bool guessing = true;
do
{
    Console.WriteLine("Hvor er holger?");
    Console.WriteLine("X koordinat = ");
    int holger_x_in = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Y koordinat = ");
    int holger_y_in = Convert.ToInt32(Console.ReadLine());

 

    if (holger_x_in == holger_x && holger_y_in == holger_y)
    {
        guessing = false;
    }
    else
    {
        Console.WriteLine("Forkert!");
        Console.Beep();
        guessing = true;
    }

} while (guessing);

Console.WriteLine("DU HAR VUNDET!");
Console.ReadKey();
