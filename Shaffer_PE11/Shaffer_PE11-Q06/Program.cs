using System;
using Shaffer_PE11_Q05;

namespace Shaffer_PE11_Q06
{
    class Program
    {
        static void Main(string[] args)
        {
            Compact c = new Compact();
            AddPassenger(c);
        }

        static void AddPassenger(IPassengerCarrier pc1)
        {
            pc1.LoadPassenger();

            if(pc1.GetType() == typeof(Compact))
            {
                Compact e = (Compact)pc1;
                Console.WriteLine(e.ToString());
            }
            if (pc1.GetType() == typeof(SUV))
            {
                SUV e = (SUV)pc1;
                Console.WriteLine(e.ToString());
            }
            if (pc1.GetType() == typeof(Pickup))
            {
                Pickup e = (Pickup)pc1;
                Console.WriteLine(e.ToString());
            }
            if (pc1.GetType() == typeof(PassengerTrain))
            {
                PassengerTrain e = (PassengerTrain)pc1;
                Console.WriteLine(e.ToString());
            }
        }
    }
}
