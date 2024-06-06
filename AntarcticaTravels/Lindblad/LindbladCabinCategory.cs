using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladCabinCategories
    {
        [XmlElement("cabincategory")]
        public List<LindbladCabinCategory> CabinCategoryList { get; set; }
    }

    public class LindbladCabinCategory
    {
        [XmlElement("code")]
        public string Code { get; set; }

        [XmlElement("description")]
        public LindbladCDataElement Description { get; set; }
    }
}
