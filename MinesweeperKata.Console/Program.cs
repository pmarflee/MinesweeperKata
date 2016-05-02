using MinesweeperKata.Core;

namespace MinesweeperKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                System.Console.WriteLine("Input not provided");
            }
            else
            {
                var fields = FieldParser.ParseFields(args[0]);
                var output = OutputWriter.Write(fields);

                System.Console.WriteLine(output);
            }
        }
    }
}
