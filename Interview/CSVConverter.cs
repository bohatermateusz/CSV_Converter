using System.IO;

namespace Interview
{
    public class CsvMain
    {
        private readonly CsvReaderWriter _instance;
        
        public CsvMain(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            var writerStream = new StreamWriter(fileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) { AutoFlush = true };
            var readerStream = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            _instance = new CsvReaderWriter(new CsvReader(readerStream), new CsvWriter(writerStream));
        }
        public void Write()
        {
           _instance.Write();
        }
        public bool Read()
        {
            return _instance.Read();
        }
    }
}
