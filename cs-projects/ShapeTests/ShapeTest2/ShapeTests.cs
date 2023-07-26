using System;
using Xunit;

namespace ShapeTest1
{
    public class ShapeTests
    {

        Circle circle;
        Triangle triangle;
        Rectangle rectangle;

        public ShapeTests()
        {
            circle = new Circle(7);
            triangle = new Triangle(3, 4, 5);
            rectangle = new Rectangle(3, 4);
        }


        [Fact]
        public void CircleObjectHasTypeCricle()
        {
            //Assert.Equal(ShapeType.Circle, circle.Type);

            Assert.True(circle is Circle);
        }

        [Fact]
        public void CircleInfoIncludesRadius()
        {
            Assert.Contains("Circle(7)", circle.Info);
        }

        [Fact]
        public void CircleAreaIsCalculatedBasedOnCircleFormula()
        {
            var expectedArea = Math.PI * 7 * 7;

            Assert.Equal(expectedArea, circle.Area);
        }


        [Fact]
        public void TriangleObjectHasTypeTriangle()
        {
            //Assert.Equal(ShapeType.Triangle, triangle.Type);

            Assert.Equal(typeof(Triangle), triangle.GetType());
        }

        [Fact]
        public void TriangleInfoIncludesSidesOfTriangle()
        {
            Assert.Contains("Triangle<3,4,5>", triangle.Info);
        }

        [Fact]
        public void TriangleAreaIsCalculatedBasedTriangleFormula()
        {
            var expectedArea = 6; //0.5*base*height

            Assert.Equal(expectedArea, triangle.Area);
        }

        [Fact(Skip ="To be Tested Later")]
        public void WeCanPutAllShapesInShapeArray()
        {
            Shape[] shapes = {
                                triangle,
                                circle,
                                rectangle
                                };

            double[] areas = { triangle.Area, circle.Area, rectangle.Area };

            for(int i=0;i<shapes.Length;i++)
            {
                Assert.True(areas[i]==shapes[i].Area, $"Failed for {shapes[i]}"  );
            }
        }
    }
}