using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Echovoice.JSON.Tests
{
    [TestClass]
    public class JSONEncodeTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void EncodeJsString()
        {
            string result = JSONEncoders.EncodeJsString("<b>sco</b>");
            result.Should().Be("\"\\u003Cb\\u003Esco\\u003C\\/b\\u003E\"");

            result = JSONEncoders.EncodeJsString("\\\b\f\n\r\t");
            result.Should().Be("\"\\\\\\b\\f\\n\\r\\t\"");
        }

        [TestMethod]
        public void EncodeObjectArrayFromString()
        {
            string result = JSONEncoders.EncodeJsObjectArray(new string[] {"[\"mike\"]", "was", "here"});
            result.Should().Be("[[\"mike\"],was,here]");
        }

        [TestMethod]
        public void EncodeStringArrayFromString()
        {
            string result = JSONEncoders.EncodeJsStringArray(new string[] { "[\"mike\"]", "was", "here" });
            result.Should().Be("[\"[\\\"mike\\\"]\",\"was\",\"here\"]");
        }

        [TestMethod]
        public void EncodeObjectArray()
        {
            dummyObject[] dummys = new dummyObject[2];
            dummys[0] = new dummyObject();
            dummys[1] = new dummyObject();

            dummys[0].fake = "mike";
            dummys[0].id = 29;

            string result = JSONEncoders.EncodeJsObjectArray(dummys);
            result.Should().Be("[[29,\"mike\"],[5,\"dummy\"]]");
        }

        [TestMethod]
        public void EncodeObjectList()
        {
            List<dummyObject> dummys = new List<dummyObject>(2);

            dummyObject dummy0 = new dummyObject();
            dummy0.fake = "mike";
            dummy0.id = 29;
            dummys.Add(dummy0);
            dummys.Add(new dummyObject());

            string result = JSONEncoders.EncodeJsObjectList<dummyObject>(dummys);
            result.Should().Be("[[29,\"mike\"],[5,\"dummy\"]]");
        }

        [TestCleanup]
        public void TearDown()
        {

        }
    }

    public class dummyObject
    {
        public string fake { get; set; }
        public int id { get; set; }

        public dummyObject()
        {
            fake = "dummy";
            id = 5;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            sb.Append(id);
            sb.Append(',');
            sb.Append(JSONEncoders.EncodeJsString(fake));
            sb.Append(']');

            return sb.ToString();
        }
    }
}
