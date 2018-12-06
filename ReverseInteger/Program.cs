using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = Reverse(1234567);
            Console.WriteLine(r);

            r = Reverse(-1234567);
            Console.WriteLine(r);
        }

        public static int Reverse(int x)
        {
            string inputStr = x.ToString();
            bool negativeFlag = false;
            if (inputStr[0] == '-')
            {
                negativeFlag = true;

            }
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputStr);

            Array.Reverse(inputBytes);
            string resultStr = Encoding.ASCII.GetString(inputBytes);
            if (negativeFlag == true)
            {
                resultStr = "-" + resultStr.Substring(0, resultStr.Length - 1);
            }

            int result = 0;
            Int32.TryParse(resultStr, out result);


            return result;
        }
    }
}
