using UnityEngine;
using UnityEngine.UI;

public class SquadronPanelAttack : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Attack, AtkBase, AtkBaseValue, AtkLevel, AtkLevelValue, AtkAbilities, AtkAbilitiesValue;
#pragma warning restore 0649
    public void FillAttackSubPanel(bool realTutorial, MonsterPowers powers = null)
    {
        LanguagesFillers.FillAttackSubPanel(Attack, AtkBase, AtkLevel, AtkAbilities);
        if (realTutorial)
        {
            if (powers != null)
            {
                FillValuesWithPowers(powers);
            }
        }
        else
        {
            if (powers != null)
            {
                FillValuesWithPowers(powers);
            }
            else
            {
                FillValuesFictious();
            }
        }
    }
    private void FillValuesWithPowers(MonsterPowers powers)
    {
        AtkBaseValue.text = powers.AttackPower.Base.ToString();
        AtkLevelValue.text = powers.AttackPower.LevelAttack.ToString();
        AtkAbilitiesValue.text = powers.AttackPower.Bonus.ToString();
    }

    private void FillValuesFictious()
    {
        AtkBaseValue.text = "17";
        AtkLevelValue.text = "4";
        AtkAbilitiesValue.text = "2.5";
    }
}
