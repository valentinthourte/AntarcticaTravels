using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    public class Expedition
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
    }
    public class ExpeditionsResponse
    {
        public Dictionary<string, Expedition> Expeditions { get; set; }
    }

}
