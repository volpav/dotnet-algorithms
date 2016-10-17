using System;

namespace Algorithms.Geometry
{
    /// <summary>
    /// Represents a point on a plane.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Gets the X-coordinate.
        /// </summary>
        public readonly double X;

        /// <summary>
        /// Gets the Y-coordinate.
        /// </summary>
        public readonly double Y;
        
        private const double Epsilon = 1e-10;

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="x">X-coordinate.</param>
        /// <param name="y">Y-coordinate.</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns value indicating whether the current object is equal to the given one.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;

            var p = (Point)obj;

            return IsZero(X - p.X) && IsZero(Y - p.Y);
        }

        /// <summary>
        /// Returns the hash code of the given object.
        /// </summary>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of the given object.
        /// </summary>
        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        /// <summary>
        /// Subtracts two points.
        /// </summary>
        /// <param name="v">First point.</param>
        /// <param name="w">Second point.</param>
        public static Point operator -(Point v, Point w)
        {
            return new Point(v.X - w.X, v.Y - w.Y);
        }

        /// <summary>
        /// Adds two points.
        /// </summary>
        /// <param name="v">First point.</param>
        /// <param name="w">Second point.</param>
        public static Point operator +(Point v, Point w)
        {
            return new Point(v.X + w.X, v.Y + w.Y);
        }

        /// <summary>
        /// Multiplies two points.
        /// </summary>
        /// <param name="v">First point.</param>
        /// <param name="w">Second point.</param>
        public static double operator *(Point v, Point w)
        {
            return v.X * w.X + v.Y * w.Y;
        }

        /// <summary>
        /// Multiplies point by the value.
        /// </summary>
        /// <param name="v">First point.</param>
        /// <param name="mult">Value.</param>
        public static Point operator *(Point v, double mult)
        {
            return new Point(v.X * mult, v.Y * mult);
        }

        /// <summary>
        /// Multiplies point by the value.
        /// </summary>
        /// <param name="mult">Value.</param>
        /// <param name="v">First point.</param>
        public static Point operator *(double mult, Point v)
        {
            return new Point(v.X * mult, v.Y * mult);
        }

        /// <summary>
        /// Returns a cross of the current point with the given one.
        /// </summary>
        /// <param name="v">Point.</param>
        public double Cross(Point v)
        {
            return X * v.Y - Y * v.X;
        }

        /// <summary>
        /// Returns value indicating whether the given value is zero (with certain accuracy).
        /// </summary>
        /// <param name="v">Value to test.</param>
        public static bool IsZero(double d)
        {
            return Math.Abs(d) < Epsilon;
        }
    }

    /// <summary>
    /// Represents a line segment.
    /// </summary>
    public struct LineSegment
    {
        /// <summary>
        /// Gets the first point.
        /// </summary>
        public readonly Point Point1;

        /// <summary>
        /// Gets the second point.
        /// </summary>
        public readonly Point Point2;
        
        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="point1">First point.</param>
        /// <param name="point2">Second point.</param>
        public LineSegment(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        /// <summary>
        /// Returns an intersection point (if any) with the given segment.
        /// </summary>
        /// <param name="other">Another line segment.</param>
        public Point? FindIntersectionPoint(LineSegment other)
        {
            Point intersection;

            return !FindIntersectionPoint(Point1, Point2, other.Point1, other.Point2, out intersection) ? null : (Point?)intersection;
        }

        /// <summary>
        /// Returns value indicating whether the current object is equal to the given one.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        public override bool Equals(object obj)
        {
            if (!(obj is LineSegment)) return false;

            var l = (LineSegment)obj;

            return Point1.Equals(l.Point1) && Point2.Equals(l.Point2);
        }

        /// <summary>
        /// Returns the hash code of the given object.
        /// </summary>
        public override int GetHashCode()
        {
            return Point1.GetHashCode() ^ Point2.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of the given object.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}, {1}", Point1.ToString(), Point2.ToString());
        }

        /// <summary>
        /// Finds (and returns) an intersection between two line segments.
        /// </summary>
        /// <param name="p">Line 1, point 1.</param>
        /// <param name="2">Line 1, point 2.</param>
        /// <param name="q">Line 2, point 1.</param>
        /// <param name="q2">Line 2, point 2.</param>
        /// <param name="intersection">Intersection.</param>
        /// <param name="considerCollinearOverlapAsIntersect">Value indicating whether collinear overlap as intersect.</param>
        private bool FindIntersectionPoint(
            Point p, 
            Point p2, 
            Point q, 
            Point q2,
            out Point intersection, 
            bool considerCollinearOverlapAsIntersect = false)
        {
            intersection = new Point();

            var r = p2 - p;
            var s = q2 - q;
            var rxs = r.Cross(s);
            var qpxr = (q - p).Cross(r);

            // If r x s = 0 and (q - p) x r = 0, then the two lines are collinear.
            if (Point.IsZero(rxs) && Point.IsZero(qpxr))
            {
                // 1. If either  0 <= (q - p) * r <= r * r or 0 <= (p - q) * s <= * s
                // then the two lines are overlapping,
                if (considerCollinearOverlapAsIntersect)
                {
                    if ((0 <= (q - p) * r && (q - p) * r <= r * r) || (0 <= (p - q) * s && (p - q) * s <= s * s))
                    {
                        return true;
                    }
                }
                    
                // 2. If neither 0 <= (q - p) * r = r * r nor 0 <= (p - q) * s <= s * s
                // then the two lines are collinear but disjoint.
                // No need to implement this expression, as it follows from the expression above.
                return false;
            }

            // 3. If r x s = 0 and (q - p) x r != 0, then the two lines are parallel and non-intersecting.
            if (Point.IsZero(rxs) && !Point.IsZero(qpxr))
            {
                return false;
            }

            // t = (q - p) x s / (r x s)
            var t = (q - p).Cross(s) / rxs;

            // u = (q - p) x r / (r x s)

            var u = (q - p).Cross(r) / rxs;

            // 4. If r x s != 0 and 0 <= t <= 1 and 0 <= u <= 1
            // the two line segments meet at the point p + t r = q + u s.
            if (!Point.IsZero(rxs) && (0 <= t && t <= 1) && (0 <= u && u <= 1))
            {
                // We can calculate the intersection point using either t or u.
                intersection = p + t * r;

                // An intersection was found.
                return true;
            }

            // 5. Otherwise, the two line segments are not parallel but do not intersect.
            return false;
        }
    }
}