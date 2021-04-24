using System.Text.Json.Serialization;

namespace Sidekick.Infrastructure.PoeApi.Trade.Filters
{
    public class TradeFilter
    {
        public SearchFilterOption Account { get; set; }

        [JsonPropertyName("indexed")]
        public SearchFilterOption Listed { get; set; }

        public SearchFilterValue Price { get; set; }

        [JsonPropertyName("sale_type")]
        public SearchFilterOption SaleType { get; set; } = new SearchFilterOption("priced");
    }
}
