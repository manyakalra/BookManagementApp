using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public abstract class Bird: Animal
    {
        public override string Breed() { return $"{this} is egg laying"; }

        public override string Move() { return Fly(); }

        public virtual string Fly() { return $"{this} flies"; }
    }

    public class Parrot : Bird
    {
        public override string Eat() { return $"{this} a fruitarian"; }

        public string HumanSpeak() { return $"{this} can mimic Human speech"; }
    }

    public class Eagle : Bird
    {
        public override string Eat() { return $"{this} a flesh eater"; }
        public string Hunt() { return $"{this} is a flying Hunter"; }
    }
}
