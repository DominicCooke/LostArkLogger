/*
using Google.OrTools.Sat;
using AccessoryOptimizerLib.Models;
using Google.Protobuf.Collections;
using System.Collections.Concurrent;

namespace AccessoryOptimizerLib.Services
{
    public class PermutationServiceV2
    {
        public List<Accessory> _necklaces = new();
        public List<Accessory> _earrings = new();
        public List<Accessory> _rings = new();

        public List<Permutation> Process(List<List<DesiredEngraving>> allDesiredEngravings)
        {
            List<Permutation> permutations = new();

            foreach (var desiredEngravings in allDesiredEngravings)
            {
                CpModel model = new();

                // VARIABLES
                List<IntVar> necklaceIntVars = new();

                for (int i = 0; i < _necklaces.Count; i++)
                {
                    necklaceIntVars.Add(model.NewIntVar(0, 1, $"necklace{i}"));
                }

                List<IntVar> earringIntVars = new();

                for (int i = 0; i < _earrings.Count; i++)
                {
                    earringIntVars.Add(model.NewIntVar(0, 1, $"earring{i}"));
                }

                List<IntVar> ringIntVars = new();

                for (int i = 0; i < _rings.Count; i++)
                {
                    ringIntVars.Add(model.NewIntVar(0, 1, $"ring{i}"));
                }

                // CONSTRAINTS
                model.Add(LinearExpr.Sum(necklaceIntVars) == 1);
                model.Add(LinearExpr.Sum(earringIntVars) == 2);
                model.Add(LinearExpr.Sum(ringIntVars) == 2);

                foreach (DesiredEngraving desiredEngraving in desiredEngravings)
                {
                    model.Add(GetSumOfEngravingType(desiredEngraving.EngravingType) >= desiredEngraving.Amount);
                }

                // SOLVER + SOLVE
                CpSolver solver = new CpSolver();
                solver.StringParameters = "enumerate_all_solutions:true";

                PermutationSolutionCallback permutationSolutionCallback = new PermutationSolutionCallback(_necklaces, _earrings, _rings);

                CpSolverStatus status = solver.Solve(model, permutationSolutionCallback);

                permutations.AddRange(permutationSolutionCallback.permutations);

                LinearExpr GetSumOfEngravingType(EngravingType engravingType)
                {
                    List<LinearExpr> linearExprs = new List<LinearExpr>();

                    for (int i = 0; i < necklaceIntVars.Count; i++)
                    {
                        linearExprs.Add(necklaceIntVars[i] * ((_necklaces[i].Engravings.FirstOrDefault(e => e.EngravingType == engravingType)?.EngravingValue) ?? 0));
                    }

                    for (int i = 0; i < earringIntVars.Count; i++)
                    {
                        linearExprs.Add(earringIntVars[i] * ((_earrings[i].Engravings.FirstOrDefault(e => e.EngravingType == engravingType)?.EngravingValue) ?? 0));
                    }

                    for (int i = 0; i < ringIntVars.Count; i++)
                    {
                        linearExprs.Add(ringIntVars[i] * ((_rings[i].Engravings.FirstOrDefault(e => e.EngravingType == engravingType)?.EngravingValue) ?? 0));
                    }

                    return LinearExpr.Sum(linearExprs);
                }
            }

            return permutations;

            //LinearExpr GetSumOfCost()
            //{
            //    List<LinearExpr> a = new List<LinearExpr>();
            //
            //    for (int i = 0; i < necklaceIntVars.Count; i++)
            //    {
            //        a.Add(necklaceIntVars[i] * necklaces[i].BuyNowPrice);
            //    }
            //
            //    for (int i = 0; i < earringIntVars.Count; i++)
            //    {
            //        a.Add(earringIntVars[i] * earrings[i].BuyNowPrice);
            //    }
            //
            //    for (int i = 0; i < ringIntVars.Count; i++)
            //    {
            //        a.Add(ringIntVars[i] * rings[i].BuyNowPrice);
            //    }
            //
            //    return LinearExpr.Sum(a);
            //}
        }
    }

    public class PermutationSolutionCallback : CpSolverSolutionCallback
    {
        private List<Accessory> _necklaces;
        private List<Accessory> _earrings;
        private List<Accessory> _rings;

        public List<Permutation> permutations = new();

        public PermutationSolutionCallback(List<Accessory> necklaces, List<Accessory> earrings, List<Accessory> rings)
        {
            _necklaces = necklaces;
            _earrings = earrings;
            _rings = rings;
        }

        public override void OnSolutionCallback()
        {
            RepeatedField<long> solution = Response().Solution;

            List<long> necklaceIndexes = solution.Take(_necklaces.Count).ToList();

            int necklaceIndex = necklaceIndexes.FindIndex(i => i == 1);

            List<long> earringIndexes = solution.Skip(_necklaces.Count).Take(_earrings.Count).ToList();

            int earring1Index = earringIndexes.FindIndex(i => i == 1);
            int earring2Index = earringIndexes.FindLastIndex(i => i == 1);

            List<long> ringsIndexes = solution.Skip(_necklaces.Count + _earrings.Count).Take(_rings.Count).ToList();

            int ring1Index = ringsIndexes.FindIndex(i => i == 1);
            int ring2Index = ringsIndexes.FindLastIndex(i => i == 1);

            Accessory earring1 = _earrings[earring1Index];
            Accessory earring2 = _earrings[earring2Index];

            Accessory ring1 = _rings[ring1Index];
            Accessory ring2 = _rings[ring2Index];

            Accessory necklace = _necklaces[necklaceIndex];
            permutations.Add(new Permutation(earring1, earring2, ring1, ring2, necklace));
        }
    }
}
*/