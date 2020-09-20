using System;

namespace Shaffer_PE11_Q05
{
    public abstract class Vehicle
    {
        public virtual void LoadPassengers()
        {

        }
    }

    public abstract class Car : Vehicle
    {

    }
    public abstract class Train : Vehicle
    {

    }

    public interface IPassengerCarrier
    {
        void LoadPassenger();
    }
    public interface IHeavyLoadCarrier
    {

    }

    public class Compact : Car, IPassengerCarrier
    {
        public void LoadPassenger()
        {

        }
    }
    public class SUV : Car, IPassengerCarrier
    {
        public void LoadPassenger()
        {

        }
    }
    public class Pickup : Car, IPassengerCarrier, IHeavyLoadCarrier
    {
        public void LoadPassenger()
        {

        }
    }

    public class PassengerTrain : Train, IPassengerCarrier
    {
        public void LoadPassenger()
        {

        }
    }

    public class FreightTrain : Train, IHeavyLoadCarrier
    {

    }
    public class _424DoubleBogey : Train, IHeavyLoadCarrier
    {

    }
}
