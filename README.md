# Tower of Hanoi as a C# Console Application

This project implements the Tower of Hanoi problem using both recursive and iterative approaches in C#. The solution can be run from Visual Studio Code and .NET.

---

## Prerequisites

- Install .NET SDK (8.0 or later)
- Install Visual Studio Code

---

## Running the Program

### **Using VS Code**
1. Open Visual Studio Code.
2. Click File → Open Folder and select the folder containing the project.
3. Open the Terminal in VS Code.
4. Run the following command:
   ```
   dotnet run -Recursive 4
   ```
   This runs the recursive Tower of Hanoi solution for **4 disks**.

5. To use the iterative approach, run:
   ```
   dotnet run -Iterative 4
   ```

---

## Implementation

## Recursive Implementation
### Concept
The recursive solution breaks the problem down into smaller subproblems:
1. Move `n-1` disks from Source → Auxiliary.
2. Move the largest disk from Source → Destination.
3. Move `n-1` disks from Auxiliary → Destination.

### Code Explanation
```csharp
static void SolveHanoiRecursive(int numDisks, string source, string destination, string auxiliary)
{
    if (numDisks == 1)
    {
        Console.WriteLine($"Move disk 1 from {source} to {destination}");
        return;
    }

    SolveHanoiRecursive(numDisks - 1, source, auxiliary, destination);
    Console.WriteLine($"Move disk {numDisks} from {source} to {destination}");
    SolveHanoiRecursive(numDisks - 1, auxiliary, destination, source);
}
```
---

## Iterative Implementation
### Concept
Instead of recursion, we use a stack to simulate the recursive behavior. The program follows the same logic but explicitly manages moves.

### Code Explanation
```csharp
static void SolveHanoiIterative(int numDisks, string source, string destination, string auxiliary)
{
    Stack<Move> stack = new Stack<Move>();
    stack.Push(new Move(numDisks, source, destination));

    while (stack.Count > 0)
    {
        Move move = stack.Pop();
        int disk = move.Disk;

        if (disk == 1)
        {
            Console.WriteLine($"Move disk 1 from {move.From} to {move.To}");
        }
        else
        {
            stack.Push(new Move(disk - 1, auxiliary, destination));
            stack.Push(new Move(1, move.From, move.To));
            stack.Push(new Move(disk - 1, move.From, auxiliary));
        }
    }
}
```

## Command-Line Arguments Example with 3 disks

```sh
dotnet run -Recursive 3
dotnet run -Iterative 3
```

---

### **Problem:**  
I struggled to understand the iterative stack-based approach, mainly because I didn’t invest enough time in the assignment. As a result, I relied heavily on YouTube and AI for guidance. However, I hope that my solution is still kind of viable.

---


## References
- [Tower of Hanoi - Wikipedia](https://en.wikipedia.org/wiki/Tower_of_Hanoi)
- [Play Tower of Hanoi](https://www.mathsisfun.com/games/towerofhanoi.html)
- [C# CheatSheet](https://yun-vis.github.io/fhstp-bcc-csharp/)
- [Solving the Tower of Hanoi](https://staael.com/blog/tower-of-hanoi)
- [GeeksForGeeks - Char keyword](https://www.geeksforgeeks.org/char-keyword-in-c-sharp/)

