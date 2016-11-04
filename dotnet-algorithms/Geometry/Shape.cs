using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.Geometry
{
    public static class Shape
    {
        public static Point[] ConvexHull(Point[] points)
        {
            if (points == null || points.Length == 0)
            {
                return new Point[] { };
            }

            List<Point> ordered = points
               .OrderBy(p => p.X)
               .ThenBy(p => p.Y)
               .ToList();
 
           List<Point> left = new List<Point>();
 
           left.Add(ordered.First());
 
           ordered.RemoveAt(0);
           ordered.Add(left.First());
 
           ConvexHullRunner(left, ordered);
 
           return left.ToArray();
        }

        private static bool ConvexHullRunner(List<Point> left, List<Point> right)
        {
            bool ret = false;
            int len = right.Count;
    
            if (right.Any())
            {
                for (int i = 0; i < len; i++)
                {
                    Point r = right[i];
    
                    left.Add(r);
                    right.RemoveAt(i);
    
                    if (IsLeftTurn(left) && (r.Equals(left.First()) || ConvexHullRunner(left, right)))
                    {
                        ret = true;
                        break;
                    }
                    else
                    {
                        right.Insert(i, left.Last());
                        left.RemoveAt(left.Count - 1);
                    }
                }
            }
    
            return ret;
        }

        private static bool IsLeftTurn(List<Point> points)
        {
            if (points.Count < 3)
            {
                return true;
            } 
            else
            {
                Point p1 = points[points.Count - 3];
                Point p2 = points[points.Count - 2];
                Point p3 = points[points.Count - 1];
    
                double result = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
    
                return result >= 0;
            }
        }
    }
}