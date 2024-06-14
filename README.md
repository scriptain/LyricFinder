# LyricFinder

## Things I learned

Ref keyword. Passing arguments by reference instead of the default behaviour of passing a copy.

Generic methods. Specifically, the Select() method defined in System.Linq.Enumerable.

Interfaces: Looking into IEnumerable<T> I wanted to know what the “I” meant. I learned about Interfaces acting as contracts that must be satisfied for any class that implements a given interface.

Extension types: Saw that Select() was defined as an “extension” in the vscode popover that describes the implementation details. Learned that “extension” means it extends the functionality of the type(string, int) it is operating on as it is not defined on string, int, etc.

Method Signatures: I learned about method signatures being used by the compiler and visual studio (for tooltips). 

DirectoryInfo class: “provides a way to represent and manipulate directory paths and their contents on a file system”

## Errors I resolved

### Error CS0411 

Offending Code:   Select((line, index) => Console.WriteLine(index));

Why? The compiler expects a TResult which was satisfied in the original code (.Select((line, index) => new { LineNumber = index + 1, LineContent = line }) because that lambda expression was returning an ‘anonymous’ type whereas my code returned void which means no return value.

My solution: Modify signature of Select during use via Select<String, Int> resolved the issue in the editor. I ended up not using Select() in my current version. Current version of the program uses a for loop to loop through every line and checks each line for a match and does something if a match is found. 
