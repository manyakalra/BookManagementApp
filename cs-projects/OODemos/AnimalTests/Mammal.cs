using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    class Mammal : Animal
    {
        public override string Breed() { return $"{this} is child-bearing"; }
    }

    class Horse : Mammal
    {
        public override string Eat() { return $"{this} is a grass eater"; }
        public override string Move() { return $"{this} runs"; }

        public string Ride() { return $"{this} is an ancient ride"; }

    }

    class Camel : Mammal
    {
        public override string Eat() { return $"{this} is a grass eater"; }
        public override string Move() { return $"{this} runs"; }

        public string Ride() { return $"{this} is an desert ride"; }

    }

    class Dog : Mammal
    {
        public override string Eat() { return $"{this} is a flesh eater"; }
        public override string Move() { return $"{this} walks"; }

        public string Hunt() { return $"{this} hunts"; }

    }

    class Cat : Mammal
    {
        public override string Eat() { return $"{this} is a flesh eater"; }
        public override string Move() { return $"{this} walks"; }

        public string Hunt() { return $"{this} hunts"; }

    }

    class Tiger : Cat { }

    class Leopard : Cat { }

}
