using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AccessoryOptimizerLib.Models
{
    public class DesiredEngravings
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        [JsonPropertyName("engravings")]
        public List<DesiredEngraving> Engravings { get; set; } = new List<DesiredEngraving>(); 
    }

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
