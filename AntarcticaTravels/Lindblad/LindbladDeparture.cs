using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladDepartures
    {
        [XmlElement("departure")]
        public List<LindbladDeparture> DepartureList { get; set; }
    }

    public class LindbladDeparture
    {
        [XmlElement("voyage")]
        public string Voyage { get; set; }

        [XmlElement("lexid")]
        public string LexId { get; set; }

        [XmlElement("startdate")]
        public string StartDate { get; set; }

        [XmlElement("enddate")]
        public string EndDate { get; set; }

        [XmlElement("shipcode")]
        public string ShipCode { get; set; }

        [XmlElement("shipname")]
        public string ShipName { get; set; }

        [XmlElement("departureGUID")]
        public string DepartureGUID { get; set; }

        [XmlElement("availability")]
        public string Availability { get; set; }

        [XmlElement("isreverse")]
        public string IsReverse { get; set; }

        [XmlElement("prices")]
        public LindbladPrices Prices { get; set; }

        [XmlElement("cabincategories")]
        public LindbladCabinCategories CabinCategories { get; set; }

        [XmlElement("extensions")]
        public LindbladExtensions Extensions { get; set; }

        [XmlElement("bookingcode")]
        public LindbladCDataElement BookingCode { get; set; }


        public DateTime ParsedStartDate
        {
            get
            {
                // Define the date format expected in the XML
                string dateFormat = "yyyy/MM/dd";

                // Attempt to parse the date string into a DateTime object
                if (DateTime.TryParseExact(StartDate, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate; // Return the parsed DateTime value
                }
                else
                {
                    throw new FormatException("Invalid date format"); // Or handle the error accordingly
                }
            }
        }
        public DateTime ParsedEndDate
        {
            get
            {
                // Define the date format expected in the XML
                string dateFormat = "yyyy/MM/dd";

                // Attempt to parse the date string into a DateTime object
                if (DateTime.TryParseExact(EndDate, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate; // Return the parsed DateTime value
                }
                else
                {
                    throw new FormatException("Invalid date format"); // Or handle the error accordingly
                }
            }
        }
    }
}
