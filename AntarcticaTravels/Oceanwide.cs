using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class OceanwideCabin
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("old_price")]
        public int OldPrice { get; set; }

        public static explicit operator VesselCabin(OceanwideCabin cabin)
        {
            return new VesselCabin(cabin.Title, new Price(cabin.OldPrice, cabin.Price));
        }


    }
    public class OceanwideTrip
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("trips")]
        public List<OceanwideTripDetails> Trips { get; set; }
    }

    public class OceanwideTripDetails
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("translated")]
        public bool Translated { get; set; }

        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }

        [JsonProperty("return_date")]
        public DateTime ReturnDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("please_note")]
        public string? PleaseNote { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("embark")]
        public string Embark { get; set; }

        [JsonProperty("disembark")]
        public string Disembark { get; set; }

        [JsonProperty("cabins")]
        public List<OceanwideCabin> Cabins { get; set; }


        [JsonProperty("ship")]
        public string Ship { get; set; }

        [JsonProperty("ship_id")]
        public int ShipId { get; set; }
    }

}
