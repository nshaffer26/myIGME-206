using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            // Upper and lower limits for imgCoord and realCoord
            double imagCoordUpper = 1.2, imagCoordLower = -1.2;
            double realCoordUpper = 1.77, realCoordLower = -0.6;

            // Boolean to hold whether user has chosen valid limits
            bool validLim = false;
            // Boolean to hold whether user gives a double
            bool validDouble = false;

            // Ask the user for limits of imagCoord.
            do
            {
                try
                {
                    Console.WriteLine("Enter the upper limit for imagCoord (e.g., 1.2). This value must be of type double");
                    imagCoordUpper = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter the lower limit for imagCoord (e.g., -1.2). This value must be of type double");
                    imagCoordLower = Convert.ToDouble(Console.ReadLine());

                    validDouble = true;

                    if(imagCoordLower < imagCoordUpper)
                    {
                        validLim = true;
                    }
                    else
                    {
                        Console.WriteLine("Please try again, the upper limit must be larger than the lower limit");
                    }
                }
                catch
                {
                    Console.WriteLine("Please try again, you must enter two double values");
                }

            }
            while (!validLim || !validDouble);

            // Reset Booleans to ask for realCoord
            validLim = false;
            validDouble = false;

            // Ask the user for limits of realCoord.
            do
            {
                try
                {
                    Console.WriteLine("Enter the upper limit for realCoord (e.g., 1.77). This value must be of type double.");
                    realCoordUpper = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter the lower limit for realCoord (e.g., -0.6). This value must be of type double");
                    realCoordLower = Convert.ToDouble(Console.ReadLine());

                    validDouble = true;

                    if (realCoordLower < realCoordUpper)
                    {
                        validLim = true;
                    }
                    else
                    {
                        Console.WriteLine("Please try again, the upper limit must be larger than the lower limit");
                    }
                }
                catch
                {
                    Console.WriteLine("Please try again, you must enter two double values");
                }

            }
            while (!validLim || !validDouble);

            // Create increments for imagCoord and realCoord to loop 48 and 80 times respectively
            double incImag = (imagCoordUpper - imagCoordLower) / 48;
            double incReal = (realCoordUpper - realCoordLower) / 80;

            // Generate Mandelbrot Fractal with given limits
            for (imagCoord = imagCoordUpper; imagCoord >= imagCoordLower; imagCoord -= incImag)
            {
                for (realCoord = realCoordLower; realCoord <= realCoordUpper; realCoord += incReal)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp) - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
