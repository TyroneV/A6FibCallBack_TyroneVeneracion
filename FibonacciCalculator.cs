using System;
using System.Numerics;
using System.Threading;

namespace A6FibCallBack_TyroneVeneracion
{
    class FibonacciCalculator
    {
        string input = "";
        string result = "";
        public void AcceptInput()
        {
            while (true)
            {
                Console.WriteLine("Input the nth number in the Fibonacci squence you want to get.");
                input = Console.ReadLine();
                try
                {
                    BigInteger.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number! Please try again!");
                }
            }
        }
        public void Calculate()
        {
            BigInteger target = BigInteger.Parse(input);

            if (target == 0) result = "0";
            if (target == 1) result = "1";

            BigInteger n1 = 1;
            BigInteger n2 = 1;
            BigInteger n3 = 0;

            for(BigInteger i = 2; i < target; i++)
            {
                Console.WriteLine("continuing to do work...");
                Thread.Sleep(1000);
                n3 = n1 + n2;
                n1 = n2;
                n2 = n3;
            }
            result = n3.ToString();
        }
        public string GiveResults()
        {
            return result;
        }
    }
}
