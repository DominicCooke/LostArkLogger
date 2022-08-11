using System.Collections.Generic;
using System.Linq;

namespace AccessoryOptimizerLib.Models
{
    public class PermutationDisplay : Permutation
    {
        public bool HasNecklace => GetAccessories().Any(a => a.AccessoryType == AccessoryType.Necklace);
        public bool HasRings => GetAccessories().Where(a => a.AccessoryType == AccessoryType.Ring).Count() == 2;
        public bool HasEarrings => GetAccessories().Where(a => a.AccessoryType == AccessoryType.Earring).Count() == 2;

        public int Cost => GetAccessories().Sum(a => a.BuyNowPrice);
        public int BidCost => GetAccessories().Sum(a => a.MinimumBid);
        public int AverageQuality => GetAccessories().Sum(a => a.Quality) / GetAccessories().Count();

        public NegativeSummary NegativeSummary { get; set; }
        public Dictionary<string, int> Engravings { get; set; }
        public StatsValue StatsValue { get; set; }

        public PermutationDisplay(Permutation permutation) : base(permutation.Earring1, permutation.Earring2, permutation.Ring1, permutation.Ring2, permutation.Necklace)
        {
            NegativeSummary = new NegativeSummary(GetAccessories());
            Engravings = GetEngravingSummary();
            StatsValue = GetStatsValue();
        }

        public bool IsThereWorryingNegativeEngraving()
        {
            return NegativeSummary.IsThereWorryingNegativeEngraving();
        }

        public bool HasEngravingAtZero()
        {
            return NegativeSummary.HasEngravingAtZero();
        }

        private StatsValue GetStatsValue()
        {
            StatsValue statsValue = new StatsValue();

            AddStatsValue(statsValue, Necklace.StatsValue);
            AddStatsValue(statsValue, Earring1.StatsValue);
            AddStatsValue(statsValue, Earring2.StatsValue);
            AddStatsValue(statsValue, Ring1.StatsValue);
            AddStatsValue(statsValue, Ring2.StatsValue);

            return statsValue;
        }

        private StatsValue AddStatsValue(StatsValue destStatsValue, StatsValue srcStatsValue)
        {
            destStatsValue.SpecValue += srcStatsValue.SpecValue;
            destStatsValue.CritValue += srcStatsValue.CritValue;
            destStatsValue.SwiftValue += srcStatsValue.SwiftValue;

            return destStatsValue; ;
        }

        private Dictionary<string, int> GetEngravingSummary()
        {
            var engravingSummary = new Dictionary<string, int>();

            foreach (var accessory in GetAccessories())
            {
                if (accessory != null)
                {
                    Engraving engraving1 = accessory.Engravings[0];
                    Engraving engraving2 = accessory.Engravings[1];

                    ProcessEngraving(engraving1);
                    ProcessEngraving(engraving2);
                }
            }

            return engravingSummary;

            void ProcessEngraving(Engraving engraving)
            {
                if (engravingSummary.Any(e => e.Key == engraving.EngravingName))
                {
                    engravingSummary.TryGetValue(engraving.EngravingName, out int currentValue);

                    engravingSummary.Remove(engraving.EngravingName);
                    engravingSummary.Add(engraving.EngravingName, engraving.EngravingValue + currentValue);
                }
                else
                {
                    engravingSummary.Add(engraving.EngravingName, engraving.EngravingValue);
                }
            }
        }
    }

    public class Permutation
    {
        public Accessory Ring1 { get; set; }
        public Accessory Ring2 { get; set; }
        public Accessory Earring1 { get; set; }
        public Accessory Earring2 { get; set; }
        public Accessory Necklace { get; set; }

        public Permutation(Accessory earring1, Accessory earring2, Accessory ring1, Accessory ring2, Accessory necklace)
        {
            Earring1 = earring1;
            Earring2 = earring2;
            Ring1 = ring1;
            Ring2 = ring2;

            if (necklace != null)
            {
                Necklace = necklace;
            }
        }

        public List<Accessory> GetAccessories()
        {
            return new List<Accessory>() { Ring1, Ring2, Earring1, Earring2, Necklace };
        }


        public int GetEngravingAmount(EngravingType engravingType)
        {
            return GetAccessories().Sum(a => a.Engravings.Where(e => e.EngravingType == engravingType).Sum(e => e.EngravingValue));
        }
    }
}