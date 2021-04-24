using System;
using UnityEngine;
using UnityEngine.UI;

public static class ImagesFillers
{    
    private const string
        BACKGROUNDS = "Sprites/Backgrounds/",
        MONSTERS_IMAGES_DIR = "Sprites/MonsterHeads/",
        MONSTER_MENU_BG = "MonsterBGs/",
        MONSTER_SHIELDS = "MonsterShields/",
        DEFINITIONS = "DefinitionsBGs/",
        MENU_BG = "MenuBGs/",
        ABILITIES_ICONS = "Sprites/AbilitiesIcons/",
        MONSTER_PLATES = "MonsterPlates/",
        MONSTER_MISSING = "MissingMonster",
        BADGES = "Sprites/Badges/",
        TYPES = "Types/",
        MONSTER_HEADS = "Sprites/MonsterHeads/",
        ABILITIES_BRANCHS_BGS = "AbilityBranchBGs/",
        DUEL_TUTORIAL_DIR = "DuelBGs/Tutorial/",
        DUEL_ATTACKPHASE = "AttackPhase/",
        DUEL_DEFENSEPHASE = "DefensePhase/",
        DUEL_HPS = "HPs/",
        DUEL_SKILLS = "DuelSkills/",
        DUEL_COMBATRESULT = "DuelResult/",
        SOUND_OFF = "SoundOff", 
        SOUND_ON = "SoundOn",
        FLAGS = "Sprites/Flags/";
    public static Sprite GetFlag(LanguageIndex language) => GetSprite(FLAGS + language.ToString());
    public static void ChangeMuteCheckmark(Image checkmark, bool enableSound) => checkmark.sprite = GetSprite(BADGES + (enableSound ? SOUND_ON : SOUND_OFF));
    public static void GetAbilityIcon(Image icon, string abilityName) => icon.sprite = GetSprite(ABILITIES_ICONS + abilityName);
    public static void AddMonsterImage(Image headHolder, Monster monster) => headHolder.sprite = GetSprite(MONSTERS_IMAGES_DIR + monster.MonsterName);
    public static void AddDuelAttackPhaseImage(Image attackPhase) => attackPhase.sprite = GetSprite(BACKGROUNDS + DUEL_TUTORIAL_DIR + DUEL_ATTACKPHASE + GameManager.Instance.PlayerPreferences.LanguageDefined);
    public static void AddDuelDefensePhaseImage(Image defensePhase) => defensePhase.sprite = GetSprite(BACKGROUNDS + DUEL_TUTORIAL_DIR + DUEL_DEFENSEPHASE + GameManager.Instance.PlayerPreferences.LanguageDefined);
    public static void AddDuelHPsImage(Image hps) => hps.sprite = GetSprite(BACKGROUNDS + DUEL_TUTORIAL_DIR + DUEL_HPS + GameManager.Instance.PlayerPreferences.LanguageDefined);
    public static void AddDuelCombatSkillsImage(Image combatSkills) => combatSkills.sprite = GetSprite(BACKGROUNDS + DUEL_TUTORIAL_DIR + DUEL_SKILLS + GameManager.Instance.PlayerPreferences.LanguageDefined);
    public static void AddDuelCombatResultImage(Image combatResult) => combatResult.sprite = GetSprite(BACKGROUNDS + DUEL_TUTORIAL_DIR + DUEL_COMBATRESULT + GameManager.Instance.PlayerPreferences.LanguageDefined);
    public static void AddMonsterShieldBackground(Image background, MonsterType type) => background.sprite = GetSprite(BACKGROUNDS + MONSTER_SHIELDS + type);
    public static void AddMonsterMenubackground(Image background, MonsterType type) => background.sprite = GetSprite(BACKGROUNDS + MONSTER_MENU_BG + type);
    public static void AddRandomDefinitionsBackground(Image background) => background.sprite = GetSprite(BACKGROUNDS + DEFINITIONS + MathConts.RandomInt(1, 4));        
    public static void AddRandomMenuBackground(Image background) => background.sprite = GetSprite(BACKGROUNDS + MENU_BG + MathConts.RandomInt(1, 7));        
    public static void AddSquadronMonsterHeads(Image attackMonster, Image defenseMonster, Image sabotageMonster, Squadron squad)
    {
        Monster monster = squad.AtkMonster;
        if (monster != null)
        {
            AddMonsterImage(attackMonster, monster);
        }
        monster = squad.DefMonster;
        if (monster != null)
        {
            AddMonsterImage(defenseMonster, monster);
        }
        monster = squad.SabMonster;
        if (monster != null)
        {
            AddMonsterImage(sabotageMonster, monster);
        }
    }
    public static void AddMonsterPlate(Image monsterHead, Image icon, Image plateBG, Monster monster)
    {
        string dir;
        if (!monster.Stats.Catched)
        {
            dir = MONSTER_MISSING;
            icon.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            AddTypeIcon(icon ,monster.Type);
            dir = GetWordToLowerCase(monster.GetRarity.ToString()) + "/" + monster.SubType.ToString().ToLower();
            AddMonsterHead(monsterHead, monster.MonsterName);
        }
        AddMonsterPlate(plateBG, dir);
    }        
    public static void AddMonsterHead(Image head, string name) => head.sprite = GetSprite(MONSTER_HEADS + name);    
    private static Sprite AddTypeIcon(Image icon, MonsterType type) => icon.sprite = GetSprite(BADGES + TYPES + type.ToString().ToLower());
    public static void AddMonsterPlate(Image plate, string dir) => plate.sprite = GetSprite(BACKGROUNDS + MONSTER_PLATES + dir);
    private static string GetWordToLowerCase(string word) => word.Substring(0, 1) + word.Substring(1).ToLower();
    private static Sprite GetSprite(string dir) => Resources.Load<Sprite>(dir);
}
