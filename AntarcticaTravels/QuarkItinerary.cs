using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    public class QuarkItinerary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("expedition_id")]
        public int ExpeditionId { get; set; }

        [JsonProperty("expedition_name")]
        public string ExpeditionName { get; set; }

        [JsonProperty("region_id")]
        public string RegionId { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("duration_days")]
        public int DurationDays { get; set; }

        [JsonProperty("start_location")]
        public string StartLocation { get; set; }

        [JsonProperty("end_location")]
        public string EndLocation { get; set; }

        [JsonProperty("embarkation")]
        public string Embarkation { get; set; }

        [JsonProperty("embarkation_port_code")]
        public string EmbarkationPortCode { get; set; }

        [JsonProperty("disembarkation")]
        public string Disembarkation { get; set; }

        [JsonProperty("disembarkation_port_code")]
        public string DisembarkationPortCode { get; set; }

        [JsonProperty("itinerary_map")]
        public List<QuarkItineraryMap> ItineraryMap { get; set; }

        [JsonProperty("itinerary_name")]
        public string ItineraryName { get; set; }
    }

    public class QuarkItineraryMap
    {
        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("fullsize_url")]
        public string FullsizeUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }
    }


    public class QuarkItineraryDay
    {
        public string Title { get; set; }
        public string DayNumber { get; set; }
        public int DayStartNumber { get; set; }
        public int DayEndNumber { get; set; }
        public string Location { get; set; }
        public string PortCode { get; set; }
        public string PortLocation { get; set; }
        public string Description { get; set; }
    }

    public class QuarkItineraryInclusion
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public List<string> Items { get; set; }
    }

    public class QuarkItineraryExclusion
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public List<string> Items { get; set; }
    }

}
