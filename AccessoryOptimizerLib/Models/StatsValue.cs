namespace AccessoryOptimizerLib.Models
{
    public class StatsValue
    {
        public int CritValue { get; set; } = 0;

        public int SpecValue { get; set; } = 0;

        public int SwiftValue { get; set; } = 0;

        public int DominationValue { get; set; } = 0;

        public int ExpertiseValue { get; set; } = 0;

        public int EnduranceValue { get; set; } = 0;

        public StatsValue(int critValue, int specValue, int swiftValue, int dominationValue = 0, int expertiseValue = 0, int enduranceValue = 0)
        {
            CritValue = critValue;
            SpecValue = specValue;
            SwiftValue = swiftValue;
            DominationValue = dominationValue;
            ExpertiseValue = expertiseValue;
            EnduranceValue = enduranceValue;
        }

        public StatsValue() { }

        public StatsValue(Stats stats)
        {
            AddStats(stats);
        }

        public int GetStatValue(Stat_Type statType)
        {
            switch (statType)
            {
                case Stat_Type.Specialization:
                    return SpecValue;
                case Stat_Type.Swiftness:
                    return SwiftValue;
                case Stat_Type.Crit:
                    return CritValue;
                case Stat_Type.Endurance:
                    return EnduranceValue;
                case Stat_Type.Domination:
                    return DominationValue;
                case Stat_Type.Expertise:
                    return ExpertiseValue;
            }

            return 0;
        }

        public void AddStats(Stats stats)
        {
            AddValue(stats.StatType1, stats.Stat1Quantity);

            if (stats.StatType2 != Stat_Type.Unset)
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
                case Stat_Type.Endurance:
                    EnduranceValue = statQuantity + EnduranceValue;
                    break;
                case Stat_Type.Domination:
                    DominationValue = statQuantity + DominationValue;
                    break;
                case Stat_Type.Expertise:
                    ExpertiseValue = statQuantity + ExpertiseValue;
                    break;
            }
        }
    }
}
