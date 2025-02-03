# Dynamic Programming

## Recursion
Recursion in computer science is a technique where the solution to a problem depends on solutions to smaller instances of the same problem.

Base Case: Case of recursion where the answer to the instance is known, where problem cannot be further broken down.

Recursion = Principal of Mathematical Induction
1. Figure out the smallest case 
2. Always assume the subproblem can be solved.
3. Solve the current problem assuming subproblem solution exists.

Note:
- Recursion always takes extra space due to implicit stack.

### Problem 1
<strong>Factorial of a number.<br>
For N:<br>
N! => N x (n - 1)!<br>
(N - 1)! = (N - 1) x (N - 2)!<br>
(N - 2)! = (N - 2) x (N - 3)!<br>
.<br>.<br>.<br>
0! = 1

so f(N) = N x f(N - 1) 

</strong>

```cs
public class Solution
{
    public int Factorial(int n)
    {
        if (n == 0) return 1;
        return n * Factorial(n - 1);
    }
}
```
### Problem 2
<strong>Fibonacci series Nth Term.<br>
For N:<br>
Nth Term = (N - 1)th Term + (N - 2)th Term<br>

</strong>

```cs
public class Solution
{
    public int FibonacciTerm(int n)
    {
        if (n == 0 || n == 1) return n;
        int f1 = FibonacciTerm(n - 1);
        int f2 = FibonacciTerm(n - 2);
        return f1 + f2;
    }
}
```
### Problem 3
<strong>Write a function to check if an array is sorted.</strong>

```cs
public class Solution
{
    public bool IsArraySorted(int[] array, int index)
    {
        if (index >= array.Length - 1)
        {
            return true;
        }

        if (array[index] >  array[index + 1])
        {
            return false;
        }

        return IsArraySorted(array, index + 1);
    }
}
```
### Problem 4
<strong>Print numbers 1...N recursively.</strong>

```cs
public class Solution
{
    public void Decending(int n)
    {
        if (n <= 0) return;
        Console.WriteLine(n);
        Decending(n - 1);
    }

    public void Ascending(int n)
    {
        if (n <= 0) return;
        Ascending(n - 1);
        Console.WriteLine(n);
    }
}
```

### Problem 5
<strong>Power of N.</strong>

```cs
public class Solution
{
    public int Power(int n, int x)
    {
        if (x == 0) return 1;
        return n * Power(n, x - 1);
    }
}
```

But above solution is taking n call stack. Can we reduce it further ?

Yes: We know a<sup>n</sup> = (a<sup>n / 2</sup>)<sup>2</sup>

```cs
public class Solution
{
    public int Power(int n, int x)
    {
        if (x == 0) return 1;
        var t = Power(n, x / 2);
        if ((x & 1) == 0)
        {
            return t * t;
        }
        else
        {
            return n * t * t;
        }
    }
}
```

### Problem 6
<strong>
Power of N.<br>
Given a '4 x N' board and tiles of size '4 x 1', count the number of ways to tile the given board using '4 x 1' tiles.

Note: A tile can either be placed horizontally (1 x 4) or Vertically (4 x 1).

</strong>

<ins>Algorithm:</ins>

Recursive Case:
- If we place the tiles Vertically then we will be reducing the board size by 1.
- If we place the tiles horizontally then we will be reducing the board size by 4.
- N > 4 We can either place tiles horizontally or Vertically: f(N) = f(N - 1) + f(N - 4)

Base Case:
- N = 0, 1 Way
- N = 1, 1 Way
- N = 2, 1 Way (since we have to place all the tiles Vertically)
- N = 3, 1 (Way since we have to place all the tiles Vertically)

<img width="634" alt="Tiling Problem" src="https://github.com/user-attachments/assets/e437c1e3-5a94-45cf-90ec-a40a28b2afa5" />

### Problem 7
<strong>
Binary Strings <br> 
Count the number of binary strings with no consecutive ones that can be formed using a binary string of Length N.
</strong>

Ref: https://leetcode.com/problems/non-negative-integers-without-consecutive-ones/description/

Lets take N = 3
We have can:
```html
000        100
001        101
010        110 x
011 x      111 x
```

<ins>Algorithm:</ins>

Recursive Case:
- If we place 0 at some place, then on next place we can have anything
- If we place 1 at some place, then on next place we cannot place 1 thus we have to place 0
- f(N) = f(N - 1) + f(N - 2)

Base Case:
- N = 0, 1 Way
- N = 1, 2 Way
- N = 2, 3 Way

### Problem 8
<strong>
Friend's Pairing Problem
Given n friends who want to got to the party, each one can remain single or can be paired up with some other friend. Each friend can be paired only once. Find out the total number of ways in which friends can remain single or can be paired up.
</strong>

