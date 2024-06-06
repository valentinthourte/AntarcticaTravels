using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladCategories
    {
        [XmlElement("category")]
        public List<LindbladCategory> CategoryList { get; set; }
    }

    public class LindbladCategory
    {
        [XmlElement("code")]
        public LindbladCDataElement Code { get; set; }

        [XmlElement("description")]
        public LindbladCDataElement Description { get; set; }
    }
}
