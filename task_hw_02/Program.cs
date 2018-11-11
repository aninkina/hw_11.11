/*
 Задача из дз номер 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_hw_02
{
    class LatinChar
    {
        char _char = 'a';

        public char GetChar { get { return _char; } } // Property for reading

        public LatinChar(char Char)
        {
            _char = Char;
        }

    }
    class Program
    {
        /// <summary>
        ///  Reading method to check the correct form of letter 
        /// </summary>
        /// <param name="message">Message to input</param>
        /// <returns>correct letter from 'a' to 'z'</returns>
        public static char ReadWord(string message)
        {
            char input;
            Console.WriteLine(message + ":");
            while (!char.TryParse(Console.ReadLine(), out input) || (input < 97) || (input > 122))
            {
                Console.Write("Error! Repeat:");
            }
            return input;

        }

        static void Main(string[] args)
        {
            do
            {
                // Input
                Console.Clear();
                bool flag = true;
                char minChar = 'a';
                char maxChar = 'a';
                do
                {
                    // Cheking right ordering
                    minChar = ReadWord("Input starting word from 'a' to 'z'");
                    maxChar = ReadWord($"Input ending word from '{minChar}' to 'z'");
                    if (minChar <= maxChar) { flag = false; }
                    else { Console.WriteLine("Error order! Repeat"); }

                } while (flag);
                // Output
                Console.WriteLine($"Sequence from '{minChar}' to '{maxChar}':");
                for (int i = minChar; i <= maxChar; i++)
                {
                    LatinChar newWord = new LatinChar((char)i);
                    Console.Write($" {newWord.GetChar} ");
                }
                Console.WriteLine();
                Console.WriteLine("Press <ESCAPE> to exit..");// Restart
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
