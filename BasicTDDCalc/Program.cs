using System;

namespace BasicTDDCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc _calculator = new Calc();
            Console.WriteLine(_calculator.SumTwoNum(2,2));
        }
    }
}
