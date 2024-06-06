using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladItineraryDays
    {
        [XmlElement("itineraryday")]
        public List<LindbladItineraryDay> ItineraryDayList { get; set; }
    }

    public class LindbladItineraryDay
    {
        [XmlElement("daynumber")]
        public LindbladCDataElement DayNumber { get; set; }

        [XmlElement("location")]
        public LindbladCDataElement Location { get; set; }

        [XmlElement("caption")]
        public LindbladCDataElement Caption { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("portcode")]
        public LindbladCDataElement PortCode { get; set; }

        [XmlElement("portname")]
        public LindbladCDataElement PortName { get; set; }
    }
}
