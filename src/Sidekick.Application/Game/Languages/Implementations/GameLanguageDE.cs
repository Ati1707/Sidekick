using System;
using Sidekick.Domain.Game.Languages;

namespace Sidekick.Application.Game.Languages.Implementations
{
    [GameLanguage("German", "de")]
    public class GameLanguageDE : IGameLanguage
    {
        public string LanguageCode => "de";
        public Uri PoeTradeSearchBaseUrl => new Uri("https://de.pathofexile.com/trade/search/");
        public Uri PoeTradeExchangeBaseUrl => new Uri("https://de.pathofexile.com/trade/exchange/");
        public Uri PoeTradeApiBaseUrl => new Uri("https://de.pathofexile.com/api/trade/");
        public Uri PoeCdnBaseUrl => new Uri("https://web.poecdn.com/");
        public string RarityUnique => "Einzigartig";
        public string RarityRare => "Selten";
        public string RarityMagic => "Magisch";
        public string RarityNormal => "Normal";
        public string RarityCurrency => "Währung";
        public string RarityGem => "Gemme";
        public string RarityDivinationCard => "Weissagungskarte";
        public string DescriptionUnidentified => "Nicht identifiziert";
        public string DescriptionQuality => "Qualität";
        public string DescriptionAlternateQuality => "Alternative Qualität";
        public string DescriptionCorrupted => "Verderbt";
        public string DescriptionSockets => "Fassungen";
        public string DescriptionItemLevel => "Gegenstandsstufe";
        public string DescriptionExperience => "Erfahrung";
        public string PrefixSuperior => "(hochwertig)";
        public string InfluenceShaper => "Schöpfer";
        public string InfluenceElder => "Ältesten";
        public string InfluenceCrusader => "Kreuzritter";
        public string InfluenceHunter => "Jägers";
        public string InfluenceRedeemer => "Erlöserin";
        public string InfluenceWarlord => "Kriegsherrn";
        public string DescriptionMapTier => "Kartenlevel";
        public string DescriptionItemQuantity => "Gegenstandsmenge";
        public string DescriptionItemRarity => "Gegenstandsseltenheit";
        public string DescriptionMonsterPackSize => "Monstergruppengröße";
        public string PrefixBlighted => "Befallene";
        
        public string DescriptionPhysicalDamage => "Physischer Schaden";
        public string DescriptionElementalDamage => "Elementarschaden";
        public string DescriptionAttacksPerSecond => "Angriffe pro Sekunde";
        public string DescriptionCriticalStrikeChance => "Kritische Trefferchance";
        public string DescriptionEnergyShield => "Energieschild";
        public string DescriptionArmour => "Rüstung";
        public string DescriptionEvasion => "Ausweichwert";
        public string DescriptionChanceToBlock => "__TranslationRequired__";

        public string DescriptionLevel => "__TranslationRequired__";

        public string PrefixAnomalous => "(anormal)";
        public string PrefixDivergent => "(abweichend)";
        public string PrefixPhantasmal => "(illusorisch)";
    }
}
