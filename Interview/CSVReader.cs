﻿using System.Collections.Generic;
using System.IO;
using Interview.Interfaces;

namespace Interview
{
    public class CsvReader : IReader
    {
        private readonly StreamReader _readerStream;

        public CsvReader(StreamReader readerStream)
        {
            _readerStream = readerStream;
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
