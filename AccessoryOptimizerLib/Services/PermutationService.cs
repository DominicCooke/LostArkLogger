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

        public (int numberOfPermutations, List<PermutationDisplay>) Process(List<List<DesiredEngraving>> allDesiredEngravings, int maxPrice, bool useStoredPermutations = false, bool filterWorryingEngraving = true, bool filterEngravingAtZero = true)
        {
            if (useStoredPermutations)
            {
                return (_permutationDisplays.Count, _permutationDisplays);
            }

            if (allDesiredEngravings.Count > 0)
            {
                var necks = _necklaces.Where(n => n.BuyNowPrice < maxPrice).ToList();
                var ears = _earrings.Where(n => n.BuyNowPrice < maxPrice).ToList();
                var rings = _rings.Where(n => n.BuyNowPrice < maxPrice).ToList();

                List<Permutation> permutationsThatMatchesDesiredEngravings = GetPermutations(necks, ears, rings, allDesiredEngravings);

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

        private bool DoesPermutationMatchDesiredEngravings(List<DesiredEngraving> desiredEngravings, Permutation permutation)
        {
            bool anyMissing = false;

            foreach (DesiredEngraving desiredEngraving in desiredEngravings)
            {
                if (permutation.GetEngravingAmount(desiredEngraving.EngravingType) >= desiredEngraving.Amount)
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
        }

        private List<Permutation> GetPermutations(List<Accessory> necklaces, List<Accessory> earrings, List<Accessory> rings, List<List<DesiredEngraving>> allDesiredEngravings)
        {
            ConcurrentBag<Permutation> permutationsThatMatchesDesiredEngravings = new ConcurrentBag<Permutation>();
            if (necklaces.Count > 0)
            {
                List<(Accessory, Accessory)> earringCombinations = GetEarringCombinations(earrings);
                List<(Accessory, Accessory)> ringCombinations = GetRingCombinations(rings);

                var desiredEngravingAmounts = allDesiredEngravings.Select(dee => dee.Sum(de => de.Amount)).ToList();

                var rangePartitioner = Partitioner.Create(0, earringCombinations.Count, 250);
                var overall = Stopwatch.StartNew();

                Parallel.ForEach(rangePartitioner, (earringRange, loopState) =>
                {
                    var stopwatch = Stopwatch.StartNew();

                    for (int i = earringRange.Item1; i < earringRange.Item2; i++)
                    {
                        (Accessory, Accessory) eC = earringCombinations[i];

                        foreach (var rC in ringCombinations)
                        {
                            // performance boosting
                            if(IsThereAWorryingNegativeEngraving(eC.Item1, eC.Item2, rC.Item1, rC.Item2))
                            {
                                continue;
                            }

                            var areAnyEngravingsSatisfied = desiredEngravingAmounts.Any(dea => dea - GetCurrentEngravingValueTotal(eC.Item1, eC.Item2, rC.Item1, rC.Item2) <= 8);

                            if (areAnyEngravingsSatisfied)
                            {
                                foreach (var necklace in necklaces)
                                {
                                    Permutation permutation = new Permutation(eC.Item1, eC.Item2, rC.Item1, rC.Item2, necklace);

                                    foreach (var desiredEngravings in allDesiredEngravings)
                                    {
                                        if (!DoesPermutationMatchDesiredEngravings(desiredEngravings, permutation))
                                        {
                                            permutationsThatMatchesDesiredEngravings.Add(permutation);
                                        }
                                    }
                                }
                            }
                        };
                        Trace.WriteLine($"Finishing a cominbation run took: {stopwatch.Elapsed}");
                        stopwatch.Stop();
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

        private List<(Accessory, Accessory)> GetEarringCombinations(List<Accessory> earrings)
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
                        // performance boosting
                        if (AreAccessoriesAreOverNegativeCap(earring, nextEarring))
                        {
                            usedIdCombinations.Add((earring.Id, nextEarring.Id));
                            continue;
                        }

                        earringCombinations.Add((earring, nextEarring));
                        usedIdCombinations.Add((earring.Id, nextEarring.Id));
                    }

                }
            }

            return earringCombinations;
        }

        private List<(Accessory, Accessory)> GetRingCombinations(List<Accessory> rings)
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
                        // performance boosting
                        if (AreAccessoriesAreOverNegativeCap(ring, nextRing))
                        {
                            usedIdCombinations.Add((ring.Id, nextRing.Id));
                            continue;
                        }

                        ringCombinations.Add((ring, nextRing));
                        usedIdCombinations.Add((ring.Id, nextRing.Id));
                    }
                }
            }

            return ringCombinations;
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

