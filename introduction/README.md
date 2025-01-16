## [Introduction](#Introduction)

### Data Structure
- Data is efficiently stored
- Data is arranged
- Programs access efficiently


**Types**
- Linear
    - Stack, Queue, LinkedList
- Non Linear
    - Graph, Tree, Heap

### Algorithm
- Plan or Blueprint
- Set of Instruction
- Execute in finite amount of time

**Why Algorithm ?**
- Mechanishm to compare Algorithms
- Predict performance
- Time and amount of resource


## [Abstract Data Type](#AbstractDataType)
- Abstraction to data structure
- Mathematical model of Data Structures
- Abtract Data Type specifies: 
    - Type of data represented or stored
    - Operation Supported

### Data Type
- Representation of Data
- Operations
- Primitive Data Types:
    - Integer, Byte, Long, Float, Double
    - Boolean, Character

## [Analysis Of Algorithm](#AnalysisOfAlgorithm)

### Time Complexity
- Running time of algorithm is proportional
- Increases with the size of the input

Ways to Analyse time complexity:
- Theoratical Analysis 
    - Performed on description of Algorithm
    - Independent of hardware & software
    - All possible input
- Experimental Analysis
    - Runtime measured on various input
    - Programming lanaguages provides time functions
    - Lapse time is computed.
    - Its easier than theoratical analysis
    - Hardware & Software dependent
    - Operating System dependent
    - Limited input
    - Difficult to predict precise running time
### Space Complexity
- How much memory is consumed.

## Order of Growth
![Screenshot from 2024-11-16 22-35-04](https://github.com/user-attachments/assets/66ae797a-f41a-43f3-8410-41f5422b8fc9)

## Asymptotic Analysis

```
f(n) n = 1,2,3,4,5...10...20...1,000...1,000,000

f(n) = n² + 6n + 5      n -> 1000

Note: Asymptotic means approaching a value

f(n) is said to be asymptotically equivalent to n²
```

### Asymptotic Notation
- Big-oh O( ): Worst Case: Upper Bound
- Big-Omega Ω( ): Best Case: Lower Bound
- Big-Theta θ( ): Average Case
