using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    public abstract class Operator
    {
        public string Name { get; set; }

        public abstract override string ToString();

        public abstract Task<List<Voyage>> GetVoyagesAsync(string path = "");
    }
}
