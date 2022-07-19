using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG2Input
{
    public static class Input
    {
        static void Main(string[] args)
        {
            static int ReadInteger(string prompt, int min, int max)
            {
                bool valid = false;
                int num = 0;
                while (!valid)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("That is not a number. Please try again");
                        Console.WriteLine();
                    }
                    else if (number >= min && number <= max)
                    {
                        return number;
                    }
                    else
                    {
                        valid = false;
                    }
                }
                return num;
            }
            static void ReadString(string prompt, ref string value)
            {
                bool valid = false;
                while (!valid)
                {
                    Console.Write(prompt);
                    value = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            static void ReadChoice(string prompt, string[] options, out int selection)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine(options[i]);
                }
                selection = ReadInteger(prompt, 1, options.Length);
            }
        }
    }
}

