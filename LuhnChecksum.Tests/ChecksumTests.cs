using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LuhnChecksum.Tests
{
    [TestFixture]
    public class ChecksumTests
    {
        [Test]
        public void DoComputeCheckDigitCorrespondsWithWikiExample()
        {
            var accountNumber = "7992739871";
            var result = Program.DoComputeCheckDigit(accountNumber);
            Assert.That(result.Equals(3),$"result was {result}");
        }

        [Test]
        public void DoValidateNumberResultCorrespondsWithWikiExample()
        {
            var accountNumber = "79927398713";
            var result = Program.DoValidateNumber(accountNumber);
            Assert.That(result.Equals(true),"result is false");
        }
    }
}
