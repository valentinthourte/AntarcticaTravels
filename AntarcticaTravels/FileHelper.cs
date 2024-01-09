using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    internal static class FileHelper
    {
        public static List<Voyage> GetVoyagesFromCSV(string path, CsvOperator op)
        {
            List<Voyage> voyages = new List<Voyage>();
            var lines = File.ReadAllLines(path);
            var headers = lines[0].Split(";");

            Voyage voyage = null;


            foreach (string line in lines.Skip(1))
            {
                var fields = line.Split(";");
                if (fields[1] != "")
                {
                    voyage = VoyageHelper.GetVoyageFromCSVFields(fields, headers, op);
                }
                else
                {
                    voyage = VoyageHelper.UpdateVoyageCabinOffers(voyage, fields, headers, op);
                    voyages.Add(voyage);
                }
            }

            //lines.Skip(1).ToList().ForEach(line =>
            //{
            //    var fields = line.Split(",");
            //    if (fields[1] != "")
            //    {
            //        voyage = VoyageHelper.GetVoyageFromCSVFields(fields, headers, op);
            //    }
            //    else
            //    {
            //        voyage = VoyageHelper.UpdateVoyageCabinOffers(voyage, fields, headers, op);
            //        voyages.Add(voyage);
            //    }
            //});
            return voyages;
        }

        internal static string WriteCSVForWebPage(List<Voyage> voyages, string operatorName)
        {
            var csv = new StringBuilder();
            var headers = GetHeadersForWebpageCSV();
            csv.AppendLine(headers);
            voyages.ForEach(voyage =>
            {
                csv = InsertVoyageToStringBuilder(voyage, csv);
            });
            //string filePath = $"{Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.Date.ToString())}.csv";
            string filePath = $"{Path.Combine(Directory.GetCurrentDirectory(), operatorName)}_voyages.csv";

            File.WriteAllText(filePath, csv.ToString());

            return Path.GetDirectoryName(filePath);
        }

        private static string GetHeadersForWebpageCSV()
        {
            return $"TOUR,START DATE,END DATE,STARTING FROM,ENDING IN,VESSEL,CABIN,PRICE,OFFER";
        }

        private static StringBuilder InsertVoyageToStringBuilder(Voyage voyage, StringBuilder csv)
        {
            try
            {
                var firstCabin = voyage.GetCabins().First();
                var first = $"{voyage.VoyageName};{voyage.StartDate.ToString("d/M/yyyy")};{voyage.EndDate.ToString("d/M/yyyy")};" +
                            $"{voyage.Embarkation};{voyage.Disembarkation};{voyage.GetVesselName()};{firstCabin.CabinName};" +
                            $"{firstCabin.GetOriginalPrice()};{(firstCabin.HasOffer() ? firstCabin.GetCabinPrice() : "")}";
                csv.AppendLine(FileHelper.SanitizeCsvLine(first));
                voyage.GetCabins().Skip(1).ToList().ForEach(cabin =>
                {
                    var line = $",,,,,," +
                                $"{SanitizeCsvLine(cabin.CabinName)},{cabin.GetOriginalPrice()},{(cabin.HasOffer() ? cabin.GetCabinPrice() : "")}";
                    csv.AppendLine(line);
                });
                return csv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        
        private static string SanitizeCsvLine(string line)
        {
            return line.Replace(',', '@').Replace(';', ',');
        }
    }
}
