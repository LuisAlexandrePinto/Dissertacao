using UnityEngine;
using UnityEngine.UI;

public class DefensorManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private DefensorAttackManager defensorAttack;
    [SerializeField]
    private DefensorDefenseManager defensorDefense;
    [SerializeField]
    private DefensorSabotageManager defensorSabotage;
    [SerializeField]
    private Text Title, AttackBaseTitle, DefenseBaseTitle, SabotageBaseTitle, AttackTotalTitle, 
        DefenseTotalTitle, SabotageTotalTitle, TotalDefenseTitle, TotalDefenseValue;
    [SerializeField]
    private Image Icon_dfx_sabviii;
#pragma warning restore 0649
    private FightersManager fightersManager;
    public void Initialize(FightersManager fightersManager) => this.fightersManager = fightersManager;
    public void OnEnable()
    {
        FightStages defender = fightersManager.GetDefender();
        LanguagesFillers.FillDefensorSection(
            Title, AttackBaseTitle, DefenseBaseTitle, SabotageBaseTitle,
            AttackTotalTitle, DefenseTotalTitle, SabotageTotalTitle,
            TotalDefenseTitle, defender.IsPlayer
        );
        TotalDefenseValue.text = defender.Defense.TotalDefensePower.ToString();
        InitiliazeAttack(defender);
        InitiliazeDefense(defender);
        InitiliazeSabotage(defender);
    }
    private void InitiliazeAttack(FightStages defensor)
    {         
        float dfx = defensor.Squad.AtkPowers.DefensePower.Bonus;
        float atvii = defensor.Defense.CripleStrikeToAttack;
        float baseDefense = MathConts.RoundNumber(defensor.Squad.AtkPowers.DefensePower.Base);
        float totalDefense = defensor.Defense.AttackDefensivePower;
        defensorAttack.Initialize(defensor.Squad.AtkMonster.MonsterName, dfx, atvii, baseDefense, totalDefense);
    }
    private void InitiliazeDefense(FightStages defensor)
    {        
        float dfi = defensor.Squad.DefPowers.DefensePower.Bonus;
        float dfiii = defensor.Squad.DefPowers.DefensePower.DivergeDamageToDefense;
        float dfv = defensor.Squad.DefPowers.DefensePower.CriticalHitResistance;        
        float dfix = defensor.Defense.StopBleedingPower;
        float sabiii = defensor.Defense.DefenseDecrease;
        float sabix = defensor.Defense.CriticalResistanteDecrease;
        float atvii = defensor.Defense.CripleStrikeToDefense;
        float baseDefense = MathConts.RoundNumber(defensor.Squad.DefPowers.DefensePower.Base);
        float totalDefense = defensor.Defense.DefenseDefensivePower;
        defensorDefense.Initialize(defensor.Squad.DefMonster.MonsterName, dfi, dfiii, dfv, dfix, sabiii, sabix, atvii, baseDefense, totalDefense);
    }
    private void InitiliazeSabotage(FightStages defensor)
    {        
        float sabi = defensor.Squad.SabPowers.SabotagePower.Bonus;
        float dfx_sabviii = 0.0f;
        if (defensor.Attack.SabFullDefense > 0)
        {
            dfx_sabviii = defensor.Defense.SabFullDefense;
            ImagesFillers.GetAbilityIcon(Icon_dfx_sabviii, AbilityIndex.DEFENSE10.ToString());
        }
        else
        {
            dfx_sabviii = defensor.Squad.DefPowers.DefensePower.Bonus;
            ImagesFillers.GetAbilityIcon(Icon_dfx_sabviii, AbilityIndex.SABOTAGE8.ToString());
        }
        float atvii = defensor.Defense.CripleStrikeToSabotage;
        float sabv = defensor.Defense.SabotageDecrease;
        float baseDefense = MathConts.RoundNumber(defensor.Squad.SabPowers.DefensePower.Base);
        float totalDefense = defensor.Defense.SabotageDefensivePower;
        defensorSabotage.Initialize(defensor.Squad.SabMonster.MonsterName, sabi, dfx_sabviii, atvii, sabv, baseDefense, totalDefense);
    }
}
