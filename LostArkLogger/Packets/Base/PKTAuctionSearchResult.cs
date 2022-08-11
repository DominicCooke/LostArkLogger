using AccessoryOptimizerLib.Models;
using System;
using System.Collections.Generic;

namespace LostArkLogger
{
    public partial class PKTAuctionSearchResult
    {
        public PKTAuctionSearchResult(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }

        public UInt64 ObjectId;
        public List<Accessory> Accessories;
    }
}
