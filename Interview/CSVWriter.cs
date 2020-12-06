using System.IO;
using InterfacesHub;

namespace Interview
{
    internal class CsvWriter : IWriter
    {
        private readonly StreamWriter _writerStream;

        internal CsvWriter(StreamWriter writerStream)
        {
            _writerStream = writerStream;
        }

        public void Write(params string[] columns)
        {
            var outPut = "";

            for (var i = 0; i < columns.Length; i++)
            {
                outPut += columns[i];
                if (columns.Length - 1 != i)
                {
                    outPut += "\t";
                }
            }

            WriteLine(outPut);
        }

        private void WriteLine(string line)
        {
            _writerStream.WriteLine(line);
        }
    }
}
