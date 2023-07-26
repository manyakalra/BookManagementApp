using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public class Animal
    {
        public string Eat() { return $"{this} eats something"; }

        public string Move() { return $"{this} moves somehow"; }

        public string Breed() { return $"{this} breeds somehow"; }

        public string Die() { return $"{this} dies"; }
    }
}
