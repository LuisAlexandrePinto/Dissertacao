
using System;

[Serializable]
public class MonsterLocationData
{
    public MonsterLocationData(float x, float y, float z, string name, int id)
    {        
        X = x;
        Y = y;
        Z = z;
        Name = name;
        SpawnTime = DateTime.UtcNow;
        Id = id;
    }
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public string Name { get; private set; }
    public DateTime SpawnTime { get; private set; }
    public int Id { get; private set; }
    public bool ToBeCatched { get; set; } = false;
}