<ins>Algorithm:</ins>

Recursive Case:
- One person can alone
- If a person can pair up with someone, then there will be 'n - 1' option he/she will be having to make pair
- f(N) = f(N - 1) + f(N - 2) (N - 1)

Base Case:
- N = 0, 1 Way
- N = 1, 1 Way

### Problem 9 - Tower of Hanoi
Tower of Hanoi is a mathematical puzzle where we have three rods (A, B, and C) and N disks. Initially, all the disks are stacked in decreasing value of diameter i.e., the smallest disk is placed on the top and they are on rod A. The objective of the puzzle is to move the entire stack to another rod (here considered C), obeying the following simple rules: 
- Only one disk can be moved at a time.
- Each move consists of taking the upper disk from one of the stacks and placing it on top of another stack i.e. a disk can only be moved if it is the uppermost disk on a stack.
- No disk may be placed on top of a smaller disk.

![image](https://github.com/user-attachments/assets/bd5637c1-6531-4851-8a47-b81b1e093156)

```cs
public class Solution
{
    public void TowerOfHanoi(int n, char from, char aux, char to)
    {
        if (n <= 0) return;
        TowerOfHanoi(n - 1, from, to, aux);
        Console.WriteLine($"Rod_{from} -> Rod_{to}");
        TowerOfHanoi(n - 1, aux, from, to);
    }
}
```

Time complexity: O(2<sup>N</sup>), There are two possibilities for every disk. Therefore, 2 * 2 * 2 * . . . * 2(N times) is 2N<br> 
Auxiliary Space: O(N), Function call stack space<br> 


## Backtracking
- Algorithmic Technique
- Recursively trying to build solution
- Searching the entire search space to solve a computation problem

### Problem Types
- Decision Problem - check for feasible solution
- Optimisation Problem - find the best solution
- Enumeration Problem - find all solution

### Problem 10 - Power Set
<strong>Given an integer array nums of unique elements, return all possible subsets (the power set).
The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:<br>
Input: nums = [1,2,3]<br>
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]<br><br>
Example 2:<br>
Input: nums = [0]<br>
Output: [[],[0]]</strong>
<br><br>


Ref: https://leetcode.com/problems/subsets/description/

```cs
public class Solution
{
    private IList<IList<int>> result = new();

    public IList<IList<int>> Subsets(int[] nums)
    {
        Find(nums, new List<int>(nums.Length), 0);
        return result;
    }

    private void Find(int[] nums, List<int> list, int i)
    {
        if (i == nums.Length)
        {
            result.Add(new List<int>(list));
            return;
        }

        list.Add(nums[i]);
        Find(nums, list, i + 1);
        list.RemoveAt(list.Count - 1);
        Find(nums, list, i + 1);
    }
}
```

### Problem 11 - N Queens
<strong>The N Queen is the problem of placing N chess queens on an N×N chessboard so that no two queens attack each other.
<img height="300" alt="image" src="https://github.com/user-attachments/assets/40c3a690-be22-4482-8d5e-1a3091f28ab2" />
<img height="300" alt="image" src="https://github.com/user-attachments/assets/d7d28bdb-11e1-489c-8a5a-ccf221d1c145" />

N Queen Problem using Backtracking:<br>
The idea is to place queens one by one in different columns, starting from the leftmost column. When we place a queen in a column, we check for clashes with already placed queens. In the current column, if we find a row for which there is no clash, we mark this row and column as part of the solution. If we do not find such a row due to clashes, then we backtrack and return false.

<img width="751" alt="image" src="https://github.com/user-attachments/assets/026ee17d-f8dd-4d7d-9cfd-2b4f03191633" />

</strong>
<br><br>

Ref: https://leetcode.com/problems/n-queens/description/

```cs
public class Solution
{
    private readonly int[][] _board;
    private readonly int _size;
    public Solution(int size)
    {
        _size = size;
        //Preparing the board
        _board = new int[size][];
        for (int i = 0; i < size; i++)
        {
            _board[i] = new int[size];
        }
    }

    public bool SolveNQueen(int row)
    {
        if (row == _size)
        {
            //Print the board
            PrintBoard();
            return true;
        }

        for (int i = 0; i < _size; i++)
        {
            if (CanPlace(row, i))
            {
                _board[row][i] = 1;
                bool success = SolveNQueen(row + 1);

                if (!success)
                {
                    _board[row][i] = 0;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CanPlace(int row, int col)
    {
        if (row ==  0)
        {
            return true;
        }

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (_board[i][j] == 1)
                {
                    if (col == j || Math.Abs(row - i) == Math.Abs(col - j)) return false;
                    break;
                }
            }
        }

        return true;
    }

    private void PrintBoard()
    {
        foreach (int[] row in _board)
        {
            foreach (int col in row)
            {
                Console.Write($"{(col == 1 ? 'Q' : 'X')} ");
            }
            Console.WriteLine();
        }
    }
}
```

