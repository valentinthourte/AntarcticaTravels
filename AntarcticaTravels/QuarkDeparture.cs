using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntarcticaTravels
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class QuarkDeparture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("departure_name")]
        public string DepartureName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("departure_id")]
        public string DepartureId { get; set; }

        [JsonProperty("expedition_id")]
        public int ExpeditionId { get; set; }

        [JsonProperty("ship_id")]
        public string ShipId { get; set; }

        [JsonProperty("ship_name")]
        public string ShipName { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("duration_days")]
        public int DurationDays { get; set; }

        [JsonProperty("itinerary_id")]
        public int ItineraryId { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }
    }
    public class QuarkDetailedDeparture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("departure_name")]
        public string DepartureName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("departure_id")]
        public string DepartureId { get; set; }

        [JsonProperty("expedition_id")]
        public int ExpeditionId { get; set; }

        [JsonProperty("ship_id")]
        public string ShipId { get; set; }

        [JsonProperty("ship_name")]
        public string ShipName { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("duration_days")]
        public int DurationDays { get; set; }

        [JsonProperty("itinerary_id")]
        public int ItineraryId { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty("cabins")]
        public Dictionary<string, QuarkDepartureCabin> Cabins { get; set; }
    }

    public class QuarkDepartureCabin
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cabin_id")]
        public string CabinId { get; set; }

        [JsonProperty("cabin_name")]
        public string CabinName { get; set; }

        [JsonProperty("occupancies")]
        public List<QuarkOccupancy> Occupancies { get; set; }
    }

    public class QuarkOccupancy
    {
        [JsonProperty("occupancy_code")]
        public string OccupancyCode { get; set; }

        [JsonProperty("occupancy_description")]
        public string OccupancyDescription { get; set; }

        [JsonProperty("availability_status")]
        public string AvailabilityStatus { get; set; }

        [JsonProperty("availability_description")]
        public string AvailabilityDescription { get; set; }

        [JsonProperty("spaces_available")]
        public int SpacesAvailable { get; set; }

        [JsonProperty("price_per_person")]
        public int PricePerPerson { get; set; }

        [JsonProperty("starting_from_total_price_per_person")]
        public int StartingFromTotalPricePerPerson { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

    }

    public class QuarkDeparturePrice
    {
        [JsonProperty("price_per_person")]
        public int PricePerPerson { get; set; }

        [JsonProperty("promo_price_per_person")]
        public int PromoPricePerPerson { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("mandatory_transfer_price_per_person")]
        public int? MandatoryTransferPricePerPerson { get; set; }

        [JsonProperty("total_price_per_person")]
        public int TotalPricePerPerson { get; set; }
    }

    public class QuarkPromotion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("promo_code")]
        public string PromoCode { get; set; }

        [JsonProperty("promo_name")]
        public string PromoName { get; set; }

        [JsonProperty("promo_start_date")]
        public DateTime PromoStartDate { get; set; }

        [JsonProperty("promo_end_date")]
        public DateTime? PromoEndDate { get; set; }

        [JsonProperty("promo_currency_code")]
        public string PromoCurrencyCode { get; set; }

        [JsonProperty("promo_discount_type")]
        public string PromoDiscountType { get; set; }

        [JsonProperty("promo_discount_value")]
        public string PromoDiscountValue { get; set; }
    }

}
