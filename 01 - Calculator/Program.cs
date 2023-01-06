using System;
using System.Globalization;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("################ CALCULATOR ################");
            Menu();
        }

        public static void Menu()
        {
            var listNumbers = new List<double>();

            
            Console.WriteLine("1 - Addition (No limit)");
            Console.WriteLine("2 - Substraction (Two numbers)");
            Console.WriteLine("3 - Multiplication (No Limit)");
            Console.WriteLine("4 - Division (Two numbers)");
            Console.Write("Select a Option: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    listNumbers = ReadListOfNumbers(1);
                    Console.WriteLine($"The Result is {Add(listNumbers)}");
                    break;

                case 2:
                    listNumbers = ReadListOfNumbers(2);
                    Console.WriteLine($"The Result is {Substract(listNumbers)}");
                    break;

                case 3:
                    listNumbers = ReadListOfNumbers(3);
                    Console.WriteLine($"The Result is {Multiply(listNumbers)}");
                    break;

                case 4:
                    listNumbers = ReadListOfNumbers(4);
                    if (CheckDivide(listNumbers) == true)
                    {
                        Console.WriteLine($"The Result is {Divide(listNumbers)}");
                    } else
                    {
                        Console.WriteLine("Impossible to divide by zero!");
                    }

                    break;

                default:
                    Console.WriteLine("Option doesn't exist. Bye!");
                    break;
            }

        }

        public static List<double> ReadListOfNumbers(short operation)
        {
            var list = new List<double>();
            int length = 0;

            if (operation == 1 || operation == 3) {
                do
                {
                    Console.Write("How many Numbers do you want put in the Operation? ");
                    length = int.Parse(Console.ReadLine());
                } while (length < 1);

                Console.WriteLine("Which numbers do you want to put?");

                while (length > 0)
                {
                    list.Add(double.Parse(Console.ReadLine()));
                    length--;
                }
            }

            if (operation == 2 || operation == 4) {
                Console.WriteLine("What is the first Number?");
                list.Add(double.Parse(Console.ReadLine()));
                Console.WriteLine("What is the second Number?");
                list.Add(double.Parse(Console.ReadLine()));
            }

            return list;
            
        }

        public static double Add(List<double> numbers)
        {
            double result = 0;

            foreach (var number in numbers)
            {
                result += number;
            }
            return result;
        }

        public static double Substract(List<double> numbers)
        {
            double result = numbers[0] - numbers[1];

            return result;
        }

        public static double Multiply(List<double> numbers)
        {
            double result = 1;

            foreach (var number in numbers)
            {
                result *= number;
            }
            return result;
        }

        public static double Divide(List<double> numbers)
        {

            double result = numbers[0] / numbers[1];

            return result;
        }

        public static bool CheckDivide(List<double> numbers)
        {
            if (numbers[1] == 0)
                return false;

            return true;
        }
    }
}

