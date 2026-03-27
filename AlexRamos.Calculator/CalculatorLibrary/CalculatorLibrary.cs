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

        /*
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting Calcultator Log");
            Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
        }
        */

        public double DoOperation(double numberOne, double numberTwo, string operation)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(numberOne);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(numberTwo);
            writer.WritePropertyName("Operation");

            // Use a switch statement to do the math.
            switch (operation)
            {
                case "a":
                    result = numberOne + numberTwo;
                    //Trace.WriteLine(String.Format("{0} + {1} = {2}", numberOne, numberTwo, result));
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = numberOne - numberTwo;
                    //Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, result));
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = numberOne * numberTwo;
                    //Trace.WriteLine(String.Format("{0} * {1} = {2}", num1, num2, result));
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (numberTwo != 0)
                    {
                        result = numberOne / numberTwo;
                        //Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, result));
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

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}