using System;
using System.Collections.Generic;

// Author: Nicholas Shaffer
// Date: 9/25/2020
namespace Shaffer_PE13
{
    // Class: Program
    // Purpose: Test the relationship between classes
    class Program
    {
        static void Main(string[] args)
        {
            // Create reference variables for the pets and interfaces
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            // Create list of pets
            Pets pets = new Pets();

            // Create random number generator
            Random rand = new Random();

            for (int i = 0; i < 50; ++i)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    // 50% chance of adding a dog
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You bought a dog!");
                        Console.Write("What is your dog's name? => ");
                        string name = Console.ReadLine();
                        Console.Write("What is your dog's license? => ");
                        string license = Console.ReadLine();

                        int age;
                        string input;
                        do
                        {
                            Console.Write("How old is your dog? => ");
                            input = Console.ReadLine();
                        }
                        while (!int.TryParse(input, out age));

                        dog = new Dog(license, name, age);

                        pets.Add(dog);

                        Console.WriteLine();
                    }
                    else
                    {
                        // else add a cat
                        Console.WriteLine();
                        Console.WriteLine("You bought a cat!");
                        Console.Write("What is your cat's name? => ");
                        string name = Console.ReadLine();

                        int age;
                        string input;
                        do
                        {
                            Console.Write("How old is your cat? => ");
                            input = Console.ReadLine();
                        }
                        while (!int.TryParse(input, out age));

                        cat = new Cat();
                        cat.Name = name;
                        cat.age = age;

                        pets.Add(cat);

                        Console.WriteLine();
                    }
                }
                else
                {
                    if(pets.Count > 0)
                    {
                        thisPet = pets.petList[rand.Next(0, pets.Count)];
                    }
                    else
                    {
                        continue;
                    }

                    if(thisPet.GetType() == typeof(Dog))
                    {
                        // thisPet is a dog
                        iDog = (Dog)thisPet;

                        // Choose a random method
                        int method = rand.Next(0, 6);
                        switch(method)
                        {
                            case 0:
                                iDog.Eat();
                                break;
                            case 1:
                                iDog.Play();
                                break;
                            case 2:
                                iDog.Bark();
                                break;
                            case 3:
                                iDog.NeedWalk();
                                break;
                            case 4:
                                iDog.GotoVet();
                                break;
                        }
                    }
                    if (thisPet.GetType() == typeof(Cat))
                    {
                        // thisPet is a cat
                        iCat = (Cat)thisPet;

                        // Choose a random method
                        int method = rand.Next(0, 4);
                        switch (method)
                        {
                            case 0:
                                iCat.Eat();
                                break;
                            case 1:
                                iCat.Play();
                                break;
                            case 2:
                                iCat.Scratch();
                                break;
                            case 3:
                                iCat.Purr();
                                break;
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }

    public class Pets
    {
        // List of pets
        public List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        // Read-Only property
        public int Count { 
            get
            {
                return petList.Count;
            }
        }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }
    }

    public abstract class Pet
    {
        private string name;
        public int age;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Pet()
        {

        }
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();
    }

    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    public class Cat : Pet, ICat
    {
        public Cat()
        {

        }

        public override void Eat()
        {
            Console.WriteLine($"{this.Name}: Om nom nom");
        }
        public override void Play()
        {
            Console.WriteLine($"{this.Name}: Got any catnip?");
        }
        public void Purr()
        {
            Console.WriteLine($"{this.Name}: This pleases me");
        }
        public void Scratch()
        {
            Console.WriteLine($"{this.Name}: Rub my belly, human");
        }
        public override void GotoVet()
        {
            Console.WriteLine($"{this.Name}: Anywhere but there!");
        }
    }
    public class Dog : Pet, IDog
    {
        public string license;

        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
        }

        public override void Eat()
        {
            Console.WriteLine($"{this.Name}: Food? Where?");
        }
        public override void Play()
        {
            Console.WriteLine($"{this.Name}: Wannaplaywannaplaywannaplaywannaplay");
        }
        public void Bark()
        {
            Console.WriteLine($"{this.Name}: Woof!");
        }
        public void NeedWalk()
        {
            Console.WriteLine($"{this.Name}: See any fire hydrants?");
        }
        public override void GotoVet()
        {
            Console.WriteLine($"{this.Name}: I thought we were going to the park!?");
        }
    }
}
