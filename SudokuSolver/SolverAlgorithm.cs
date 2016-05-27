namespace SudokuSolver
{
    public class SolverAlgorithm
    {
        private int[,] matrix;
        private const int maxRow = 9;
        private const int maxCol = 9;

        public SolverAlgorithm(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public bool SolveSudoku()
        {

            int row;
            int col;
            int[] blankCell = FindBlankLocation();
            row = blankCell[0];
            col = blankCell[1];
            if (row == -1)
            {
                return true;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (IsValid(row, col, i))
                {
                    matrix[row, col] = i;
                    if (SolveSudoku())
                    {
                        return true;
                    }
                    matrix[row, col] = 0;
                }
            }

            return false;
        }

        private int[] FindBlankLocation()
        {
            int[] cell = new int[2];

            for (int i = 0; i < maxRow; i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        cell[0] = i;
                        cell[1] = j;
                        return cell;
                    }
                }
            }

            cell[0] = -1;
            cell[1] = -1;

            return cell;
        }

        private bool IsValid(int row, int col, int num)
        {
            if (!IsInRow(row, num) &&
                !IsInCol(col, num) &&
                !IsInBox(row - row % 3, col - col % 3, num))
            {
                return true;
            }

            return false;
        }

        private bool IsInRow(int row, int num)
        {
            for (int i = 0; i < maxRow; i++)
            {
                if (matrix[row, i] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInCol(int col, int num)
        {
            for (int i = 0; i < maxCol; i++)
            {
                if (matrix[i, col] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInBox(int row, int col, int num)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i + row, j + col] == num)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}