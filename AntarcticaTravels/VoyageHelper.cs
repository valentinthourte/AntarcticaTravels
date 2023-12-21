using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    internal static class VoyageHelper
    {
        public static Voyage GetVoyageFromCSVFields(string[] fields, string[] headers, CsvOperator op)
        {
            string format = "dd/MM/yyyy";
            var departureDate = DateTime.ParseExact(fields[op.StartDateIndex], format, CultureInfo.InvariantCulture);
            var arrivalDate = DateTime.ParseExact(fields[op.EndDateIndex], format, CultureInfo.InvariantCulture);
            var embarkLocation = fields[op.EmbarkationIndex];
            var disembarkLocation = fields[op.DisembarkationIndex];
            var voyageName = fields[op.VoyageIndex];

            var vessel = GetUpdatedVessel(fields, headers, op);
          
            Voyage voyage = new Voyage(voyageName,departureDate,arrivalDate, embarkLocation, disembarkLocation, vessel);

            return voyage;
        }

        internal static Voyage UpdateVoyageCabinOffers(Voyage? voyage, string[] fields, string[] headers, CsvOperator op)
        {
            var i = op.StartCabinIndex;
            while (i < fields.Length)
            {
                string cabinName = headers[i];
                if (!string.IsNullOrEmpty(cabinName)) {

                    var field = SanitizePriceField(fields[i]);
                    double cabinOfferPrice = 0;
                    double.TryParse(field, out cabinOfferPrice);
                    try
                    {
                        voyage.VoyageVessel.Cabins.Find(cabin => cabin.CabinName == cabinName).SetOfferPrice(cabinOfferPrice);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine($"Key not found: {ex.Message}");
                    }
                }
                i++;
            }
            return voyage;
        }

        private static Vessel GetUpdatedVessel(string[] fields, string[] headers, CsvOperator op)
        {
            string vesselName = fields[op.VesselIndex];
            var vessel = new Vessel(vesselName);//VesselHelper.GetVesselByName(vesselName);
            return SetCabinsForVessel(vessel, fields, headers, op.StartCabinIndex);
        }

        private static Vessel SetCabinsForVessel(Vessel vessel, string[] fields, string[] headers, int startCabinIndex)
        {
            var i = startCabinIndex;
            List<VesselCabin> returnCabins = new List<VesselCabin>();
            while (i < fields.Length)
            {
                string cabinName = headers[i];
                var field = SanitizePriceField(fields[i]);
                double cabinPrice = 0;
                double.TryParse(field, out cabinPrice);

                Price price = new Price(cabinPrice);
                try
                {
                    returnCabins.Add(new VesselCabin(cabinName, price));
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine($"Key not found: {ex.Message}");
                }
                i++;
            }
            vessel.SetCabins(returnCabins);
            return vessel;
        }

        private static string SanitizePriceField(string field)
        {
            field = field.Replace('"', char.Parse(" ")).Trim();
            field = field.Replace("\\", "");
            field = field.Replace("$", "");
            field = field.Replace(".", "");
            return field;
        }
        
        public static List<Voyage> GetAllVoyages()
        {
            //Operator op = OperatorHelper.GetOperators().First();
            //string path = "D:\\Repos\\AntarcticaTravels\\AntarcticaTravels\\AntarcticaTravels\\Poseidon.csv";
            //var voyages = FileHelper.GetVoyagesFromCSV(path, op);
            //return voyages;
            return new List<Voyage>();
        }

        internal static List<Vessel> GetVesselsFromVoyages(List<Voyage> voyageList)
        {
            return voyageList.DistinctBy(voyage => voyage.GetVesselName()).Select(voyage => voyage.VoyageVessel).ToList();
        }

        internal static List<VesselCabin> GetCabinsFromDetailedDeparture(QuarkDetailedDeparture? detailedDeparture)
        {
            List<VesselCabin> returnCabins = new();
            if (detailedDeparture.ShipName == "World Explorer")
            {
                Console.WriteLine("World explorer");
            }
            foreach (QuarkDepartureCabin cabin in detailedDeparture.Cabins.Values)
            {
                QuarkOccupancy oc = cabin.Occupancies.Where(o => o.OccupancyCode == "AA").FirstOrDefault() ?? cabin.Occupancies[0];
                VesselCabin returnCabin = new VesselCabin(cabin.CabinName, new Price(oc.PricePerPerson, oc.StartingFromTotalPricePerPerson));
                returnCabins.Add(returnCabin);
            }
            return returnCabins;
        }

        internal static List<VesselCabin> GetCabinsFromOceanwideCabins(List<OceanwideCabin> cabins)
        {
            throw new NotImplementedException();
        }
    }
}
