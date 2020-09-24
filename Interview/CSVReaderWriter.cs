using System;
using System.Collections.Generic;
using System.IO;

namespace Interview
{
    public class CsvReaderWriter
    {
        private StreamReader _readerStream;
        private StreamWriter _writerStream;

        [Flags]
        public enum Mode { Read = 1, Write = 2 }

        public void Open(string fileName, Mode mode)
        {
            switch (mode)
            {
                case Mode.Read:
                    _readerStream = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    break;
                case Mode.Write:
                {
                    var fileInfo = new FileInfo(fileName);
                    _writerStream = new StreamWriter(fileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) {AutoFlush = true};
                    break;
                }
                default:
                    throw new Exception("Unknown file mode for " + fileName);
            }
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

        public bool Read()
        {
            const char separator = '\t';

            var line = ReadLine();
            var columns = GetColumns(line, separator);

            if (columns.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void WriteLine(string line)
        {
            _writerStream.WriteLine(line);
        }

        private string ReadLine()
        {
            return _readerStream.ReadLine();
        }
        private static string[] GetColumns(string line, char separator)
        {
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
