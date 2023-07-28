using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Shapes
{
    public enum ShapeType { Circle, Triangle, Rectangle,Star}
    public class Shape
    {
        public ShapeType Type { get; private set; }
        double radius;
        double s1, s2, s3;
        double width, height;
        int sides, length;

        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
            this.Type = ShapeType.Rectangle;
        }

        public Shape(double radius)
        {
            this.radius = radius;
            Type = ShapeType.Circle;
        }

        public Shape(double s1, double s2, double s3)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
            Type = ShapeType.Triangle;
        }

      

        public double Periemeter
        {
            get
            {
                
                switch (Type)
                {
                    case ShapeType.Circle: return 2*Math.PI*radius;
                    case ShapeType.Rectangle: return 2*(width+height);
                    case ShapeType.Triangle: return s1 + s2 + s3;
                    default: return double.NaN;
                }
                    
            }
        }

        public double Area
        {
            get
            {

                double area = 0;

                 if(Type == ShapeType.Triangle)
                {
                    double s = Periemeter / 2;
                    area = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
                }
                if (Type == ShapeType.Rectangle)
                {
                    return width * height;
                }
                else
                {
                    area = Math.PI * radius * radius;
                }

                return area;
            }
        }
    
    
        public string Info
        {
            get
            {
                if (Type == ShapeType.Circle)
                    return $"Circle({radius})";
                else if(Type == ShapeType.Rectangle)
                    return $"Rectangle[{width},{height}]";
                else
                    return $"Triangle<{s1},{s2},{s3}>";
            }
        }
        
    }
}
