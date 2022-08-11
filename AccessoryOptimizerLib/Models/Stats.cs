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
        public Stat_Type? StatType2 { get; set; } = null;

        [JsonPropertyName("stat2Quantity")]
        public int Stat2Quantity { get; set; } = 0;

        public Stats(int statType1, int stat1Quantity)
        {
            StatType1 = (Stat_Type)statType1;
            Stat1Quantity = stat1Quantity;
        }

        [JsonConstructor]
        public Stats(int statType1, int stat1Quantity, int? statType2, int stat2Quantity)
        {
            StatType1 = (Stat_Type)statType1;
            Stat1Quantity = stat1Quantity;
            StatType2 = (Stat_Type)statType2;
            Stat2Quantity = stat2Quantity;
        }

        public Stats(int statType1, int stat1Quantity, int statType2, int stat2Quantity)
        {
            StatType1 = (Stat_Type)statType1;
            Stat1Quantity = stat1Quantity;
            StatType2 = (Stat_Type)statType2;
            Stat2Quantity = stat2Quantity;
        }

        public Stats(Stat_Type statType1, int stat1Quantity, Stat_Type? statType2 = null, int stat2Quantity = 0)
        {
            StatType1 = statType1;
            Stat1Quantity = stat1Quantity;
            StatType2 = statType2;
            Stat2Quantity = stat2Quantity;
        }

        public Stats(AccessoryType accessoryType, Stat_Type statType1, Stat_Type? statType2 = null)
        {
            StatType1 = statType1;
            Stat1Quantity = GetRandomAccessoryStatValue(accessoryType);

            if (statType2 != null)
            {
                StatType2 = statType2;
                Stat2Quantity = GetRandomAccessoryStatValue(accessoryType);
            }
        }

        private int GetRandomAccessoryStatValue(AccessoryType accessoryType)
        {
            Random random = new Random();

            switch (accessoryType)
            {
                case AccessoryType.Ring:
                    return random.Next(161, 199);
                case AccessoryType.Earring:
                    return random.Next(241, 299);
                case AccessoryType.Necklace:
                    return random.Next(401, 499);
            }

            return 0;
        }
    }
}
