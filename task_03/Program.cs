/*
 Задача с семинара номер 3
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_03
{
    public class Polygon
    {
        double _radius;

        int _n;

        public Polygon(double radius, int n)
        {
            _radius = radius;
            _n = n;
        }

        public Polygon() : this(10, 3) { } // Default constructor

        public double ReadRadius { get { return _radius; } }

        public double Area
        {
            get { return Perimetr * _radius / 2; }
            set { }
        }

        public double Perimetr
        {
            get
            {
                try
                {
                    double a = 2 * _radius / Math.Tan(Math.PI / 2 - Math.PI / _n);
                    return a;
                }
                catch (DivideByZeroException) { Console.WriteLine("Dividing by zero error!"); return 0; }
            }
        }

        // Getting arguments,area and perimetr of current polygon
        public string PolygonData()
        {
            return $"n = {_n}, r = {_radius}, P = {Perimetr:f3}," + $"Area = {Area:f3}";
        }
    }
    class Program
    {
        /// <summary>
        /// Return correct Radius, limited by 1000,(or zero values, considered as end of input)
        /// </summary>
        /// <param name="message">Message of inputing</param>
        /// <returns>Correct radius (or zero values, considered as end of input)</returns>
        public static int ReadNumber(string message)
        {
            int input;
            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out input) || (input < 0) || (input > 1000))
            {
                Console.WriteLine();
                Console.Write("Error, repeat:");
            }

            return input;
        }

        /// <summary>
        /// Return correct a number of sides, limited by 100,(or zero values, considered as end of input)
        /// </summary>
        /// <param name="message">Message of inputing</param>
        /// <returns>Correct a number of sides (or zero values, considered as end of input)</returns>
        public static int ReadSides(string message)
        {
            int input;
            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out input) || (input == 1) || (input == 2) || (input < 0) || (input > 100))
            {
                Console.WriteLine();
                Console.Write("Error, repeat:");
            }

            return input;
        }

        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                double squareMax = -1; // Lower bound
                int indexMax = 0;
                double squareMin = double.MaxValue; // Upper bound
                int indexMin = 0;

                int i = -1; // Counter a number of polygons
                int quanityPolygon = 100; // Upper bound  number of polygons 
                Polygon[] arr = new Polygon[quanityPolygon];

                do
                {
                    i++;
                    arr[i] = new Polygon(); // Create an default object
                    // Inputing
                    int side = ReadSides("Input an amount of sides:");
                    double rasius = ReadNumber("Input radius's value:");
                    arr[i] = new Polygon(rasius, side); // Recreate 
                    if (arr[i].ReadRadius != 0) // Outputing after each new object
                    {
                        Console.WriteLine($"{arr[i].PolygonData()}");
                    }
                    // Find minimum and maximum areas
                    if (squareMax < arr[i].Area) { squareMax = arr[i].Area; indexMax = i; }
                    if (squareMin > arr[i].Area) { squareMin = arr[i].Area; indexMin = i; }

                } while (arr[i].ReadRadius != 0); // End of input

                Array.Resize(ref arr, i);
                Console.Clear();

                // Output  with marked extreme areas
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j == indexMax)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{arr[j].PolygonData()}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (j == indexMin)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{arr[j].PolygonData()}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine($"{arr[j].PolygonData()}");
                    }
                }
                Console.WriteLine("Press <ESCAPE> to exit.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);// Restart a program
        }
    }
}
