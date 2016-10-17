using System;

using Xunit;

using Algorithms.IO;
using Algorithms.Geometry;

namespace Tests.Geometry
{
    public class LineTests : TestBase
    {
        [Fact]
        public void CanCalculateIntersection()
        {
            var line1 = new LineSegment(new Point(1.35, 1.89), new Point(3.825, 3.330));
            var line2 = new LineSegment(new Point(2.25, 3.15), new Point(3.465, 1.755));

            Point? intersection = line1.FindIntersectionPoint(line2);

            Assert.True(intersection != null && intersection.HasValue);

            Assert.True(Math.Round(intersection.Value.X, 10) == 2.6756520047);
            Assert.True(Math.Round(intersection.Value.Y, 10) == 2.6612884391);
        }

        [Fact]
        public void CanTellOfNoIntersection()
        {
            var line1 = new LineSegment(new Point(1.35, 1.89), new Point(3.825, 3.330));
            var line2 = new LineSegment(new Point(12.25, 13.15), new Point(13.465, 11.755));

            Point? intersection = line1.FindIntersectionPoint(line2);

            Assert.True(intersection == null);
        }
    }
}