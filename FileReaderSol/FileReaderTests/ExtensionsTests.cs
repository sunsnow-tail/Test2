using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void SubstringCutEndTestShortValue()
        {
            var testValue = "012345";

            var result = testValue.SubstringCutEnd(1, 3);

            Assert.AreEqual("123", result);
        }

        [TestMethod()]
        public void SubstringCutEndTestLongValue()
        {
            var testValue = "012345";

            var result = testValue.SubstringCutEnd(1, 30);

            Assert.AreEqual("12345", result);
        }
    }
}