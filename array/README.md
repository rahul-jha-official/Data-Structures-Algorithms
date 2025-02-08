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
- Auxiliary Space: O(1), Additional space is required for the temporary array used during merging.

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
### Counting Sort
Counting Sort is a non-comparison-based sorting algorithm. It is particularly efficient when the range of input values is small compared to the number of elements to be sorted. The basic idea behind Counting Sort is to count the frequency of each distinct element in the input array and use that information to place the elements in their correct sorted positions.

* Note that it will only work with limited set of number 'k' such that 'k' is too much less than size of the number 'n'.
* Creating a list of 'k' elements store the count in the list and finally insert each number based on their count

**Complexity Analysis of Merge Sort**
- Time Complexity: O(N+M), where N and M are the size of inputArray[] and countArray[] respectively
  - Best Case: O(N+M)
  - Average Case: O(N+M)
  - Worst Case: O(N+M)
- Auxiliary Space: O(N+M)

```cs
public class CountingSort<T> where T: IComparable<T>
{
    public void Sort(T[] array)
    {
        var maps = new SortedDictionary<T, int>();
        foreach (var item in array)
        {
            if (!maps.ContainsKey(item)) maps.Add(item, 0);
            maps[item]++;
        }
        int index = 0;
        foreach (var item in maps.Keys)
        {
            for (int i = 0; i < maps[item]; i++)
            {
                array[index++] = item;
            }
        }
    }
}
```

### Heap Sort
Heap sort is a comparison-based sorting technique based on Binary Heap Data Structure. It can be seen as an optimization over selection sort where we first find the max (or min) element and swap it with the last (or first). We repeat the same process for the remaining elements. In Heap Sort, we use Binary Heap so that we can quickly find and move the max element in O(Log n) instead of O(n) and hence achieve the O(n Log n) time complexity.

- Heap is a Binary Tree with the following property:
    - Tree should be complete. Left node should be filled first before filing the right element.
    - Every Node's key is larger than (or equal to) the key of its children.

Algorithm:
- Create a heap from the array elements.
- Poll (Fetch the Root and then delete the root) the element from the heap and store the element in the last.
- Repeat the process unti the heap become empty.

Complexity Analysis of Heap Sort
- Time Complexity: O(n log n)
- Auxiliary Space: O(log n), due to the recursive call stack. However, auxiliary space can be O(1) for iterative implementation.

```cs
public class HeapSort<T> where T: IComparable<T>
{
    public void Sort(T[] array)
    {
        CreateHeap(array);
        
        for (int i = array.Length - 1; i >= 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            FixHeapForward(array, i);
        }
    }

    private void CreateHeap(T[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            FixHeapReverse(array, i);
        }
    }

    private void FixHeapReverse(T[] array, int i)
    {
        int j = (i - 1) / 2;
        while (array[i].CompareTo(array[j]) > 0) 
        {
            (array[i], array[j]) = (array[j], array[i]);
            i = j;
            j = (i - 1) / 2;
        }
    }

    private void FixHeapForward(T[] array, int limit)
    {
        int j = 0;
        while (j < limit)
        {
            int left = 2 * j + 1;
            int right = 2 * j + 2;

            if (left < limit && right < limit)
            {
                if (array[left].CompareTo(array[j]) >= 0 && array[left].CompareTo(array[right]) >= 0)
                {
                    (array[left], array[j]) = (array[j], array[left]);
                    j = left;
                }
                else if (array[right].CompareTo(array[j]) >= 0 && array[left].CompareTo(array[right]) <= 0)
                {
                    (array[right], array[j]) = (array[j], array[right]);
                    j = right;
                }
                else
                {
                    break;
                }
            }
            else if (left < limit)
            {
                if (array[left].CompareTo(array[j]) >= 0)
                {
                    (array[left], array[j]) = (array[j], array[left]);
                    j = left;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }
}
```
