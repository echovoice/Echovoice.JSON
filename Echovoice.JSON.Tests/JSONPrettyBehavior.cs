﻿using NUnit.Framework;
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
    public class JSONPrettyBehavior
    {
        private static readonly string NewLine = Environment.NewLine;
        private readonly string _basicPrettyPrintArrayInObjectExample =
            "{" + NewLine +
            "    \"CreatedDate\": \"\\/Date(1262329200000)\\/\"," + NewLine +
            "    \"Id\": \"7df51e04-ca58-4804-82f6-e0af2f1d5265\"," + NewLine +
            "    \"Names\": [" + NewLine +
            "        \"One\"," + NewLine +
            "        \"Two\"," + NewLine +
            "        \"Three\"" + NewLine +
            "    ]" + NewLine +
            "}";

        [Test]
        public void should_be_able_to_handle_an_empty_object()
        {
            var example = "{" + NewLine + "    " + NewLine  + "}";

            const string originalString = "{}";

            var prettyString = originalString.PrettyPrintJson();

            ComparePrettyResultWithExampleResult(originalString, prettyString, example);
        }


        [Test]
        public void should_be_able_to_pretty_print_a_simple_object()
        {
            var testObj = new SimpleObject { Hammer = "throw" };

            var unprettyString = testObj.ToJSON().Replace(":", " :" + NewLine + NewLine + NewLine);

            ComparePrettyPrintResultWithExample(testObj, unprettyString, _jsonLintVersionOfSimpleObject);
        }

        private readonly string _jsonLintVersionOfSimpleObject = "{" + NewLine + "    \"Hammer\": \"throw\"" + NewLine + "}";
        

        [Test]
        public void should_pretty_print_json_an_object_with_complex_members()
        {
            var testObj = CreateTestLeafObject();

            SerializeAndCompareTheTwoStrings(testObj, _basicPrettyPrintArrayInObjectExample);
        }

        [Test]
        public void should_beautify_nested_objects_correctly()
        {
            var testComplexObject = GenerateComplexTestObject();

            var complexTestString = File.ReadAllText("TestFiles\\jsonLintBeautifyExample.json");

            SerializeAndCompareTheTwoStrings(testComplexObject, complexTestString);
        }


        private static TestLeafObject CreateTestLeafObject()
        {
            return new TestLeafObject
            {
                Id = new Guid("7df51e04-ca58-4804-82f6-e0af2f1d5265"),
                Names = new[] { "One", "Two", "Three" },
                CreatedDate = new DateTime(2010, 1, 1)
            };
        }

        private static TestRootObject GenerateComplexTestObject()
        {
            return new TestRootObject
            {
                Leaves = new List<TestLeafObject> { CreateTestLeafObject(), CreateTestLeafObject(), CreateTestLeafObject() },
                Id = new Guid("325116C6-5147-4f09-8B9D-5547359A5153"),
                CreatedDate = new DateTime(2010, 4, 14),
                Friend = CreateTestLeafObject(),
                Titles = new[] { "Crazy horse's weeding", "\"c:\\windows\\home\"", "happy" }
            };
        }


        private static void SerializeAndCompareTheTwoStrings<T>(T testObj, string example)
        {
            var unprettyString = testObj.ToJSON();

            ComparePrettyPrintResultWithExample(testObj, unprettyString, example);
        }

        private static void ComparePrettyPrintResultWithExample<T>(T testObj, string unprettyString, string example)
        {
            var prettyString = unprettyString.PrettyPrintJson();
            var deserializedObject = prettyString.DeserializeFromJson<T>();
            //Assert.That(deserializedObject, Is.EqualTo(testObj));

            ComparePrettyResultWithExampleResult(unprettyString, prettyString, example);
        }

        private static void ComparePrettyResultWithExampleResult(string original, string prettyString, string example)
        {
            //Assert.That(prettyString, Is.Not.EqualTo(string.Empty));
            //Assert.That(prettyString, Is.EqualTo(example));
        }
    }
}
