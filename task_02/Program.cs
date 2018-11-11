/*
 Задание с семинара номер 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_02
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y) { X = x; Y = y; }
        public Point() : this(0, 0) { } // Default constructor
        public double Ro
        {
            get
            {
                return X * X + Y * Y;
            }
        }  // Calculate a radius
        public double Fi // Calculate an angle
        {
            get
            {
                if ((X > 0) && (Y >= 0)) { return Math.Atan(Y / X); }

                else if ((X > 0) && (Y < 0)) { return Math.Atan(Y / X) + 2 * Math.PI; }

                else if (X < 0) { return Math.Atan(Y / X) + Math.PI; }

                else if ((X == 0) && (Y > 0)) { return Math.PI / 2; }

                else if ((X == 0) && (Y < 0)) { return 3 * Math.PI / 2; }

                else { return 0; }
            }
        }

        public string PointData // Data of the point
        {
            get
            {
                string maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2} ";
                return string.Format(maket, X, Y, Ro, Fi);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create two points
            Point a, b, c;
            a = new Point(3, 4);
            Console.WriteLine(a.PointData);
            b = new Point(0, 3);
            Console.WriteLine(b.PointData);
            // Input coordinates from user, create a point
            c = new Point();
            double x = 0, y = 0;
            do
            {
                Console.Write("x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("y = ");
                double.TryParse(Console.ReadLine(), out y);
                c.X = x; c.Y = y;

            } while (x == 0 | y == 0);
            // Define sequence by  radius magnitude   
            Point min = (a.Ro <= b.Ro) ? (a.Ro <= c.Ro ? a : c) : (b.Ro <= c.Ro ? b : c);
            Point max = (a.Ro >= b.Ro) ? (a.Ro >= c.Ro ? a : c) : (b.Ro >= c.Ro ? b : c);
            Point mid = (a.Ro <= b.Ro) ? (a.Ro >= c.Ro ? a : (c.Ro >= b.Ro ? c : b)) : (a.Ro <= c.Ro ? a : (c.Ro >= b.Ro ? c : b));
            // Output
            Console.WriteLine($"The closest point: {min.PointData}");
            Console.WriteLine($"The middle point: {mid.PointData}");
            Console.WriteLine($"The farest point: {max.PointData}");

            Console.ReadKey();
        }
    }
}
