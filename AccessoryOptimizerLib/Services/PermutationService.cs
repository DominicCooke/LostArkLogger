using AccessoryOptimizerLib.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccessoryOptimizerLib.Services
{
    public partial class PermutationService
    {
        public List<Accessory> _necklaces = new List<Accessory>();
        public List<Accessory> _earrings = new List<Accessory>();
        public List<Accessory> _rings = new List<Accessory>();

        public List<PermutationDisplay> _permutationDisplays = new List<PermutationDisplay>();

        public (int numberOfPermutations, List<PermutationDisplay>) Process(List<DesiredEngravings> allDesiredEngravings, int minCost, int maxPrice, bool useStoredPermutations = false, bool filterWorryingEngraving = true, bool filterEngravingAtZero = true)
        {
            if (useStoredPermutations)
            {
                return (_permutationDisplays.Count, _permutationDisplays);
            }

            if (allDesiredEngravings.Count > 0)
            {
                var necks = _necklaces.Where(n => n.BuyNowPrice >= minCost && n.BuyNowPrice < maxPrice).ToList();
                var ears = _earrings.Where(n => n.BuyNowPrice >= minCost && n.BuyNowPrice < maxPrice).ToList();
                var rings = _rings.Where(n => n.BuyNowPrice >= minCost && n.BuyNowPrice < maxPrice).ToList();
                //var necks = new List<Accessory>();

                //rings.Add(new Accessory(AccessoryType.Ring, AccessoryRank.Relic, 87, 0, 0, new List<Engraving>() { new Engraving(EngravingType.Barricade, 5), new Engraving(EngravingType.Stabilized_Status, 3) }, new Engraving(EngravingType.Atk_Power_Reduction, 2), new Stats(Stat_Type.Specialization, 195)));
                //rings.Add(new Accessory(AccessoryType.Ring, AccessoryRank.Legendary, 96, 0, 0, new List<Engraving>() { new Engraving(EngravingType.Grudge, 3), new Engraving(EngravingType.Combat_Readiness, 3) }, new Engraving(EngravingType.Defence_Reduction, 3), new Stats(Stat_Type.Specialization, 178)));
                //necks.Add(new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, 92, 0, 0, new List<Engraving>() { new Engraving(EngravingType.Combat_Readiness, 5), new Engraving(EngravingType.Increases_Mass, 3) }, new Engraving(EngravingType.Atk_Power_Reduction, 1), new Stats(Stat_Type.Specialization, 490, Stat_Type.Swiftness, 495)));

                List<Permutation> permutationsThatMatchesDesiredEngravings = GetPermutations(necks, ears, rings, allDesiredEngravings, filterWorryingEngraving);

                _permutationDisplays = permutationsThatMatchesDesiredEngravings.Select(p => new PermutationDisplay(p)).ToList();
                int numberOfPermutations = _permutationDisplays.Count;

                if (filterWorryingEngraving)
                {
                    _permutationDisplays = _permutationDisplays.Where(e => !e.IsThereWorryingNegativeEngraving()).ToList();
                }

                if (filterEngravingAtZero)
                {
                    _permutationDisplays = _permutationDisplays.Where(e => e.HasEngravingAtZero()).ToList();
                }

                return (numberOfPermutations, _permutationDisplays);
            }

            return (0, new List<PermutationDisplay>());
        }

        private bool DoesPermutationMatchDesiredEngravings(DesiredEngravings desiredEngravings, List<Accessory> accessories)
        {
            bool anyMissing = false;

            foreach (DesiredEngraving desiredEngraving in desiredEngravings.Engravings)
            {
                if (GetEngravingAmount(desiredEngraving.EngravingType) >= desiredEngraving.Amount)
                {
                    continue;
                }
                else
                {
                    anyMissing = true;
                    break;
                }
            }

            return anyMissing;

            int GetEngravingAmount(EngravingType engravingType)
            {
                return accessories.Sum(a => a.Engravings.Where(e => e.EngravingType == engravingType).Sum(e => e.EngravingValue));
            }
        }

        private List<Permutation> GetPermutations(List<Accessory> necklaces, List<Accessory> earrings, List<Accessory> rings, List<DesiredEngravings> allDesiredEngravings, bool filterWorryingEngraving)
        {
            ConcurrentBag<Permutation> permutationsThatMatchesDesiredEngravings = new ConcurrentBag<Permutation>();
            if (necklaces.Count > 0)
            {
                List<(DesiredEngravings desiredEngravings, int overallAmount)> desiredEngravingAmounts = allDesiredEngravings.Select(dee => (dee, dee.Engravings.Sum(de => de.Amount))).ToList();

                List<(Accessory, Accessory)> earringCombinations = GetEarringCombinations(earrings, desiredEngravingAmounts, filterWorryingEngraving);
                List<(Accessory, Accessory)> ringCombinations = GetRingCombinations(rings, desiredEngravingAmounts, filterWorryingEngraving);

                var rangePartitioner = Partitioner.Create(0, earringCombinations.Count, 250);
                var overall = Stopwatch.StartNew();

                Parallel.ForEach(rangePartitioner, (earringRange, loopState) =>
                {
                    //var stopwatch = Stopwatch.StartNew();

                    for (int i = earringRange.Item1; i < earringRange.Item2; i++)
                    {
                        (Accessory, Accessory) eC = earringCombinations[i];

                        foreach (var rC in ringCombinations)
                        {
                            // performance boosting
                            if (IsThereAWorryingNegativeEngraving(eC.Item1, eC.Item2, rC.Item1, rC.Item2))
                            {
                                continue;
                            }

                            var areAnyEngravingsReleastic = desiredEngravingAmounts.Any(dea => dea.Item2 - GetCurrentEngravingValueTotal(eC.Item1, eC.Item2, rC.Item1, rC.Item2) <= 8);

                            if (areAnyEngravingsReleastic)
                            {
                                foreach (var necklace in necklaces)
                                {
                                    var accs = new List<Accessory>() { eC.Item1, eC.Item2, rC.Item1, rC.Item2, necklace };

                                    NegativeSummary negativeSummary = new NegativeSummary(accs);

                                    if (negativeSummary.IsThereWorryingNegativeEngraving() && filterWorryingEngraving)
                                    {
                                        continue;
                                    }

                                    foreach (var desiredEngravings in allDesiredEngravings)
                                    {
                                        if (!DoesPermutationMatchDesiredEngravings(desiredEngravings, accs))
                                        {
                                            permutationsThatMatchesDesiredEngravings.Add(new Permutation(eC.Item1, eC.Item2, rC.Item1, rC.Item2, necklace));
                                        }
                                    }
                                }
                            }
                        };
                        //Trace.WriteLine($"Finishing a cominbation run took: {stopwatch.Elapsed}");
                        //stopwatch.Stop();
                    }
                });
                Trace.WriteLine($"It took this long in total: {overall.Elapsed}");
                overall.Stop();
            }

            return permutationsThatMatchesDesiredEngravings.ToList();
        }

        private int GetCurrentEngravingValueTotal(Accessory earring1, Accessory earring2, Accessory ring1, Accessory ring2)
        {
            return earring1.Engravings.Sum(e => e.EngravingValue)
                            + earring2.Engravings.Sum(e => e.EngravingValue)
                            + ring1.Engravings.Sum(e => e.EngravingValue)
                            + ring2.Engravings.Sum(e => e.EngravingValue);
        }

        private int GetCurrentEngravingValueTotal(DesiredEngravings desiredEngravings, Accessory acc1, Accessory acc2)
        {
            /*
            return acc1.Engravings.Sum(e => e.EngravingValue)
                            + acc2.Engravings.Sum(e => e.EngravingValue);
            */

            List<Engraving> engravings = acc1.Engravings.Concat(acc2.Engravings).ToList();
            int amountOfEngravingValueFromAccessories = 0;

            foreach (DesiredEngraving desiredEngraving in desiredEngravings.Engravings)
            {
                int amountFromAccessoryEngravings = engravings.Where(e => e.EngravingType == desiredEngraving.EngravingType).Sum(e => e.EngravingValue);

                if (desiredEngraving.Amount <= amountFromAccessoryEngravings)
                {
                    amountOfEngravingValueFromAccessories += desiredEngraving.Amount;
                }
                else
                {
                    amountOfEngravingValueFromAccessories += amountFromAccessoryEngravings;
                }
            }

            return amountOfEngravingValueFromAccessories;
        }

        private List<(Accessory, Accessory)> GetEarringCombinations(List<Accessory> earrings, List<(DesiredEngravings desiredEngravings, int overallAmount)> desiredEngravingAmounts, bool filterWorryingEngraving)
        {
            List<(Guid, Guid)> usedIdCombinations = new List<(Guid, Guid)>();
            List<(Accessory, Accessory)> earringCombinations = new List<(Accessory, Accessory)>();

            foreach (var (earring, k) in earrings.Select((value, k) => (value, k)))
            {
                for (int p = k; p < earrings.Count; p++)
                {
                    Accessory nextEarring = earrings[p];

                    if (usedIdCombinations.Any(i => (i.Item1 == earring.Id && i.Item2 == nextEarring.Id) || (i.Item2 == earring.Id && i.Item1 == nextEarring.Id)) || earring.Id == nextEarring.Id)
                    {
                        continue;
                    }
                    else
                    {
                        usedIdCombinations.Add((earring.Id, nextEarring.Id));

                        // performance boosting
                        if (AreAccessoriesAreOverNegativeCap(earring, nextEarring) && filterWorryingEngraving)
                        {
                            continue;
                        }

                        // performance boosting
                        var areAnyEngravingsRealistic = desiredEngravingAmounts.Any(dea => dea.overallAmount - GetCurrentEngravingValueTotal(dea.desiredEngravings, earring, nextEarring) <= 24);

                        if (areAnyEngravingsRealistic)
                        {
                            earringCombinations.Add((earring, nextEarring));
                        }
                    }
                }
            }

            // performance boosting
            List<(Accessory, Accessory)> finalEarringCombinations = FilterCombinationsForBestOfEachEngraving(earringCombinations);

            return finalEarringCombinations;
        }

        private List<(Accessory, Accessory)> GetRingCombinations(List<Accessory> rings, List<(DesiredEngravings desiredEngravings, int overallAmount)> desiredEngravingAmounts, bool filterWorryingEngraving)
        {
            List<(Guid, Guid)> usedIdCombinations = new List<(Guid, Guid)>();
            List<(Accessory, Accessory)> ringCombinations = new List<(Accessory, Accessory)>();

            foreach (var (ring, k) in rings.Select((value, k) => (value, k)))
            {
                for (int p = k; p < rings.Count; p++)
                {
                    Accessory nextRing = rings[p];

                    if (usedIdCombinations.Any(i => (i.Item1 == ring.Id && i.Item2 == nextRing.Id) || (i.Item2 == ring.Id && i.Item1 == nextRing.Id)) || ring.Id == nextRing.Id)
                    {
                        continue;
                    }
                    else
                    {
                        usedIdCombinations.Add((ring.Id, nextRing.Id));

                        // performance boosting
                        if (AreAccessoriesAreOverNegativeCap(ring, nextRing) && filterWorryingEngraving)
                        {
                            continue;
                        }

                        // performance boosting
                        var areAnyEngravingsRealistic = desiredEngravingAmounts.Any(dea => dea.overallAmount - GetCurrentEngravingValueTotal(dea.desiredEngravings, ring, nextRing) <= 24);

                        if (areAnyEngravingsRealistic)
                        {
                            ringCombinations.Add((ring, nextRing));
                        }
                    }
                }
            }

            // performance boosting
            List<(Accessory, Accessory)> finalRingCombinations = FilterCombinationsForBestOfEachEngraving(ringCombinations);

            return finalRingCombinations;
        }

        private List<(Accessory, Accessory)> FilterCombinationsForBestOfEachEngraving(List<(Accessory, Accessory)> combinations)
        {
            IEnumerable<IGrouping<string, (Accessory, Accessory)>> groupings = combinations.GroupBy(ec => $"{ec.Item1.GetEngravingId()}{ec.Item2.GetEngravingId()}");
            List<(Accessory, Accessory)> finalCombinations = new List<(Accessory, Accessory)>();

            foreach (IGrouping<string, (Accessory, Accessory)> grouping in groupings)
            {
                var cheapest = grouping.Select(g => (g, g.Item1.BuyNowPrice + g.Item2.BuyNowPrice)).OrderBy(g => g.Item2).ToList();

                var highestStat1 = OrderCombinationsWithHighestOfStatType((Stat_Type)PSO.DesiredStatType1, grouping);
                var highestStat2 = OrderCombinationsWithHighestOfStatType((Stat_Type)PSO.DesiredStatType2, grouping);

                var potentialCombinations = new List<(Accessory, Accessory)>();
                potentialCombinations
                    .AddRange(
                        highestStat1
                            .Select(c => c.g)
                            .Take(highestStat1.Count < 10 ? highestStat1.Count : 10)
                        .Concat(
                            highestStat2
                                .Select(c => c.g)
                                .Take(highestStat2.Count < 10 ? highestStat2.Count : 10)
                                )
                        .Concat(
                            cheapest
                                .Select(c => c.g)
                                .Take(cheapest.Count < 10 ? cheapest.Count : 10)
                                )
                            );

                var uniqueFinalCombinations = potentialCombinations.GroupBy(o => $"{o.Item1.Id}{o.Item2.Id}").Select(g => g.First());
                finalCombinations.AddRange(uniqueFinalCombinations);
            }

            return finalCombinations;
        }

        private List<((Accessory, Accessory) g, int)> OrderCombinationsWithHighestOfStatType(Stat_Type statType, IGrouping<string, (Accessory, Accessory)> grouping)
        {
            switch (statType)
            {
                case Stat_Type.Swiftness:
                    return grouping.Select(g => (g, g.Item1.StatsValue.SwiftValue + g.Item2.StatsValue.SwiftValue)).OrderBy(g => g.Item2).Reverse().ToList();
                case Stat_Type.Specialization:
                    return grouping.Select(g => (g, g.Item1.StatsValue.SpecValue + g.Item2.StatsValue.SpecValue)).OrderBy(g => g.Item2).Reverse().ToList();
                case Stat_Type.Crit:
                    return grouping.Select(g => (g, g.Item1.StatsValue.CritValue + g.Item2.StatsValue.CritValue)).OrderBy(g => g.Item2).Reverse().ToList();
                case Stat_Type.Endurance:
                    return grouping.Select(g => (g, g.Item1.StatsValue.EnduranceValue + g.Item2.StatsValue.EnduranceValue)).OrderBy(g => g.Item2).Reverse().ToList();
                case Stat_Type.Domination:
                    return grouping.Select(g => (g, g.Item1.StatsValue.DominationValue + g.Item2.StatsValue.DominationValue)).OrderBy(g => g.Item2).Reverse().ToList();
                case Stat_Type.Expertise:
                    return grouping.Select(g => (g, g.Item1.StatsValue.ExpertiseValue + g.Item2.StatsValue.ExpertiseValue)).OrderBy(g => g.Item2).Reverse().ToList();
                default:
                    break;
            }

            return new List<((Accessory, Accessory) g, int)>();
        }

        private bool IsThereAWorryingNegativeEngraving(Accessory earring1, Accessory earring2, Accessory ring1, Accessory ring2)
        {
            List<Accessory> accessories = new List<Accessory>() { earring1, earring2, ring1, ring2 };

            NegativeSummary negativeSummary = new NegativeSummary(accessories);
            return negativeSummary.IsThereWorryingNegativeEngraving();
        }

        private bool AreAccessoriesAreOverNegativeCap(Accessory accessory1, Accessory accessory2)
        {
            var negativeSummary = new NegativeSummary(new List<Accessory>() { accessory1, accessory2 });

            return negativeSummary.IsThereWorryingNegativeEngraving();
        }
    }
}

