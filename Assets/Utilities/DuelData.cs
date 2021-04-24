using System;

[Serializable]
public class DuelData
{
    public DuelData(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
        SpawnTime = DateTime.UtcNow;
    }

    public float X { get; internal set; }
    public float Y { get; internal set; }
    public float Z { get; internal set; }
    public DateTime SpawnTime { get; internal set; }
}
