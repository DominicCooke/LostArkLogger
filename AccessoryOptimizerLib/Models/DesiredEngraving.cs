using System.Text.Json.Serialization;

namespace AccessoryOptimizerLib.Models
{
    public class DesiredEngraving
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("engravingType")]
        public EngravingType EngravingType { get; set; }

        public DesiredEngraving(int amount, EngravingType engravingType)
        {
            Amount = amount;
            EngravingType = engravingType;
        }
    }
}
