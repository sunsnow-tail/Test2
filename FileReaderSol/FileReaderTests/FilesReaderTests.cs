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
    public class FilesReaderTests
    {
        [TestMethod()]
        public void ReadFileTest()
        {
            //this file has one tab => 1 error
            var filename = "test.txt";

            byte[] data = System.IO.File.ReadAllBytes(filename);

            List<Models.ErrorData> errors;

            var returnList = FilesReader.ReadFile(data, filename , out errors);

            Assert.AreEqual(1, errors.Count());
        }

        [TestMethod()]
        public void ReadFileTestBigFile()
        {
            //this file has 300 tabs => 300 errors
            var filename = "hugetest.txt";

            byte[] data = System.IO.File.ReadAllBytes(filename);

            List<Models.ErrorData> errors;

            var returnList = FilesReader.ReadFile(data, filename, out errors);

            Assert.AreEqual(300, errors.Count());
        }
    }


}