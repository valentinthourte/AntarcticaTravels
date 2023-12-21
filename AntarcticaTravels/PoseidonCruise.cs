using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Cruises")]
    public class CruiseList
    {
        [XmlElement("Cruise")]
        public List<Cruise> Cruise { get; set; }
    }

    public class Cruise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string ShipName { get; set; }
        public string Destination { get; set; }
        public string Embarcation { get; set; }
        public string Disembarkation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Url { get; set; }

        [XmlElement("Notes")]
        public CruiseNotes Notes { get; set; }

        [XmlElement("Highlights")]
        public CruiseHighlights Highlights { get; set; }

        [XmlElement("Days")]
        public CruiseDays Days { get; set; }

        [XmlElement("Prices")]
        public CruisePrices Prices { get; set; }
    }

    public class CruiseNotes
    {
        [XmlElement("Include")]
        public CruiseNoteList Include { get; set; }

        [XmlElement("NotInclude")]
        public CruiseNoteList NotInclude { get; set; }
    }

    public class CruiseNoteList
    {
        [XmlElement("Elem")]
        public List<string> Elem { get; set; }
    }

    public class CruiseHighlights
    {
        [XmlElement("Elem")]
        public string HighlightsText { get; set; }
    }

    public class CruiseDays
    {
        [XmlElement("Day")]
        public List<Day> DayList { get; set; }
    }

    public class Day
    {
        public string Title { get; set; }
        public string Text { get; set; }

        [XmlElement("Images")]
        public DayImages Images { get; set; }
    }

    public class DayImages
    {
        [XmlElement("Image")]
        public List<string> ImageList { get; set; }
    }

    public class CruisePrices
    {
        [XmlElement("Cabin")]
        public List<Cabin> CabinList { get; set; }
    }

    public class Cabin
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static explicit operator VesselCabin(Cabin c)
        {
            return new VesselCabin(c.Name, new Price((double)c.Price));
        }
    }

}
