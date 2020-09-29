using System.Collections.Generic;
using System.IO;
using InterfacesHub;

namespace Interview
{
    internal class CsvReader : IReader
    {
        private readonly StreamReader _readerStream;

        internal CsvReader(StreamReader readerStream)
        {
            _readerStream = readerStream;
        }
        public (bool, string[]) Read()
        {
            const char separator = '\t';
            var line = ReadLine();
            var columns = GetColumns(separator, line);
            var readColumn = line != null && columns.Length != 0;

            return (readColumn, columns);
        }

        private string ReadLine()
        {
            return _readerStream.ReadLine();
        }
        private static string[] GetColumns(char separator, string line)
        {
            line ??= "";
            var columns = new List<string>();
            int index;
            while ((index = line.IndexOf(separator)) > 0)
            {
                var column = line.Substring(0, index);
                line = line.Substring(index + 1);
                columns.Add(column);
            }
            columns.Add(line);
            return columns.ToArray();
        }
    }
}
