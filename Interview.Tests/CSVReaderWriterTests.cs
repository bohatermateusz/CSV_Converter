using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

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
                _instance.Write(i.ToString(), (i + 1).ToString());
            }

            _instance.Read();
            var numberOfElements = new List<string[]>();

            while (_instance.Read().Item1)
            {
                numberOfElements.Add(_instance.Read().Item2);    
            }

            Assert.That(numberOfElements.Count, Is.EqualTo(500));
        }
    }
}