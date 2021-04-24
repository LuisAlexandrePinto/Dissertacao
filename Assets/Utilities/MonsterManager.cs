using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private List<Monster> monsters;
#pragma warning restore 0649
    public List<Monster> Monsters { get => monsters; }
    public Monster ToCatch { get; private set; }
    public void AddCatchedMonster()
    {
        Catching catching = GameManager.Instance.Catching;
        if (catching.MonsterNameToCatch.Length > 0)
        {
            GetMonsterByName(catching.MonsterNameToCatch).Stats.AddId(catching.MonsterToCatchId);
            TotalCaught++;
        }
    }

    public void IncrementNonCaptured() => TotalNonCaptured++;
    public void IncrementSeenOnMonster(Monster seen)
    {
        if (seen != null)
        {
            Monster monster = GetMonsterByName(seen.MonsterName);
            monster.Stats.IncrementSeen();
            TotalSaw++;
        }
    }
    public Monster GetRandomMonster() => monsters[Random.Range(0, monsters.Count)];
    public Monster GetMonsterByName(string name) => name != null ? monsters.Find(monster => monster.MonsterName.Equals(name)) : null;
    public List<Monster> GetMonstersByRarity(MonsterRarity rarity) => monsters.FindAll(monster => monster.GetRarity == rarity);

    public int TotalCaught { get; private set; } = 0;
    public int TotalSaw { get; private set; } = 0;
    public int TotalNonCaptured { get; private set; } = 0;
    public int UpdateManyCaught() => TotalCaught = monsters.FindAll(monster => monster.Stats.Catched).Count;
    public int HowManyCaught(MonsterRarity rarity) => monsters.Sum(monster => monster.GetRarity == rarity ? monster.Stats.CatchedAmount : 0);
    public float CaptureRatio() => TotalSaw > 0 ? MathConts.RoundNumber(TotalCaught/ TotalSaw) : 0;
    public void UpdateManySaw() => TotalSaw = monsters.FindAll(monster => monster.Stats.Seen).Count;
    private void LoadData()
    {
        List<MonsterData> data = GameManager.Instance.CurrentPlayer.MonsterData;
        if (data == null || data.Count == 0)
        {
            GameManager.Instance.CurrentPlayer.UpdateMonsters();
        }
        else
        {
            data.ForEach(monster => GetMonsterByName(monster.Name).InitiateByData(monster));
            monsters.ForEach(monster => MonsterRng.AddIds(monster.Stats.CatchesIds));
        }
    }
    public Monster GetTypeLineRandomMonster(MonsterType monsterType)
    {
        List<Monster> typeMonster = monsters.FindAll(monster => monster.Type == monsterType);
        return typeMonster[Random.Range(0, typeMonster.Count)];
    }
    public bool HasMonster(string name, int id) => GetMonsterByName(name).Stats.CatchesIds.Contains(id);
    void Start() => LoadData();
    public List<MonsterData> GetMonstersData()
    {
        List<MonsterData> monsterDatas = new List<MonsterData>();
        monsters.ForEach(monster => monster.InitiateData());
        monsters.ForEach(monster => monsterDatas.Add(new MonsterData(monster)));
        return monsterDatas;
    }
}