using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShapeTest2
{
    public class PointTests
    {
        int x = 3, y = 4, z = 5;
        Point origin;
        Point3D pt;

        public PointTests()
        {
            origin = new Point();
            pt = new Point3D(x,y,z);
        }


        [Fact]
        public void Point3DObjectsArePointObjects()
        {
            Assert.True(pt is Point);
        }


        [Fact]
        public void Point3DConstructorInvokesPointConstructor()
        {
            Point3D point = new Point3D(3,4,5);
            Assert.Equal(3, point.X);
        }

        [Fact]
        public void Point3DConstructorInvokesPoint3Constrctor()
        {
            var point=new Point3D(3,4,5);

            Assert.Equal(5, point.Z);
        }

        [Fact]
        public void CanCalculateDistanceBetweenTwoPoints()
        {
            var p2 = new Point(3, 4);
            var distance = p2.Distance(origin);

            Assert.Equal(5, distance);
        }

        [Fact]
        public void CanCalculateDistanceForPoint3DObjectIn2DPlane()
        {
            var pt = new Point3D(3, 4, 5);
            var distance = origin.Distance(pt);

            Assert.Equal(5, distance);
        }

        [Fact]
        public void InfoCanShowXOfPoint3D()
        {
            Assert.Contains(x.ToString(), pt.Info);
        }

        [Fact]
        public void InfoCanShowZOfPoint3D()
        {
            Assert.Contains(z.ToString(), pt.Info);
        }

        [Fact]
        public void Point3DReferenceInfoShouldShowInforForPoint3D()
        {
            Point3D pt = new Point3D(3, 4, 5);

            Assert.Equal("Point( 3, 4, 5 )", pt.Info);
        }

        [Fact]
        public void PointReferenceInfoShouldShowInforForPoint3D()
        {
            Point pt = new Point3D(3, 4, 5);

            Assert.Equal("Point( 3, 4, 5 )", pt.Info);
        }
    }
}
