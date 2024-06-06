using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    internal class ApiOperator : Operator
    {
        private Dictionary<string, string> URLs;

        public ApiOperator(string name)
        {
            this.Name = name;
        }

        public ApiOperator(string name, Dictionary<string, string> Urls) : this(name)
        {
            this.URLs = Urls;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name},");
            foreach (var url in this.URLs)
            {
                sb.Append($"{url.Key},{url.Value},");
            }
            string finalString = sb.ToString();
            return finalString.Remove(finalString.Length - 2);
        }

        public override async Task<List<Voyage>> GetVoyagesAsync(string filePath = "")
        {
            List<Voyage> voyages = null;
            switch (this.Name)
            {
                case "Quark":
                    {
                        voyages = await HttpHelper.GetQuarkVoyages(this.URLs);
                        break;
                    }
                case "Oceanwide":
                    {
                        voyages = await HttpHelper.GetOceanwideVoyages(this.URLs);
                        break;
                    }
                case "Poseidon":
                    {
                        voyages = await HttpHelper.GetPoseidonVoyages(this.URLs);
                        break;
                    }
                case "Atlas":
                    {
                        voyages = await HttpHelper.GetAtlasVoyages(this.URLs);
                        break;
                    }
                case "Lindblad":
                    {
                        voyages = await HttpHelper.GetLindbladVoyages(this.URLs);
                        break;
                    }
            }
            return voyages.OrderBy(voyage => voyage.VoyageVessel.VesselName).ThenBy(voyage => voyage.StartDate).ToList() ?? new List<Voyage>();
        }
    }
}
