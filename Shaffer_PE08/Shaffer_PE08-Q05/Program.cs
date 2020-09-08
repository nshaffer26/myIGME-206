using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaffer_PE08_Q05
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/07/2020
    // Purpose: According to the formula z = 3y^2 + 2x - 1, store values of z in a 3-dimensional array
    class Program
    {
        // Method: Main
        // Calculate and store values of z for x range [-1.0,1.0] and y range [1.0,4.0], both in increments of 0.1
        static void Main(string[] args)
        {
            // 3-dimensional double array to hold values of z based on given x and y (x, y, and z stored in third dimension)
            double[,,] values = new double[21, 31, 3];

            // Counters for both x and y
            int xCount = 0;
            int yCount = 0;

            // Loop to calculate and store z. Also stores values of x and y to get z
            for(double x = -1.0; x <= 1.0; x += 0.1)
            {
                for(double y = 1.0; y <= 4.01; y += 0.1)
                {
                    // Calculate z
                    double z = (3 * Math.Pow(Math.Round(y), 2)) + (2 * Math.Round(x)) - 1;

                    // Store z, as well as the x and y values used to calculate that z
                    values[xCount, yCount, 0] = x;
                    values[xCount, yCount, 1] = y;
                    values[xCount, yCount, 2] = z;

                    yCount++;
                }
                // Set yCount back to zero to start over for next value of x
                yCount = 0;
                xCount++;
            }

            // Print data
            for(int i = 0; i < values.GetLength(0); i++)
            {
                for(int j = 0; j < values.GetLength(1); j++)
                {
                    Console.Write($" [{i},{j}] = {values[i, j, 0]}, ");
                    Console.Write(values[i, j, 1] + ", ");
                    Console.WriteLine(values[i, j, 2]);
                }
            }
        }
    }
}
