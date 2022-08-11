using System.Collections.Generic;
using System.Linq;

namespace AccessoryOptimizerLib.Models
{
    public class NegativeSummary
    {
        public int AmountOfMoveSpeed = 0;
        public int AmountOfAtkSpeed = 0;
        public int AmountOfAtkPower = 0;
        public int AmountOfDefenceReduction = 0;
        public int LowestValue;

        public decimal AverageNegativeValue => (AmountOfAtkPower + AmountOfDefenceReduction + AmountOfAtkSpeed + AmountOfMoveSpeed) / 4;

        public bool IsThereWorryingNegativeEngraving()
        {
            return AmountOfMoveSpeed > 4
            || AmountOfAtkPower > 4
            || AmountOfDefenceReduction > 4
            || AmountOfAtkSpeed > 4;
        }

        public bool HasEngravingAtZero()
        {
            return AmountOfMoveSpeed == 0
            || AmountOfAtkPower == 0
            || AmountOfDefenceReduction == 0
            || AmountOfAtkSpeed == 0;
        }

        public NegativeSummary(List<Accessory> accessories)
        {
            foreach (var accessory in accessories)
            {
                if (accessory != null)
                {
                    switch (accessory.NegativeEngraving.EngravingType)
                    {
                        case EngravingType.Move_Speed_Reduction:
                            AmountOfMoveSpeed += accessory.NegativeEngraving.EngravingValue;
                            break;
                        case EngravingType.Atk_Speed_Reduction:
                            AmountOfAtkSpeed += accessory.NegativeEngraving.EngravingValue;
                            break;
                        case EngravingType.Atk_Power_Reduction:
                            AmountOfAtkPower += accessory.NegativeEngraving.EngravingValue;
                            break;
                        case EngravingType.Defence_Reduction:
                            AmountOfDefenceReduction += accessory.NegativeEngraving.EngravingValue;
                            break;
                    }
                }
            }

            LowestValue = new List<int>() { AmountOfAtkPower, AmountOfAtkSpeed, AmountOfDefenceReduction, AmountOfMoveSpeed }.Min();
        }
    }
}