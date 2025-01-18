## Dynamic Programming

### Recursion
Recursion in computer science is a technique where the solution to a problem depends on solutions to smaller instances of the same problem.

Base Case: Case of recursion where the answer to the instance is known, where problem cannot be further broken down.

Recursion = Principal of Mathematical Induction
1. Figure out the smallest case 
2. Always assume the subproblem can be solved.
3. Solve the current problem assuming subproblem solution exists.

Note:
- Recursion always takes extra space due to implicit stack.

<strong>Problem 1:<br> Factorial of a number.<br>
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

<strong>Problem 2:<br> Fibonacci series Nth Term.<br>
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

<strong>Problem 3:<br> Write a function to check if an array is sorted.</strong>

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

<strong>Problem 4 <br> Print numbers 1...N recursively.</strong>

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

<strong>Problem 5 <br> Power of N.</strong>

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

<strong>Problem 5 <br> 
Power of N.<br>
Given a '4 x N' board and tiles of size '4 x 1', count the number of ways to tile the given board using '4 x 1' tiles.

Note: A tile can either be placed horizontally (1 x 4) or Vertically (4 x 1).

</strong>

Recursive Case:
- If we place the tiles Vertically then we will be reducing the board size by 1.
- If we place the tiles horizontally then we will be reducing the board size by 4.
- N > 4 We can either place tiles horizontally or Vertically: f(N) = f(N-1) + f(N-4)
Base Case:
- N = 0, 1 Way
- N = 1, 1 Way
- N = 2, 1 Way (since we have to place all the tiles Vertically)
- N = 3, 1 (Way since we have to place all the tiles Vertically)
