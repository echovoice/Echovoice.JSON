using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
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
            result.Length.Should().Be(1);
            result[0].Should().BeEmpty();
        }

        [TestMethod]
        public void DecodeEmptyStringArray()
        {
            string input = "[]";
            string[] result = JSONDecoders.DecodeJsStringArray(input);
            // Empty arrays return an array with one empty string element
            result.Length.Should().Be(1);
            result[0].Should().BeEmpty();
        }

        [TestMethod]
        public void DecodeNullOrWhitespace()
        {
            string[]? result1 = JSONDecoders.DecodeJSONArray(null!);
            result1.Should().BeEmpty();

            string[] result2 = JSONDecoders.DecodeJSONArray("");
            result2.Should().BeEmpty();

            string[] result3 = JSONDecoders.DecodeJSONArray("   ");
            result3.Should().BeEmpty();
        }

        [TestMethod]
        public void EncodeNullArray()
        {
            string result = JSONEncoders.EncodeJsStringArray(null!);
            result.Should().Be("[]");

            string result2 = JSONEncoders.EncodeJsObjectArray((string[]?)null);
            result2.Should().Be("[]");

            string result3 = JSONEncoders.EncodeJsObjectArray((object[]?)null);
            result3.Should().Be("[]");
        }

        [TestMethod]
        public void EncodeEmptyArray()
        {
            string result = JSONEncoders.EncodeJsStringArray(new string[] { });
            result.Should().Be("[]");
        }

        [TestMethod]
        public void EncodeSingleElement()
        {
            string result = JSONEncoders.EncodeJsStringArray(new[] { "test" });
            result.Should().Be("[\"test\"]");
        }

        [TestMethod]
        public void DecodeStringWithEscapes()
        {
            string input = "\"\\\"quoted\\\"\"";
            string result = JSONDecoders.DecodeJsString(input);
            result.Should().Be("\"quoted\"");
        }

        [TestMethod]
        public void EncodeStringWithSpecialChars()
        {
            string input = "Line1\nLine2\tTabbed";
            string result = JSONEncoders.EncodeJsString(input);
            result.Should().Contain("\\n").And.Contain("\\t");
        }

        [TestMethod]
        public void EncodeStringWithBackslash()
        {
            string input = "C:\\path\\to\\file";
            string result = JSONEncoders.EncodeJsString(input);
            result.Should().Contain("\\\\");
        }

        [TestMethod]
        public void EncodeStringWithForwardSlash()
        {
            string input = "http://example.com/path";
            string result = JSONEncoders.EncodeJsString(input);
            result.Should().Contain("\\/");
        }

        [TestMethod]
        public void SliceWithNegativeEnd()
        {
            string s = "HelloWorld";
            string result = s.Slice(0, -5);
            result.Should().Be("Hello");
        }

        [TestMethod]
        public void SliceMiddleSection()
        {
            string s = "0123456789";
            string result = s.Slice(2, 7);
            result.Should().Be("23456");
        }

        [TestMethod]
        public void DecodeArrayWithObjectContainingEscapedQuotes()
        {
            string input = "[{\"key\": \"value \\\"quoted\\\"\"}]";
            string[] result = JSONDecoders.DecodeJSONArray(input);
            result.Length.Should().Be(1);
            result[0].Should().Contain("quoted");
        }

        [TestMethod]
        public void EncodeStringWithControlCharacters()
        {
            string input = "Test\b\f\r";
            string result = JSONEncoders.EncodeJsString(input);
            result.Should().Contain("\\b").And.Contain("\\f").And.Contain("\\r");
        }

        [TestMethod]
        public void EncodeStringWithUnicodeCharacters()
        {
            string input = "Hello 世界";
            string result = JSONEncoders.EncodeJsString(input);
            result.Should().Contain("\\u");
        }

        [TestMethod]
        public void DecodeNestedArraysThreeLevels()
        {
            string input = "[[[1,2],[3,4]],[[5,6],[7,8]]]";
            string[] result = JSONDecoders.DecodeJSONArray(input);
            result.Length.Should().Be(2);
            
            string[] level2a = JSONDecoders.DecodeJSONArray(result[0]);
            level2a.Length.Should().Be(2);
            
            string[] level3 = JSONDecoders.DecodeJSONArray(level2a[0]);
            level3.Length.Should().Be(2);
            level3[0].Should().Be("1");
            level3[1].Should().Be("2");
        }
    }
}
