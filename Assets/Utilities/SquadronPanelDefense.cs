using UnityEngine;
using UnityEngine.UI;

public class SquadronPanelDefense : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Defense, DefBase, DefBaseValue, DefLevel, DefLevelValue, DefAbilities, DefAbilitiesValue;
#pragma warning restore 0649
    public void FillDefenseSubPanel(bool realTutorial, MonsterPowers powers = null)
    {
        LanguagesFillers.FillDefenseSubPanel(Defense, DefBase, DefLevel, DefAbilities);
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
        DefBaseValue.text = powers.DefensePower.Base.ToString();
        DefLevelValue.text = powers.DefensePower.LevelDefense.ToString();
        DefAbilitiesValue.text = powers.DefensePower.Bonus.ToString();
    }

    private void FillValuesFictious()
    {
        DefBaseValue.text = "15";
        DefLevelValue.text = "1.5";
        DefAbilitiesValue.text = "2";
    }
}
