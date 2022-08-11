using System.Text.Json.Serialization;

namespace ParsedLogParser.Models
{
    public class ParsedLog
    {
        [JsonPropertyName("startedOn")]
        public object StartedOn { get; set; }

        [JsonPropertyName("lastCombatPacket")]
        public object LastCombatPacket { get; set; }

        [JsonPropertyName("fightStartedOn")]
        public object FightStartedOn { get; set; }

        [JsonPropertyName("entities")]
        public Dictionary<string, Entity> Entities { get; set; }

        [JsonPropertyName("damageStatistics")]
        public DamageStatistics DamageStatistics { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("mostDamageTakenEntity")]
        public DamageTakenEntity MostDamageTakenEntity { get; set; }

        public DateTime Date { get; set; }
        public string FileName { get; set; }
    }

    public class DamageTakenEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("damageTaken")]
        public int DamageTaken { get; set; }

        [JsonPropertyName("isPlayer")]
        public bool IsPlayer { get; set; }
    }

    public class DamageStatistics
    {
        [JsonPropertyName("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        [JsonPropertyName("topDamageDealt")]
        public int TopDamageDealt { get; set; }

        [JsonPropertyName("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        [JsonPropertyName("topDamageTaken")]
        public int TopDamageTaken { get; set; }

        [JsonPropertyName("totalHealingDone")]
        public int TotalHealingDone { get; set; }

        [JsonPropertyName("topHealingDone")]
        public int TopHealingDone { get; set; }

        [JsonPropertyName("totalShieldDone")]
        public int TotalShieldDone { get; set; }

        [JsonPropertyName("topShieldDone")]
        public int TopShieldDone { get; set; }
    }

    public class Entity
    {
        [JsonPropertyName("lastUpdate")]
        public long LastUpdate { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("class")]
        public string Class { get; set; }

        [JsonPropertyName("isPlayer")]
        public bool IsPlayer { get; set; }

        [JsonPropertyName("isDead")]
        public bool IsDead { get; set; }

        [JsonPropertyName("deathTime")]
        public object DeathTime { get; set; }

        [JsonPropertyName("gearScore")]
        public string GearScore { get; set; }

        [JsonPropertyName("currentHp")]
        public int CurrentHp { get; set; }

        [JsonPropertyName("maxHp")]
        public int MaxHp { get; set; }

        [JsonPropertyName("damageDealt")]
        public int DamageDealt { get; set; }

        [JsonPropertyName("healingDone")]
        public int HealingDone { get; set; }

        [JsonPropertyName("shieldDone")]
        public int ShieldDone { get; set; }

        [JsonPropertyName("damageTaken")]
        public int DamageTaken { get; set; }
        
        [JsonPropertyName("skills")]
        public Dictionary<string, Skill> Skills { get; set; }

        [JsonPropertyName("hits")]
        public Hits Hits { get; set; }
    }

    public class Skill
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("totalDamage")]
        public int TotalDamage { get; set; }

        [JsonPropertyName("maxDamage")]
        public int MaxDamage { get; set; }

        [JsonPropertyName("hits")]
        public Hits Hits { get; set; }
    }

    public class Hits
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("crit")]
        public int Crit { get; set; }

        [JsonPropertyName("backAttack")]
        public int BackAttack { get; set; }

        [JsonPropertyName("frontAttack")]
        public int FrontAttack { get; set; }

        [JsonPropertyName("counter")]
        public int Counter { get; set; }
    }
}

