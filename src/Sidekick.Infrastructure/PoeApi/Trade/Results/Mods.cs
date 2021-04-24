using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sidekick.Infrastructure.PoeApi.Trade.Results
{
    public class Mods
    {
        public List<Mod> Implicit { get; set; } = new List<Mod>();
        public List<Mod> Explicit { get; set; } = new List<Mod>();
        public List<Mod> Crafted { get; set; } = new List<Mod>();
        public List<Mod> Enchant { get; set; } = new List<Mod>();
        public List<Mod> Fractured { get; set; } = new List<Mod>();

        [JsonIgnore]
        public List<Mod> Pseudo { get; set; } = new List<Mod>();
    }
}
