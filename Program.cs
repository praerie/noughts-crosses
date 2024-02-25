using System;

class Program
{
    static void Main(string[] args)
    {
        string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        for (int i=0; i<3; i++)
        {
            for (int j=0; j<3; j++)
            {
                // print grid element 
                Console.Write(grid[i * 3 + j]);

                // add vertical separator if not last column
                if (j<2)
                {
                    Console.Write(" | ");
                }
            }
            // move to next line after each row
            Console.WriteLine();

            // add horizontal separator if not last row
            if (i<2)
            {
                Console.WriteLine("-----------");
            }
        }
    }
}
