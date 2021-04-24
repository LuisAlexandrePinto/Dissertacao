using UnityEngine;
using UnityEngine.UI;

public class MonsterPercentagesPanel : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text AttackPercentage, DefenseDecrPercentage, DefenseIncrPercentage, SabotagePercentage, AttackTotalPercentage, DefenseTotalPercentage, SabotageTotalPercentage;    
    [SerializeField]
    private Image AttackHead, DefenseHead, SabotageHead;
#pragma warning restore 0649

    public void Initialize(FightStages attacker, FightStages defender)
    {        
        InitiateHeads(defender);
        AttackPercentage.text = defender.Defense.DivergeDamageToAttack.ToString();
        DefenseIncrPercentage.text = defender.Squad.DefPowers.DefensePower.DivergeDamageToDefense.ToString();
        DefenseDecrPercentage.text = attacker.Attack.DecreaseDivergePower.ToString();
        SabotagePercentage.text = defender.Defense.DivergeDamageToSabotage.ToString();
        AttackTotalPercentage.text = defender.Defense.PercentageDamageAttack.ToString();
        DefenseTotalPercentage.text = defender.Defense.PercentageDamageDefense.ToString();
        SabotageTotalPercentage.text = defender.Defense.PercentageDamageSabotage.ToString();
    }

    private void InitiateHeads(FightStages defender)
    {
        ImagesFillers.AddMonsterHead(AttackHead, defender.Squad.AtkMonster.MonsterName);
        ImagesFillers.AddMonsterHead(DefenseHead, defender.Squad.DefMonster.MonsterName);
        ImagesFillers.AddMonsterHead(SabotageHead, defender.Squad.SabMonster.MonsterName);
    }
}
