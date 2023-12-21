using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    public class VesselCabin
    {
        public string CabinName { get; set; }
        private Price CabinPrice { get; set; }

        public VesselCabin(string cabinName, Price cabinPrice)
        {
            CabinName = cabinName;
            CabinPrice = cabinPrice;
        }
        public bool HasOffer()
        {
            return this.CabinPrice.OfferPrice != -1;
        }
        public double GetCabinPrice()
        {
            return this.CabinPrice.OfferPrice != -1 ? this.CabinPrice.OfferPrice : this.CabinPrice.StartPrice;
        }
        public double GetOriginalPrice()
        {
            return this.CabinPrice.StartPrice;
        }
        internal void SetOfferPrice(double cabinOfferPrice)
        {
            this.CabinPrice.SetOfferPrice(cabinOfferPrice);
        }
    }
}
