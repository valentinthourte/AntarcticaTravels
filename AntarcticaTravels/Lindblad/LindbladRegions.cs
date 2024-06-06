using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladRegions
    {
        [XmlElement("region")]
        public List<string> RegionList { get; set; }
    }
}
