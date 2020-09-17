using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            // ------------- START FIX ------------- //
            // Compile-Time Error: Missing semicolon
            //int nY
            int nY;
            // ------------- END FIX ------------- //
            int nAnswer;

            // ------------- START FIX ------------- //
            // Compile-Time Error: Missing quotes for string argument
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y.");
            // ------------- END FIX ------------- //

            do
            {
                Console.Write("Enter a whole number for x: ");
                // ------------- START FIX ------------- //
                // Logical/Compile-Time Error: User entered value is not saved into sNumber, therefore it
                // cannot be used by the while loop because it has not been assigned
                //    Console.ReadLine();
                //} while (!int.TryParse(sNumber, out nX));
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));
            // ------------- END FIX ------------- //

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
                // ------------- START FIX ------------- //
                // Logical Error: User entered value is saved to nX instead of nY, and value is not verified
                // to be positive. Also, while loop should continue if the parse function returns false
                //} while (int.TryParse(sNumber, out nX));
            } while (!int.TryParse(sNumber, out nY) || nY < 0);
            // ------------- END FIX ------------- //

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            // ------------- START FIX ------------- //
            // Logical Error: Actual values not replaced in string
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
            // ------------- END FIX ------------- //
        }

        // ------------- START FIX ------------- //
        // Compile-Time Error: Function does not always return an integer, and the function should be static
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        // ------------- END FIX ------------- //
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                // ------------- START FIX ------------- //
                // Logical Error/Compile-Time Error: Base case is 1, not 0. Also, nothing is returned
                //returnVal = 0;
                returnVal = 1;
                return returnVal;
                // ------------- END FIX ------------- //
            }
            else
            {
                // ------------- START FIX ------------- //
                // Logical Error: Not computing or returning the correct value, nExponent incremented when it
                // should be decremented
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1);
                //
                // multiply the base with all subsequent values
                //returnVal = nBase * nextVal;
                return nBase * Power(nBase, nExponent - 1);
                // ------------- END FIX ------------- //
            }

            // ------------- START FIX ------------- //
            // Logical Error/Compile-Time Error: Not needed and not returning anything
            //returnVal;
            // ------------- END FIX ------------- //
        }
    }
}
