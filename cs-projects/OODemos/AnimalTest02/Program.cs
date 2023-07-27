using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello Animal World");

            

            Animal[] animals =
            {
                new Tiger(),
                new Horse(),
                new Crocodile(),
                //new Animal(),
                new Snake(),
                new Eagle(),
                new Horse(),
                //new Cat(),
                //new Mammal(),
                new Leopard(),
                //new Reptile(),
                new Dog(),
                new Parrot(),
                //new Bird(),
                new Camel()
            };

            foreach (var animal in animals)
            {
                if (animal.IsDomestic)
                    Console.Write("*** ");
                else
                    Console.Write("### ");

                Console.WriteLine(animal); //animal.ToString()
                Console.WriteLine(animal.Eat());
                Console.WriteLine(animal.Breed());
                Console.WriteLine(animal.Move());


                //Super reference can't be assigned to sub class
                //Tiger t = animal;  //doesn't work

                //We can force typecast
                //BE ABSOLUTELY SURE IF YOU KNOW WHAT YOU ARE DOING
                //HuntIfYouAreATiger(animal);

                //HuntIfYouAreACat(animal);
                HuntIfYouAreAHunter(animal);
                RideIfYouAreARidebale(animal);

                Console.WriteLine(animal.Die());


                Console.WriteLine("\n");
            }
        }

        private static void RideIfYouAreARidebale(Animal animal)
        {
            if(animal is IRideable)
            {
                var rideable = animal as IRideable;

                Console.WriteLine(rideable.Ride());

            }
        }

        private static void HuntIfYouAreAHunter(Animal animal)
        {
            var hunter = animal as IHunter;

            if(hunter!=null)
                Console.WriteLine(hunter.Hunt());
        }

        private static void HuntIfYouAreACat(Animal animal)
        {
            var cat = animal as Cat;
            if (cat != null)
                Console.WriteLine(cat.Hunt());
        }

        private static void HuntIfYouAreATiger(Animal animal)
        {
            if (animal is Tiger)
            {
                Tiger t = (Tiger)animal;
                Console.WriteLine(t.Hunt());
            }
        }
    }
}
