using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    internal class CsvOperator : Operator
    {
        public int StartDateIndex { get; set; }
        public int EndDateIndex { get; set; }
        public int VoyageIndex { get; set; }
        public int EmbarkationIndex { get; set; }
        public int DisembarkationIndex { get; set; }
        public int VesselIndex { get; set; }
        public int StartCabinIndex { get; set; }

        public CsvOperator(string name, int startDateIndex, int endDateIndex, int voyageIndex, int embarkationIndex, int disembarkationIndex, int vesselIndex, int startCabinIndex, string filePath = "Poseidon.csv")
        {
            Name = name;
            StartDateIndex = startDateIndex;
            EndDateIndex = endDateIndex;
            VoyageIndex = voyageIndex;
            EmbarkationIndex = embarkationIndex;
            DisembarkationIndex = disembarkationIndex;
            VesselIndex = vesselIndex;
            StartCabinIndex = startCabinIndex;
        }

        public override string ToString()
        {
            return $"{Name},{StartDateIndex},{EndDateIndex},{VoyageIndex},{EmbarkationIndex},{DisembarkationIndex},{VesselIndex},{StartCabinIndex}";
        }

        public override Task<List<Voyage>> GetVoyagesAsync(string filePath)
        {
            var voyages = FileHelper.GetVoyagesFromCSV(filePath, this);
            return Task.FromResult(voyages);
        }
    }
}
