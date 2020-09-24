using System;

namespace Shaffer_PE12_Q03
{
    // Class: MyClass
    // Author: Nicholas Shaffer
    // Date: 9/23/2020
    // Purpose: Parent class
    public class MyClass
    {
        private string myString;

		public string MyString
        {
            set
            {
                myString = value;
            }
        }

        public virtual string GetString()
        {
            return myString;
        }

    }

    // Class: MyDerivedClass
    // Author: Nicholas Shaffer
    // Date: 9/23/2020
    // Purpose: Child class
    public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }

        public static void Main(string[] args)
        {
            MyDerivedClass mDC1 = new MyDerivedClass();

            mDC1.MyString = "Set string with property in parent class";
            Console.WriteLine(mDC1.GetString() + "\n");
        }
    }
}
