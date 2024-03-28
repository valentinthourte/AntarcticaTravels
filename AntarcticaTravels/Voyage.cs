using AntarcticaTravels.Atlas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntarcticaTravels
{
    public class Voyage
    {
        public string VoyageName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Embarkation { get; set; }
        public string Disembarkation { get; set; }
        public Vessel VoyageVessel { get; set; }
        public Voyage(string name, DateTime startDate, DateTime endDate, string embark, string disembark, Vessel vessel)
        {
            VoyageName = name;
            StartDate = startDate;
            EndDate = endDate;
            Embarkation = embark;
            Disembarkation = disembark;
            VoyageVessel = vessel;
        }

        internal double CheapestPrice()
        {
            return this.VoyageVessel.GetCheapestPrice();
        }

        internal string? GetVesselName()
        {
            return this.VoyageVessel.GetName();
        }

        internal List<VesselCabin> GetCabins()
        {
            return this.VoyageVessel.Cabins;
        }

        //public static explicit operator Voyage(DetailedExpedition? ex)
        //{
        //    return new Voyage
        //    {
        //        VoyageName = ex.ExpeditionName,
        //        StartDate = ex.Itineraries.,
        //        EndDate = endDate,
        //        Embarkation = embark,
        //        Disembarkation = disembark,
        //        VoyageVessel = vessel
        //    };
        //}   
    }
}
