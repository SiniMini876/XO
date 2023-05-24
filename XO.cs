using System;

namespace XO
{
    internal class XO
    {
        private int[,] cells;
        private int size;
        const int X = 1;
        const int O = 2;
        public XO(int size = 3)
        {
            cells = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = 0;
                }
            }
            this.size = size;
        }

        public bool Occupied(int row, int col)
        {
            return cells[row, col] != 0;
        }

        public int GetSize()
        {
            return size;
        }

        public bool Occupy(int row, int col, int player)
        {
            if (Occupied(row, col))
                return false;
            else
                cells[row, col] = player;
            return true;
        }

        public void Print()
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    char player = cells[i, j] == 1 ? 'X' : cells[i, j] == 2 ? 'O' : ' ';
                    Console.Write($"| {player} ");
                }
                Console.Write("|");
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("-");
            }
        }

        public void Print(int[,] winner)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    char player = cells[i, j] == 1 ? 'X' : cells[i, j] == 2 ? 'O' : ' ';
                    Console.Write("|");
                    for (int k = 1; k < winner.GetLength(0); k++)
                    {
                        if (winner[k, 0] == i && winner[k, 1] == j)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                    }
                    Console.Write($" {player} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write("|");
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("-");
            }
        }

        public int[,] Won()
        {
            int cntXmain = 0, cntOmain = 0, cntXsec = 0, cntOsec = 0, cntXrow = 0, cntOrow = 0, cntXcol = 0, cntOcol = 0;
            for (int i = 0; i < size; i++)
            {
                if (cells[i, i] == 1)
                    cntXmain++;
                else if (cells[i, i] == 2)
                    cntOmain++;

                if (cells[i, size - 1 - i] == 1)
                    cntXsec++;
                else if (cells[i, size - 1 - i] == 2)
                    cntOsec++;

                for (int j = 0; j < size; j++)
                {
                    if (cells[i, j] == 1)
                        cntXrow++;
                    else if (cells[i, j] == 2)
                        cntOrow++;

                    if (cells[j, i] == 1)
                        cntXcol++;
                    else if (cells[j, i] == 2)
                        cntOcol++;
                }
                if (cntXrow == size)
                {
                    int[,] res = new int[size + 1, 2];
                    res[0, 0] = X;
                    for (int j = 1; j <= size; j++)
                    {
                        res[j, 0] = i;
                        res[j, 1] = j - 1;
                    }
                    return res;
                }
                if (cntXcol == size)
                {
                    int[,] res = new int[size + 1, 2];
                    res[0, 0] = X;
                    for (int j = 1; j <= size; j++)
                    {
                        res[j, 0] = j - 1;
                        res[j, 1] = i;
                    }
                    return res;
                }
                if (cntOrow == size)
                {
                    int[,] res = new int[size + 1, 2];
                    res[0, 0] = O;
                    for (int j = 1; j <= size; j++)
                    {
                        res[j, 0] = i;
                        res[j, 1] = j - 1;
                    }
                    return res;
                }
                if (cntOcol == size)
                {
                    int[,] res = new int[size + 1, 2];
                    res[0, 0] = O;
                    for (int j = 1; j <= size; j++)
                    {
                        res[j, 0] = j - 1;
                        res[j, 1] = i;
                    }
                    return res;
                }
                cntXrow = 0;
                cntXcol = 0;
                cntOrow = 0;
                cntOcol = 0;
            }
            if (cntXmain == size)
            {
                int[,] res = new int[size + 1, 2];
                res[0, 0] = X;
                for (int i = 1; i <= size; i++)
                {
                    res[i, 0] = i - 1;
                    res[i, 1] = i - 1;
                }
                return res;
            }
            if (cntXsec == size)
            {
                int[,] res = new int[size + 1, 2];
                res[0, 0] = X;
                for (int i = 1; i <= size; i++)
                {
                    res[i, 0] = i - 1;
                    res[i, 1] = size - i;
                }
                return res;
            }
            if (cntOmain == size)
            {
                int[,] res = new int[size + 1, 2];
                res[0, 0] = O;
                for (int i = 1; i <= size; i++)
                {
                    res[i, 0] = i - 1;
                    res[i, 1] = i - 1;
                }
                return res;
            }
            if (cntOsec == size)
            {
                int[,] res = new int[size + 1, 2];
                res[0, 0] = O;
                for (int i = 1; i <= size; i++)
                {
                    res[i, 0] = i - 1;
                    res[i, 1] = size - i;
                }
                return res;
            }

            bool full = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[i, j] == 0)
                        full = false;
                }
            }
            if (full)
                return new int[,] { { 4, 0 } };
            else
                return new int[,] { { 0, 0 } };

        }
    }
}