<strong>
    Count the numbers of ways to place the Queeen.
</strong>
<br><br>

```cs
public class Solution
{
    private readonly int[][] _board;
    private readonly int _size;
    public Solution(int size)
    {
        _size = size;
        //Preparing the board
        _board = new int[size][];
        for (int i = 0; i < size; i++)
        {
            _board[i] = new int[size];
        }
    }

    public int SolveNQueen(int row)
    {
        if (row == _size)
        {
            return 1;
        }
        int ways = 0;
        for (int i = 0; i < _size; i++)
        {
            if (CanPlace(row, i))
            {
                _board[row][i] = 1;
                ways += SolveNQueen(row + 1);
                _board[row][i] = 0;
            }
        }
        return ways;
    }

    private bool CanPlace(int row, int col)
    {
        if (row ==  0)
        {
            return true;
        }

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (_board[i][j] == 1)
                {
                    if (col == j || Math.Abs(row - i) == Math.Abs(col - j)) return false;
                    break;
                }
            }
        }

        return true;
    }
}
```
Complexity: O(N<sup>N</sup>) or o(N!)

### Problem 11 - Generate Parentheses
<strong>
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.<br><br>

Example 1:<br>
Input: n = 3<br>
Output: ["((()))","(()())","(())()","()(())","()()()"]<br><br>

Example 2:<br>
Input: n = 1<br>
Output: ["()"]<br>

</strong>

Ref: https://leetcode.com/problems/generate-parentheses/description/

<br>

```cs
public class Solution 
{
    public IList<string> GenerateParenthesis(int n) 
    {
        var result = new List<string>();
        Generate(new char[2 * n], 0, result);
        return result;        
    }
    public void Generate(char[] braces, int index, List<string> result)
    {
        if (index == braces.Length)
        {
            if (IsValid(braces))
            {
                result.Add(string.Join("", braces));
            }
            return;
        }

        if (index is 0)
        {
            braces[0] = '(';
            Generate(braces, 1, result);
        }
        else
        {
            braces[index] = '(';
            Generate(braces, index + 1, result);
            braces[index] = ')';
            Generate(braces, index + 1, result);
        }
    }
    private bool IsValid(char[] braces) 
    {
        int check = 0;
        for (int i = 0; i < braces.Length; i++)
        {
            if (braces[i] == '(') check++;
            else check--;

            if (check < 0) return false;
        }
        return check == 0;
    }
}
```


### Problem 12 - Solve Sudoku

Ref: https://leetcode.com/problems/sudoku-solver/description/

```cs
public class Solution 
{
    private const int max = 9;
    public void SolveSudoku(char[][] board) 
    {
        Solve(board, 0, 0);
    }

    private bool Solve(char[][] board, int i, int j)
    {
        if (i == board.Length)
        {
            return true;
        }

        if (j == board.Length)
        {
            return Solve(board, i + 1, 0);
        }

        if (board[i][j] != '.')
        {
            return Solve(board, i, j + 1);
        }

        for (int n = 1; n <= max; n++)
        {
            if (CanPlace(board, i, j, (char)('0' + n))) 
            {
                board[i][j] = (char)('0' + n);
                if (Solve(board, i, j + 1))
                {
                    return true;
                }
            }
        }

        board[i][j] = '.';
        return false;
    }

    private bool CanPlace(char[][] board, int i, int j, char n)
    {
        for (int k = 0; k < board.Length; k++)
        {
            if (board[i][k] == n || board[k][j] == n) return false;
        }

        var x = (i / 3) * 3;
        var y = (j / 3) * 3;

        for (int r = x; r < (3 + x); r++)
        {
            for (int c = y; c < (3 + y); c++)
            {
                if (board[r][c] == n)
                {
                    return false;
                }
            }            
        }

        return true;
    }
}
```

<br>

**Similar Problem: Validate if Soduko board is valid.**

Ref: https://leetcode.com/problems/valid-sudoku/description/

```cs
public class Solution 
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
            if ((k != j && board[i][k] == n) 
                    || (i != k && board[k][j] == n)
                ) 
            { 
                return false;
            }
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
```

### Hamiltonian Path

Hamiltonian Path is a path in a directed or undirected graph that visits each vertex exactly once. The problem to check a graph (directed or undirected) contains a Hamiltonian path is NP-Complete, so it is the problem of finding all the Hamiltonian Paths in a graph.

