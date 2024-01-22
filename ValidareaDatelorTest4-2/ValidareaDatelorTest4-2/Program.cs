using System;

namespace Sudoku
{
    class Program
    {
        const int SudokuBoardSize = 9;
        const int SudokuBlockSize = 3;
        private const string ItemType1 = "linia";
        private const string ItemType2 = "coloana";
        private const string ItemType3 = "blocul";

        static void Main()
        {
            byte[,] sudokuBoard = new byte[SudokuBoardSize, SudokuBoardSize];
            string message = ReadSudokuBoard(sudokuBoard);
            if (message != "")
            {
                Console.WriteLine(message);
                Console.WriteLine(false);
            }
            else if (IsValidSudokuBoard(sudokuBoard) != "")
            {
                Console.WriteLine(IsValidSudokuBoard(sudokuBoard));
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(true);
            }

            Console.Read();
        }

        static string IsValidSudokuBoard(byte[,] sudokuBoard)
        {
            string message = "";
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                if (IsValidSudokuItem(sudokuBoard, ItemType1, i) != "")
                {
                    message = IsValidSudokuItem(sudokuBoard, ItemType1, i);
                    break;
                }
                else if (IsValidSudokuItem(sudokuBoard, ItemType2, i) != "")
                {
                    message = IsValidSudokuItem(sudokuBoard, ItemType2, i);
                    break;
                }
                else if (IsValidSudokuItem(sudokuBoard, ItemType3, i) != "")
                {
                    message = IsValidSudokuItem(sudokuBoard, ItemType3, i);
                    break;
                }
            }

            return message;
        }

        static string IsValidSudokuItem(byte[,] sudokuBoard, string itemType, int itemIndex)
        {
            byte[] sudokuValuesCount = new byte[SudokuBoardSize];
            string message = "";

            for (int i = 0; i < SudokuBoardSize; i++)
            {
                byte sudokuValue = GetSudokuValue(sudokuBoard, itemType, itemIndex, i);
                sudokuValuesCount[sudokuValue - 1]++;
                if (sudokuValuesCount[sudokuValue - 1] > 1)
                {
                    if (itemType == ItemType1)
                    {
                        message = "Elementul " + sudokuValue + " apare de mai multe ori pe " + itemType + " " + i;
                        break;
                    }
                    else if (itemType == ItemType2)
                    {
                        message = "Elementul " + sudokuValue + " apare de mai multe ori pe " + itemType + " " + (itemIndex + 1);
                        break;
                    }
                    else if (itemType == ItemType3)
                    {
                        message += "Elementul " + sudokuValue + " apare de mai multe ori in " + itemType + " " + (itemIndex + 1);
                        break;
                    }
                }
            }

            return message;
        }

        static byte GetSudokuValue(byte[,] sudokuBoard, string itemType, int itemIndex, int position)
        {
            switch (itemType)
            {
                case ItemType1:
                    return sudokuBoard[itemIndex, position];
                case ItemType2:
                    return sudokuBoard[position, itemIndex];
                case ItemType3:
                    int line = itemIndex / SudokuBlockSize * SudokuBlockSize + position / SudokuBlockSize;
                    int column = itemIndex % SudokuBlockSize * SudokuBlockSize + position % SudokuBlockSize;
                    return sudokuBoard[line, column];
            }

            return 0;
        }

        static string ReadSudokuBoard(byte[,] sudokuBoard)
        {
            string message = "";
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                int line = i + 1;
                string[] lineValues = ReadLineValues();
                if (lineValues.Length > SudokuBoardSize)
                {
                    message += "Sunt mai mult de 9 elemente pe linia " + line;
                }
                else if (lineValues.Length < SudokuBoardSize)
                {
                    message += "Sunt sub 9 elemente pe linia " + line;
                }
                else
                {
                    for (int j = 0; j < SudokuBoardSize; j++)
                    {
                        message += IsValidSudokuValue(lineValues[j], out int value) ? "" : "Element invalid pe linia " + line + ": " + lineValues[j];
                        sudokuBoard[i, j] = (byte)value;
                    }
                }
            }

            return message;
        }

        static string[] ReadLineValues()
        {
            string line;
            do
            {
                line = Console.ReadLine();
            }
            while (line == "");

            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        static bool IsValidSudokuValue(string stringValue, out int value)
        {
            if (!int.TryParse(stringValue, out value))
            {
                return false;
            }

            if (value < 1 || value > SudokuBoardSize)
            {
                return false;
            }

            return true;
        }
    }
}
