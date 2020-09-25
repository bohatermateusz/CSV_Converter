using Interview;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvMain csv = new CsvMain("s");
            csv.Read();
            csv.Write();
        }
    }
}
