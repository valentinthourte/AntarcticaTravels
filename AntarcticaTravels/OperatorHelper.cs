namespace AntarcticaTravels
{
    internal static class OperatorHelper
    {
        private const string CSV_OPERATORS_FILE_PATH = "CSV_operators.csv";
        private const string API_OPERATORS_FILE_PATH = "API_operators.csv";

        internal static List<Operator> GetOperatorsFromCsv(string path, OperatorDecoder op)
        {
            var lines = File.ReadAllLines(path);
            var headers = lines[0].Split(",");
            List<Operator> operators = new List<Operator>();
            foreach (var line in lines.Skip(1))
            {
                operators.Add(op.GetOperatorFromCsvLine(line));
            }
            return operators;
        }

        internal static List<Operator> GetCSVOperators()
        {
            return GetOperatorsFromCsv(CSV_OPERATORS_FILE_PATH, new CsvOperatorDecoder());
        }

        internal static void AddOperator(Operator op)
        {
            string line = op.ToString();
            string fileName = CSV_OPERATORS_FILE_PATH;
            AppendLineToCSV(fileName, line);
        }
        static void AppendLineToCSV(string fileName, string lineToWrite)
        {
            // Open the file in append mode and create a StreamWriter
            using (StreamWriter streamWriter = new StreamWriter(fileName, true))
            {
                // Append the line to the CSV file
                streamWriter.WriteLine(lineToWrite);
            }
        }

        internal static List<Operator> GetAPIOperators()
        {
            return GetOperatorsFromCsv(API_OPERATORS_FILE_PATH, new ApiOperatorDecoder());
        }
    }
}