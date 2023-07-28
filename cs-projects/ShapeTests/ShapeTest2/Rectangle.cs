using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Shapes
{
    public class Rectangle : Shape
    {
        double width, height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Perimeter
        {
            get
            {
                return 2 * (width * height);
            }
        }

        public override double Area
        {
            get
            {
                return width * height;
            }
        }

        public override string ToString()
        {
                return $"Rectangle[{width},{height}]";
        }
    }
}
