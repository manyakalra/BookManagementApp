using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalTests
{
    public abstract class Animal
    {
        public abstract string Eat();
        public abstract string Move();
        public abstract string Breed();
        public string Die() { return $"{this} dies"; }

        public bool IsDomestic
        {
            get { return this is IDomestic; }
        }

        public override string ToString()
        {
            var str = base.ToString();
            var i = str.LastIndexOf(".");
            if (i > 0)
                str = str.Substring(i + 1);

            return str;
        }

    }
}
