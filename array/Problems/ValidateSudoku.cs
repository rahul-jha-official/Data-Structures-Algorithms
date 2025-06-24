// LINK - https://leetcode.com/problems/valid-sudoku/description/

// Approach 1 - Match everything separately
public class ValidateSudoku 
{
    public bool IsValidSudoku(char[][] board) 
    {
        var set = new HashSet<char>();
        
        //Checking Rows
        foreach (char[] row in board) 
        {
            foreach (char element in row) 
            {
                if (element == '.') continue;
                bool flag = set.Add(element);
                if (!flag) return false;
            }
            set.Clear();
        }

        //Checking Column
        for (int i = 0; i < 9; i++) 
        {
            for (int j = 0; j < 9; j++) 
            {
                if (board[j][i] == '.') continue;
                bool flag = set.Add(board[j][i]);
                if (!flag) return false;
            }
            set.Clear();
        }

        //3 x 3
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }

        set.Clear();

        for (int i = 0; i < 3; i++) 
        {
            for (int j = 3; j < 6; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }

        set.Clear();

        for (int i = 0; i < 3; i++) 
        {
            for (int j = 6; j < 9; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }
        set.Clear();        
        /* ------------------------------------------- */
        
        for (int i = 3; i < 6; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }

        set.Clear();

        for (int i = 3; i < 6; i++) 
        {
            for (int j = 3; j < 6; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }
        
        set.Clear();  

        for (int i = 3; i < 6; i++) 
        {
            for (int j = 6; j < 9; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }

        set.Clear();

        /* ------------------------------------------- */
        
        for (int i = 6; i < 9; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }

        set.Clear();
        
        for (int i = 6; i < 9; i++) 
        {
            for (int j = 3; j < 6; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }
        
        set.Clear();
        
        for (int i = 6; i < 9; i++) 
        {
            for (int j = 6; j < 9; j++) 
            {
                if (board[i][j] == '.') continue;
                bool flag = set.Add(board[i][j]);
                if (!flag) return false;
            }
        }
        
        set.Clear();
        
        return true;
    }
}

// Approach 2 
public class ValidateSudoku 
{
    public bool IsValidSudoku(char[][] board) 
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[i][j] == '.') continue;
                if (!IsValid(board, i, j, board[i][j])) return false;
            }
        }
        return true;
    }

    private bool IsValid(char[][] board, int i, int j, char n)
    {
        for (int k = 0; k < board.Length; k++)
        {
            if ((k != j && board[i][k] == n) || (i != k && board[k][j] == n)) return false;
        }

        var x = (i / 3) * 3;
        var y = (j / 3) * 3;

        for (int r = x; r < (3 + x); r++)
        {
            for (int c = y; c < (3 + y); c++)
            {
                if (i == r && j == c)
                {
                    continue;
                }
                if (board[r][c] == n)
                {
                    return false;
                }
            }            
        }

        return true;
    }
}
