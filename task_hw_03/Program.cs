/*
 Задача из дз номер 3
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_hw_03
{
    public class Complex
    {
        double _a;
        double _b;

        public Complex(double a, double b)
        {
            _a = a;
            _b = b;
        }
        public Complex()
        {
            _a = 0;
            _b = 0;
        }
        public Complex(Complex original)
        {
            _a = original.Re();
            _b = original.Im();
        }


        // Define real part
        public double Re()
        {
            return _a;
        }
        // Define imaginary part
        public double Im()
        {
            return _b;
        }
        // Calculate complex module
        public double Abs()
        {
            return Math.Sqrt(_a * _a + _b * _b);
        }
        // Calculate complex argument
        public double Arg()
        {

            if (_a > 0) { return Math.Atan(_b / _a); }

            else if ((_a < 0) && (_b < 0)) { return Math.Atan(_b / _a) - Math.PI; }

            else if ((_a < 0) && (_b >= 0)) { return Math.Atan(_b / _a) + Math.PI; }

            else { Console.WriteLine("Dividing by zero error"); return 0; }



        }

        // Define arithmetc operations with complex numbers
        public static string SummarizeComplex(Complex a, Complex b)
        {
            double re = a.Re() + b.Re();
            double im = a.Im() + b.Im();
            Complex newComplex = new Complex(re, im);
            return newComplex.ToString();
        }

        public static string SubtractComplex(Complex a, Complex b)
        {
            double re = a.Re() - b.Re();
            double im = a.Im() - b.Im();
            Complex newComplex = new Complex(re, im);
            return newComplex.ToString();
        }

        public static string MultiplyComplex(Complex a, Complex b)
        {
            double re = a.Re() * b.Re() - a.Im() * b.Im();
            double im = a.Im() * b.Re() + a.Re() * b.Im();
            Complex newComplex = new Complex(re, im);
            return newComplex.ToString();
        }

        public static string DivideComplex(Complex a, Complex b)
        {
            double re;
            double im;
            double denominator = b.Re() * b.Re() + b.Im() * b.Im();
            double numeratorReal = a.Re() * b.Re() + a.Im() * b.Im();
            double numeratorIm = a.Re() * b.Im() - a.Im() * b.Re();
            if (denominator != 0)
            {
                re = numeratorReal / denominator;
                im = numeratorIm / denominator;
                Complex newComplex = new Complex(re, im);
                return newComplex.ToString();
            }
            else { return "Dividing by zero error"; }


        }
        // Redefine inherited method toString
        public override string ToString()
        {
            return $"{_a:f3} + ({_b:f3})i ";
        }
    }
    class Program
    {
        /// <summary>
        /// Method for checking correct form of double number
        /// </summary>
        /// <param name="message">Message to input</param>
        /// <returns>Correct number</returns>
        public static double ReadNumber(string message)
        {
            double input;
            Console.Write(message + ":");
            while (!double.TryParse(Console.ReadLine(), out input) || (Math.Abs(input) > 10000))
            {
                Console.Write("Error! Repeat:");
            }

            return input;
        }

        /// <summary>
        /// Method for creating complex number by adding real part and imaginary part
        /// </summary>
        /// <returns> Complex number </returns>
        public static Complex CreateComplex()
        {
            Console.WriteLine("Put the  number as 'a+bi'");
            double re = ReadNumber("Input real part");
            double im = ReadNumber("Input imaginary part");
            Complex number = new Complex(re, im);
            return number;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                //Input, create complex numbers
                Console.WriteLine("1st number:");
                Complex number1 = CreateComplex();
                Console.WriteLine("1d number:");
                Complex number2 = CreateComplex();
                // Getting info of complex numbers
                Console.WriteLine($"First number N1 = {number1.ToString()}, mod(N1) ={number1.Abs():f3}, arg(N1) ={number1.Arg():f3}");
                Console.WriteLine($"Second number N2 = {number2.ToString()}, mod(N2) ={number2.Abs():f3}, arg(N1) ={number2.Arg():f3}");
                Console.WriteLine();
                //Calculation
                Console.WriteLine($"N1 - N2 = {Complex.SubtractComplex(number1, number2)}");
                Console.WriteLine($"N1 + N2 = {Complex.SummarizeComplex(number1, number2)}");
                Console.WriteLine($"N1 * N2 = {Complex.MultiplyComplex(number1, number2)}");
                Console.WriteLine($"N1 / N2 = {Complex.DivideComplex(number1, number2)}");
                Console.WriteLine("Press <ESCAPE> to exit..");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);// Restart
        }
    }
}
