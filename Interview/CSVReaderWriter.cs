using System;
using System.IO;
using Interview.Interfaces;

namespace Interview
{
    public class CsvReaderWriter
    {
        private StreamReader _readerStream;
        private StreamWriter _writerStream;

        private readonly IReader _reader;
        private readonly IWriter _writer;
        

        public CsvReaderWriter(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }
        
        public void Write(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            _writerStream = new StreamWriter(fileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) { AutoFlush = true };
            _writer.Write();
        }
        public void Read(string fileName)
        {
            _readerStream = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            _reader.Read();
        }
    }
    
}
