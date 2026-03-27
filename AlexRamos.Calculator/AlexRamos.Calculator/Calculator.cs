/// <summary>
/// This class handles arithmetic calculations and returns the result.
/// </summary>

class Calculator
{
    public static double DoOperation(double numberOne, double numberTwo, string operation)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

        // Use a switch statement to do the math.
        switch (operation)
        {
            case "a":
                result = numberOne + numberTwo;
                break;
            case "s":
                result = numberOne - numberTwo;
                break;
            case "m":
                result = numberOne * numberTwo;
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (numberTwo != 0)
                {
                    result = numberOne / numberTwo;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
}