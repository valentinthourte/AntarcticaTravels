using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    public class Vessel
    {
        public string VesselName { get; set; }
        public List<VesselCabin> Cabins { get; set; }
        public VesselCabin CheapestCabin { get; set; }

        public Vessel(string name)
        {
            this.VesselName = name;
        }
        public Vessel(string name, List<VesselCabin> cabins)
        {
            this.VesselName = name;
            SetCabins(cabins);
        }

        public void SetCabins(List<VesselCabin> cabins)
        {
            this.Cabins = cabins;
            this.CheapestCabin = this.Cabins.MinBy(cabin => cabin.GetCabinPrice());
        }
        public double GetCheapestPrice()
        {
            return this.CheapestCabin.GetCabinPrice();
        }

        internal string? GetName()
        {
            return this.VesselName;
        }
    }
}
