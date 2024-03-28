namespace AntarcticaTravels
{
    public class AtlasMarketPricing
    {
        public string sailing { get; set; }
        public string embark { get; set; }
        public string ship { get; set; }
        public string cruise { get; set; }
        public CruiseName cruise_name { get; set; }
        public string brand { get; set; }
        public int duration { get; set; }
        public int sea_days { get; set; }
        public object nccf_total_pp { get; set; }
        public string gft_total_pp { get; set; }
        public List<AtlasRate> rates { get; set; }
    }
    public class CruiseName
    {
        public string en_us { get; set; }
    }

    public class Name
    {
        public string en_us { get; set; }
    }

    public class PricingBreakdown
    {
        public double fare { get; set; }
        public double total_price { get; set; }
        public double total_fare { get; set; }
        public double single_supplement { get; set; }
        public double gft { get; set; }
    }

    public class AtlasPricing
    {
        public string category { get; set; }
        public int minimum_age { get; set; }
        public int maximum_age { get; set; }
        public PricingBreakdown pricing_breakdown { get; set; }
    }

    public class AtlasGuestPricing
    {
        public string guest { get; set; }
        public List<AtlasPricing> pricing { get; set; }
    }

    public class MarketPricingGrade
    {
        public string code { get; set; }
        public int available_cabins { get; set; }
        public List<AtlasGuestPricing> guest_pricing { get; set; }
    }

    public class AtlasRate
    {
        public string code { get; set; }
        public Name name { get; set; }
        public string restriction { get; set; }
        public string market { get; set; }
        public string currency { get; set; }
        public object agency { get; set; }
        public List<MarketPricingGrade> grades { get; set; }
    }
}