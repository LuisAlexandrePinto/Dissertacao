using UnityEngine;
using UnityEngine.UI;

public class DamagePanelManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Round, PercentageTitle, DamageTitle, NormalTotalTitle, NormalTotalValue, 
        CriticalTotalTitle, CriticalTotalValue, PassiveTotalTitle, PassiveTotalValue, 
        NormalDmgTitle, CriticalDmgTitle, PassiveDmgTitle, FaintedTitle, ReviveTitle, HealTitle, 
        AttackTotalHpTitle, AttackTotalHpValue, DefenseTotalHpTitle, DefenseTotalHpValue, EndRoundBtn;
    [SerializeField]
    private MonsterPercentagesPanel monsterPercentagesPanel;
    [SerializeField]
    private MonsterDamagePanel attackPanel, defensePanel, sabotagePanel;
#pragma warning restore 0649


    private FightersManager fightersManager;
    public void Initialize(FightersManager fightersManager) => this.fightersManager = fightersManager;

    public void OnEnable()
    {
        FightStages attacker = fightersManager.GetAttacker();
        FightStages defender = fightersManager.GetDefender();
        LanguagesFillers.FillDamageResultPanel(
            Round, attacker.Round, PercentageTitle, DamageTitle, NormalTotalTitle, 
            CriticalTotalTitle, PassiveTotalTitle, NormalDmgTitle, CriticalDmgTitle, 
            PassiveDmgTitle, FaintedTitle, ReviveTitle, HealTitle, EndRoundBtn, 
            AttackTotalHpTitle, DefenseTotalHpTitle
        );
        monsterPercentagesPanel.Initialize(attacker, defender);
        FillTotalDamageValues(attacker);
        FillAttackPanel(attacker, defender);
        FillDefensePanel(attacker, defender);
        FillSabotagePanel(attacker, defender);
        FillSquadHps(attacker, defender);
        fightersManager.ChangeStances();
    }
    private void FillTotalDamageValues(FightStages attacker)
    {
        NormalTotalValue.text = attacker.Attack.NormalDamage.ToString();
        PassiveTotalValue.text = attacker.Attack.CriticalHitPower.ToString();
        CriticalTotalValue.text = attacker.Attack.BleedingPower.ToString();
    }
    private void FillSquadHps(FightStages attacker, FightStages defender)
    {
        AttackTotalHpValue.text = attacker.SquadHealth.ToString();
        DefenseTotalHpValue.text = defender.SquadHealth.ToString();
    }

    private void FillAttackPanel(FightStages attacker, FightStages defender)
    {           
        attackPanel.Initialize(defender.Squad.AtkMonster.MonsterName, attacker.Attack.NormalDamageToAttack.ToString(), 
            attacker.Attack.CriticalDamageToAttack.ToString(), attacker.Attack.PassiveDamageToAttack.ToString(),
            defender.Defense.AttackMonsterFainted, defender.Squad.AtkPowers.HealthPower.WasRevived, 
            defender.Squad.AtkPowers.HealthPower.LastHeal.ToString()
        );
    }
    private void FillDefensePanel(FightStages attacker, FightStages defender)
    {             
        defensePanel.Initialize(defender.Squad.DefMonster.MonsterName, attacker.Attack.NormalDamageToDefense.ToString(),
            attacker.Attack.CriticalDamageToDefense.ToString(), attacker.Attack.PassiveDamageToDefense.ToString(),
            defender.Defense.DefenseMonsterFainted, defender.Squad.DefPowers.HealthPower.WasRevived, 
            defender.Squad.DefPowers.HealthPower.LastHeal.ToString()
        );
    }
    private void FillSabotagePanel(FightStages attacker, FightStages defender)
    {              
        sabotagePanel.Initialize(defender.Squad.SabMonster.MonsterName, attacker.Attack.NormalDamageToSabotage.ToString(),
            attacker.Attack.CriticalDamageToSabotage.ToString(), attacker.Attack.PassiveDamageToSabotage.ToString(),
            defender.Defense.SabotageMonsterFainted, defender.Squad.SabPowers.HealthPower.WasRevived,
            defender.Squad.SabPowers.HealthPower.LastHeal.ToString()
        );
    }
}
