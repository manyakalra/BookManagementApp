using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public class Reptile: Animal
    {
        public string Breed() { return $"{this} is egg laying"; }
        public string Eat() { return $"{this} is omnivore"; }
        
        public string Hunt() { return $"{this} hunts"; }

        public string Move() { return $"{this} crawls"; }
    }

    public class Crocodile : Reptile
    {
        public string Eat() { return $"{this} is flesh eater"; }

        public string Hunt() { return $"{this} great underwater hunter"; }
    }

    public class Snake: Reptile
    {
        public string Hunt() { return $"{this} is a poisonous Hunter"; }
    }
}
