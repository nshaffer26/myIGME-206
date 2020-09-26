using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaffer_PE14
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 class1 = new MyClass1();
            MyMethod(class1);

            MyClass2 class2 = new MyClass2();
            MyMethod(class2);
        }

        public static void MyMethod(object myObject)
        {
            IMyInterface myInterface = null;

            if (myObject.GetType() == typeof(MyClass1))
            {
                myInterface = (MyClass1)myObject;
            }
            if(myObject.GetType() == typeof(MyClass2))
            {
                myInterface = (MyClass2)myObject;
            }

            myInterface.MyIMethod();
        }
    }

    public interface IMyInterface
    {
        void MyIMethod();
    }

    public class MyClass1 : IMyInterface
    {
        public void MyIMethod()
        {
            Console.WriteLine("This is class 1");
        }
    }
    public class MyClass2 : IMyInterface
    {
        public void MyIMethod()
        {
            Console.WriteLine("This is class 2");
        }
    }

}
