using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.AreEqual("3", result[0]);
            Assert.AreEqual("gew8u3rethex", result[1]);
            Assert.AreEqual("1", result[2]);
            Assert.AreEqual("Example 0.9.6", result[3]);
            Assert.AreEqual("[30,60,true]", result[4]);
            Assert.AreEqual("[1,true,true,true,\"250K\",\"50M\"]", result[5]);
            Assert.AreEqual("true", result[6]);
            Assert.AreEqual("true", result[7]);
            Assert.AreEqual("120", result[8]);
            Assert.AreEqual("{\"api_day_quota\": 1000,\"api_day_reset\": 41268740,\"api_day_used\": 153,\"api_hour_quota\": 100,\"api_hour_reset\": 41267360,\"api_hour_used\": 15,\"sample_feature_1\": true,\"sample_feature_2\": false}", result[9]);
        }

        [TestMethod]
        public void DecodeComplexJSONArray()
        {
            string input = "[14,4,[14,\"data\"],[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]]";
            string[] result = JSONDecoders.DecodeJSONArray(input);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("14", result[0]);
            Assert.AreEqual("4", result[1]);
            Assert.AreEqual("[14,\"data\"]", result[2]);
            Assert.AreEqual("[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]", result[3]);

            result = JSONDecoders.DecodeJSONArray(result[3]);

            Assert.AreEqual("[5,\"10.186.122.15\"]", result[0]);
            Assert.AreEqual("[6,\"10.186.122.16\"]", result[1]);
        }

        [TestMethod]
        public void DecodeJsStringArray()
        {
            string input = "[\"philcollins\",\"Ih8PeterG\"]";
            string[] result = JSONDecoders.DecodeJsStringArray(input);

            Assert.AreEqual("philcollins", result[0]);
            Assert.AreEqual("Ih8PeterG", result[1]);
        }

        [TestMethod]
        public void DecodeJsString()
        {
            string result = JSONDecoders.DecodeJsString("\"\\u003Cb\\u003Esco\\u003C\\/b\\u003E\"");
            Assert.AreEqual("<b>sco</b>", result);
        }

        [TestMethod]
        public void DecodeSliceExtensions()
        {
            string s = "0123456789_";

            Assert.AreEqual("0", s.Slice(0, 1));     // First char
            Assert.AreEqual("01", s.Slice(0, 2));    // First two chars
            Assert.AreEqual("1", s.Slice(1, 2));     // Second char
            Assert.AreEqual("89_", s.Slice(8, 11));  // Last three chars

            Assert.AreEqual("1234567", s.Slice(1, -3));
        }

        [TestCleanup]
        public void TearDown()
        {

        }
    }
}
