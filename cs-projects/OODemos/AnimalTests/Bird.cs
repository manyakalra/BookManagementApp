using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public class Bird: Animal
    {
        public string Breed() { return $"{this} is egg laying"; }
       
        public string Move() { return Fly(); }

        public string Fly() { return $"{this} flies"; }
    }

    public class Parrot : Bird
    {
        public string Eat() { return $"{this} a fruitarian"; }

        public string HumanSpeak() { return $"{this} can mimic Human speech"; }
    }

    public class Eagle : Bird
    {
        public string Eat() { return $"{this} a flesh eater"; }
        public string Hunt() { return $"{this} is a flying Hunter"; }
    }
}
