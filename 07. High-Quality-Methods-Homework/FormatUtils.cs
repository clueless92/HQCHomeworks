using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class FormatUtils
    {
        public static string DigitToText(char digit)
        {
            switch (digit)
            {
                case '0':
                    return "zero";
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                default:
                    throw new ArgumentException("Not a valid base 10 digit.");
            }
        }

        public static string FormatNumber(object number, string format)
        {
            string formatString = format.ToLower();
            if (formatString == "f")
            {
                return String.Format("{0:f2}", number);
            }
            if (formatString == "%")
            {
                return String.Format("{0:0p}", number);
            }
            if (formatString == "r")
            {
                return String.Format("{0,8}", number);
            }

            throw new ArgumentException("Invalid format string.");
        }
    }
}
