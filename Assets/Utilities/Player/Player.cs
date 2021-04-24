using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player
{
    private string path;
    private const int ABILITY_GAINER = 3, ZERO = 0;
    private const float levelBase = 100, levelXpIncrementer = 2.5f;
    public float Xp { get; private set; } = ZERO;
    public float RequiredXp { get => levelBase + (Level * levelXpIncrementer); }
    public float NeededXp { get => RequiredXp - Xp; }
    public float LevelBase { get => levelBase; }
    public int Level { get; private set; } = 1;
    public int PlayerPoints { get; set; } = 120; //3
    public int PlayerMaxPoints { get; set; } = 120; //3
    public int ExtraThrows { get => Level / 10; }
    public int WonBattles { get; set; } = ZERO;
    public int LostBattles { get; set; } = ZERO;
    public int InspPotions { get; set; } = ZERO;
    public int HpPotions { get; set; } = ZERO;
    public int RetreatBattles { get; set; } = ZERO;
    public int WinRatio => (TotalBattles > ZERO) ? WonBattles * 100 / TotalBattles : ZERO;
    public int TotalBattles => WonBattles + LostBattles + RunnedAwayBatles;
    public int RunnedAwayBatles { get; set; } = ZERO;
    private string AttackMonsterName, DefenseMonsterName, SabotageMonsterName = null;
    private Squadron squadron = new Squadron();
    public void PutAttackMonsterName(string name) => AttackMonsterName = name;
    public void PutDefenseMonsterName(string name) => DefenseMonsterName = name;
    public void PutSabotageMonsterName(string name) => SabotageMonsterName = name;
    public Squadron Squadron
    {
        get
        {
            if (!squadron.IsReady)
            {
                squadron = new Squadron(
                    GameManager.Instance.MonsterManager.GetMonsterByName(AttackMonsterName),
                    GameManager.Instance.MonsterManager.GetMonsterByName(DefenseMonsterName),
                    GameManager.Instance.MonsterManager.GetMonsterByName(SabotageMonsterName)
                    );
            }
            return squadron;
        }
    }
    public List<AbilityData> Abilities { get; private set; } = new List<AbilityData>();
    public List<MonsterData> MonsterData { get; private set; } = new List<MonsterData>();    
    public string Username { get; set; } = "LPScorp10n";
    public string Password { get; set; }
    public string Email { get; set; }
    public int IncrPoints { get; private set; } = 3;
    public CharsTypes CharType { get; private set; }

    private PlayerData Data;
    public Player()
    {
        Username = PlayerPrefs.GetString(SquadUpConstants.USERNAME);
        path = Application.persistentDataPath + "/Player-" + Username + ".dat";
        Load();
    }
    public void AddXp(float xp)
    {
        Debug.Log(xp);
        Debug.Log(Level);
        Xp += Mathf.Max(ZERO, xp);
        if (Xp > RequiredXp)
        {
            Xp %= levelBase;
            PlayerPoints += ABILITY_GAINER;
            PlayerMaxPoints += ABILITY_GAINER;
            Level++;
        }
        Save();
    }
    public void UpdateMonsters()
    {
        MonsterData = GameManager.Instance.MonsterManager.GetMonstersData();
        Save();
    }
    public void UpdateAbilities()
    {
        Abilities = GameManager.Instance.AbilitiesContainer.GetAbilitiesData();
        Save();
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData(this);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            Data = (PlayerData)bf.Deserialize(file);
            file.Close();
            Password = Data.Password;
            Email = Data.Email;
            Xp = Data.Xp;
            Level = Data.Lvl;
            Abilities = Data.Abilities;
            MonsterData = Data.MonsterData;
            AttackMonsterName = Data.AttackMonsterName;
            DefenseMonsterName = Data.DefenseMonsterName;
            SabotageMonsterName = Data.SabotageMonsterName;
            CharType = Data.CharType;
        }
        else
        {
            Save();
        }
    }
    public string GetPointsToMax() => PlayerPoints + "/" + PlayerMaxPoints;
}
