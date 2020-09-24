using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview.Tests
{
    public class CsvReaderWriterTests
    {
        //CsvMain instance = new CsvMain("dd");

        [SetUp]
        public void Setup()
        {
            

        }

        [Test]
        public void ReadFile()
        {
            //instance.Read();


        }
        [Test]
        public void WriteFile()
        {
            var tempFileName = Path.GetTempFileName();
            CsvMain instance = new CsvMain(tempFileName);
            instance.Write();
            for (int i = 0; i < 1000; i++)
            {
                instance.Write();
            }
            instance.Read();
            List<(string Column1, string Column2)> columns = new List<(string Column1, string Column2)>();
            string column1 = "dd";
            string column2 = "aa";

            var co = instance.Read();

            while (instance.Read())
            {
                
            }

            while (readerWriter.Read(column1, column2))
            {
                columns.Add((column1, column2));
            }

            Assert.That(columns.Count, Is.EqualTo(1000));

        }

        //[Test]
        //public void WritesAndReadsFile()
        //{


        //    var readerWriter = new CsvReaderWriter();
        //    var tempFileName = Path.GetTempFileName();
        //    readerWriter.Open(tempFileName, CsvReaderWriter.Mode.Write);
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        readerWriter.Write(i.ToString(), (i+1).ToString());
        //    }
            
        //    readerWriter.Open(tempFileName, CsvReaderWriter.Mode.Read);

            
        //    List<(string Column1, string Column2)> columns = new List<(string Column1, string Column2)>();
        //    string column1 = "dd";
        //    string column2 = "aa";
        //    while (readerWriter.Read(column1,column2))
        //    {
        //        columns.Add((column1, column2));
        //    }
            
        //    Assert.That(columns.Count, Is.EqualTo(1000));
        //}
    }
}