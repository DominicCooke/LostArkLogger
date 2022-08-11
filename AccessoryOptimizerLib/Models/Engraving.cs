using System;
using System.Text.Json.Serialization;
using static AccessoryOptimizerLib.Services.PermutationService;

namespace AccessoryOptimizerLib.Models
{
    public class Engraving
    {
        [JsonPropertyName("engravingType")]
        public EngravingType EngravingType { get; set; }

        [JsonPropertyName("engravingValue")]
        public int EngravingValue { get; set; }

        public string EngravingName => PSO.EngravingList[Convert.ToUInt32(EngravingType)];

        public Engraving(int engravingType, int engravingValue)
        {
            EngravingType = (EngravingType)engravingType;
            EngravingValue = engravingValue;
        }

        [JsonConstructor]
        public Engraving(EngravingType engravingType, int engravingValue)
        {
            EngravingType = engravingType;
            EngravingValue = engravingValue;
        }
    }
}
