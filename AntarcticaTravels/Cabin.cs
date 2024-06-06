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
        private Price? CabinPrice { get; set; }

        
        public VesselCabin(string cabinName) 
        {
            this.CabinName = cabinName;
            this.CabinPrice = null;
        }

        public VesselCabin(string cabinName, Price cabinPrice)
        {
            CabinName = cabinName;
            CabinPrice = cabinPrice;
        }

        public bool HasOffer()
        {
            return this.CabinPrice is null ? false : this.CabinPrice.OfferPrice != -1;
        }
        public string GetCabinPrice()
        {
            return this.CabinPrice is null ? "N/A" : (this.CabinPrice.OfferPrice != -1 ? this.CabinPrice.OfferPrice : this.CabinPrice.StartPrice).ToString();
        }
        public string GetOriginalPrice()
        {
            return this.CabinPrice is null ? "N/A" : (this.CabinPrice.StartPrice).ToString();
        }
        internal void SetOfferPrice(double cabinOfferPrice)
        {
            this.CabinPrice.SetOfferPrice(cabinOfferPrice);
        }
    }
}
