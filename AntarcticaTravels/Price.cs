using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    public class Price
    {
        public double StartPrice { get; set; }
        public double OfferPrice { get; set; } = -1;
        public Price(double price) 
        {
            StartPrice = price;
        }
        public Price(double price, double offerPrice)
        {
            StartPrice = price;
            OfferPrice = offerPrice;
        }

        public void ResetOffer()
        {
            OfferPrice = -1;
        }

        internal void SetOfferPrice(double offerPrice)
        {
            this.OfferPrice = offerPrice;
        }
    }
}
