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
