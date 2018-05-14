using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sample Question
// Author: Theodore Hua

namespace psc
{
    class Program
    {
        static void Main(string[] args)
        {
            String command;
            Int32 desiredSum;
            String[] seriesOfIntStrings;
            
            Boolean quit = false;

            // Loop over console input until quit command issued
            while(!quit)
            {
                // Display program info
                Console.WriteLine("\nPrint combinations for a specified sum.");
                Console.WriteLine("\nCommands");
                Console.WriteLine("\t /start to enter number series & specified sum");
                Console.WriteLine("\t /quit to end program.");
                Console.WriteLine("Please enter an option:");

                command = Console.ReadLine();
                switch (command)
                {
                    case "/start":
                        Console.WriteLine("\nEnter a series of integers (e.g. 1 2 5 6)");

                        // TODO - Test input for numbers only
                        // For now assume int input as expected
                        // BUG - If input has trailing whitespace, exception thrown

                        // As input is read from CLI, split into a string 
                        // array using whitespace as a delimiter 
                        seriesOfIntStrings = Console.ReadLine().Split(' ');

                        // Parse the string array to convert contents to 
                        // Int32 data type to stored in the Int List
                        List<int> seriesOfInts = seriesOfIntStrings.Select(Int32.Parse).ToList();

                        Console.WriteLine("\nEnter desired sum:");

                        // TODO - Test input for a single int only
                        // For now assume single int input
                        desiredSum = Int32.Parse(Console.ReadLine());

                        PrintSumCombinations(seriesOfInts, desiredSum);
                                                
                        break;
                    case "/help":
                        Console.WriteLine("\nNothing to see here, move along.\n");
                        break;

                    case "/quit":
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("\nI'm sorry Dave, I can't do that.\n");
                        break;
                }
             
            }
        }

        // Using the following function signature, write a C# function that prints out 
        // every combination of indices using Console.WriteLine() whose values add up 
        // to a specified sum, n. Values of 0 should be ignored.
        //
        // public void PrintSumCombinations(List<int> numbers, int n);
        // 
        // - It’s okay to use additional private functions to implement the public function
        // - Be sure to print out the indices of numbers and not the values at those indices
        // - Don’t worry too much about memory or CPU optimization; focus on correctness
        // 
        // To help clarify the problem, calling the function with the following input:
        // 
        // List<int> numbers = new List<int> { 1, 1, 2, 2, 4 };
        // PrintSumCombinations(numbers, 4);
        //
        // Should result in the following console output(the ordering of the different 
        // lines isn’t important and may vary by implementation):
        // 
        // 0 1 2 (i.e.numbers[0] + numbers[1] + numbers[2] = 1 + 1 + 2 = 4)
        // 0 1 3
        // 2 3
        // 4
        public static void PrintSumCombinations(List<int> numbers, int n)
        {
            int testSum = 0;
            String permutation = null;

            Console.WriteLine("\nPermutations:");

            // Loop through each element of the List.
            for(int i = 0; i <= numbers.Count; i++)
            {
                permutation = null;
                testSum = 0;

                // This loop will take each element as a starting point 
                // for a sum of a series. The loop will break once the 
                // specified sum, n, is met.
                for (int j = i; j < numbers.Count; j++)
                {
                    testSum += numbers.ElementAt<int>(j);
                    permutation = permutation + j.ToString() + " ";

                    if (testSum == n)
                    {
                        Console.WriteLine("\n" + permutation);
                    }
                }
            }
        }
    }
}
