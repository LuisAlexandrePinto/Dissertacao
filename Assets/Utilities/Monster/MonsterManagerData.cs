using System;
using System.Collections.Generic;

[Serializable]
public class MonsterManagerData
{
    public List<MonsterData> MonsterData { get; private set; } = new List<MonsterData>();

    public MonsterManagerData(List<MonsterData> monsterData) => MonsterData = monsterData;
}
