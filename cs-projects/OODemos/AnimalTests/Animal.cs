using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public class Animal
    {
        public virtual string Eat() { return $"{this} eats something"; }

        public virtual string Move() { return $"{this} moves somehow"; }

        public virtual string Breed() { return $"{this} breeds somehow"; }

        public string Die() { return $"{this} dies"; }
    }
}
