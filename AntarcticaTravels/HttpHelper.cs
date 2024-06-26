﻿using AntarcticaTravels.Atlas;
using AntarcticaTravels.Lindblad;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.DirectoryServices;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Xml.Serialization;

namespace AntarcticaTravels
{
    internal class HttpHelper
    {
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

            string ITINERARY_URL = URLs["ItineraryURL"];
            string DEPARTURE_URL = URLs["DepartureURL"];
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

        internal static async Task<List<Voyage>> GetAtlasVoyages(Dictionary<string, string> URLs)
        {
            string CRUISE_LIST_URL = URLs["CruiseListURL"];
            string MARKET_PRICING_URL = URLs["MarketPricingURL"];
            string SHIPS_URL = URLs["ShipsURL"];
            string TOKEN_URL = URLs["TokenURL"];

            string token = await GetAtlasToken(TOKEN_URL);
            List<Voyage> voyageList = new List<Voyage>();
            List<string> failedVoyages = new List<string>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            

            HttpResponseMessage marketPricingResponse = await client.GetAsync(MARKET_PRICING_URL);
            HttpResponseMessage cruiseListResponse = await client.GetAsync(CRUISE_LIST_URL);
            string responseString = await cruiseListResponse.Content.ReadAsStringAsync();

            var sailingsWithoutPricing = new List<string>();
            if (cruiseListResponse.IsSuccessStatusCode && marketPricingResponse.IsSuccessStatusCode)
            {
                List<AtlasMarketPricing> marketPricingList = JsonConvert.DeserializeObject<List<AtlasMarketPricing>>(await marketPricingResponse.Content.ReadAsStringAsync());
                AtlasCruiseList cruiseList = JsonConvert.DeserializeObject<AtlasCruiseList>(await cruiseListResponse.Content.ReadAsStringAsync());
                if (cruiseList is not null && cruiseList.Cruises.Any())
                {
                    foreach (AtlasCruiseHeader cruise in cruiseList.Cruises)
                    {
                        try
                        {
                            HttpResponseMessage cruiseDetailResponse = await client.GetAsync($"{CRUISE_LIST_URL}{cruise.Code}/");
                            string cruiseDetailResponseString = await cruiseDetailResponse.Content.ReadAsStringAsync();
                            AtlasCruiseDetail? cruiseDetail = JsonConvert.DeserializeObject<AtlasCruiseDetail>(cruiseDetailResponseString);
                            HttpResponseMessage shipDetailResponse = await client.GetAsync($"{SHIPS_URL}/{cruiseDetail.Ship.Code}/");
                            AtlasShip? ship = JsonConvert.DeserializeObject<AtlasShip>(await shipDetailResponse.Content.ReadAsStringAsync());
                            foreach (AtlasSailing sailing in cruiseDetail.Sailings)
                            {
                                AtlasMarketPricing marketPricing = marketPricingList.Where(m => m.sailing == sailing.Code).FirstOrDefault();
                                if (marketPricing is not null)
                                {
                                    Vessel vessel = ship.ToVessel(marketPricing);
                                    Voyage voyage = cruiseDetail.ToVoyage(vessel, sailing);
                                    if (ship.name == "World Navigator" && voyage.VoyageName.Contains("11-Night Reykjavik to Oslo"))
                                    {
                                        Console.WriteLine("11-Night Reykjavik to Oslo");
                                    }    
                                    voyageList.Add(voyage);
                                }
                                else
                                {
                                    Console.WriteLine($"MarketPricing is null for sailing {sailing.Code}");
                                    sailingsWithoutPricing.Add(sailing.Code);

                                }
                            }
                        }
                        catch (Exception ex) 
                        { 
                            Console.WriteLine(ex.ToString());
                            failedVoyages.Add($"{cruise.Code}: {ex.Message}");
                        }
                    }
                }
            }
            Console.Write(failedVoyages);
            return voyageList;
        }

        private static async Task<string> GetAtlasToken(string TOKEN_URL)
        {
            var requestBody = new
            {
                username = "aov:antarcticatravels",
                password = "qV46x7Rt_aov",
                channel_partner = "1",
                agency = "8697",
                channel = "CS"
            };

            var jsonBody = JsonConvert.SerializeObject(requestBody);

            string token = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(TOKEN_URL, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    dynamic responseData = JsonConvert.DeserializeObject(responseContent);
                    token = responseData.token;
                }
                else
                {
                    throw new Exception("Could not obtain Atlas Token.");
                }
            }
            return token;
        }

        internal static async Task<List<Voyage>> GetLindbladVoyages(Dictionary<string, string> URLs)
        {
            string LINDBLAD_URL = URLs["GeneralURL"];
            List<Voyage> voyages = new List<Voyage>();

            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage response = await http.GetAsync(LINDBLAD_URL);
                string xml = await response.Content.ReadAsStringAsync();
                LindbladResponse lindbladResponse;

                using (TextReader reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(LindbladResponse));
                    try
                    {
                        lindbladResponse = (LindbladResponse)serializer.Deserialize(reader);
                    }
                    catch (Exception ex)
                    {
                        throw; 
                    }
                    List<LindbladShip> ships = lindbladResponse.Ships.ShipList;
                    foreach(LindbladVacationOffer offer in lindbladResponse.VacationOffers)
                    {
                        List<string> validRegions = new List<string>() { "ANTARCTICA", "ARCTIC", "SOUTH AMERICA" };
                        if (offer.Regions.RegionList.Where(r => validRegions.Contains(r)).FirstOrDefault() is not null)
                        {
                            foreach (LindbladDeparture departure in offer.Departures.DepartureList)
                            {
                                LindbladShip voyageShip = ships.Where(s => s.Name.Value == departure.ShipName).FirstOrDefault();
                                if (voyageShip != null)
                                {
                                    Vessel vessel = voyageShip.ToVessel(departure.Prices.PriceList);
                                    Voyage voyage = new Voyage(offer.Title.Value, departure.ParsedStartDate, departure.ParsedEndDate, offer.ItineraryDays.ItineraryDayList.First().PortName.Value, offer.ItineraryDays.ItineraryDayList.Last().PortName.Value, vessel);
                                    voyages.Add(voyage);
                                }
                            }
                        }
                    }
                }
            }
            return voyages;
        }
    }
}