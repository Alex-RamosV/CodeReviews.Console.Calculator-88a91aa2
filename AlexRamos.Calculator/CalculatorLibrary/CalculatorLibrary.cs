/// <summary>
/// This class handles arithmetic calculations and returns the result.
/// </summary>

// using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double BasicArithmeticOperations(double numberOne, double numberTwo, string operation)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

            writer.WriteStartObject();
            writer.WritePropertyName("Operand one");
            writer.WriteValue(numberOne);
            writer.WritePropertyName("Operand two");
            writer.WriteValue(numberTwo);
            writer.WritePropertyName("Operation");

            // Use a switch statement to do the math.
            switch (operation)
            {
                case "1":
                    result = numberOne + numberTwo;
                    writer.WriteValue("Add");
                    break;

                case "2":
                    result = numberOne - numberTwo;
                    writer.WriteValue("Subtract");
                    break;

                case "3":
                    result = numberOne * numberTwo;
                    writer.WriteValue("Multiply");
                    break;

                case "4":
                    // Ask the user to enter a non-zero divisor.
                    if (numberTwo != 0)
                    {
                        result = numberOne / numberTwo;
                    }
                    writer.WriteValue("Divide");
                    break;

                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double ExponentsAndRadicals(double userNumber, string operation)
        {
            double result = double.NaN;

            writer.WriteStartObject();
            writer.WritePropertyName("Operand one");
            writer.WriteValue(userNumber);
            writer.WritePropertyName("Operation");

            switch (operation)
            {
                case "1":
                    result = Math.Sqrt(userNumber);
                    writer.WriteValue("Square root");
                    break;


                case "2":
                    result = Math.Pow(userNumber, 2);
                    writer.WriteValue("Power of two");
                    break;

                case "3":
                    result = Math.Pow(10, userNumber);
                    writer.WriteValue("Exponentiation");
                    break;

                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double TrigonometricFunctions(double userNumber, string operation)
        {
            double result = double.NaN;

            writer.WriteStartObject();
            writer.WritePropertyName("Operand one");
            writer.WriteValue(userNumber);
            writer.WritePropertyName("Operation");

            switch (operation)
            {
                case "1":
                    result = Math.Sin((userNumber * Math.PI / 180));
                    writer.WriteValue("Sine");
                    break;

                case "2":
                    result = Math.Cos((userNumber * Math.PI / 180));
                    writer.WriteValue("Cosine");
                    break;

                case "3":
                    result = Math.Tan((userNumber * Math.PI / 180));
                    writer.WriteValue("Tangent");
                    break;

                case "4":
                    result = 1 / Math.Sin((userNumber * Math.PI / 180));
                    writer.WriteValue("Consecant");
                    break;

                case "5":
                    result = 1 / Math.Cos((userNumber * Math.PI / 180));
                    writer.WriteValue("Secant");
                    break;

                case "6":
                    result = 1 / Math.Tan((userNumber * Math.PI / 180));
                    writer.WriteValue("Cotangent");
                    break;

                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}