namespace FraudDetection
{
    internal class Program
    {
        private const string INPUT_DATA_FILE = "InputData.txt";

        static void Main(string[] args)
        {
            var fraudDetector = new FraudDetector();
            var inputData = ReadInputFile();
            fraudDetector.LoadData(inputData);
            var fraudulentOrders = fraudDetector.GetFraudulentOrdersIds();
            Console.WriteLine(string.Join(",", fraudulentOrders));
            
            // Adding a readline to see the console output.
            Console.ReadLine();
        }

        private static List<string> ReadInputFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), INPUT_DATA_FILE);
            return File.ReadAllLines(path).ToList();
        }
    }
}
