using System;

namespace Sidekick.Common.Game.Languages.Implementations
{
    [GameLanguage("English", "en")]
    public class GameLanguageEN : IGameLanguage
    {
        public string LanguageCode => "en";
        public Uri PoeTradeSearchBaseUrl => new("https://www.pathofexile.com/trade/search/");
        public Uri PoeTradeExchangeBaseUrl => new("https://www.pathofexile.com/trade/exchange/");
        public Uri PoeTradeApiBaseUrl => new("https://www.pathofexile.com/api/trade/");
        public Uri PoeCdnBaseUrl => new("https://web.poecdn.com/");
        public string RarityUnique => "Unique";
        public string RarityRare => "Rare";
        public string RarityMagic => "Magic";
        public string RarityNormal => "Normal";
        public string RarityCurrency => "Currency";
        public string RarityGem => "Gem";
        public string RarityDivinationCard => "Divination Card";
        public string DescriptionUnidentified => "Unidentified";
        public string DescriptionQuality => "Quality";
        public string DescriptionAlternateQuality => "Alternate Quality";
        public string DescriptionLevel => "Level";
        public string DescriptionCorrupted => "Corrupted";
        public string DescriptionSockets => "Sockets";
        public string DescriptionItemLevel => "Item Level";
        public string DescriptionExperience => "Experience";
        public string DescriptionPhysicalDamage => "Physical Damage";
        public string DescriptionElementalDamage => "Elemental Damage";
        public string DescriptionEnergyShield => "Energy Shield";
        public string DescriptionArmour => "Armour";
        public string DescriptionEvasion => "Evasion Rating";
        public string DescriptionChanceToBlock => "Chance to Block";
        public string DescriptionAttacksPerSecond => "Attacks per Second";
        public string DescriptionCriticalStrikeChance => "Critical Strike Chance";
        public string PrefixSuperior => "Superior";
        public string InfluenceShaper => "Shaper";
        public string InfluenceElder => "Elder";
        public string InfluenceCrusader => "Crusader";
        public string InfluenceHunter => "Hunter";
        public string InfluenceRedeemer => "Redeemer";
        public string InfluenceWarlord => "Warlord";
        public string DescriptionMapTier => "Map Tier";
        public string DescriptionItemQuantity => "Item Quantity";
        public string DescriptionItemRarity => "Item Rarity";
        public string DescriptionMonsterPackSize => "Monster Pack Size";
        public string PrefixBlighted => "Blighted";

        public string PrefixAnomalous => "Anomalous";
        public string PrefixDivergent => "Divergent";
        public string PrefixPhantasmal => "Phantasmal";
    }
}
