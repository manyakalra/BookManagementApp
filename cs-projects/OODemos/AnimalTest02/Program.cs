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
                new Cat(),
                //new Mammal(),
                new Leopard(),
                new Reptile(),
                new Dog(),
                new Parrot(),
                //new Bird(),
                new Camel()
            };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.Eat());
                Console.WriteLine(animal.Breed());
                Console.WriteLine(animal.Move());
                Console.WriteLine(animal.Die());
                Console.WriteLine();
            }
        }
    }
}
