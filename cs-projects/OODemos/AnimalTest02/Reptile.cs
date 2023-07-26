using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public abstract class Reptile: Animal
    {
        public override string Breed() { return $"{this} is egg laying"; }
        public override string Eat() { return $"{this} is omnivore"; }

        public abstract string Hunt();// { return $"{this} hunts"; }

        public override string Move() { return $"{this} crawls"; }
    }

    public class Crocodile : Reptile
    {
        public override string Eat() { return $"{this} is flesh eater"; }

        public override string Hunt() { return $"{this} great underwater hunter"; }
    }

    public class Snake: Reptile
    {
        public override string Hunt() { return $"{this} is a poisonous Hunter"; }
    }
}
