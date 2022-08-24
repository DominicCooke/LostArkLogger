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
        public long Duration { get; set; }

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
        public long DamageTaken { get; set; }

        [JsonPropertyName("isPlayer")]
        public bool IsPlayer { get; set; }
    }

    public class DamageStatistics
    {
        [JsonPropertyName("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        [JsonPropertyName("topDamageDealt")]
        public long TopDamageDealt { get; set; }

        [JsonPropertyName("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        [JsonPropertyName("topDamageTaken")]
        public long TopDamageTaken { get; set; }

        [JsonPropertyName("totalHealingDone")]
        public long TotalHealingDone { get; set; }

        [JsonPropertyName("topHealingDone")]
        public long TopHealingDone { get; set; }

        [JsonPropertyName("totalShieldDone")]
        public long TotalShieldDone { get; set; }

        [JsonPropertyName("topShieldDone")]
        public long TopShieldDone { get; set; }
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
        public object GearScore { get; set; }

        [JsonPropertyName("currentHp")]
        public long CurrentHp { get; set; }

        [JsonPropertyName("maxHp")]
        public long MaxHp { get; set; }

        [JsonPropertyName("damageDealt")]
        public long DamageDealt { get; set; }

        [JsonPropertyName("healingDone")]
        public long HealingDone { get; set; }

        [JsonPropertyName("shieldDone")]
        public long ShieldDone { get; set; }

        [JsonPropertyName("damageTaken")]
        public long DamageTaken { get; set; }
        
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
        public long TotalDamage { get; set; }

        [JsonPropertyName("maxDamage")]
        public long MaxDamage { get; set; }

        [JsonPropertyName("hits")]
        public Hits Hits { get; set; }
    }

    public class Hits
    {
        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("crit")]
        public long Crit { get; set; }

        [JsonPropertyName("backAttack")]
        public long BackAttack { get; set; }

        [JsonPropertyName("frontAttack")]
        public long FrontAttack { get; set; }

        [JsonPropertyName("counter")]
        public long Counter { get; set; }
    }
}

