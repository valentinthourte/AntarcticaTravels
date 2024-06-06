using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels.Lindblad
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("response")]
    public class LindbladResponse
    {
        [XmlElement("ships")]
        public LindbladShips Ships { get; set; }

        [XmlElement("vacationoffer")]
        public List<LindbladVacationOffer> VacationOffers { get; set; }
    } 

    public class LindbladSpecialOffers
    {
        [XmlElement("specialoffer")]
        public List<LindbladSpecialOffer> SpecialOfferList { get; set; }
    }

    public class LindbladSpecialOffer
    {
        [XmlElement("title")]
        public LindbladCDataElement Title { get; set; }

        [XmlElement("description")]
        public LindbladCDataElement Description { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }
    }

    public class LindbladCDataElement
    {
        [XmlText]
        public string Value { get; set; }
    }

}
