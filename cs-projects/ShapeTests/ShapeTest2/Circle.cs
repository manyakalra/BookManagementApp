using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Shapes
{
    public class Circle : Shape
    {
        double radius;
        //public ShapeType Type { get; private set; }

        public Circle(double radius)
        {
            this.radius = radius;
            //Type = ShapeType.Circle;
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }

        public override double Area
        {
            get
            {

                double area = 0;
                area = Math.PI * radius * radius;
                return area;
            }
        }

        public override string ToString()
        {
               return $"Circle({radius})";
        }
    }

}
