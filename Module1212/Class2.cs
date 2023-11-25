using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1212
{

    class Program
    {
        public delegate double MathOperation(double a, double b);
        public static class MathOperations
        {
            public static double Add(double a, double b) => a + b;
            public static double Subtract(double a, double b) => a - b;
            public static double Multiply(double a, double b) => a * b;
            public static double Divide(double a, double b) => a / b;
        }
        public static double PerformOperation(double x, double y, MathOperation operation)
        {
            return operation(x, y);
        }
        static void Main(string[] args)
        {
            MathOperation add = MathOperations.Add;
            MathOperation subtract = MathOperations.Subtract;
            MathOperation multiply = MathOperations.Multiply;
            MathOperation divide = MathOperations.Divide;

            double result1 = PerformOperation(10, 5, add);
            Console.WriteLine($"Addition: {result1}");

            double result2 = PerformOperation(10, 5, subtract);
            Console.WriteLine($"Subtraction: {result2}");


            MathOperation lambdaMultiply = (a, b) => a * b;
            double lambdaResult = PerformOperation(10, 5, lambdaMultiply);
            Console.WriteLine($"Lambda Multiply: {lambdaResult}");


            MathOperation operationsChain = add + subtract + multiply + divide;
            double chainResult = PerformOperation(10, 5, operationsChain);
            Console.WriteLine($"Operations Chain Result: {chainResult}");
            Console.ReadKey();
        }
    }

}