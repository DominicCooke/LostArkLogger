using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AccessoryOptimizerLib.Models
{
    public class Accessory
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("accessoryType")]
        public AccessoryType AccessoryType { get; set; }

        [JsonPropertyName("accessoryRank")]
        public AccessoryRank AccessoryRank { get; set; }

        [JsonPropertyName("quality")]
        public int Quality { get; set; }

        [JsonPropertyName("minimumBid")]
        public int MinimumBid { get; set; }

        [JsonPropertyName("buyNowPrice")]
        public int BuyNowPrice { get; set; }

        [JsonPropertyName("engravings")]
        public List<Engraving> Engravings { get; set; }

        [JsonPropertyName("negativeEngraving")]
        public Engraving NegativeEngraving { get; set; }

        [JsonPropertyName("statsValue")]
        public StatsValue StatsValue { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonConstructor]
        public Accessory(Guid id, AccessoryType accessoryType, AccessoryRank accessoryRank, int quality, int minimumBid, int buyNowPrice, List<Engraving> engravings, Engraving negativeEngraving, StatsValue statsValue, Stats stats)
        {
            AccessoryType = accessoryType;
            AccessoryRank = accessoryRank;
            Quality = quality;
            MinimumBid = minimumBid;
            BuyNowPrice = buyNowPrice;
            Engravings = engravings;
            NegativeEngraving = negativeEngraving;
            StatsValue = statsValue;
            Id = id;
            Stats = stats;
        }
        public Accessory(AccessoryType accessoryType, AccessoryRank accessoryRank, int quality, int minimumBid, int buyNowPrice, List<Engraving> engravings, Engraving negativeEngraving, Stats stats)
        {
            AccessoryType = accessoryType;
            AccessoryRank = accessoryRank;
            Quality = quality;
            MinimumBid = minimumBid;
            BuyNowPrice = buyNowPrice;
            Engravings = engravings;
            NegativeEngraving = negativeEngraving;
            StatsValue = new StatsValue(stats);
            Stats = stats;
            Id = Guid.NewGuid();
        }

        public string GetEngravingId()
        {
            var engravingNames = Engravings.Select(e => $"{e.EngravingName}{e.EngravingValue}").OrderBy(e => e).ToList();
            return $"{engravingNames[0]}{engravingNames[1]}";
        }
    }
}
