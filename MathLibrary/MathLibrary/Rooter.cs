﻿using System;

namespace MathLibrary
{
    public class Rooter
    {
        public Rooter()
        {

        }


        public double SquareRoot(double input)
        {
            if (input <= 0.0)
            {
                throw new ArgumentOutOfRangeException($"The input value {input} cannot be null!");
            }

            double result = input;
            double previousResult = -input;
            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = result - (result * result - input) / (2 * result);
            }
            return result;
        }
    }
}