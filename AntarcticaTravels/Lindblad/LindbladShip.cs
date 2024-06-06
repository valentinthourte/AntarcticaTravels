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
                LindbladDeck deck = this.DeckPlan.Decks.Where(d => d.Categories.CategoryList.Where(c => c.Code.Value == price.Category.Value).FirstOrDefault() != null).FirstOrDefault();
                if (deck != null)
                {
                    Price cabinPrice = price.Double > 0 ? new Price(price.Double, price.DoubleDiscount) : new Price(price.Solo, price.SoloDiscount);
                    VesselCabin cabin = new VesselCabin(deck.Name.Value, cabinPrice);
                    cabins.Add(cabin);
                }

            }
            return new Vessel(this.Name.Value, cabins);
        }
    }
}
