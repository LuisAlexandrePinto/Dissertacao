using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public float Xp { get; private set; }
    public float RequiredXp { get; private set; }
    public float LevelBase { get; private set; }
    public int Lvl { get; private set; }
    public List<AbilityData> Abilities { get; private set; } = new List<AbilityData>();
    public List<MonsterData> MonsterData { get; private set; } = new List<MonsterData>();
    public string AttackMonsterName { get; set; }
    public string DefenseMonsterName { get; set; }
    public string SabotageMonsterName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public CharsTypes CharType { get; private set; }
    public PlayerData(Player player)
    {
        Xp = player.Xp;
        RequiredXp = player.RequiredXp;
        LevelBase = player.LevelBase;
        Lvl = player.Level;
        Abilities = player.Abilities;
        MonsterData = player.MonsterData;
        Username = player.Username;
        Password = player.Password;
        Email = player.Email;
        CharType = player.CharType;
        AttackMonsterName = player.Squadron.AtkMonster != null ? player.Squadron.AtkMonster.MonsterName : null;
        DefenseMonsterName = player.Squadron.DefMonster != null ? player.Squadron.DefMonster.MonsterName : null;
        SabotageMonsterName = player.Squadron.SabMonster != null ? player.Squadron.SabMonster.MonsterName : null;
    }

    public PlayerData(string username, string password, string email, CharsTypes charsTypes)
    {
        Username = username;
        Password = password;
        Email = email;
        CharType = charsTypes;
        Xp = 0;
        RequiredXp = 100;
        LevelBase = 100;
        Lvl = 1;
        Abilities = new List<AbilityData>();
        AttackMonsterName = null;
        DefenseMonsterName = null;
        SabotageMonsterName = null;        
    }
}
