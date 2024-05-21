using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double lowNumber = GetPositiveNumber("Enter a positive low number: ");
            double highNumber = GetHighNumber("Enter a high number greater than the low number: ", lowNumber);
            double difference = highNumber - lowNumber;
            Console.WriteLine($"The difference between {highNumber} and {lowNumber} is {difference}");
            List<double> numbers = new List<double>();
            for (double i = lowNumber; i <= highNumber; i++)
            {
                numbers.Add(i);
            }
            WriteNumbersToFile("numbers.txt", numbers);

            List<double> readNumbers = ReadNumbersFromFile("numbers.txt");
            double sum = CalculateSum(readNumbers);
            Console.WriteLine($"The sum of the numbers is {sum}");

            List<double> primeNumbers = GetPrimeNumbers(lowNumber, highNumber);
            Console.WriteLine("Prime numbers between low and high:");
            foreach (double prime in primeNumbers)
            {
                Console.WriteLine(prime);
            }
        }
        static double GetPositiveNumber(string prompt)
        {
            double number;
            do
            {
                Console.Write(prompt);
                number = double.Parse(Console.ReadLine());
            } while (number <= 0);
            return number;
        }
        static double GetHighNumber(string prompt, double lowNumber)
        {
            double number;
            do
            {
                Console.Write(prompt);
                number = double.Parse(Console.ReadLine());
            } while (number <= lowNumber);
            return number;
        }
        static void WriteNumbersToFile(string filePath, List<double> numbers)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(numbers[i]);
                }
            }
        }
        static List<double> ReadNumbersFromFile(string filePath)
        {
            List<double> numbers = new List<double>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    numbers.Add(double.Parse(line));
                }
            }
            return numbers;
        }
        static double CalculateSum(List<double> numbers)
        {
            double sum = 0;
            foreach (double number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        static List<double> GetPrimeNumbers(double low, double high)
        {
            List<double> primes = new List<double>();
            for (double i = low; i <= high; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
        static bool IsPrime(double number)
        {
            if (number < 2) return false;
            for (double i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