### Problem 13 - Unique Path 3

Ref: https://leetcode.com/problems/unique-paths-iii/description/

```cs
public class Solution 
{
    private readonly int[][] directions = new int[4][]
    {
        new int[] {0, -1},
        new int[] {0, 1},
        new int[] {-1, 0},
        new int[] {1, 0},
    };

    public int UniquePathsIII(int[][] grid) 
    {
        var visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++) visited[i] = new bool[grid[0].Length];
        
        var obstacles = 0;
        var startX = 0;
        var startY = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    startX = i;
                    startY = j;
                    visited[startX][startY] = true;
                }

                if (grid[i][j] == -1)
                {
                    obstacles++;
                }
            }
        }

        return CanWin(grid, visited, startX, startY, 1, obstacles);
    }

    private int CanWin(int[][] grid, bool[][] visited, int i, int j, int count, int obstacles)
    {
        if (grid[i][j] == 2)
        {
            return count == (grid.Length * grid[0].Length - obstacles) ? 1 : 0;
        }

        var result = 0;

        foreach (var direction in directions)
        {
            var x = i + direction[0];
            var y = j + direction[1];

            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length) continue;

            if (!visited[x][y] && grid[x][y] != -1)
            {
                visited[x][y] = true;
                result += CanWin(grid, visited, x, y, count + 1, obstacles);
                visited[x][y] = false;
            }
        }

        return result;
    }
}
```


## Tiling Problems
### Problem 14: Domino and Tromino Tiling

Ref: https://leetcode.com/problems/domino-and-tromino-tiling/description/

```cs
public class Solution 
{
    private const long MODULO = 1_000_000_007;
    public int NumTilings(int n) 
    {
        var f = new long[n + 1];
        var g = new long[n + 1];

        for (int i = 0; i <= 2 && i <= n; i++)
        {
            f[i] = g[i] = i;
        }

        for (int i = 3; i <= n; i++)
        {
            f[i] = (f[i - 1] + f[i - 2] + 2 * g[i - 2]) % MODULO;
            g[i] = (g[i - 1] + f[i - 1]) % MODULO;
        }
        
        return (int)f[n];
    }
}
```

## Pascal Triangle
In mathematics, Pascal's triangle is an infinite triangular array of the binomial coefficients which play a crucial role in probability theory, combinatorics, and algebra.

![image](https://github.com/user-attachments/assets/13177e41-24d5-40ed-8f13-c40b8cde1ee8)

### Patterns Within the Triangle
- The first diagonal is, of course, just "1"s
- The next diagonal has the Counting Numbers (1,2,3, etc).
- The third diagonal has the triangular numbers
    - Nth Term of the series is **N (N + 1) / 2**
- The fourth diagonal, not highlighted, has the tetrahedral numbers.
    - Nth Term of the series is (n * (n + 1) * (n + 2)) / 6

![image](https://github.com/user-attachments/assets/afd0edc0-ef68-4975-b8a4-b338080cc752)

### Symmetrical
The triangle is also symmetrical. The numbers on the left side have identical matching numbers on the right side, like a mirror image.

![image](https://github.com/user-attachments/assets/996b026e-2b1f-40c3-bfb8-d315697b63c4)

### Horizontal Sums
- The horizontal sum is Power of 2.
- Nth Term of the series is 2 <sup>N - 1</sup>

<br>

![image](https://github.com/user-attachments/assets/c8d5a669-c822-4120-ac80-2a64c6331033)

### Exponents of 11
Each line is also the powers (exponents) of 11:
- 11<sup>0</sup> = 1
- 11<sup>1</sup> = 11
- 11<sup>2</sup> = 121
- ...
- 11<sup>5</sup> = 161051 <br><br>
  ![image](https://github.com/user-attachments/assets/55f42b3f-8489-4742-8214-bf6b45ee27de)

<br>

![image](https://github.com/user-attachments/assets/d8b54be7-455e-45dd-a34a-bff9eb965820)

### Fibonacci Sequence
The Fibonacci Sequence is the series of numbers:
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...

![image](https://github.com/user-attachments/assets/f043a844-194b-43cd-8388-65e88a8e5413)

### Odds and Evens
If we color the Odd and Even numbers, we end up with a pattern the same as the Sierpinski Triangle

![image](https://github.com/user-attachments/assets/3c5a5f0b-0956-4c5a-8da4-c2355f94661d)

### Polynomials
Pascal's Triangle also shows us the coefficients in binomial expansion:

![image](https://github.com/user-attachments/assets/5bec5f87-209f-4d79-b781-f4dbe751ce64)
