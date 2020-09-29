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


        public (bool, string[]) ReadValueTuple()
        {
            const char separator = '\t';
            var line = ReadLine();
            var columns = GetColumns(separator, line);
            var flag = line != null && columns.Length != 0;

            return (flag, columns);
        }

        public bool Read()
        {


            const char separator = '\t';

            var line = ReadLine();

            if (line == null) return false;
            var columns = GetColumns(separator, line);

            if (columns.Length == 0)
            {
                return false;
            }

            return true;

        }



        //public bool Read(out string column1, out string column2)
        //{
        //    const int firstColumn = 0;
        //    const int secondColumn = 1;

        //    const char separator = '\t';

        //    var line = ReadLine();

        //    if (line == null)
        //    {
        //        column1 = null;
        //        column2 = null;

        //        return false;
        //    }

        //    var columns = GetColumns(line, separator);

        //    if (columns.Length == 0)
        //    {
        //        column1 = null;
        //        column2 = null;

        //        return false;
        //    }

        //    column1 = columns[firstColumn];
        //    column2 = columns[secondColumn];

        //    return true;
        //}


        private string ReadLine()
        {
            return _readerStream.ReadLine();
        }
        private static string[] GetColumns(char separator, string line = "")
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
