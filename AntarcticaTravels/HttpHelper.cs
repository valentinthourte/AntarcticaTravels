using Newtonsoft.Json;
using System.ComponentModel;
using System.DirectoryServices;
using System.Security.Policy;
using System.Xml.Serialization;

namespace AntarcticaTravels
{
    internal class HttpHelper
    {
        //internal static async Task<List<Voyage>> GetVoyagesFromURL(string text)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        try
        //        {
        //            HttpResponseMessage response = await http.GetAsync(text);
        //            return response.Content.;
        //        }
        //        catch
        //        {
        //            throw;
        //        }
        //    }
        //}

        internal static async Task<string> GetJsonFromRequest(string url)
        {
            using (HttpClient http = new HttpClient ())
            {
                HttpResponseMessage response = await http.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }

        internal static async Task<List<Voyage>> GetPoseidonVoyages(Dictionary<string, string> URLs)
        {
            string POSEIDON_URL = URLs.Values.ElementAt(0);
            List<Voyage> voyageReturnList = new();

            using (HttpClient http = new HttpClient ())
            {
                HttpResponseMessage response = await http.GetAsync(POSEIDON_URL);
                string xml = await response.Content.ReadAsStringAsync();
                CruiseList cruiseList;

                using (TextReader reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CruiseList));
                    cruiseList = (CruiseList)serializer.Deserialize(reader);
                    foreach (Cruise cruise in cruiseList.Cruise)
                    {
                        List<VesselCabin> cabins = cruise.Prices.CabinList.Select(c => (VesselCabin)c).ToList();
                        if (cabins.Count > 0)
                        {
                            Vessel vessel = new Vessel(cruise.ShipName, cabins);
                            Voyage voyage = new Voyage(cruise.Name, DateTime.ParseExact(cruise.StartDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact(cruise.EndDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), cruise.Embarcation, cruise.Disembarkation, vessel);
                            voyageReturnList.Add(voyage);
                        }
                    }
                }
            }
            return voyageReturnList;
        }


        internal static async Task<List<Voyage>> GetOceanwideVoyages(Dictionary<string, string> URLs)
        {
            string OCEANWIDE_URL = URLs.Values.ElementAt(0);
            List<Voyage> voyageReturnList = new();

            using (HttpClient http = new HttpClient ()) 
            {
                HttpResponseMessage response = await http.GetAsync(OCEANWIDE_URL);
                string json = await response.Content.ReadAsStringAsync();
                OceanwideTrip trips = JsonConvert.DeserializeObject<OceanwideTrip>(json) ?? new();

                foreach (OceanwideTripDetails trip in trips.Trips)
                {
                    List<VesselCabin> cabins = trip.Cabins.Select(c => (VesselCabin)c).ToList();
                    Vessel vessel = new Vessel(trip.Ship, cabins);
                    Voyage voyage = new Voyage(trip.Name, trip.DepartureDate, trip.ReturnDate, trip.Embark, trip.Disembark, vessel);
                    voyageReturnList.Add(voyage);
                }
            }
            return voyageReturnList;
        }

        internal static async Task<List<Voyage>> GetQuarkVoyages(Dictionary<string, string> URLs)
        {

            string ITINERARY_URL = URLs.Values.ElementAt(0);
            string DEPARTURE_URL = URLs.Values.ElementAt(1);
            List<Voyage> voyageReturnList = new();

            HttpClient itineraryClient = new HttpClient();
            HttpClient departureClient = new HttpClient();
            HttpClient departureDetailClient = new HttpClient();



            HttpResponseMessage departureResponse = await departureClient.GetAsync(DEPARTURE_URL);
            HttpResponseMessage itineraryResponse = await itineraryClient.GetAsync(ITINERARY_URL);

            var itResponse = await itineraryResponse.Content.ReadAsStringAsync();
            var deResponse = await departureResponse.Content.ReadAsStringAsync();

            Dictionary<string, QuarkItinerary> itineraries = JsonConvert.DeserializeObject<Dictionary<string, QuarkItinerary>>(itResponse);
            Dictionary<string, QuarkDeparture> departureList = JsonConvert.DeserializeObject<Dictionary<string, QuarkDeparture>>(deResponse);

            foreach (QuarkItinerary it in itineraries.Values)
            {
                int itineraryId = it.Id;
                List<QuarkDeparture> itineraryDepartures = departureList.Values.Where(d => d.ItineraryId == itineraryId).ToList();
                foreach (QuarkDeparture de in itineraryDepartures)
                {
                    HttpResponseMessage departureDetailResponse = await departureDetailClient.GetAsync($"{DEPARTURE_URL}/{de.Id}");
                    if (departureDetailResponse.IsSuccessStatusCode)
                    {
                        try
                        {

                            QuarkDetailedDeparture detailedDeparture = JsonConvert.DeserializeObject<QuarkDetailedDeparture>(await departureDetailResponse.Content.ReadAsStringAsync());
                            List<VesselCabin> cabins = VoyageHelper.GetCabinsFromDetailedDeparture(detailedDeparture);
                            Vessel vessel = new Vessel(de.ShipName, cabins);
                            Voyage voyage = new Voyage(it.ExpeditionName, detailedDeparture.StartDate, detailedDeparture.EndDate, it.Embarkation, it.Disembarkation, vessel);
                            voyageReturnList.Add(voyage);
                            Console.WriteLine(voyage);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }
            
            return voyageReturnList;
        }

    }

}