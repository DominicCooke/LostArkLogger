using AccessoryOptimizer.Models;


Main();

void Main()
{
    bool workOutNecklace = true;
    if(workOutNecklace)
    {
        WorkoutNecklace();
    }

    bool workOutEarring = false;

    if(workOutEarring)
    {
        WorkoutEarring();
    }
}

void WorkoutNecklace()
{
    byte[] necklaceBytes = GetNecklaceData();
    necklaceBytes = RemoveFromByteArray(necklaceBytes, 14);

    byte[] buyout = GetValue(249999);
    byte[] bid = GetValue(199999);

    byte[] engraving1 = GetValue((int)EngravingType.Demonic_Impulse);
    byte[] engraving1Quantity = GetValue(5);

    byte[] engraving2 = GetValue((int)EngravingType.Grudge);
    byte[] engraving2Quantity = GetValue(3);

    byte[] statType1 = GetValue((int)Stat_Type.Crit);
    byte[] statType1Quantity = GetValue(498);

    byte[] statType2 = GetValue((int)Stat_Type.Specialization);
    byte[] statType2Quantity = GetValue(454);

    byte[] negativeEngravingType = GetValue((int)EngravingType.Move_Speed_Reduction);
    byte[] negativeEngravingQuantity = GetValue(2);

    byte[] itemId = GetValue(213300030);

    var buyout_byteToStart = Search(necklaceBytes, buyout.Reverse().ToArray());
    Console.WriteLine($"Buyout: {buyout_byteToStart}");
    var bid_byteToStart = Search(necklaceBytes, bid.Reverse().ToArray());
    Console.WriteLine($"Bid: {bid_byteToStart}");

    var engraving1_byteToStart = Search(necklaceBytes, engraving1.Reverse().ToArray());
    var engraving1Quantity_byteToStart = engraving1_byteToStart + 5;
    Console.WriteLine($"Engraving Type 1: {engraving1_byteToStart}");
    Console.WriteLine($"Engraving Quantity 1: {engraving1Quantity_byteToStart}");

    var engraving2_byteToStart = Search(necklaceBytes, engraving2.Reverse().ToArray());
    var engraving2Quantity_byteToStart = engraving2_byteToStart + 5;
    Console.WriteLine($"Engraving Type 2: {engraving2_byteToStart}");
    Console.WriteLine($"Engraving Quantity 2: {engraving2Quantity_byteToStart}");

    var statType1_byteToStart = Search(necklaceBytes, statType1.Reverse().ToArray());
    var statType1Quantity_byteToStart = Search(necklaceBytes, statType1Quantity.Reverse().ToArray());
    Console.WriteLine($"Stat Type 1: {statType1_byteToStart}");
    Console.WriteLine($"Stat Quantity 1: {statType1Quantity_byteToStart}");

    var statType2_byteToStart = Search(necklaceBytes, statType2.Reverse().ToArray());
    var statType2Quantity_byteToStart = Search(necklaceBytes, statType2Quantity.Reverse().ToArray());
    Console.WriteLine($"Stat Type 2: {statType2_byteToStart}");
    Console.WriteLine($"Stat Quantity 2: {statType2Quantity_byteToStart}");

    var negativeEngravingType_byteToStart = Search(necklaceBytes, negativeEngravingType.Reverse().ToArray());
    var negativeEngravingQuantity_byteToStart = negativeEngravingType_byteToStart + 9;
    Console.WriteLine($"Neg Engraving Type: {negativeEngravingType_byteToStart}");
    Console.WriteLine($"Neg Engraving Quantity: {negativeEngravingQuantity_byteToStart}");

    var itemId_byteToStart = Search(necklaceBytes, itemId.Reverse().ToArray());
    Console.WriteLine($"Item ID: {itemId_byteToStart}");
}

void WorkoutEarring()
{
    byte[] earringBytes = GetEarringData();
    earringBytes = RemoveFromByteArray(earringBytes, 14);

    byte[] buyout = GetValue(45000);
    byte[] bid = GetValue(35000);

    byte[] engraving1 = GetValue((int)EngravingType.Demonic_Impulse);
    byte[] engraving1Quantity = GetValue(3);

    byte[] engraving2 = GetValue((int)EngravingType.Grudge);
    byte[] engraving2Quantity = GetValue(3);

    byte[] statType1 = GetValue((int)Stat_Type.Specialization);
    byte[] statType1Quantity = GetValue(191);

    byte[] negativeEngravingType = GetValue((int)EngravingType.Defence_Reduction);
    byte[] negativeEngravingQuantity = GetValue(3);

    byte[] itemId = GetValue(213300042);

    var buyout_byteToStart = Search(earringBytes, buyout.Reverse().ToArray());
    Console.WriteLine($"Buyout: {buyout_byteToStart}");
    var bid_byteToStart = Search(earringBytes, bid.Reverse().ToArray());
    Console.WriteLine($"Bid: {bid_byteToStart}");

    var engraving1_byteToStart = Search(earringBytes, engraving1.Reverse().ToArray());
    var engraving1Quantity_byteToStart = engraving1_byteToStart + 5;
    Console.WriteLine($"Engraving Type 1: {engraving1_byteToStart}");
    Console.WriteLine($"Engraving Quantity 1: {engraving1Quantity_byteToStart}");

    var engraving2_byteToStart = Search(earringBytes, engraving2.Reverse().ToArray());
    var engraving2Quantity_byteToStart = engraving2_byteToStart + 5;
    Console.WriteLine($"Engraving Type 2: {engraving2_byteToStart}");
    Console.WriteLine($"Engraving Quantity 2: {engraving2Quantity_byteToStart}");

    var statType1_byteToStart = Search(earringBytes, statType1.Reverse().ToArray());
    var statType1Quantity_byteToStart = Search(earringBytes, statType1Quantity.Reverse().ToArray());
    Console.WriteLine($"Stat Type 1: {statType1_byteToStart}");
    Console.WriteLine($"Stat Quantity 1: {statType1Quantity_byteToStart}");

    var negativeEngravingType_byteToStart = Search(earringBytes, negativeEngravingType.Reverse().ToArray());
    var negativeEngravingQuantity_byteToStart = negativeEngravingType_byteToStart + 9;
    Console.WriteLine($"Neg Engraving Type: {negativeEngravingType_byteToStart}");
    Console.WriteLine($"Neg Engraving Quantity: {negativeEngravingQuantity_byteToStart}");

    var itemId_byteToStart = Search(earringBytes, itemId.Reverse().ToArray());
    Console.WriteLine($"Item ID: {itemId_byteToStart}");
}

