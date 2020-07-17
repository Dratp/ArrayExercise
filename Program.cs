using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;

namespace Extra31_58
{
    class Program
    {
        // Extra stuff 31-58


        static void Main(string[] args)
        {
            //Exercise31();
            //Exercise32();
            //Exercise33();
            //Exercise34();
            //Exercise35();
            //Exercise35WithSplit();
            //Exercise36();
            Exercise37through40();

        }

        private static void Exercise37through40()
        {
            Console.WriteLine("\nExercise 37\n");
            // Prompt the user to enter five numbers. Store these numbers in an array and output their sum.
            Console.WriteLine("\nExercise 38\n");
            // Prompt the user to enter five numbers. Store these numbers in an array and output their
            // average.
            Console.WriteLine("\nExercise 39\n");
            // Prompt the user to enter five numbers. Store these numbers in an array and output them in
            // ascending order
            Console.WriteLine("\nExercise 40\n");
            // Prompt the user to enter five numbers. Store these numbers in an array and output the median.

            double[] numbers = new double[5];
            double sum = 0;
            string proceed;
            do
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = GetVaildDouble("Enter a number: <<");
                    sum = sum + numbers[i];
                }
                Console.WriteLine("Sum:");
                Console.WriteLine($"{numbers[0]} + {numbers[1]} + {numbers[2]} + {numbers[3]} + {numbers[4]} = {sum}");
                Console.WriteLine("Average:");
                Console.WriteLine($"({numbers[0]} + {numbers[1]} + {numbers[2]} + {numbers[3]} + {numbers[4]}) / {numbers.Length} = {sum / numbers.Length}");
                Console.WriteLine("Sorted:");
                Array.Sort(numbers);
                DisplayArray(numbers);
                Console.WriteLine("Median");
                Console.WriteLine($"The median of ({numbers[0]}, {numbers[1]}, {numbers[2]}, {numbers[3]}, {numbers[4]}) is {numbers[2]}");
                Console.Write("would you like to continue (y/n)? ");
                proceed = GetYesOrNo();
            } while (proceed != "N");
            Console.WriteLine("Goodbye!");
        }

        private static void Exercise36()
        {
            Console.WriteLine("\nExercise 36\n");
            // Create two arrays, each of size 5. Fill the first array with the numbers: 12, 11, 10, 9, 8. Fill the
            // second array with the strings: "Drummers Drumming", "Pipers Piping", "Lords a-Leaping",
            // "Ladies Dancing", "Maids a-Milking".Combine both arrays to display a piece of the Christmas
            // song.

            string[] christmasGifts = { "Drummers Drumming", "Pipers Piping", "Lords-a-Leaping", "Ladies Dancing", "Maids-a-Milking" };
            int[] daysOfChristmas = { 12, 11, 10, 9, 8 };
            string proceed;

            do
            {
                for (int i = 0; i < daysOfChristmas.Length; i++)
                {
                    Console.WriteLine($"{daysOfChristmas[i]} {christmasGifts[i]}");
                }
                Console.Write("Enter a command (sing/quit): ");
                proceed = GetValidString("sing", "quit");
            } while (proceed != "quit");   

        }

        private static void Exercise35WithSplit()
        {
            Console.WriteLine("\nExercise 35\n");
            // Create an array of size 5 and fill it with the following strings: "cow", "elephant", "jaguar", "horse",
            // "crow".Prompt the user to enter two indices separated by a space. The first index will specify
            // the word, and the second will specify a letter in that word. Display the corresponding word and
            // letter.

            string[] Ex35 = { "Cow", "Elephant", "Jaguar", "Horse", "Crow" };
            DisplayArray(Ex35);

            bool isInputValid;
            string[] input;
            int[] index = { 0, 0 };
            
            string proceed = "N";
            //Console.WriteLine(Ex35.Length);

            Console.Write("Enter two indices: ");
            do
            {
                restart:
                input = Console.ReadLine().Split(" ");
                int length = input.Length;
                if (length != 2)
                {
                    Console.Write("Please enter 2 integers seperated by a space: ");
                    continue;
                }
                for (int i = 0; i < 2; i++)
                {
                    isInputValid = int.TryParse(input[i], out index[i]);
                    //Console.WriteLine($"isInputValid = {isInputValid}, input{i} = {input[i]}, index{i} = {index[i]}");
                    if (!isInputValid)
                    {
                        Console.WriteLine($"Index {i} was not an integer.  Please enter 2 integers seperated by a space: ");
                        goto restart;
                    }
                    if (index[i] > Ex35[i].Length)
                    {
                        Console.Write($"Index {i} is to large.  Please enter 2 integers seperated by a space: ");
                        goto restart;
                    }
                }
                Console.WriteLine($"The value at index {index[0]} is {Ex35[index[0]]}.  The letter at index {index[1]} is {Ex35[index[0]].Substring(index[1], 1)}");
                Console.Write("\nWould you like to continue (y/n)? ");
                proceed = GetYesOrNo();
            } while (proceed == "Y");

            Console.WriteLine("Goodbye!");
        }

        private static void Exercise35()
        {
            Console.WriteLine("\nExercise 35\n");
            // Create an array of size 5 and fill it with the following strings: "cow", "elephant", "jaguar", "horse",
            // "crow".Prompt the user to enter two indices separated by a space. The first index will specify
            // the word, and the second will specify a letter in that word. Display the corresponding word and
            // letter.

            string[] Ex35 = { "Cow", "Elephant", "Jaguar", "Horse", "Crow" };
            DisplayArray(Ex35);

            Regex validateIndices = new Regex(@"^[0-9]+\s[0-9]+$");
            bool isInputValid;
            string input;
            int index1;
            int index2;
            string proceed = " ";
            //Console.WriteLine(Ex35.Length);

            do
            {
                do
                {
                    Console.Write("Enter two indices: ");
                    input = Console.ReadLine();
                    isInputValid = validateIndices.IsMatch(input);
                    if (!isInputValid)
                    {
                        Console.WriteLine("Please use the format 2 numbers seperated by a space: ");
                        continue;
                    }
                    int space = input.IndexOf(" ");
                    //Console.WriteLine(space);
                    index1 = int.Parse(input.Substring(0, space));
                    index2 = int.Parse(input.Substring(space, input.Length - space));
                    if (index1 < Ex35.Length && index1 > -1)
                    {
                        if (index2 < Ex35[index1].Length && index2 > -1)
                        {
                            Console.WriteLine($"The value at index {index1} is {Ex35[index1]}.  The letter at index {index2} is {Ex35[index1].Substring(index2, 1)}");
                            isInputValid = true;
                        }
                        else
                        {
                            Console.WriteLine($"The second index is greater than the length of the word {Ex35[index1]} Please try again.");
                            isInputValid = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The first index is greater than the amount of objects in the array.  Please try again.");
                        isInputValid = false;
                    }
                } while (!isInputValid);

                Console.Write("Would you like to continue (y/n)? ");
                proceed = GetYesOrNo();

            } while (proceed == "Y");

            Console.WriteLine("Goodbye!");
        }


        private static void Exercise34()
        {
            Console.WriteLine("\nExercise 34\n");
            // Create an array of size 5 and fill it with the following numbers: 16, 32, 64, 128, 256. Prompt the
            // user to enter a command, 'half' or 'double'.If the user enters 'half', half all the elements in the
            // array.If the user enters 'double', double all the elements in the array.

            double[] Ex34 = { 8,16,32,64,128};
            DisplayArray(Ex34);

            while (true)
            {
                Console.Write("Enter a command (half/double): ");
                string input = GetValidString("half", "double");
                if (input == "half")
                {
                    Console.WriteLine("halfing the array");
                    for (int i = 0; i < Ex34.Count(); i++)
                    {
                        Ex34[i] = Ex34[i] / 2;
                    }
                }
                else if (input == "double")
                {
                    Console.WriteLine("doubling the array");
                    for (int i = 0; i < Ex34.Count(); i++)
                    {
                        Ex34[i] = Ex34[i] * 2;
                    }
                }
                DisplayArray(Ex34);
                Console.WriteLine("Would you like to continue (y/n)? ");
                string proceed = GetYesOrNo();
                if (proceed == "N")
                {
                    break;
                }
            }

            Console.WriteLine("Goodbye!");

        }

        private static void Exercise33()
        {
            // Create an array of size 5 and fill it with the following numbers: 2, 8, 0, 24, 51.Let the user change
            // the array by specifying an index and a replacement number.

            Console.WriteLine("\nExercise 33\n");
            
            int[] Ex33 = { 2, 8, 0, 24, 51 };
            string proceed;
            DisplayArray(Ex33);

            while (true)
            {
                int index = GetVaildInt("Enter an index of the array (0-4): ",0,4);
                Console.Write($"The value at index {index} is {Ex33[index]}.  Would you like to change it (y/n)? ");
                string choice = GetYesOrNo();
                switch (choice)
                {
                    case "Y":
                        int input = GetVaildInt($"Enter the new value at index {index}: "); 
                        Ex33[index] = input;
                        DisplayArray(Ex33);
                        break;
                    case "N":
                        break;
                }
                Console.WriteLine("Would you like to continue y/n? ");
                proceed = GetYesOrNo();
                if (proceed == "N")
                {
                    break;
                }
            }
            Console.WriteLine("Goodbye!");
        }

        private static void Exercise32()
        {
            // Create an array of size 5 and fill it with the following numbers: 2, 8, 0, 24, 51. Prompt the user to
            // enter a number.If the number is in the array, display the index at which it is located.
            
            Console.WriteLine("\nExercise 32\n");
            
            int[] Ex32 = { 2, 8, 0, 24, 51 };
            string proceed;
            DisplayArray(Ex32);

            while (true)
            {
                int input = GetVaildInt("Enter an integer and we will see if it is in the array: ");
                int index = Array.IndexOf(Ex32, input);
                if (index > 0)
                {
                    Console.WriteLine($"That number is in the array at index {index}!");
                }
                else
                {
                    Console.WriteLine("That number is not in the Array.");
                }
                Console.Write("Would you like to continue (y/n): ");
                proceed = Console.ReadLine();
                if (proceed == "n")
                {
                    break;
                }
            }
            Console.WriteLine("Goodbye!");

        }

        private static void Exercise31()
        {
            // Create an array of size 5 and fill it with the following numbers: 2, 8, 0, 24, 51. Prompt the user to
            // enter an index.Display the element in the array at that index.
            
            Console.WriteLine("\nExercise 31\n");
            
            int[] Ex31 = { 2, 8, 0, 24, 51 };
            string proceed;
            DisplayArray(Ex31);

            while (true)
            {
                int input = GetVaildInt("Enter an index of the array 0, 1, 2, 3 or 4: ", 0, 4);
                Console.WriteLine(Ex31[input]);
                Console.Write("Would you like to continue (y/n): ");
                proceed = Console.ReadLine();
                if (proceed == "n")
                {
                    break;
                }
            }

        }

        static void DisplayArray(int[] numbers)
        {
            Console.Write("The array contains the following: ");

            foreach (int num in numbers)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine("\n");
        }

        static void DisplayArray(double[] numbers)
        {
            Console.Write("The array contains the following: ");

            foreach (double num in numbers)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine("\n");
        }

        static void DisplayArray(string[] words)
        {
            Console.Write("The array contains the following: ");

            foreach (string word in words)
            {
                Console.Write($"{word}, ");
            }
            Console.WriteLine("\n");
        }

        static string GetYesOrNo()
        {
            string choice;
            while (true)
            {
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                if (choice == "Y" || choice == "N")
                {
                    break;
                }
                else
                {
                    Console.Write("You did not enter y or n please try again: ");
                }
            }
            

            return choice;
        }

        static int GetVaildInt(string quest, int lower, int upper)
        {
            bool isValid;
            int validInt;

            Console.Write(quest);
            
            while(1 == 1)
            {
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out validInt);
                if (isValid && validInt <= upper && validInt >= lower)
                {
                    break;
                }
                else
                {
                    Console.Write("That is not a valid input please try again: ");
                }
            }

            return validInt;
        }

        static string GetValidString(string validChoice1, string validChoice2)
        {
            string userChoice;
            string Choice1 = validChoice1.ToUpper();
            string Choice2 = validChoice2.ToUpper();
            while (true)
            {
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToUpper();
                if (userChoice == Choice1)
                {
                    userChoice = validChoice1;
                    break;
                }
                else if(userChoice == Choice2)
                {
                    userChoice = validChoice2;
                    break;
                }
                else
                {
                    Console.Write($"That was not a valid input please choose {validChoice1} or {validChoice2}: ");
                }
            }

            return userChoice;
        }

        static int GetVaildInt(string quest)
        {
            bool isValid;
            int validInt;

            Console.Write(quest);

            while (1 == 1)
            {
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out validInt);
                if (isValid)
                {
                    break;
                }
                else
                {
                    Console.Write("That is not a valid input please try again: ");
                }
            }

            return validInt;
        }

        static double GetVaildDouble(string quest)
        {
            bool isValid;
            double validDouble;

            Console.Write(quest);

            while (1 == 1)
            {
                string input = Console.ReadLine();
                isValid = double.TryParse(input, out validDouble);
                if (isValid)
                {
                    break;
                }
                else
                {
                    Console.Write("That is not a valid input please try again: ");
                }
            }

            return validDouble;
        }


    }
}
