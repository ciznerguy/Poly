using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Poly
{
    internal class Program
    {
        //public class Animal
        // {
        //     protected string Name;
        //     public Animal(string name)
        //     {
        //         Name = name;
        //     }
        //     public virtual void MakeNoise()
        //     {
        //         Console.WriteLine("Animal is making noise");

        //     }
        //     public void Eat()
        //     {
        //         Console.WriteLine("Animal is eating");
        //     }

        // }
        // public class Dog : Animal
        // {
        //     public Dog(string name) : base(name)
        //     {
        //     }
        //     public override void MakeNoise()
        //     {
        //         Console.WriteLine("Woof");
        //     }

        //     public void Growl()
        //     {
        //         Console.WriteLine("Grrr");
        //     }

        // }
        // public class Cat : Animal
        // {
        //     public Cat(string name) : base(name)
        //     {
        //     }

        //     public override void MakeNoise()
        //     {
        //         Console.WriteLine("Meow");
        //     }



        // }
        // public static void DoAnimalStuff(Animal a)

        // {
        //     a.MakeNoise();
        //     if (a is Dog)
        //     {
        //         Dog d = (Dog)a;
        //         d.Growl();
        //     }
        // }


        public abstract class Animal
    {
            protected double food=1;

            public  Animal()
            {

            }
            public virtual bool IsHungry()
            {
                return false;
            }

            public  double  GetFood()
            {
                return food;
            }
    }

    public class Lion : Animal
    {
            private bool IsLionHungry;
            
            public Lion(bool isHungry)
            {
                food  = base.food * 2;
                this.IsLionHungry = isHungry;
            }
           
            public override bool IsHungry()
            {
                return this.IsLionHungry;
            }
            public bool IsDangerous ()
            {
             return true;
            }
    }

                public class Duck : Animal
                {
                public Duck()
                {
                this.food = base.food;
            }

       
               
        }

            public class Panda : Animal
            {
                public Panda()
                {
                    food = base.food+1;
                }

                   
             }

            public class Cage
            {
                private Animal[] Animals;

                public Cage(Animal[] animals)
                {
                    Animals = animals;
                }

                public double TotalVegetarianFood()
                {
                    double totalFood = 0;
                    foreach (Animal   animal in Animals)
                    {
                        if (!(animal is Lion)) 
                            totalFood += animal.GetFood();
                    }
                    return totalFood;
                }

                public bool IsMix()
                {
                    bool hasLion = false;
                    bool hasOtherAnimal = false;

                    foreach (Animal animal in Animals)
                    {
                        if (animal is Lion) hasLion = true;
                        else hasOtherAnimal = true;
                    }
                    return hasLion && hasOtherAnimal;
                }

                public Animal[] GetAnimals()
            {
                return Animals;
            }
            }

        public class Zoo
        {
            private Cage[] Cages;

            public Zoo(Cage[] cages)
            {
                Cages = cages;
            }

            public Lion[] GetHungryLions()
            {
                Lion[] hungryLions = new Lion[100];
                int count = 0;

                foreach (Cage cage in Cages)
                {
                    foreach (Animal animal in cage.GetAnimals())
                    {
                        if (animal is Lion && animal.IsHungry())
                        {
                            hungryLions[count++] = (Lion)animal;
                            if (count >= 100) return hungryLions;
                        }
                    }
                }
                return hungryLions;
            }
        }

    
        public static void Main()
        {
            Cage cage1 = new Cage(new Animal[] { new Lion(true), new Lion(false) });
            Cage cage2 = new Cage(new Animal[] { new Panda(), new Duck() });
            Cage cage3 = new Cage(new Animal[] { new Lion(false), new Panda() });

            Zoo zoo = new Zoo(new Cage[] { cage1, cage2, cage3 });

            Console.WriteLine("Cage 1 Vegetarian Food: " + cage1.TotalVegetarianFood()); // Should be 0
            Console.WriteLine("Cage 2 Vegetarian Food: " + cage2.TotalVegetarianFood()); // Should be 3
            Console.WriteLine("Cage 3 Vegetarian Food: " + cage3.TotalVegetarianFood()); // Should be 2

            Console.WriteLine("Cage 1 Is Mix: " + cage1.IsMix()); // Should be False
            Console.WriteLine("Cage 2 Is Mix: " + cage2.IsMix()); // Should be False
            Console.WriteLine("Cage 3 Is Mix: " + cage3.IsMix()); // Should be True

            Lion[] hungryLions = zoo.GetHungryLions();
            int hungryCount = 0;
            foreach (var lion in hungryLions)
            {
                if (lion != null) hungryCount++;
            }
            Console.WriteLine("Number of Hungry Lions: " + hungryCount);
        }
    }


          
}
