using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels.Atlas
{
    public class AtlasCruiseDetail
    {
        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("ship")]
        public Ship Ship { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("externalCode")]
        public object ExternalCode { get; set; }

        [JsonProperty("name")]
        public CruiseName Name { get; set; }

        [JsonProperty("nights")]
        public int Nights { get; set; }

        [JsonProperty("seaDays")]
        public int SeaDays { get; set; }

        [JsonProperty("descriptions")]
        public object Descriptions { get; set; }

        [JsonProperty("images")]
        public List<object> Images { get; set; }

        [JsonProperty("map")]
        public object Map { get; set; }

        [JsonProperty("itinerary")]
        public List<AtlasItinerary> Itinerary { get; set; }

        [JsonProperty("sailings")]
        public List<AtlasSailing> Sailings { get; set; }

        internal Voyage ToVoyage(Vessel vessel)
        {
            DateTime startDate = this.Sailings.First().Date;
            DateTime endDate = startDate.AddDays(this.Nights);
            Voyage voyage = new Voyage(this.Name.EnUs, startDate, endDate, this.Itinerary.First().Port.Name.EnUs, this.Itinerary.Last().Port.Name.EnUs, vessel);

            return voyage;
        }
    }

    public class AtlasSailing
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
    }

    public class Port
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public PortName Name { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("tenderRequired")]
        public bool TenderRequired { get; set; }

        [JsonProperty("images")]
        public List<object> Images { get; set; }
    }

    public class PortName
    {
        [JsonProperty("en-us")]
        public string EnUs { get; set; }
    }

    public class Description
    {
        [JsonProperty("en-us")]
        public string EnUs { get; set; }
    }

    public class AtlasItinerary
    {
        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("port")]
        public Port Port { get; set; }

        [JsonProperty("arriveTime")]
        public string ArriveTime { get; set; }

        [JsonProperty("departTime")]
        public string DepartTime { get; set; }

        [JsonProperty("extraInformation")]
        public object ExtraInformation { get; set; }
    }

    public class Brand
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Ship
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CruiseName
    {
        [JsonProperty("en-us")]
        public string EnUs { get; set; }
    }

}
