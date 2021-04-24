using UnityEngine;
using UnityEngine.UI;

public class AttackDefenseMonsterManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text
        PersonalStats,
        TypeTitle, TypeValue, SubTypeTitle, SubTypeValue,
        SawTitle, SawValue, CatchTitle, CatchValue,
        ToEvolveTitle, ToEvolveValue,
        CombatStats,
        AttackTitle,
        AtkBaseTitle, AtkBaseValue, AtkLevelTitle, AtkLevelValue,
        DefenseTitle,
        DefBase, DefBaseValue, DefLevelTitle, DefLevelValue,
        HealthTitle,
        HpBaseTitle, HpBaseValue, HpLevelTitle, HpLevelValue;
    [SerializeField]
    private Image atkHead, defHead;
    [SerializeField]
    private GameObject AtkShield, DefShield, Stats;
#pragma warning restore 0649

    public void Initialize(Monster monster)
    {
        if (monster.Type == MonsterType.ATTACK)
        {
            AtkShield.SetActive(true);
            DefShield.SetActive(false);
            ImagesFillers.AddMonsterHead(atkHead, monster.MonsterName);
        }
        else
        {
            AtkShield.SetActive(false);
            DefShield.SetActive(true);
            ImagesFillers.AddMonsterHead(defHead, monster.MonsterName);
        }
        Stats.SetActive(true);
        MonsterPowers powers = monster.GetPowers();        
        LanguagesFillers.FillMonsterPersonalStats(PersonalStats, TypeTitle, SubTypeTitle, SawTitle, CatchTitle, ToEvolveTitle);
        LanguagesFillers.FillAtkDefMonsterCombatStats(CombatStats, AttackTitle, AtkBaseTitle, AtkLevelTitle, DefenseTitle, DefBase,
            DefLevelTitle, HealthTitle, HpBaseTitle, HpLevelTitle);
        TypeValue.text = monster.Type.ToString();
        SubTypeValue.text = monster.SubType.ToString();
        ToEvolveValue.text = monster.Stats.CatchesToEvolve + " " + LanguagesFillers.Lang.ToCatch;
        AtkBaseValue.text = powers.AttackPower.Base.ToString();
        AtkLevelValue.text = powers.AttackPower.LevelAttack.ToString();
        DefBaseValue.text = powers.DefensePower.Base.ToString();
        DefLevelValue.text = powers.DefensePower.LevelDefense.ToString();
        HpBaseValue.text = powers.HealthPower.BaseHp.ToString();
        HpLevelValue.text = powers.HealthPower.LevelHp.ToString();
    }
}
