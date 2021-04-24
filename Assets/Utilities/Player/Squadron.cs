using UnityEngine;

public class Squadron
{
    private Monster attack, defense, sabotage = null;
    private const float HP_POTION = 25.0f, INSPIRATION = 10.0f;
    public Squadron(Monster attackMonster = null, Monster defenseMonster = null, Monster sabotageMonster = null)
    {
        AtkMonster = attackMonster;
        DefMonster = defenseMonster;
        SabMonster = sabotageMonster;
    }
    private Monster CheckAndProcessMonster(Monster monster, MonsterType monsterType) => monster != null && monster.Type == monsterType ? monster : null;

    public MonsterPowers AtkPowers { get; private set; } = null;
    public MonsterPowers DefPowers { get; private set; } = null;
    public MonsterPowers SabPowers { get; private set; } = null;
    public float Inspiration { get; private set; } = 0;
    public Monster AtkMonster
    {
        get => attack;
        private set
        {
            attack = CheckAndProcessMonster(value, MonsterType.ATTACK);
            if (attack != null)
            {
                AtkPowers = attack.GetPowers();
            }
        }
    }
    public Monster DefMonster
    {
        get => defense;
        private set
        {
            defense = CheckAndProcessMonster(value, MonsterType.DEFENSE);
            if(defense !=null)
            {
                DefPowers = defense.GetPowers();
            }
        }
    }
    public Monster SabMonster
    {
        get => sabotage;
        private set
        {
            sabotage = CheckAndProcessMonster(value, MonsterType.SABOTAGE);
            if(sabotage != null)
            {
                SabPowers = sabotage.GetPowers();
            }
        }
    }
    public bool IsReady { get => AtkMonster != null && DefMonster != null && SabMonster != null; }
    public bool IsMonsterInSquadron(Monster monster)
    {
        switch (monster.Type)
        {
            case MonsterType.ATTACK: return AtkMonster != null && AtkMonster.MonsterName.Equals(monster.MonsterName);
            case MonsterType.DEFENSE: return DefMonster != null && DefMonster.MonsterName.Equals(monster.MonsterName);
            case MonsterType.SABOTAGE: return SabMonster != null && SabMonster.MonsterName.Equals(monster.MonsterName);
            default: return false;
        }
    }
    public void UpdateCurrentHealth()
    {
        AtkPowers.HealthPower.SetCurrentHp();
        DefPowers.HealthPower.SetCurrentHp();
        SabPowers.HealthPower.SetCurrentHp();
    }
    public float GetTotalHealth() => AtkPowers.HealthPower.CurrentHp + DefPowers.HealthPower.CurrentHp + SabPowers.HealthPower.CurrentHp;
    public void AddMonster(Monster monster)
    {
        switch (monster.Type)
        {
            case MonsterType.ATTACK:
                AtkMonster = monster;
                GameManager.Instance.CurrentPlayer.PutAttackMonsterName(attack.MonsterName);
                break;
            case MonsterType.DEFENSE:
                DefMonster = monster;
                GameManager.Instance.CurrentPlayer.PutDefenseMonsterName(defense.MonsterName);
                break;
            case MonsterType.SABOTAGE:
                SabMonster = monster;
                GameManager.Instance.CurrentPlayer.PutSabotageMonsterName(sabotage.MonsterName);
                break;
        }
    }

    public void UseHPPotion()
    {
        GameManager.Instance.CurrentPlayer.HpPotions -= 1;
        AtkPowers.HealthPower.RestoreLife(MathConts.GetPercentageOf(AtkPowers.HealthPower.MaxHp, AtkPowers.HealthPower.CurrentHp > 0 ? HP_POTION : 0));
        DefPowers.HealthPower.RestoreLife(MathConts.GetPercentageOf(DefPowers.HealthPower.MaxHp, DefPowers.HealthPower.CurrentHp > 0 ? HP_POTION : 0));
        SabPowers.HealthPower.RestoreLife(MathConts.GetPercentageOf(SabPowers.HealthPower.MaxHp, SabPowers.HealthPower.CurrentHp > 0 ? HP_POTION : 0));
    }

    public void UseInspPotion(bool onOff)
    {
        GameManager.Instance.CurrentPlayer.InspPotions -= 1;
        Inspiration = onOff ? INSPIRATION : 0;
    }

    public void ResetPowers()
    {
        AtkPowers.AttackPower.ResetPowers();
        AtkPowers.DefensePower.ResetPowers();
        AtkPowers.HealthPower.ResetPowers();
        DefPowers.AttackPower.ResetPowers();
        DefPowers.DefensePower.ResetPowers();
        DefPowers.HealthPower.ResetPowers();
        SabPowers.AttackPower.ResetPowers();
        SabPowers.DefensePower.ResetPowers();
        SabPowers.SabotagePower.ResetPowers();
        SabPowers.HealthPower.ResetPowers();
    }
    public void ApplyDamage(float DamageToAttack, float DamageToDefense, float DamageToSabotage)
    {
     /*   Debug.Log("******************************************************************************************");
        Debug.Log(ATKMonster.MonsterName + " CURRENT HP: " + ATKMonsterPowers.HealthPower.CurrentHp);
        Debug.Log(DEFMonster.MonsterName + " CURRENT HP: " + DEFMonsterPowers.HealthPower.CurrentHp);
        Debug.Log(SABMonster.MonsterName + " CURRENT HP: " + SABMonsterPowers.HealthPower.CurrentHp);*/
        AtkPowers.HealthPower.ProcessDamage(DamageToAttack);
        DefPowers.HealthPower.ProcessDamage(DamageToDefense);
        SabPowers.HealthPower.ProcessDamage(DamageToSabotage);
       /* Debug.Log("--------------------------------------------------------------------------------------");
        Debug.Log(ATKMonster.MonsterName + " CURRENT HP: " + ATKMonsterPowers.HealthPower.CurrentHp + " DANO RECEBIDO: " + DamageToAttack);
        Debug.Log(DEFMonster.MonsterName + " CURRENT HP: " + DEFMonsterPowers.HealthPower.CurrentHp + " DANO RECEBIDO: " + DamageToDefense);
        Debug.Log(SABMonster.MonsterName + " CURRENT HP: " + SABMonsterPowers.HealthPower.CurrentHp + " DANO RECEBIDO: " + DamageToSabotage);
        Debug.Log("******************************************************************************************");*/
    }
    
}
