using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest2
{
    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x=0, int y=0)
        {
            Console.WriteLine("Point() called");
            X = x;
            Y = y;
        }


        public double Distance(Point p2)
        {
            var dx = X - p2.X;
            var dy = Y - p2.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public string Info
        {
            get
            {
                return $"Point( {X}, {Y} )";
            }

        }

   }

    class Point3D : Point
    {
        public int Z { get; private set; }

        public Point3D(int x, int y, int z):base(x,y)
        {
            Console.WriteLine("Point3D() called");
            Z = z;
        }

        public string Info
        {
            get
            {
                return base.Info.Replace(" )", $", {Z} )");
            }
        }

    }
}
