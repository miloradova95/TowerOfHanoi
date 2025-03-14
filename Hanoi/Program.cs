namespace Hanoi
{
    class Program
    {
        //Helper class to store the move of a disk from one pole to another
        class Move
        {
            public int Disk;
            public string From, To;

            public Move(int disk, string from, string to)
            {
                Disk = disk;
                From = from;
                To = to;
            }
        }


        // Recursive solution to the Tower of Hanoi problem
        // Move numDisks disks from the source pole to the destination pole with auxiliary pole as the helper
        // disks are numbered from 1 to n(numDisks) where 1 is the smallest disk and n(numDisks) is the largest disk
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

        //Iterative solution to the Tower of Hanoi problem using a stack
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

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("  hanoi -Recursive <numDisks>");
                Console.WriteLine("  hanoi -Iterative <numDisks>");
                return;
            }

            if (!int.TryParse(args[1], out int numDisks) || numDisks < 1)
            {
                Console.WriteLine("Error: Please provide a valid positive integer for the number of disks.");
                return;
            }

            if (args[0] == "-Recursive")
            {
                Console.WriteLine($"Solving Tower of Hanoi recursively with {numDisks} disks:");
                SolveHanoiRecursive(numDisks, "A", "C", "B");
            }
            else if (args[0] == "-Iterative")
            {
                Console.WriteLine($"Solving Tower of Hanoi iteratively with {numDisks} disks:");
                SolveHanoiIterative(numDisks, "A", "C", "B");
            }
            else
            {
                Console.WriteLine("Error: Invalid option. Use -Recursive or -Iterative.");
            }
        }
    }
}