namespace AccessoryOptimizerLib.Models
{
    public class StatsValue
    {
        public int CritValue { get; set; } = 0;

        public int SpecValue { get; set; } = 0;

        public int SwiftValue { get; set; } = 0;

        public StatsValue(int critValue, int specValue, int swiftValue)
        {
            CritValue = critValue;
            SpecValue = specValue;
            SwiftValue = swiftValue;
        }

        public StatsValue() { }

        public StatsValue(Stats stats)
        {
            AddStats(stats);
        }

        public void AddStats(Stats stats)
        {
            AddValue(stats.StatType1, stats.Stat1Quantity);

            if (stats.StatType2 != null)
            {
                AddValue((Stat_Type)stats.StatType2, (int)stats.Stat2Quantity);
            }
        }

        private void AddValue(Stat_Type statType, int statQuantity)
        {
            switch (statType)
            {
                case Stat_Type.Specialization:
                    SpecValue = statQuantity + SpecValue;
                    break;
                case Stat_Type.Swiftness:
                    SwiftValue = statQuantity + SwiftValue;
                    break;
                case Stat_Type.Crit:
                    CritValue = statQuantity + CritValue;
                    break;
            }
        }
    }
}
