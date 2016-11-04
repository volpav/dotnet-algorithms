using System;
using System.Linq;
using System.Collections.Generic;

using Xunit;

using Algorithms.IO;
using Algorithms.Geometry;

namespace Tests.Geometry
{
    public class ShapeTests : TestBase
    {
        [Fact]
        public static void CanHandleEmptySetForConvexHull()
        {
            Point[] result = Shape.ConvexHull(null);
            Assert.True(result.Length == 0);

            result = Shape.ConvexHull(new Point[] { });
            Assert.True(result.Length == 0);
        }

        [Fact]
        public static void CanComputeConvexHull()
        {
            var points = new List<Point>(new Point[] {
               new Point(4.4, 14),
               new Point(6.7, 15.25),
               new Point(6.9, 12.8),
               new Point(2.1, 11.1),
               new Point(9.5, 14.9),
               new Point(13.2, 11.9),
               new Point(10.3, 12.3),
               new Point(6.8, 9.5),
               new Point(3.3, 7.7),
               new Point(0.6, 5.1),
               new Point(5.3, 2.4),
               new Point(8.45, 4.7),
               new Point(11.5, 9.6),
               new Point(13.8, 7.3),
               new Point(12.9, 3.1),
               new Point(11, 1.1)
           });
 
           var result = Shape.ConvexHull(points.ToArray());
 
           Assert.True(result.Length == 3);
           Assert.True(result[0].X == 0.6 && result[0].Y == 5.1);
           Assert.True(result[1].X == 2.1 && result[1].Y == 11.1);
           Assert.True(result[2].X == 0.6 && result[2].Y == 5.1);
        }
    }
}