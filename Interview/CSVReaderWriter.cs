using InterfacesHub;

namespace Interview
{
    internal class CsvReaderWriter
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        internal CsvReaderWriter(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }
        internal void Write()
        {
            _writer.Write();
        }
        internal void Read()
        {
            _reader.Read();
        }
    }
    
}
