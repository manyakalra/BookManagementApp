using ConceptArchitect.Shapes;
using System;
using Xunit;

namespace ShapeTest1
{
    public class ShapeTests
    {

        Shape circle;
        Shape triangle;

        public ShapeTests()
        {
            circle = new Shape(7);
            triangle = new Shape(3, 4, 5);
        }


        [Fact]
        public void CircleObjectHasTypeCricle()
        { 
            Assert.Equal(ShapeType.Circle, circle.Type);
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
            Assert.Equal(ShapeType.Triangle, triangle.Type);
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
    }
}