using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladExtensions
    {
        [XmlElement("extension")]
        public List<LindbladExtension> ExtensionList { get; set; }
    }

    public class LindbladExtension
    {
        [XmlElement("extdepartureid")]
        public string ExtDepartureId { get; set; }

        [XmlElement("code")]
        public LindbladCDataElement Code { get; set; }

        [XmlElement("name")]
        public LindbladCDataElement Name { get; set; }

        [XmlElement("flag")]
        public string Flag { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("duration")]
        public int Duration { get; set; }

        [XmlElement("price")]
        public LindbladExtensionPrice Price { get; set; }
    }
    public class LindbladExtensionPrice
    {
        [XmlElement("double")]
        public double Double { get; set; }

        [XmlElement("solo")]
        public double Solo { get; set; }
    }
}
