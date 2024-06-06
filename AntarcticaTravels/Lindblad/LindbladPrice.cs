using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladPrices
    {
        [XmlElement("price")]
        public List<LindbladPrice> PriceList { get; set; }
    }

    public class LindbladPrice
    {
        [XmlElement("category")]
        public LindbladCDataElement Category { get; set; }

        [XmlElement("double")]
        public double Double { get; set; }

        [XmlElement("doubleDiscount")]
        public double DoubleDiscount { get; set; }

        [XmlElement("solo")]
        public double Solo { get; set; }

        [XmlElement("soloDiscount")]
        public double SoloDiscount { get; set; }
    }
}
