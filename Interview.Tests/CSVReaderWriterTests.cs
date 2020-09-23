using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview.Tests
{
    public class CSVReaderWriterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WritesAndReadsFile()
        {
            var readerWriter = new CSVReaderWriter();
            var tempFileName = Path.GetTempFileName();
            readerWriter.Open(tempFileName, CSVReaderWriter.Mode.Write);
            for (int i = 0; i < 1000; i++)
            {
                readerWriter.Write(i.ToString(), (i+1).ToString());
            }
            
            readerWriter.Open(tempFileName, CSVReaderWriter.Mode.Read);

            List<(string Column1, string Column2)> columns = new List<(string Column1, string Column2)>();
            while (readerWriter.Read(out var column1, out var column2))
            {
                columns.Add((column1, column2));
            }
            
            Assert.That(columns.Count, Is.EqualTo(1000));
        }
    }
}