using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Shapes
{
    public class Triangle : Shape
    {
        double s1, s2, s3;
        public Triangle(double s1, double s2, double s3)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
            //Type = ShapeType.Triangle;
        }

        public override double Perimeter
        {
            get
            {
                return s1 + s2 + s3;
            }
        }

        public override double Area
        {
            get
            {
                double area = 0;
                double s = Perimeter / 2;
                area = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
                return area;
            }
        }

        public override string ToString()
        {
                return $"Triangle<{s1},{s2},{s3}>";
        }
    }



}
