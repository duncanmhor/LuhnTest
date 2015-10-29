using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnChecksum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.ComputeCheckDigit)
                {
                   var result =  DoComputeCheckDigit(options.NumberToValidate);
                    Console.WriteLine($"Check digit is {result}");
                    Console.WriteLine($"Full result is {options.NumberToValidate}{result}");
                }
                else if (options.DoValidation)
                {
                    var isValid =  DoValidateNumber(options.NumberToValidate);
                    var message = isValid ? "Checksum is valid" : "Checksum is not valid";
                    Console.WriteLine(message);
                }

            }
        }

        public static bool DoValidateNumber(string numberToValidate)
        {
            var chars = numberToValidate.ToCharArray();
            var backChars = chars.Reverse().ToList();
            var candidateCheckDigit = Int32.Parse(backChars.First().ToString());
            var tempSum = 0;
            for (int i = 1; i < backChars.Count; i++)
            {

                if (i % 2 != 0)
                {
                    int val = Int32.Parse(backChars[i].ToString());
                    if (val * 2 > 9)
                    {
                        val = 1 + (val * 2 - 10);
                    }
                    else
                    {
                        val = val * 2;
                    }
                    tempSum += val;
                }
                else
                {
                    tempSum += Int32.Parse(backChars[i].ToString());
                }
               
            }
            return (tempSum + candidateCheckDigit)%10 == 0;
        }

        public static int DoComputeCheckDigit(string numberToValidate)
        {
            var chars = numberToValidate.ToCharArray();
            var backChars = chars.Reverse().ToList();
            var tempSum = 0;
            for (int i = 0; i < backChars.Count; i++)
            {

                if (i%2== 0)
                {
                    int val = Int32.Parse(backChars[i].ToString());
                    if (val*2 > 9)
                    {
                        val = 1 + (val*2 - 10);
                    }
                    else
                    {
                        val = val*2;
                    }
                    tempSum += val;
                }
                else
                {
                    tempSum += Int32.Parse(backChars[i].ToString());
                }
            }

            var result = (tempSum*9)%10;
            return result;
        }
    }
}
