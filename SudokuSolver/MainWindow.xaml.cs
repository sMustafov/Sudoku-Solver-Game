namespace SudokuSolver
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class MainWindow : Window
    {
        private bool canSolve = true;
        private int[,] sudokuMatrix;
        private const int maxRows = 9;
        private const int maxCols = 9;

        public MainWindow()
        {
            sudokuMatrix = new int[maxRows, maxCols];
            InitializeComponent();
        }

        private void FillSudokuMatrix(string coords, int number)
        {
            int row = int.Parse(coords[0].ToString());
            int col = int.Parse(coords[1].ToString());
            sudokuMatrix[row, col] = number;
        }

        private void MatrixInit(string coords)
        {
            int row = int.Parse(coords[0].ToString());
            int col = int.Parse(coords[1].ToString());
            sudokuMatrix[row, col] = 0;
            canSolve = true;
        }

        private void FillTextBox(TextBox textBox)
        {
            textBox.Background = Brushes.White;
            textBox.MaxLength = 1;
            try
            {
                string coords = textBox.Name.Substring(6);
                MatrixInit(coords);
                int number = int.Parse(textBox.Text);
                CanSolve(coords, number);
                FillSudokuMatrix(coords, number);
            }
            catch (Exception)
            {

            }
        }

        private void CanSolve(string coords, int number)
        {
            TextBox t = new TextBox();
            string n = string.Format("Number" + coords[0] + coords[1]);
            t = (TextBox)FindName(n);
            t.Background = Brushes.White;

            int currentRow = int.Parse(coords[0].ToString());
            int currentCol = int.Parse(coords[1].ToString());
            int unsolvedRow = -1;
            int unsolvedCol = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sudokuMatrix[i + (currentRow - currentRow % 3), j + (currentCol - currentCol % 3)] == number)
                    {
                        unsolvedRow = i;
                        unsolvedCol = j;
                        goto Outer;
                    }
                }
            }
            for (int col = 0; col < maxCols; col++)
            {
                if (col != currentCol &&
                    number == sudokuMatrix[currentRow, col])
                {
                    unsolvedCol = col;
                    goto Outer;
                }
            }
            for (int row = 0; row < maxRows; row++)
            {
                if (row != currentRow &&
                    number == sudokuMatrix[row, currentCol])
                {
                    unsolvedRow = row;
                    goto Outer;
                }
            }
        Outer:
            if (unsolvedRow != -1 || unsolvedCol != -1)
            {
                canSolve = false;
                t.Background = Brushes.Red;
            }
        }

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrix = new int[9, 9];
            Array.Copy(sudokuMatrix, 0, matrix, 0, 9 * 9);
            if (!canSolve)
            {
                Result.Text = "There is no solution !";
            }
            else
            {
                SolverAlgorithm solver = new SolverAlgorithm(matrix);

                if (!solver.SolveSudoku())
                {
                    Result.Text = "There is no solution !";
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            string name = "Number" + i + j;
                            TextBox t = (TextBox)FindName(name);
                            t.MaxLength = 0;

                            if (matrix[i, j] != sudokuMatrix[i, j])
                            {
                                t.Foreground = Brushes.Black;
                            }

                            t.Text = matrix[i, j].ToString();
                        }
                    }
                    Result.Text = "Sudoku Solved !";
                }
            }
        }

        private void Result_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result.MaxLength = 0;
        }

        private void Number00_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number00);
        }

        private void Number01_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number01);
        }

        private void Number02_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number02);
        }

        private void Number10_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number10);
        }

        private void Number11_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number11);
        }

        private void Number12_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number12);
        }

        private void Number20_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number20);
        }

        private void Number21_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number21);
        }

        private void Number22_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number22);
        }

        private void Number03_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number03);
        }

        private void Number04_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number04);
        }

        private void Number05_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number06);
        }

        private void Number13_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number06);
        }

        private void Number14_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number14);
        }

        private void Number15_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number15);
        }

        private void Number23_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number23);
        }

        private void Number24_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number24);
        }

        private void Number25_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number25);
        }

        private void Number06_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number06);
        }

        private void Number07_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number07);
        }

        private void Number08_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number08);
        }

        private void Number16_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number16);
        }

        private void Number17_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number17);
        }

        private void Number18_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number18);
        }

        private void Number26_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number26);
        }

        private void Number27_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number27);
        }

        private void Number28_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number28);
        }

        private void Number30_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number30);
        }

        private void Number31_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number31);
        }

        private void Number32_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number32);
        }

        private void Number40_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number40);
        }

        private void Number41_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number41);
        }

        private void Number42_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number42);
        }

        private void Number50_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number50);
        }

        private void Number51_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number51);
        }

        private void Number52_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number52);
        }

        private void Number33_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number33);
        }

        private void Number34_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number34);
        }

        private void Number35_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number35);
        }

        private void Number43_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number43);
        }

        private void Number44_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number44);
        }

        private void Number45_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number45);
        }

        private void Number53_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number53);
        }

        private void Number54_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number54);
        }

        private void Number55_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number55);
        }

        private void Number36_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number36);
        }

        private void Number37_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number37);
        }

        private void Number38_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number38);
        }

        private void Number46_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number46);
        }

        private void Number47_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number47);
        }

        private void Number48_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number48);
        }

        private void Number56_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number56);
        }

        private void Number57_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number57);
        }

        private void Number58_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number58);
        }

        private void Number60_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number60);
        }

        private void Number61_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number61);
        }

        private void Number62_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number62);
        }

        private void Number70_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number70);
        }

        private void Number71_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number71);
        }

        private void Number72_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number72);
        }

        private void Number80_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number80);
        }

        private void Number81_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number81);
        }

        private void Number82_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number82);
        }

        private void Number63_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number63);
        }

        private void Number64_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number64);
        }

        private void Number65_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number65);
        }

        private void Number73_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number73);
        }

        private void Number74_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number74);
        }

        private void Number75_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number75);
        }

        private void Number83_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number83);
        }

        private void Number84_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number84);
        }

        private void Number85_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number85);
        }

        private void Number66_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number66);
        }

        private void Number67_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number67);
        }

        private void Number68_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number68);
        }

        private void Number76_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number76);
        }

        private void Number77_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number77);
        }

        private void Number78_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number78);
        }

        private void Number86_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number86);
        }

        private void Number87_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number87);
        }

        private void Number88_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTextBox(Number88);
        }
    }
}