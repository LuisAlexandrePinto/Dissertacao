using System;
using System.Collections.Generic;

[Serializable]
public class MonsterData
{
    public int SeenAmount { get; }
    public int Id { get; }
    public string Name { get; }
    public int Level { get; }
    public List<int> CatchesIds;
    public int CurrentCatchToEvolve { get; }
    public MonsterData(Monster monster)
    {
        Name = monster.MonsterName;
        Id = monster.Id;
        if (monster.Stats != null)
        {
            SeenAmount = monster.Stats.SeenAmount;
            CatchesIds = monster.Stats.CatchesIds;
            Level = monster.Stats.Level;
            CurrentCatchToEvolve = monster.Stats.CurrentCatchToEvolve;
        }
        else
        {
            SeenAmount = 0;
            CatchesIds = new List<int>();
            Level = 1;
            CurrentCatchToEvolve = 0;
        }
    }

}