byte[] RemoveFromByteArray(byte[] src, int amountToDelete)
{
    byte[] dst = new byte[src.Length - amountToDelete];

    Array.Copy(src, amountToDelete, dst, 0, dst.Length);

    return dst;
}

int Search(byte[] src, byte[] pattern)
{
    int maxFirstCharSlot = src.Length - pattern.Length + 1;
    for (int i = 0; i < maxFirstCharSlot; i++)
    {
        if (src[i] != pattern[0]) // compare only first byte
            continue;

        // found a match on first byte, now try to match rest of the pattern
        for (int j = pattern.Length - 1; j >= 1; j--)
        {
            if (src[i + j] != pattern[j]) break;
            if (j == 1) return i;
        }
    }
    return -1;
}

byte[] GetValue(int intValue)
{
    byte[] intBytes = BitConverter.GetBytes(intValue);
    Array.Reverse(intBytes);
    byte[] result = intBytes;
    return result;
}

byte[] GetValue16(Int16 intValue)
{
    byte[] intBytes = BitConverter.GetBytes(intValue);
    Array.Reverse(intBytes);
    byte[] result = intBytes;
    return result;
}

uint GetInt16Value(byte[] bytes)
{
    Array.Reverse(bytes);
    uint intValue = BitConverter.ToUInt16(bytes, 0);
    return intValue;
}

uint GetInt32Value(byte[] bytes)
{
    Array.Reverse(bytes);
    uint intValue = BitConverter.ToUInt32(bytes, 0);
    return intValue;
}

long GetInt64Value(byte[] bytes)
{
    Array.Reverse(bytes);
    long intValue = BitConverter.ToInt64(bytes, 0);
    return intValue;
}

byte[] GetNecklaceData()
{
    return new byte[] { 1, 0, 0, 0, 20, 50, 5, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 180, 130, 190, 4, 0, 0, 32, 28, 62, 179, 182, 12, 0, 0, 65, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 31, 24, 108, 23, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 16, 0, 0, 0, 144, 1, 0, 0, 2, 110, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 198, 1, 0, 0, 244, 1, 0, 0, 15, 0, 0, 0, 144, 1, 0, 0, 2, 110, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 242, 1, 0, 0, 244, 1, 0, 0, 35, 3, 0, 0, 1, 0, 0, 0, 3, 105, 0, 0, 0, 3, 8, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 25, 1, 0, 0, 5, 0, 0, 0, 3, 105, 0, 0, 0, 2, 8, 147, 1, 1, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 118, 0, 0, 0, 3, 0, 0, 0, 3, 105, 0, 0, 0, 1, 8, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 63, 13, 3, 0, 0, 0, 0, 0, 0, 63, 13, 3, 0, 0, 0, 0, 0, 0, 16, 39, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 143, 208, 3, 0, 0, 0, 0, 0, 230, 135, 196, 5, 177, 102, 0, 0, 173, 189, 81, 5, 0, 0, 0, 0 };
}

byte[] GetEarringData()
{
    return new byte[] { 1, 0, 0, 0, 20, 50, 5, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 167, 95, 40, 2, 0, 0, 64, 60, 74, 179, 182, 12, 0, 0, 8, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 31, 24, 108, 23, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 16, 0, 0, 0, 160, 0, 0, 0, 2, 210, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 191, 0, 0, 0, 200, 0, 0, 0, 33, 3, 0, 0, 1, 0, 0, 0, 3, 105, 0, 0, 0, 3, 4, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 25, 1, 0, 0, 3, 0, 0, 0, 3, 105, 0, 0, 0, 2, 4, 147, 1, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 118, 0, 0, 0, 3, 0, 0, 0, 3, 105, 0, 0, 0, 1, 4, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 184, 136, 0, 0, 0, 0, 0, 0, 0, 184, 136, 0, 0, 0, 0, 0, 0, 0, 214, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 200, 175, 0, 0, 0, 0, 0, 0, 230, 135, 68, 218, 199, 181, 0, 0, 4, 163, 83, 5, 0, 0, 0, 0 };
}
