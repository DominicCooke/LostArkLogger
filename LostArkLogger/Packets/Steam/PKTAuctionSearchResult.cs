using AccessoryOptimizerLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LostArkLogger
{
    public partial class PKTAuctionSearchResult
    {
        #region Network Fields Index

        // Build 1.331.367.1873750 - 2022-09-28
        internal const int Header_Length = 14;

        private const int Item_Id = 73 - Header_Length;
        
        private const int Necklace_Length = 317 - Header_Length;
        private const int Necklace_Stat_1_Type = 142;
        private const int Necklace_Stat_1_Value = Necklace_Stat_1_Type + 8;
        private const int Necklace_Stat_2_Type = 171;
        private const int Necklace_Stat_2_Value = Necklace_Stat_2_Type + 8;
        private const int Necklace_Engrav_1_Type = 229;
        private const int Necklace_Engrav_1_Value = Necklace_Engrav_1_Type + 8;
        private const int Necklace_Engrav_2_Type = 258;
        private const int Necklace_Engrav_2_Value = Necklace_Engrav_2_Type + 8;
        private const int Necklace_Neg_Engrave_Type = 200;
        private const int Necklace_Neg_Engrave_Value = Necklace_Neg_Engrave_Type + 8;
        private const int Necklace_Initial_Bid = 23;
        private const int Necklace_Current_Bid = 283;
        private const int Necklace_Buyout = 31;

        private const int Ring_Length = 288 - Header_Length;
        private const int Ring_Stat_1_Type = 142;
        private const int Ring_Stat_1_Value = Ring_Stat_1_Type + 8;
        private const int Ring_Engrav_1_Type = 200;
        private const int Ring_Engrav_1_Value = Ring_Engrav_1_Type + 8;
        private const int Ring_Engrav_2_Type = 229;
        private const int Ring_Engrav_2_Value = Ring_Engrav_2_Type + 8;
        private const int Ring_Neg_Engrave_Type = 171;
        private const int Ring_Neg_Engrave_Value = Ring_Neg_Engrave_Type + 8;
        private const int Ring_Initial_Bid = 23;
        private const int Ring_Current_Bid = 254;
        private const int Ring_Buyout = 31;
                
        #endregion

        public void SteamDecode(BitReader reader)
        {
            DecodeHeader(reader);

            while (reader.BitsLeft >= Necklace_Length * 8 
                   || reader.BitsLeft >= Ring_Length * 8)
            {
                var itemOffset = reader.Position / 8; // Because Position is in bits

                var itemId = GetValueInt32(reader, itemOffset + Item_Id);

                // Set position backward because itemId belong to item struct
                reader.Position = itemOffset * 8; // Still in bits so let's multiply by 8

                (var accType, var accRank) = GetAccessoryTypeAndRank(itemId);

                if (!accType.HasValue)
                {
                    Trace.WriteLine($"ItemId {itemId} is not known.");
                    
                    var remainingBytes = reader.BitsLeft / 8;
                    var data = reader.ReadBytes(remainingBytes);
                    Trace.WriteLine($"Bytes: {string.Join(", ", data)}");

                    // If not item is not an accessory, array is not parsed correctly.
                    reader.Position = 0;
                    return;
                }
                else if (accType == AccessoryType.Necklace)
                {
                    var acc = GetNecklace(reader, accType.Value, accRank.Value);
                    Accessories.Add(acc);
                }
                else if (accType == AccessoryType.Ring
                        || accType == AccessoryType.Earring)
                {
                    var acc = GetEarringOrRing(reader, accType.Value, accRank.Value);
                    Accessories.Add(acc);
                }
            }

            if (reader.BitsLeft != 0) Debug.Assert(reader.BitsLeft != 0);
        }

        private void DecodeHeader(BitReader reader)
        {
            var headerBytes = reader.ReadBytes(Header_Length);
            var arrayLength = headerBytes[0];

            Accessories = new List<Accessory>(arrayLength);
        }

        private static Accessory GetNecklace(BitReader reader, AccessoryType accessoryType, AccessoryRank accessoryRank)
        {
            var beginOffset = reader.Position / 8; // Because Position is in bits

            var stat1_type = GetValueInt32(reader, beginOffset + Necklace_Stat_1_Type);
            var stat1_value = GetValueInt32(reader, beginOffset + Necklace_Stat_1_Value);
            var stat2_type = GetValueInt32(reader, beginOffset + Necklace_Stat_2_Type);
            var stat2_value = GetValueInt32(reader, beginOffset + Necklace_Stat_2_Value);
            var engrav1_type = GetValueInt32(reader, beginOffset + Necklace_Engrav_1_Type);
            var engrav1_value = GetValueInt32(reader, beginOffset + Necklace_Engrav_1_Value);
            var engrav2_type = GetValueInt32(reader, beginOffset + Necklace_Engrav_2_Type);
            var engrav2_value = GetValueInt32(reader, beginOffset + Necklace_Engrav_2_Value);
            var neg_engrav_type = GetValueInt32(reader, beginOffset + Necklace_Neg_Engrave_Type);
            var neg_engrav_value = GetValueInt32(reader, beginOffset + Necklace_Neg_Engrave_Value);
            var initialBid = GetValueInt32(reader, beginOffset + Necklace_Initial_Bid);
            var currentBid = GetValueInt32(reader, beginOffset + Necklace_Current_Bid);
            var buyout = GetValueInt32(reader, beginOffset + Necklace_Buyout);

            var stats = new Stats((Stat_Type)stat1_type, stat1_value, (Stat_Type)(stat2_type), stat2_value);
            var quality = GetStatQuality(accessoryType, accessoryRank, stat1_value, stat2_value);

            var accessory = new Accessory(
                accessoryType,
                accessoryRank,
                quality,
                currentBid,
                buyout,
                new List<Engraving>
                {
                    new Engraving(engrav1_type, engrav1_value),
                    new Engraving(engrav2_type, engrav2_value),
                },
                new Engraving(neg_engrav_type, neg_engrav_value),
                stats
            );

            reader.Position = (beginOffset + Necklace_Length) * 8;

            return accessory;
        }

        private static Accessory GetEarringOrRing(BitReader reader, AccessoryType accessoryType, AccessoryRank accessoryRank)
        {
            var beginOffset = reader.Position / 8; // Because Position is in bits

            var stat1_type = GetValueInt32(reader, beginOffset + Ring_Stat_1_Type);
            var stat1_value = GetValueInt32(reader, beginOffset + Ring_Stat_1_Value);
            var engrav1_type = GetValueInt32(reader, beginOffset + Ring_Engrav_1_Type);
            var engrav1_value = GetValueInt32(reader, beginOffset + Ring_Engrav_1_Value);
            var engrav2_type = GetValueInt32(reader, beginOffset + Ring_Engrav_2_Type);
            var engrav2_value = GetValueInt32(reader, beginOffset + Ring_Engrav_2_Value);
            var neg_engrav_type = GetValueInt32(reader, beginOffset + Ring_Neg_Engrave_Type);
            var neg_engrav_value = GetValueInt32(reader, beginOffset + Ring_Neg_Engrave_Value);
            var initialBid = GetValueInt32(reader, beginOffset + Ring_Initial_Bid);
            var currentBid = GetValueInt32(reader, beginOffset + Ring_Current_Bid);
            var buyout = GetValueInt32(reader, beginOffset + Ring_Buyout);

            var stats = new Stats((Stat_Type)stat1_type, stat1_value);
            var quality = GetStatQuality(accessoryType, accessoryRank, stat1_value);

            var accessory = new Accessory(
                accessoryType,
                accessoryRank,
                quality,
                currentBid,
                buyout,
                new List<Engraving>
                {
                    new Engraving(engrav1_type, engrav1_value),
                    new Engraving(engrav2_type, engrav2_value),
                },
                new Engraving(neg_engrav_type, neg_engrav_value),
                stats
            );

            reader.Position = (beginOffset + Ring_Length) * 8;

            return accessory;
        }

        private static int GetValueInt32(BitReader reader, int absolutePosition)
        {
            reader.Position = absolutePosition * 8;
            return BitConverter.ToInt32(reader.ReadBytes(4));
        }

        private static int GetStatQuality(AccessoryType accessoryType, AccessoryRank accessoryRank, int statQuantity, int stat2Quantity = 0)
        {
            decimal real = 0;
            int actualStat;
            switch (accessoryType)
            {
                case AccessoryType.Ring:
                    if (accessoryRank == AccessoryRank.Legendary)
                    {
                        actualStat = statQuantity - 130;
                        real = (decimal)(actualStat / 0.5);
                    }
                    else if (accessoryRank == AccessoryRank.Relic)
                    {
                        actualStat = statQuantity - 160;
                        real = (decimal)(actualStat / 0.4);
                    }
                    break;
                case AccessoryType.Earring:
                    if (accessoryRank == AccessoryRank.Legendary)
                    {
                        actualStat = statQuantity - 195;
                        real = (decimal)(actualStat / 0.75);
                    }
                    else if (accessoryRank == AccessoryRank.Relic)
                    {
                        actualStat = statQuantity - 240;
                        real = (decimal)(actualStat / 0.6);
                    }
                    break;
                case AccessoryType.Necklace:
                    if (accessoryRank == AccessoryRank.Legendary)
                    {
                        actualStat = statQuantity + stat2Quantity - 650;
                        real = (decimal)(actualStat / 2.5);
                    }
                    else if (accessoryRank == AccessoryRank.Relic)
                    {
                        actualStat = statQuantity + stat2Quantity - 800;
                        real = (decimal)(actualStat / 2);
                    }
                    break;
            }
            real = Math.Round(real);
            
            if (real > 100 || real < 0)
                Debug.Assert(real > 100 || real < 0, "Quality calculation is wrong");

            return (int)real;
        }

        private static (AccessoryType?, AccessoryRank?) GetAccessoryTypeAndRank(int itemId)
        {
            AccessoryType? accessoryType = null;
            AccessoryRank? accessoryRank = null;

            switch ((EarringItemIds)itemId)
            {
                case EarringItemIds.Radiant_Destroyer_Earrings:
                case EarringItemIds.Radiant_Inquirer_Earrings:
                case EarringItemIds.Corrupted_Space_Earrings:
                case EarringItemIds.Corrupted_Time_Earrings:
                case EarringItemIds.Wailing_Chaos_Earrings:
                case EarringItemIds.Wailing_Aeon_Earrings:
                    {
                        accessoryType = AccessoryType.Earring;
                        accessoryRank = AccessoryRank.Relic;
                    }
                    break;

                case EarringItemIds.Splendid_Destroyer_Earring:
                case EarringItemIds.Splendid_Inquirer_Earring:
                case EarringItemIds.Twisted_Space_Earring:
                case EarringItemIds.Twisted_Time_Earring:
                case EarringItemIds.Fallen_Chaos_Earring:
                case EarringItemIds.Fallen_Aeon_Earring:
                    {
                        accessoryType = AccessoryType.Earring;
                        accessoryRank = AccessoryRank.Legendary;
                    }
                    break;
            }

            switch ((RingItemIds)itemId)
            {
                case RingItemIds.Radiant_Destroyer_Ring:
                case RingItemIds.Radiant_Inquirer_Ring:
                case RingItemIds.Corrupted_Space_Ring:
                case RingItemIds.Corrupted_Time_Ring:
                case RingItemIds.Wailing_Chaos_Ring:
                case RingItemIds.Wailing_Aeon_Ring:
                    {
                        accessoryType = AccessoryType.Ring;
                        accessoryRank = AccessoryRank.Relic;
                    }
                    break;
            
                case RingItemIds.Splendid_Destroyer_Ring:
                case RingItemIds.Splendid_Inquirer_Ring:
                case RingItemIds.Twisted_Space_Ring:
                case RingItemIds.Twisted_Time_Ring:
                case RingItemIds.Fallen_Chaos_Ring:
                case RingItemIds.Fallen_Aeon_Ring:
                    {
                        accessoryType = AccessoryType.Ring;
                        accessoryRank = AccessoryRank.Legendary;
                    }
                    break;
            }

            switch ((NecklaceItemIds)itemId)
            {
                case NecklaceItemIds.Radiant_Inquirer_Necklace:
                case NecklaceItemIds.Corrupted_Time_Necklace:
                case NecklaceItemIds.Wailing_Chaos_Necklace:
                    {
                        accessoryType = AccessoryType.Necklace;
                        accessoryRank = AccessoryRank.Relic;
                    }
                    break;

                case NecklaceItemIds.Splendid_Inquirer_Necklace:
                case NecklaceItemIds.Twisted_Time_Necklace:
                case NecklaceItemIds.Fallen_Chaos_Necklace:
                    {
                        accessoryType = AccessoryType.Necklace;
                        accessoryRank = AccessoryRank.Legendary;
                    }
                    break;
            }

            return (accessoryType, accessoryRank);
        }

        #region EarringItemIds

        public enum EarringItemIds
        {
            // relic
            Radiant_Destroyer_Earrings = 213300061,
            Radiant_Inquirer_Earrings = 213300051,
            Corrupted_Space_Earrings = 213300021,
            Corrupted_Time_Earrings = 213300011,
            Wailing_Chaos_Earrings = 213300031,
            Wailing_Aeon_Earrings = 213300041,

            // legendary
            Splendid_Destroyer_Earring = 213200061,
            Splendid_Inquirer_Earring = 213200051,
            Twisted_Space_Earring = 213200021,
            Twisted_Time_Earring = 213200011,
            Fallen_Chaos_Earring = 213200031,
            Fallen_Aeon_Earring = 213200041
        }

        #endregion

        #region RingItemIds

        public enum RingItemIds
        {
            // relic
            Radiant_Destroyer_Ring = 213300062,
            Radiant_Inquirer_Ring = 213300052,
            Corrupted_Space_Ring = 213300022,
            Corrupted_Time_Ring = 213300012,
            Wailing_Chaos_Ring = 213300032,
            Wailing_Aeon_Ring = 213300042,

            // legendary
            Splendid_Destroyer_Ring = 213200062,
            Splendid_Inquirer_Ring = 213200052,
            Twisted_Space_Ring = 213200022,
            Twisted_Time_Ring = 213200012,
            Fallen_Chaos_Ring = 213200032,
            Fallen_Aeon_Ring = 213200042
        }

        #endregion

        #region NecklaceItemIds

        public enum NecklaceItemIds
        {
            // relic
            Radiant_Inquirer_Necklace = 213300050,
            Corrupted_Time_Necklace = 213300010,
            Wailing_Chaos_Necklace = 213300030,

            // legendary
            Splendid_Inquirer_Necklace = 213200050,
            Twisted_Time_Necklace = 213200010,
            Fallen_Chaos_Necklace = 213200030,
        }

        #endregion
        
    }
}
