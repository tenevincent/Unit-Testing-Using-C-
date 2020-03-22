using System;

namespace Factorial
{
    class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                int iTargetNumber = Convert.ToInt32(args[0]);

                if (iTargetNumber == 0)
                {
                    Console.WriteLine("Factorial of Zero = 1");
                }
                else if (iTargetNumber < 0)
                {
                    Console.WriteLine("Please enter a positive number greater than 0");
                }
                else
                {
                    double dFactorialResult = 1;

                    for (int i = iTargetNumber; i >= 1; i--)
                    {
                        dFactorialResult = dFactorialResult * i;
                    }
                                        
                    Console.WriteLine("Factorial of {0} = {1}", iTargetNumber, dFactorialResult);
                }
                
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not a valid number", args[0]);
                return 1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please enter a number between 1 and {0}", Int32.MaxValue);
                return 1;
            }
            catch (Exception)
            {
                Console.WriteLine("There is a problem! Please try later");
                return 1;
            }
        }
    }
}
