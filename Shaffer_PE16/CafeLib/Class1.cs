using System;

namespace CafeLib
{
    public interface IMood
    {
        string Mood { get; }
    }
    public interface ITakeOrder
    {
        void TakeOrder();
    }

    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;

        public Customer customer;

        public HotDrink()
        {
        }
        public HotDrink(string brand)
        {
        }

        public virtual void AddSugar(byte amount)
        {
            sugar += amount;
        }

        public abstract void Steam();
    }

    public class Waiter : IMood
    {
        public string name;

        public string Mood
        {
            get
            {
                return Mood;
            }
        }

        public void ServerCustomer(HotDrink cup)
        {
        }
    }
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood
        {
            get
            {
                return Mood;
            }
        }
    }

    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public CupOfCoffee(string brand) : base(brand)
        {
        }

        public override void Steam()
        {
        }
        public void TakeOrder()
        {
        }
    }
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public CupOfTea(bool customerIsWealthy)
        {
        }

        public override void Steam()
        {
        }
        public void TakeOrder()
        {
        }
    }
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source
        {
            set
            {
                this.source = value;
            }
        }

        // TODO: What does ":this(false)" mean?
        public CupOfCocoa()
        {
        }
        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {
        }

        
        public override void Steam()
        {
        }
        public override void AddSugar(byte amount)
        {
        }
        public void TakeOrder()
        {
        }
    }
}
