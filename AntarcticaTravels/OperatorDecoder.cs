namespace AntarcticaTravels
{
    internal interface OperatorDecoder
    {
        internal Operator GetOperatorFromCsvLine(string line);
    }

    internal class CsvOperatorDecoder : OperatorDecoder
    {
        Operator OperatorDecoder.GetOperatorFromCsvLine(string line)
        {
            var opFields = line.Split(",");
            var Name = opFields[0];
            var StartDateIndex = int.Parse(opFields[1]);
            var EndDateIndex = int.Parse(opFields[2]);
            var VoyageIndex = int.Parse(opFields[3]);
            var EmbarkationIndex = int.Parse(opFields[4]);
            var DisembarkationIndex = int.Parse(opFields[5]);
            var VesselIndex = int.Parse(opFields[6]);
            var StartCabinIndex = int.Parse(opFields[7]);
            return new CsvOperator(Name, StartDateIndex, EndDateIndex, VoyageIndex, EmbarkationIndex, DisembarkationIndex, VesselIndex, StartCabinIndex);
        }
    }
    internal class ApiOperatorDecoder : OperatorDecoder
    {
        Operator OperatorDecoder.GetOperatorFromCsvLine(string line)
        {
            var opFields = line.Split(",");
            var Name = opFields[0];
            Dictionary<string, string> urlList = new ();
            for (int i = 1; i < opFields.Length - 1; i++)
            {
                string key = opFields[i];
                i++;
                string value = opFields[i];
                urlList[key] = value;
            }    
            return new ApiOperator(Name, urlList);
        }
    }

}