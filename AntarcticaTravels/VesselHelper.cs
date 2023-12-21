using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    internal static class VesselHelper
    {
        public static Vessel GetVesselByName(string name)
        {
            var vesselList = VesselHelper.GetVessels();
            foreach (var vessel in vesselList)
            {
                if (vessel.VesselName == name)
                {
                    return vessel;
                }
            }
            throw new Exception("Vessel name not registered.");
        }

        public static IEnumerable<Vessel> GetVessels()
        {
            return new List<Vessel>();
        }
    }
}
