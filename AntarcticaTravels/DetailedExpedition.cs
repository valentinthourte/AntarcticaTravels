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

    public class DetailedExpedition
    {
        public int Id { get; set; }
        public DateTime Modified { get; set; }
        public string ExpeditionName { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string RegionId { get; set; }
        public string Region { get; set; }
        public List<string> Destinations { get; set; }
        public List<string> Highlights { get; set; }
        public HeroImage HeroImage { get; set; }
        public Dictionary<string, ExpeditionImage> Images { get; set; }
        public Dictionary<string, QuarkItinerary> Itineraries { get; set; }
        public Dictionary<string, QuarkDeparture> Departures { get; set; }
    }

    public class HeroImage
    {
        public string MediaType { get; set; }
        public string FullsizeUrl { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
        public Dimensions Dimensions { get; set; }
    }

    public class ExpeditionImage
    {
        public string MediaType { get; set; }
        public string FullsizeUrl { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
        public Dimensions Dimensions { get; set; }
        public string ThumbnailUrl { get; set; }
    }

    public class Dimensions
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }





}
