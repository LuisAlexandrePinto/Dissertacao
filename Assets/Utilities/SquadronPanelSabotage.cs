using UnityEngine;
using UnityEngine.UI;

public class SquadronPanelSabotage : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Sabotage, SabBase, SabBaseValue, SabLevel, SabLevelValue, SabAbilities, SabAbilitiesValue;
#pragma warning restore 0649
    public void FillSabotageSubPanel(bool realTutorial, MonsterPowers powers = null)
    {
        LanguagesFillers.FillSabotageSubPanel(Sabotage, SabBase, SabLevel, SabAbilities);
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
        SabBaseValue.text = powers.SabotagePower.Base.ToString();
        SabLevelValue.text = powers.SabotagePower.LevelSabotage.ToString();
        SabAbilitiesValue.text = powers.SabotagePower.Bonus.ToString();
    }

    private void FillValuesFictious()
    {
        SabBaseValue.text = "20";
        SabLevelValue.text = "6";
        SabAbilitiesValue.text = "1.5";
    }
}
