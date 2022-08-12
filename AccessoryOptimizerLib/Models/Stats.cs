using System;
using System.Text.Json.Serialization;

namespace AccessoryOptimizerLib.Models
{
    public class Stats
    {
        [JsonPropertyName("statType1")]
        public Stat_Type StatType1 { get; set; }

        [JsonPropertyName("stat1Quantity")]
        public int Stat1Quantity { get; set; }

        [JsonPropertyName("statType2")]
        public Stat_Type StatType2 { get; set; } = Stat_Type.Unset;

        [JsonPropertyName("stat2Quantity")]
        public int Stat2Quantity { get; set; } = 0;

        public Stats(int statType1, int stat1Quantity)
        {
            StatType1 = (Stat_Type)statType1;
            Stat1Quantity = stat1Quantity;
        }

        [JsonConstructor]
        public Stats(Stat_Type statType1, int stat1Quantity, Stat_Type statType2 = Stat_Type.Unset, int stat2Quantity = 0)
        {
            StatType1 = (Stat_Type)statType1;
            Stat1Quantity = stat1Quantity;
            StatType2 = (Stat_Type)statType2;
            Stat2Quantity = stat2Quantity;
        }
    }
}
