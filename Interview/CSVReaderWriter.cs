using System.IO;
using Interview.Interfaces;

namespace Interview
{
    public class CsvReaderWriter
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        public CsvReaderWriter(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }
        public void Write()
        {
            _writer.Write();
        }
        public void Read()
        {
            _reader.Read();
        }
    }
    
}
