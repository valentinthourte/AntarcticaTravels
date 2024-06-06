using AntarcticaTravels.Atlas;

namespace AntarcticaTravels
{

    public class AtlasShip
    {
        public string updated { get; set; }
        public Brand brand { get; set; }
        public string code { get; set; }
        public object external_code { get; set; }
        public string name { get; set; }
        public object size { get; set; }
        public int length { get; set; }
        public int total_capacity { get; set; }
        public int total_cabins { get; set; }
        public List<Deck> decks { get; set; }
        public List<Grade> grades { get; set; }

        internal Vessel ToVessel(AtlasMarketPricing marketPricing)
        {
            List<VesselCabin> cabins = new List<VesselCabin>();

            foreach (Grade grade in grades)
            {
                MarketPricingGrade marketGrade = marketPricing.rates.Skip(1).Take(1).First().grades.Where(g => g.code == grade.code).FirstOrDefault();
                VesselCabin cabin;
                if (marketGrade != null)
                {
                    PricingBreakdown breakdown = marketGrade.guest_pricing.First().pricing.Where(p => p.category == "adult").First().pricing_breakdown;
                    double price = breakdown.fare;
                    double offerPrice = Math.Floor((price - Math.Abs(breakdown.discount)) / 2) + breakdown.gft;
                    cabin = new VesselCabin(grade.name.Values.First(), new Price(price, offerPrice));
                }
                else
                {
                    cabin = new VesselCabin(grade.name.Values.First());
                }

                cabins.Add(cabin);
            }

            Vessel vessel = new Vessel(this.name, cabins);
            return vessel;
        }
    }

    public class Grade
    {
        public string code { get; set; }
        public string external_code { get; set; }
        public Dictionary<string, string> name { get; set; }
        public string meta_category { get; set; }
        public string valid_from { get; set; }
        public object valid_to { get; set; }
        public int cabin_qty { get; set; }
        public string colour_code { get; set; }
        public int minimum_occupancy { get; set; }
        public int maximum_occupancy { get; set; }
        public string size { get; set; }
        public List<string> decks { get; set; }
        public List<object> cabin_attributes { get; set; }
    }

    public class Deck
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Brand
    {
        public string code { get; set; }
        public string name { get; set; }
    }


}