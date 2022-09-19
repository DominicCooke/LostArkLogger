
using AccessoryOptimizerLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LostArkLogger
{
    public partial class PKTAuctionSearchResult
    {
        #region Network Fields Index
        /* 
         * All integral value are offset relative to payload
         * But when decoding we need relative offset of the previous offset
         */

        // Build 1.317.353.1852897 - 2022-09-08
        internal const int Header_Length = 14;
        private const int ItemId_Index = 27 - Header_Length;

        private const int Necklace_Length = 317 - Header_Length;
        private const int Earring_Or_Ring_Length = 288 - Header_Length;

        private const int ItemId_Bytes_Skipped_After = 64;

        // Example why relative is important
        private int PacketLength
        {
            get
            {
                return Header_Length
                    + (Accessories.Count(e => e.AccessoryType == AccessoryType.Necklace) * Necklace_Length)
                    + (Accessories.Count(e => e.AccessoryType != AccessoryType.Necklace) * Earring_Or_Ring_Length);
            }
        }

        #endregion

        public void SteamDecode(BitReader reader)
        {
            var startPosition = reader.Position;

            DecodeHeader(reader);

            while (reader.BitsLeft >= Earring_Or_Ring_Length * 8
                   || reader.BitsLeft >= Necklace_Length * 8)
            {
                DecodeAccessory(reader);
            }
        }

        public void DecodeHeader(BitReader reader)
        {
            var headerBytes = reader.ReadBytes(Header_Length);
            var arrayLength = headerBytes[4];

            Accessories = new List<Accessory>(arrayLength);
        }

        public void DecodeAccessory(BitReader reader)
        {
            var startAcessoryIndex = reader.Position;

            reader.Position += ItemId_Index * 8; // Because Position is in bits not bytes
            var itemId = BitConverter.ToInt32(reader.ReadBytes(4));

            (var accessoryType, var accessoryRank) = GetAccessoryTypeAndRank(itemId);

            (var stats1, var stats1_amount) = GetValueType(reader, startIndex: ItemId_Bytes_Skipped_After);

            if (accessoryType == null)
            {
                Debug.Assert(accessoryType == null);
            }

            int? stats2 = null, stats2_amount = null;
            if (accessoryType == AccessoryType.Necklace)
            {
                (stats2, stats2_amount) = GetValueType(reader, startIndex: 16);
            }

            (var negEngrave, var negEngrave_amount) = GetValueType(reader, startIndex: 16);
            (var engrave1, var engrave1_amount) = GetValueType(reader, startIndex: 16);
            (var engrave2, var engrave2_amount) = GetValueType(reader, startIndex: 16);

            reader.Position += 29 * 8; // Because Position is in bits not bytes
            var buyout = BitConverter.ToInt32(reader.ReadBytes(4));

            reader.Position += 12 * 8; // Because Position is in bits not bytes
            var initialBid = BitConverter.ToInt32(reader.ReadBytes(4));

            reader.Position += 4 * 8; // Because Position is in bits not bytes
            var currentBid = BitConverter.ToInt32(reader.ReadBytes(4));

            reader.Position += 36 * 8; // Because Position is in bits not bytes

            var result = accessoryType == AccessoryType.Necklace
                ? reader.Position == startAcessoryIndex + Necklace_Length * 8
                : reader.Position == startAcessoryIndex + Earring_Or_Ring_Length * 8;

            Stats stats;
            int quality;
            if (accessoryType == AccessoryType.Necklace)
            {
                stats = new Stats((Stat_Type)stats1, stats1_amount, (Stat_Type)(stats2.Value), stats2_amount.Value);
                quality = GetStatQuality(accessoryType.Value, accessoryRank.Value, stats1_amount, stats2_amount.Value);
            }
            else
            {
                stats = new Stats((Stat_Type)stats1, stats1_amount);
                quality = GetStatQuality(accessoryType.Value, accessoryRank.Value, stats1_amount);
            }

            var accessory = new Accessory(
                    accessoryType.Value,
                    accessoryRank.Value,
                    quality,
                    currentBid,
                    buyout,
                    new List<Engraving>
                    {
                        new Engraving(engrave1, engrave1_amount),
                        new Engraving(engrave2, engrave2_amount),
                    },
                    new Engraving(negEngrave, negEngrave_amount),
                    stats
                );

            Accessories.Add(accessory);
        }

        public static (int Type, int Value) GetValueType(BitReader reader, int startIndex = 0)
        {
            reader.Position += startIndex * 8; // Because Position is in bits not bytes

            var value = BitConverter.ToInt32(reader.ReadBytes(4));
            _ = reader.ReadBytes(5);
            var type = BitConverter.ToInt32(reader.ReadBytes(4));

            return (type, value);
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

        private int GetStatQuality(AccessoryType accessoryType, AccessoryRank accessoryRank, int statQuantity, int stat2Quantity = 0)
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
            {
                bool sus = true;
            }

            return (int)real;
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
