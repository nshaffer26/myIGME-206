using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Nicholas Shaffer
// Date: 11/19/2020
namespace Shaffer_UnitTest03_Q7
{
    class Wizard : IComparable<Wizard>
    {
        public string name;
        public int age;

        public Wizard(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Wizard w)
        {
            return this.age.CompareTo(w.age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Wizard> wizards = new List<Wizard>()
            {
                new Wizard("Gandalf", 2019),
                new Wizard("Albus Dumbledore", 115),
                new Wizard("Harry Potter", 40),
                new Wizard("Hermione Granger", 41),
                new Wizard("Ron Weasley", 40),
                new Wizard("Merlin", 460),
                new Wizard("Wizard of Id", 56),
                new Wizard("Wizard of Oz", 120),
                new Wizard("Zatanna", 56),
                new Wizard("Doctor Strange", 57)
            };

            // Sort using List.Sort() overload
            List<Wizard> wizardsSorted = new List<Wizard>();
            wizardsSorted.AddRange(wizards);
            wizardsSorted.Sort();

            // Sort with delegate
            List<Wizard> wizardsDelegateSort = wizards
                .OrderBy(delegate (Wizard w) { return w.age; })
                .ThenBy(delegate (Wizard w) { return w.name; }).ToList();

            // Sort with lambda expression
            List<Wizard> wizardsLambdaSort = wizards
                .OrderBy((Wizard w) => { return w.age; })
                .ThenBy((Wizard w) => { return w.name; }).ToList();

            // Print out results for testing
            string wOriginal = "";
            string wSorted = "";
            string wDelegate = "";
            string wLambda = "";

            for(int i = 0; i < wizards.Count; i++)
            {
                wOriginal += $"Age: {wizards[i].age}, Name: {wizards[i].name}\n";
                wSorted += $"Age: {wizardsSorted[i].age}, Name: {wizardsSorted[i].name}\n";
                wDelegate += $"Age: {wizardsDelegateSort[i].age}, Name: {wizardsDelegateSort[i].name}\n";
                wLambda += $"Age: {wizardsLambdaSort[i].age}, Name: {wizardsLambdaSort[i].name}\n";
            }

            Console.WriteLine($"Original:\n{wOriginal}\n");
            Console.WriteLine($"List.Sort():\n{wSorted}\n");
            Console.WriteLine($"Delegate:\n{wDelegate}\n");
            Console.WriteLine($"Lambda:\n{wLambda}\n");
        }
    }
}
