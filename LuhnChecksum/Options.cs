using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace LuhnChecksum
{
    class Options
    {
        [Option('c')]
        public bool ComputeCheckDigit { get; set; }

        [Option('v')]
        public bool DoValidation { get; set; }
        [Option('n')]
        public string NumberToValidate { get; set; }
    }
}
