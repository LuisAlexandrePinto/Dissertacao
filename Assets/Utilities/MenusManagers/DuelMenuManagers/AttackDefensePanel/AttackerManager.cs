using UnityEngine;
using UnityEngine.UI;

public class AttackerManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private AttackerAttackManager attackerAttack;
    [SerializeField]
    private AttackerDefenseManager attackerDefense;
    [SerializeField]
    private AttackerSabotageManager attackerSabotage;
    [SerializeField]
    private Text Title, AttackBaseTitle, DefenseBaseTitle, SabotageBaseTitle, AttackTotalTitle, 
        DefenseTotalTitle, SabotageTotalTitle, TotalAttackTitle, TotalAttackValue, Continue, Round;
    [SerializeField]
    private Image Icon_ativ_sabvii;
#pragma warning restore 0649

    private FightersManager fightersManager;
    public void Initialize(FightersManager fightersManager) => this.fightersManager = fightersManager;
    public void OnEnable()
    {
        FightStages attacker = fightersManager.GetAttacker();
        LanguagesFillers.FillAttackerSection(
            Title, AttackBaseTitle, DefenseBaseTitle, SabotageBaseTitle, 
            AttackTotalTitle , DefenseTotalTitle, SabotageTotalTitle, TotalAttackTitle, 
            Continue, attacker.IsPlayer, Round, attacker.Round
        );
        TotalAttackValue.text = attacker.Attack.TotalAttackPower.ToString();
        InitiliazeAttack(attacker);
        InitiliazeDefense(attacker);
        InitiliazeSabotage(attacker);
    }
    private void InitiliazeAttack(FightStages attacker)
    {                
        float ati = attacker.Squad.AtkPowers.AttackPower.Bonus;
        float atiii = attacker.Attack.CriticalHitPower;
        float atv = attacker.Attack.BleedingPower;
        float atviii = attacker.Attack.DoubleStrikePower;
        float atix = attacker.Attack.AdrenalineRushPower;
        float atx = attacker.Attack.AtkOnTurnBonusAttack;
        float sabiv = attacker.Attack.AttackDecrease;
        float baseAttack = MathConts.RoundNumber(attacker.Squad.AtkPowers.AttackPower.Base);
        float totalAttack = attacker.Attack.AttackOffensivePower;
        attackerAttack.Initialize(attacker.Squad.AtkMonster.MonsterName, ati, atiii, atv, atviii, atix, atx, sabiv, baseAttack, totalAttack);
    }
    private void InitiliazeDefense(FightStages attacker)
    {        
        float ativ = attacker.Squad.DefPowers.AttackPower.Bonus;
        float atx = attacker.Attack.DefOnTurnBonusAttack;
        float baseAttack = MathConts.RoundNumber(attacker.Squad.DefPowers.AttackPower.Base);
        float totalAttack = attacker.Attack.DefenseOffensivePower;
        attackerDefense.Initialize(attacker.Squad.DefMonster.MonsterName, ativ, atx, baseAttack, totalAttack);
    }
    private void InitiliazeSabotage(FightStages attacker)
    {        
        float sabi = attacker.Squad.SabPowers.SabotagePower.Bonus;
        float ativ_sabvii = 0.0f;
        if (attacker.Attack.SabFullAttack > 0) 
        {
            ativ_sabvii = attacker.Attack.SabFullAttack;
            ImagesFillers.GetAbilityIcon(Icon_ativ_sabvii, AbilityIndex.ATTACK4.ToString());
        } 
        else 
        {
            ativ_sabvii = attacker.Squad.SabPowers.AttackPower.Bonus;
            ImagesFillers.GetAbilityIcon(Icon_ativ_sabvii, AbilityIndex.SABOTAGE7.ToString());
        }        
        float atx = attacker.Attack.SabOnTurnBonusAttack;
        float sabv = attacker.Attack.SabotageDecrease;
        float baseAttack = MathConts.RoundNumber(attacker.Squad.SabPowers.AttackPower.Base);
        float totalAttack = attacker.Attack.SabotageOffensivePower;
        attackerSabotage.Initialize(attacker.Squad.SabMonster.MonsterName, sabi, ativ_sabvii, atx, sabv, baseAttack, totalAttack);
    }
}
