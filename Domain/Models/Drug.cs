using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DomainLayer.Models
{
    public class Drug : BaseModule
    {

        [JsonPropertyName("commercial_name_en")]
        public string CommercialNameEn { get; set; }

        [JsonPropertyName("commercial_name_ar")]
        public string CommercialNameAr { get; set; }

        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("drug_class")]
        public string DrugClass { get; set; }

        [JsonPropertyName("route")]
        public string Route { get; set; }

        //[JsonPropertyName("price_egp")]
        //public decimal? PriceEgp { get; set; }
    }
}

