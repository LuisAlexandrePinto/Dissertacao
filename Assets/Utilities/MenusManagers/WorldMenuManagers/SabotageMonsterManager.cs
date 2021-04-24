using UnityEngine;
using UnityEngine.UI;

public class SabotageMonsterManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text
        PersonalStats,
        TypeTitle, TypeValue, SubTypeTitle, SubTypeValue,
        SawTitle, SawValue, CatchTitle, CatchValue,
        ToEvolveTitle, ToEvolveValue,
        CombatStats,
        SabotageTitle,
        SabBaseTitle, SabBaseValue, SabLevelTitle, SabLevelValue,
        AttackTitle,
        AtkBaseTitle, AtkBaseValue, AtkLevelTitle, AtkLevelValue,
        DefenseTitle,
        DefBase, DefBaseValue, DefLevelTitle, DefLevelValue,
        HealthTitle,
        HpBaseTitle, HpBaseValue, HpLevelTitle, HpLevelValue;
    [SerializeField]
    private Image MonsterHead;
    [SerializeField]
    private GameObject MonsterShield, Stats;
#pragma warning restore 0649


    public void Initialize(Monster monster)
    {
        MonsterShield.SetActive(true);
        Stats.SetActive(true);
        MonsterPowers powers = monster.GetPowers();        
        ImagesFillers.AddMonsterHead(MonsterHead, monster.MonsterName);
        LanguagesFillers.FillMonsterPersonalStats(PersonalStats, TypeTitle, SubTypeTitle, SawTitle, CatchTitle, ToEvolveTitle);
        LanguagesFillers.FillSabMonsterCombatStats(CombatStats,
            SabotageTitle, SabBaseTitle, SabLevelTitle,
            AttackTitle, AtkBaseTitle, AtkLevelTitle,
            DefenseTitle, DefBase, DefLevelTitle,
            HealthTitle, HpBaseTitle, HpLevelTitle);
        TypeValue.text = monster.Type.ToString();
        SubTypeValue.text = monster.SubType.ToString();
        ToEvolveValue.text = monster.Stats.CatchesToEvolve + " " + LanguagesFillers.Lang.ToCatch;
        SabBaseValue.text = powers.SabotagePower.Base.ToString();
        SabLevelValue.text = powers.SabotagePower.LevelSabotage.ToString();
        if (powers.AttackPower.Base == 0)
        {
            AtkBaseValue.text = (powers.SabotagePower.Total / 2).ToString();
            AtkLevelValue.text = "0";
            DefBaseValue.text = powers.DefensePower.Base.ToString();
            DefLevelValue.text = powers.DefensePower.LevelDefense.ToString();

        }
        else
        {
            AtkBaseValue.text = powers.AttackPower.Base.ToString();
            AtkLevelValue.text = powers.AttackPower.LevelAttack.ToString();
            DefBaseValue.text = (powers.SabotagePower.Total / 2).ToString();
            DefLevelValue.text = "0";
        }
        HpBaseValue.text = powers.HealthPower.BaseHp.ToString();
        HpLevelValue.text = powers.HealthPower.LevelHp.ToString();
    }
}
