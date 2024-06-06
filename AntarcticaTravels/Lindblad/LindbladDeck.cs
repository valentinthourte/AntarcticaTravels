using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladDeckPlan
    {
        [XmlElement("deck")]
        public List<LindbladDeck> Decks { get; set; }
    }

    public class LindbladDeck
    {
        [XmlElement("order")]
        public LindbladCDataElement Order { get; set; }

        [XmlElement("name")]
        public LindbladCDataElement Name { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("categories")]
        public LindbladCategories Categories { get; set; }
    }
}
