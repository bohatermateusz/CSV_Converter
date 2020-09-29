using System.IO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Tests
{
    public class CsvReaderWriterTests
    {
        private string _tempFileName;
        private CsvMain _instance;

        [SetUp]
        public void Setup()
        {
            _tempFileName = Path.GetTempFileName();
            _instance = new CsvMain(_tempFileName);
        }

        [Test]
        public void WriteAndReadFile()
        {
            _instance.Write();
            for (var i = 0; i < 1000; i++)
            {
                _instance.Write();
            }

            _instance.ReadValueTuple();

            var columns3 = new List<string[]>();
            //var columns = new List<(string Column1, string Column2)>();

            //const string column1 = "column1";
            //const string column2 = "column2";

            while (_instance.ReadValueTuple().Item1)
            {
                columns3.Add(_instance.ReadValueTuple().Item2);    
                //columns.Add((column1, column2));
            }

            Assert.That(columns3.Count, Is.EqualTo(1000));

        }
    }
}