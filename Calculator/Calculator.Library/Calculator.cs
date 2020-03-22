using System;

namespace Calculator.Library
{
    public class Calculator
    {
        public static int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be ZERO");

            int result = numerator / denominator;
            return result;
        }

        private static bool IsPositive(int number)
        {
            return number > 0;
        }


        public static int AddPositives(int number1, int number2)
        {
            if (IsPositive(number1)  && IsPositive(number2))
            {
                int result = number1 + number2;
                return result;
            }
            throw new ArgumentException("Only positive numbers are allowed!");
        }



        public static int Add(int numerator, int denominator)
        {
            int result = numerator + denominator;
            return result;
        }


    }
}