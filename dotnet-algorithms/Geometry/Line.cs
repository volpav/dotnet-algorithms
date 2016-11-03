using System;

namespace Algorithms.Geometry
{
    public struct Point
    {
        public readonly double X;
        public readonly double Y;

        private const double _Epsilon = 1e-10;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point)) 
            {
                return false;
            }

            Point p = (Point)obj;

            return IsZero(X - p.X) && IsZero(Y - p.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public static Point operator -(Point v, Point w)
        {
            return new Point(v.X - w.X, v.Y - w.Y);
        }

        public static Point operator +(Point v, Point w)
        {
            return new Point(v.X + w.X, v.Y + w.Y);
        }

        public static double operator *(Point v, Point w)
        {
            return v.X * w.X + v.Y * w.Y;
        }

        public static Point operator *(Point v, double mult)
        {
            return new Point(v.X * mult, v.Y * mult);
        }

        public static Point operator *(double mult, Point v)
        {
            return new Point(v.X * mult, v.Y * mult);
        }

        public double Cross(Point v)
        {
            return X * v.Y - Y * v.X;
        }

        public static bool IsZero(double d)
        {
            return Math.Abs(d) < _Epsilon;
        }
    }

    public struct LineSegment
    {
        public readonly Point Point1;
        public readonly Point Point2;
        
        public LineSegment(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public Point? FindIntersectionPoint(LineSegment other)
        {
            Point intersection;

            return !FindIntersectionPoint(Point1, Point2, other.Point1, other.Point2, out intersection) ? null : (Point?)intersection;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LineSegment)) 
            {
                return false;
            }

            LineSegment l = (LineSegment)obj;

            return Point1.Equals(l.Point1) && Point2.Equals(l.Point2);
        }

        public override int GetHashCode()
        {
            return Point1.GetHashCode() ^ Point2.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Point1.ToString(), Point2.ToString());
        }

        private bool FindIntersectionPoint(
            Point p, 
            Point p2, 
            Point q, 
            Point q2,
            out Point intersection, 
            bool considerCollinearOverlapAsIntersect = false)
        {
            intersection = new Point();

            Point r = p2 - p;
            Point s = q2 - q;
            double rxs = r.Cross(s);
            double qpxr = (q - p).Cross(r);

            if (Point.IsZero(rxs) && Point.IsZero(qpxr))
            {
                if (considerCollinearOverlapAsIntersect)
                {
                    if ((0 <= (q - p) * r && (q - p) * r <= r * r) || (0 <= (p - q) * s && (p - q) * s <= s * s))
                    {
                        return true;
                    }
                }
                    
                return false;
            }

            if (Point.IsZero(rxs) && !Point.IsZero(qpxr))
            {
                return false;
            }

            double t = (q - p).Cross(s) / rxs;
            double u = (q - p).Cross(r) / rxs;

            if (!Point.IsZero(rxs) && (0 <= t && t <= 1) && (0 <= u && u <= 1))
            {
                intersection = p + t * r;

                return true;
            }

            return false;
        }
    }
}