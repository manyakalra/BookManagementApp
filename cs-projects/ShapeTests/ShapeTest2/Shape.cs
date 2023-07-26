using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest1
{
    public class Shape
    {
        public double Area
        {
            get { return double.NaN; }
        }
    }

    public class Circle : Shape
    {
        double radius;
        //public ShapeType Type { get; private set; }

        public Circle(double radius)
        {
            this.radius = radius;
            //Type = ShapeType.Circle;
        }

        public double Periemeter
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }

        public double Area
        {
            get
            {

                double area = 0;
                area = Math.PI * radius * radius;
                return area;
            }
        }

        public string Info
        {
            get
            {   
                 return $"Circle({radius})";
            }
        }
    }

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

        public double Periemeter
        {
            get
            {
                return s1 + s2 + s3;                
            }
        }

        public double Area
        {
            get
            {
                double area = 0;
                double s = Periemeter / 2;
                area = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
                return area;
            }
        }

        public string Info
        {
            get
            {
                return $"Triangle<{s1},{s2},{s3}>";
            }
        }
    }

    public class Rectangle : Shape
    {
        double width,height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Perimeter
        {
            get
            {
                return 2*(width * height);
            }
        }

        public double Area
        {
            get
            {
                return width * height;
            }
        }
     
        
        public string Info
        {
            get
            {
                return $"Rectangle[{width},{height}]";
            }
        }
    }


}
