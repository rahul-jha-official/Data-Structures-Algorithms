# String
A string is an object of type String whose value is text. Internally, the text is stored as a sequential read-only collection of Char objects. The Length property of a string represents the number of Char objects it contains, not the number of Unicode characters. String is **immutable** type.

## Characters
- **char** is a keyword that is used to declare a variable which store a character value from the range of +U0000 to U+FFFF.
- The char type keyword is an alias for the .NET System.Char structure type that represents a Unicode UTF-16 character.
- Each character occupies 16 bits (2 Bytes) of memory.
- Some static methods of char
  - char.IsUpper
  - char.IsLower
  - char.IsLetter
  - char.IsWhiteSpace
  - char.IsBetween
  - char.ToUpper
  - char.ToLower
 
## String Interning
String interning in C# is a memory optimization technique used to reduce the memory usage by storing only one copy of each distinct string value. When a string is interned, the runtime ensures that all instances of the string with the same value point to the same memory location, rather than creating separate copies for each instance.

Interned strings are never garbage-collected until the application domain is unloaded, so they stay in memory for the duration of the program's execution. Therefore, interning too many strings can lead to excessive memory usage, especially if you are working with a large number of unique strings.
