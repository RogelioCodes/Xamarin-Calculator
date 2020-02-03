using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public static class OperatorCase
    {

        public static double Calculate(double value1, double value2, string myoperator)
        {
            double result = 0;
            switch (myoperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }
            return result;
        }
    }

}
