using System;
using UnityEngine;

public static class MathConts
{
    const int ZERO = 0;
    private static readonly System.Random random = new System.Random();
    private static readonly object syncLock = new object();

    public static float GetPercentageOf(float value, float percentage) => RoundNumber((percentage / 100f) * value);
    public static float RoundNumber(float value, int houses = 1) => (float)Math.Round((Decimal)value, houses, MidpointRounding.AwayFromZero);
    public static float ProcessPercentage(float percentage, float value) => percentage > ZERO ? GetPercentageOf(value, percentage) : ZERO;
    //public static bool ProcessChance(float chance) => chance / 100f > GetRandomPercentage();
   public static bool ProcessChance(float chance, float inspiration, string Name)
    {
        Debug.Log("******************************");
        Debug.Log("Ability: " + Name);
        Debug.Log("Chance: " + chance);
        float per = GetRandomPercentage();
        Debug.Log("Percentage: " + per);
        Debug.Log("******************************");
        return ((inspiration + chance) / 100.0f) > 0; //per;
    }    
    public static float GetRandomPercentage() => (float)(Math.Truncate(RandomNumber() * 100) / 100);
    public static double RandomNumber()
    {
        lock (syncLock)
        { // synchronize
            return random.NextDouble();
        }
    }

    public static int RandomInt()
    {
        lock (syncLock)
        { // synchronize
            return random.Next();
        }
    }
    public static int RandomInt(int min, int max)
    {
        lock (syncLock)
        { // synchronize
            return random.Next(min, max);
        }
    }
    public static bool HalfChance() => RandomNumber() > 0.5;
}
