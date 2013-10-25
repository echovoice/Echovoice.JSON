using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echovoice.JSON.Pretty;
using System.IO;

namespace Echovoice.JSON.Tests
{
    [TestFixture]
    public class JSONPrettyTests
    {
        private static readonly string NewLine = Environment.NewLine;

        private readonly string _complexPrettyPrintArrayInObjectExample = "{\"CreatedDate\": \"\\/Date(1262329200000)\\/\",\"Id\": \"7df51e04-ca58-4804-82f6-e0af2f1d5265\",\"Names\": [\"One\",\"Two\",\"Three\"]}";
        private readonly string _basicPrettyPrintArrayInObjectExample = "[4,5,2,1]";

        [Test]
        public void testComplexPretty()
        {
            _complexPrettyPrintArrayInObjectExample.PrettyPrintJson().Should().Be
            ("{" + NewLine +
            "    \"CreatedDate\":  \"\\/Date(1262329200000)\\/\"," + NewLine +
            "    \"Id\":  \"7df51e04-ca58-4804-82f6-e0af2f1d5265\"," + NewLine +
            "    \"Names\":  [" + NewLine +
            "        \"One\"," + NewLine +
            "        \"Two\"," + NewLine +
            "        \"Three\"" + NewLine +
            "    ]" + NewLine +
            "}");
        }

        [Test]
        public void testBasicPretty()
        {
            string complexTestString = File.ReadAllText("TestFiles\\example.json");

            _basicPrettyPrintArrayInObjectExample.PrettyPrintJson().Should().Be(complexTestString);
        }

        
    }
}
