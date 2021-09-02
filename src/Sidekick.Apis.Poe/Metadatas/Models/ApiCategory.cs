using System.Collections.Generic;

namespace Sidekick.Apis.Poe.Metadatas.Models
{
    /// <summary>
    /// Uniques
    /// Armour
    /// Cards
    /// Gems
    /// Jewels
    /// Maps
    /// Weapons
    /// Prophecies
    /// Itemised Monsters
    /// Watchstones
    /// </summary>
    public class ApiCategory
    {
        public string Label { get; set; }
        public List<ApiItem> Entries { get; set; }
    }
}