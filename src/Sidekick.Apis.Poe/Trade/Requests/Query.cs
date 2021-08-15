using System.Collections.Generic;
using Sidekick.Apis.Poe.Trade.Filters;

namespace Sidekick.Apis.Poe.Trade.Requests
{
    public class Query
    {
        public Status Status { get; set; } = new Status();
        public string Name { get; set; }
        public string Type { get; set; }
        public string Term { get; set; }
        public List<StatFilterGroup> Stats { get; set; } = new List<StatFilterGroup>();
        public SearchFilters Filters { get; set; } = new SearchFilters();
    }
}
