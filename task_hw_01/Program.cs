/*
 Задача из дз номер 1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_hw_01
{
    class Circle
    {
        double _r;

        public double Radius { get { return _r; } }

        public Circle() : this(1) { }// Default value

        public Circle(double radius)
        {
            _r = radius;
        }

        public double S
        {
            get
            {
                return Math.PI * _r * _r;
            }
        } // Count area


    }
    class Program
    {
        /// <summary>
        /// Defining correct number method
        /// </summary>
        /// <param name="message">Inform of input</param>
        /// <returns>Correct number, limited by 10000</returns>
        public static double ReadNumber(string message)
        {
            double input;
            Console.WriteLine(message + ":");
            while (!double.TryParse(Console.ReadLine(), out input) || (input <= 0) || (input > 10000))
            {
                Console.Write("Error! Repeat:");
            }
            return input;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                // Input and checking correct form
                bool flag = true;
                double Rmax = 0;
                double Rmin = 0;
                double delta = 0;
                do
                {
                    Rmin = ReadNumber("Input a minimum radius");
                    Rmax = ReadNumber("Input a maximum radius");
                    if (Rmax >= Rmin) { flag = false; }
                    else { Console.WriteLine("Error values, try again"); }
                }
                while (flag);
                flag = true;
                do
                {
                    delta = ReadNumber("Input delta");
                    if (delta <= Rmax) { flag = false; }
                } while (flag);
                // Create objects, calculate area, output area by value step == delta
                for (double i = Rmin; i <= Rmax; i += delta)
                {
                    Circle NewCircle = new Circle(i);
                    Console.WriteLine($"Radius = {i:f3}, Area = {NewCircle.S:f3}");
                }

                Console.WriteLine("Press <ESCAPE> to exit..");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);// Restart a program
        }
    }
}
