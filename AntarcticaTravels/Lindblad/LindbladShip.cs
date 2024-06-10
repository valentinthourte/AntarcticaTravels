using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntarcticaTravels.Lindblad
{
    public class LindbladShips
    {
        [XmlElement("ship")]
        public List<LindbladShip> ShipList { get; set; }
    }

    public class LindbladShip
    {
        [XmlElement("code")]
        public LindbladCDataElement Code { get; set; }

        [XmlElement("name")]
        public LindbladCDataElement Name { get; set; }

        [XmlElement("deckplan")]
        public LindbladDeckPlan DeckPlan { get; set; }

        internal Vessel ToVessel(List<LindbladPrice> priceList)
        {
            List<VesselCabin> cabins = new List<VesselCabin>();
            foreach (LindbladPrice price in priceList)
            {
                string cabinName = price.Category.Value;
                Price cabinPrice = cabinName.Contains("S") ? (price.SoloDiscount == 0 ? new Price(price.Solo) : new Price(price.Solo, price.Solo - price.SoloDiscount)) : (price.DoubleDiscount == 0 ? new Price(price.Double) : new Price(price.Double, price.Double - price.DoubleDiscount));
                VesselCabin cabin = new VesselCabin($"CATEGORY {cabinName}", cabinPrice);
                cabins.Add(cabin);
            }

            return new Vessel(this.Name.Value, cabins);
        }
    }
}
