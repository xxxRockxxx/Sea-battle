using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    class WorkMatrix
    {
        public void ConsoleClear()
        {
            Console.Clear();
        }
        public void DrawMatrix(char[,] Matrix,int numberMatrix)
        {
            if (numberMatrix == 1 )
            {
                Console.WriteLine("============= Поле для выстрелов ============= \n" );
            }
            if (numberMatrix == 2 )
            {
                Console.WriteLine("============= Поле с короблями ============= \n");
            }
            Console.WriteLine("АБВГДЕЖЗИК");
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (Matrix[i, j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (Matrix[i, j] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (Matrix[i, j] == 'C')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (Matrix[i, j] == 'I')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (Matrix[i, j] == 0)
                    {
                        Matrix[i, j] = '0';
                    }
                    Console.Write(Matrix[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
