using System;
using System.Collections.Generic;

namespace Shaffer_UnitTest02_Q04
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<(double, double, double), double> values = new SortedList<(double, double, double), double>();

            for (double w = -2.0; w <= 0.0; w += 0.2)
            {
                w = Math.Round(w, 1);

                for (double x = 0.0; x <= 4.0; x += 0.1)
                {
                    x = Math.Round(x, 1);

                    for (double y = -1.0; y <= 1.0; y += 0.1)
                    {
                        y = Math.Round(y, 1);

                        // z = 4y^3 + 2x^2 - 8w + 7
                        double z = (4 * Math.Pow(y, 3)) + (2 * Math.Pow(x, 2)) - (8 * w) + 7;
                        z = Math.Round(z, 1);

                        values[(w, x, y)] = z;
                    }
                }
            }

            foreach (KeyValuePair<(double, double, double), double> val in values)
            {
                Console.WriteLine($"{val.Key}: {val.Value}");
            }
        }
    }
}
