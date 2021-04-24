using System;
using System.Collections.Generic;

public static class MonsterRng
{
    private static readonly List<int> idNumbers = new List<int>();
    private static readonly int min = 0, max = 10000;
    
    public static int GenerateNumber()
    {
        Random rng = new Random();
        for (; ; )
        {
            int id;
            id = rng.Next(min, max+1);
            if (!idNumbers.Contains(id))
            {
                idNumbers.Add(id);
                return id;
            }
        }
    }

    public static void AddIds(List<int> ids) => idNumbers.AddRange(ids);
}
