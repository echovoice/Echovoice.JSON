using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Echovoice.JSON.Tests
{
    [TestClass]
    public class EdgeCaseTests
    {
        [TestMethod]
        public void DecodeEmptyArray()
        {
            string input = "[]";
            string[] result = JSONDecoders.DecodeJSONArray(input);
            // Empty arrays return an array with one empty string element
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(string.Empty, result[0]);
        }

        [TestMethod]
        public void DecodeEmptyStringArray()
        {
            string input = "[]";
            string[] result = JSONDecoders.DecodeJsStringArray(input);
            // Empty arrays return an array with one empty string element
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(string.Empty, result[0]);
        }

        [TestMethod]
        public void DecodeNullOrWhitespace()
        {
            string[]? result1 = JSONDecoders.DecodeJSONArray(null!);
            Assert.AreEqual(0, result1.Length);

            string[] result2 = JSONDecoders.DecodeJSONArray("");
            Assert.AreEqual(0, result2.Length);

            string[] result3 = JSONDecoders.DecodeJSONArray("   ");
            Assert.AreEqual(0, result3.Length);
        }

        [TestMethod]
        public void EncodeNullArray()
        {
            string result = JSONEncoders.EncodeJsStringArray(null!);
            Assert.AreEqual("[]", result);

            string result2 = JSONEncoders.EncodeJsObjectArray((string[]?)null);
            Assert.AreEqual("[]", result2);

            string result3 = JSONEncoders.EncodeJsObjectArray((object[]?)null);
            Assert.AreEqual("[]", result3);
        }

        [TestMethod]
        public void EncodeEmptyArray()
        {
            string result = JSONEncoders.EncodeJsStringArray(new string[] { });
            Assert.AreEqual("[]", result);
        }

        [TestMethod]
        public void EncodeSingleElement()
        {
            string result = JSONEncoders.EncodeJsStringArray(new[] { "test" });
            Assert.AreEqual("[\"test\"]", result);
        }

        [TestMethod]
        public void DecodeStringWithEscapes()
        {
            string input = "\"\\\"quoted\\\"\"";
            string result = JSONDecoders.DecodeJsString(input);
            Assert.AreEqual("\"quoted\"", result);
        }

        [TestMethod]
        public void EncodeStringWithSpecialChars()
        {
            string input = "Line1\nLine2\tTabbed";
            string result = JSONEncoders.EncodeJsString(input);
            Assert.IsTrue(result.Contains("\\n"));
            Assert.IsTrue(result.Contains("\\t"));
        }

        [TestMethod]
        public void EncodeStringWithBackslash()
        {
            string input = "C:\\path\\to\\file";
            string result = JSONEncoders.EncodeJsString(input);
            Assert.IsTrue(result.Contains("\\\\"));
        }

        [TestMethod]
        public void EncodeStringWithForwardSlash()
        {
            string input = "http://example.com/path";
            string result = JSONEncoders.EncodeJsString(input);
            Assert.IsTrue(result.Contains("\\/"));
        }

        [TestMethod]
        public void SliceWithNegativeEnd()
        {
            string s = "HelloWorld";
            string result = s.Slice(0, -5);
            Assert.AreEqual("Hello", result);
        }

        [TestMethod]
        public void SliceMiddleSection()
        {
            string s = "0123456789";
            string result = s.Slice(2, 7);
            Assert.AreEqual("23456", result);
        }

        [TestMethod]
        public void DecodeArrayWithObjectContainingEscapedQuotes()
        {
            string input = "[{\"key\": \"value \\\"quoted\\\"\"}]";
            string[] result = JSONDecoders.DecodeJSONArray(input);
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result[0].Contains("quoted"));
        }

        [TestMethod]
        public void EncodeStringWithControlCharacters()
        {
            string input = "Test\b\f\r";
            string result = JSONEncoders.EncodeJsString(input);
            Assert.IsTrue(result.Contains("\\b"));
            Assert.IsTrue(result.Contains("\\f"));
            Assert.IsTrue(result.Contains("\\r"));
        }

        [TestMethod]
        public void EncodeStringWithUnicodeCharacters()
        {
            string input = "Hello 世界";
            string result = JSONEncoders.EncodeJsString(input);
            Assert.IsTrue(result.Contains("\\u"));
        }

        [TestMethod]
        public void DecodeNestedArraysThreeLevels()
        {
            string input = "[[[1,2],[3,4]],[[5,6],[7,8]]]";
            string[] result = JSONDecoders.DecodeJSONArray(input);
            Assert.AreEqual(2, result.Length);
            
            string[] level2a = JSONDecoders.DecodeJSONArray(result[0]);
            Assert.AreEqual(2, level2a.Length);
            
            string[] level3 = JSONDecoders.DecodeJSONArray(level2a[0]);
            Assert.AreEqual(2, level3.Length);
            Assert.AreEqual("1", level3[0]);
            Assert.AreEqual("2", level3[1]);
        }
    }
}
