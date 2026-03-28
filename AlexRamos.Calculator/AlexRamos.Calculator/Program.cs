using System.Text.RegularExpressions;
using CalculatorLibrary;

/// <summary>
/// This class manages the program's execution flow.
/// </summary>
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEndApp = false;
            int numberOfOperations = 0;

            Calculator calculator = new();

            while (!isEndApp)
            {
                Console.WriteLine("Console Calculator in C# - Main Menu\r");
                Console.WriteLine("------------------------------------\n");

                Console.WriteLine("Choose an math category from the following list:\n");

                Console.WriteLine("\t1 - Arithmetic Operations");
                Console.WriteLine("\t2 - Exponents and Radicals");
                Console.WriteLine("\t3 - Trigonometric Functions");

                Console.WriteLine($"\nNumber of times calculator was used: {numberOfOperations}");

                Console.Write("\nWhat's your option? ");

                string? mathOperation = Console.ReadLine();

                if (mathOperation == null || !Regex.IsMatch(mathOperation.Trim(), "^[1-3]$"))
                {
                    Console.WriteLine("\nError: Unrecognized math category input.");
                }
                else
                {
                    switch (mathOperation)
                    {
                        case "1":
                            Console.Clear();

                            Console.WriteLine("Console Calculator in C# - Basic Arithmetic Operations\r");
                            Console.WriteLine("------------------------------------------------------\n");

                            Console.WriteLine("Choose an math operation from the following list:\n");

                            Console.WriteLine("\t1 - Add");
                            Console.WriteLine("\t2 - Subtract");
                            Console.WriteLine("\t3 - Multiply");
                            Console.WriteLine("\t4 - Divide");

                            Console.WriteLine($"\nNumber of times calculator was used: {numberOfOperations}");

                            Console.Write("\nWhat's your option? ");

                            mathOperation = Console.ReadLine();

                            if (mathOperation == null || !Regex.IsMatch(mathOperation.Trim(), "^[1-4]$"))
                            {
                                Console.WriteLine("\nError: Unrecognized input.");
                                break;
                            }
                            else
                            {
                                double cleanNum1 = GetValue();
                                double cleanNum2 = GetValue();

                                double result = 0;

                                numberOfOperations++;

                                try
                                {
                                    result = calculator.BasicArithmeticOperations(cleanNum1, cleanNum2, mathOperation);
                                    if (double.IsNaN(result))
                                    {
                                        Console.WriteLine("This operation will result in a mathematical error.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nYour result: {0:0.##}", result);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nOh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                                }
                            }

                            break;

                        case "2":
                            Console.Clear();

                            Console.WriteLine("Console Calculator in C# - Exponents and Radicals Operations\r");
                            Console.WriteLine("------------------------------------------------------------\n");

                            Console.WriteLine("Choose an math operation from the following list:\n");

                            Console.WriteLine("\t1 - Square Root");
                            Console.WriteLine("\t2 - Power of two");
                            Console.WriteLine("\t3 - Exponentiation");

                            Console.WriteLine($"\nNumber of times calculator was used: {numberOfOperations}");

                            Console.Write("\nWhat's your option? ");

                            mathOperation = Console.ReadLine();

                            if (mathOperation == null || !Regex.IsMatch(mathOperation.Trim(), "^[1-3]$"))
                            {
                                Console.WriteLine("\nError: Unrecognized math category input.");
                            }
                            else
                            {
                                double cleanNum1 = GetValue();

                                double result = 0;

                                numberOfOperations++;

                                try
                                {
                                    result = calculator.ExponentsAndRadicals(cleanNum1, mathOperation);

                                    if (double.IsNaN(result))
                                    {
                                        Console.WriteLine("This operation will result in a mathematical error.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nYour result: {0:0.##}", result);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nOh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                                }
                            }

                            break;

                        case "3":
                            Console.Clear();

                            Console.WriteLine("Console Calculator in C# - Trigonometric Functions\r");
                            Console.WriteLine("--------------------------------------------------\n");

                            Console.WriteLine("Choose an math operation from the following list:\n");

                            Console.WriteLine("\t1 - Sine");
                            Console.WriteLine("\t2 - Cosine");
                            Console.WriteLine("\t3 - Tangent");
                            Console.WriteLine("\t4 - Consecant");
                            Console.WriteLine("\t5 - Secant");
                            Console.WriteLine("\t6 - Cotangent");

                            Console.WriteLine($"\nNumber of times calculator was used: {numberOfOperations}");

                            Console.Write("\nWhat's your option? ");

                            mathOperation = Console.ReadLine();

                            if (mathOperation == null || !Regex.IsMatch(mathOperation.Trim(), "^[1-6]$"))
                            {
                                Console.WriteLine("\nError: Unrecognized math category input.");
                            }
                            else
                            {
                                double cleanNum1 = GetValue();

                                double result = 0;

                                numberOfOperations++;

                                try
                                {
                                    result = calculator.TrigonometricFunctions(cleanNum1, mathOperation);
                                    if (double.IsNaN(result))
                                    {
                                        Console.WriteLine("This operation will result in a mathematical error.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nYour result: {0:0.##}", result);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nOh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                                }
                            }

                            break;

                        default:
                            break;
                    }
                }

                Console.WriteLine("\n------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n")
                {
                    isEndApp = true;
                }

                Console.Clear();
            }

            calculator.Finish();

            return;
        }

        public static double GetValue()
        {
            Console.Write("\nType a number, and then press Enter: ");
            string? userInput = Console.ReadLine();

            double userNumber = 0;

            while (!double.TryParse(userInput, out userNumber))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                userInput = Console.ReadLine();
            }

            return userNumber;
        }
    }
}
