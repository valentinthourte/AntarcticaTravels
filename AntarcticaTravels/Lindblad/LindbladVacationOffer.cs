using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladVacationOffer
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("title")]
        public LindbladCDataElement Title { get; set; }

        [XmlElement("numberofnights")]
        public int NumberOfNights { get; set; }

        [XmlElement("packageid")]
        public string PackageId { get; set; }

        [XmlElement("uniquepackageid")]
        public string UniquePackageId { get; set; }

        [XmlElement("shipname")]
        public LindbladCDataElement ShipName { get; set; }

        [XmlElement("regions")]
        public LindbladRegions Regions { get; set; }

        [XmlElement("departures")]
        public LindbladDepartures Departures { get; set; }

        [XmlElement("itinerarydays")]
        public LindbladItineraryDays ItineraryDays { get; set; }

        [XmlElement("specialoffers")]
        public LindbladSpecialOffers SpecialOffers { get; set; }

        [XmlElement("whatsincluded")]
        public LindbladCDataElement WhatsIncluded { get; set; }
    }
}
