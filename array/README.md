# Array
You can store multiple variables of the same type in an array data structure. You declare an array by specifying the type of its elements. If you want the array to store elements of any type, you can specify object as its type.
```cs 
datatype[] arrayName;
```

An array has the following properties:
- An array can be single-dimensional, multidimensional, or jagged.
- The number of dimensions are set when an array variable is declared. The length of each dimension is established when the array instance is created. These values can't be changed during the lifetime of the instance.
- A jagged array is an array of arrays, and each member array has the default value of null.
- Arrays are zero indexed: an array with n elements is indexed from 0 to n-1.
- Array elements can be of any type, including an array type.
- Array types are reference types derived from the abstract base type Array. All arrays implement IList and IEnumerable. You can use the foreach statement to iterate through an array. Single-dimensional arrays also implement IList and IEnumerable.


Usefull Single Dimensional Array Syntax
- array[^1] -> Get last element or get first element from end.
- array[^2] -> Get second last element or get second element from end.

### Params Keyword
- **params** keyword is used as a parameter which can take the VARIABLE number of parameters.
- It is useful when programmer don't have any prior knowledge about the number of parameters to be used.

Syntax:
```cs
void MethodName(params DataType[] VariableName)
{
    //Body of Method
}
```

## Sorting

### Bubble Sort
Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in the wrong order. This algorithm is not suitable for large data sets as its average and worst-case time complexity are quite high.

**Complexity Analysis of Bubble Sort:**
- Time Complexity: O(N<sup>2</sup>)
- Auxiliary Space: O(1)

```cs
public class BubbleSort<T> where T: IComparable<T>
{
    public void Sort(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}
```

### Selection Sort
Selection Sort is a comparison-based sorting algorithm. It sorts an array by repeatedly selecting the smallest (or largest) element from the unsorted portion and swapping it with the first unsorted element. This process continues until the entire array is sorted.

**Complexity Analysis of Bubble Sort:**
- Time Complexity: O(N<sup>2</sup>)
- Auxiliary Space: O(1)

```cs
public class SelectionSort<T> where T: IComparable<T>
{
    public void Sort(T[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            var minIndex = i + 1;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[minIndex].CompareTo(array[j]) > 0)
                {
                    minIndex = j;
                }
            }

            if (array[i].CompareTo(array[minIndex]) > 0)
            {
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }
    }
}
```

### Insertion Sort
Insertion sort is a simple sorting algorithm that works by iteratively inserting each element of an unsorted list into its correct position in a sorted portion of the list.

**Complexity Analysis of Bubble Sort:**
- Time Complexity:
  - Best Case: O(N)
  - Average Case: O(N<sup>2</sup>)
  - Worst Case: O(N<sup>2</sup>)
- Auxiliary Space: O(1)

```cs
public class InsertionSort<T> where T: IComparable<T>
{
    public void Sort(T[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            var value = array[i];
            var index = i - 1;
            while (index >= 0 && array[index].CompareTo(value) > 0)
            {
                array[index + 1] = array[index--];
            }
            array[index + 1] = value;
        }
    }
}
```

### Merge Sort
Merge sort is a sorting algorithm that follows the divide-and-conquer approach. It works by recursively dividing the input array into smaller subarrays and sorting those subarrays then merging them back together to obtain the sorted array.

**Complexity Analysis of Merge Sort**
- Time Complexity:
  - Best Case: O(n log n), When the array is already sorted or nearly sorted.
  - Average Case: O(n log n), When the array is randomly ordered.
  - Worst Case: O(n log n), When the array is sorted in reverse order.
- Auxiliary Space: O(n), Additional space is required for the temporary array used during merging.

```cs
public class MergeSort<T> where T: IComparable<T>
{
    public void Sort(T[] array)
    {
        Divide(array, 0, array.Length - 1);
    }

    private void Divide(T[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        int middle = (right - left) / 2 + left;

        Divide(array, left, middle);
        Divide(array, middle + 1, right);
        Conquer(array, left, right);
    }
    private void Conquer(T[] array, int left, int right)
    {
        for (int i = left; i <= right; i++)
        {
            var value = array[i];
            var index = i - 1;
            while (index >= 0 && array[index].CompareTo(value) > 0)
            {
                array[index + 1] = array[index--];
            }
            array[index + 1] = value;
        }
    }
}
```
