using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Echovoice.JSON.Tests
{
    [TestClass]
    public class JSONDecodeTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void DecodeJSONArray()
        {
            string input = "[3,\"gew8u3rethex\",1,\"Example 0.9.6\",[30,60,true],[1,true,true,true,\"250K\",\"50M\"],true,true,120,{\"api_day_quota\": 1000,\"api_day_reset\": 41268740,\"api_day_used\": 153,\"api_hour_quota\": 100,\"api_hour_reset\": 41267360,\"api_hour_used\": 15,\"sample_feature_1\": true,\"sample_feature_2\": false}]";
            string[] result = JSONDecoders.DecodeJSONArray(input);

            result[0].Should().Be("3");
            result[1].Should().Be("gew8u3rethex");
            result[2].Should().Be("1");
            result[3].Should().Be("Example 0.9.6");
            result[4].Should().Be("[30,60,true]");
            result[5].Should().Be("[1,true,true,true,\"250K\",\"50M\"]");
            result[6].Should().Be("true");
            result[7].Should().Be("true");
            result[8].Should().Be("120");
            result[9].Should().Be("{\"api_day_quota\": 1000,\"api_day_reset\": 41268740,\"api_day_used\": 153,\"api_hour_quota\": 100,\"api_hour_reset\": 41267360,\"api_hour_used\": 15,\"sample_feature_1\": true,\"sample_feature_2\": false}");
        }

        [TestMethod]
        public void DecodeComplexJSONArray()
        {
            string input = "[14,4,[14,\"data\"],[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]]";
            string[] result = JSONDecoders.DecodeJSONArray(input);

            result.Length.Should().Be(4);
            result[0].Should().Be("14");
            result[1].Should().Be("4");
            result[2].Should().Be("[14,\"data\"]");
            result[3].Should().Be("[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]");

            result = JSONDecoders.DecodeJSONArray(result[3]);

            result[0].Should().Be("[5,\"10.186.122.15\"]");
            result[1].Should().Be("[6,\"10.186.122.16\"]");
        }

        [TestMethod]
        public void DecodeJsStringArray()
        {
            string input = "[\"philcollins\",\"Ih8PeterG\"]";
            string[] result = JSONDecoders.DecodeJsStringArray(input);

            result[0].Should().Be("philcollins");
            result[1].Should().Be("Ih8PeterG");
        }

        [TestMethod]
        public void DecodeJsString()
        {
            string result = JSONDecoders.DecodeJsString("\"\\u003Cb\\u003Esco\\u003C\\/b\\u003E\"");
            result.Should().Be("<b>sco</b>");
        }

        [TestMethod]
        public void DecodeSliceExtensions()
        {
            string s = "0123456789_";

            s.Slice(0, 1).Should().Be("0");     // First char
            s.Slice(0, 2).Should().Be("01");    // First two chars
            s.Slice(1, 2).Should().Be("1");     // Second char
            s.Slice(8, 11).Should().Be("89_");  // Last three chars

            s.Slice(1, -3).Should().Be("1234567");
        }

        [TestCleanup]
        public void TearDown()
        {

        }
    }
}
