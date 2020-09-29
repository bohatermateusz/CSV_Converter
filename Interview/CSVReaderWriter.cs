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
        internal void Write(params string[] columns)
        {
            _writer.Write(columns);
        }
        internal (bool, string[]) Read()
        {
            return _reader.Read();
        }
    }
    
}
