using UnityEngine;
using UnityEngine.UI;

public class SquadronPanelHP : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Health, HealthBase, HealthBaseValue, HealthLevel, HealthLevelValue, HealthAbilities, HealthAbilitiesValue;
#pragma warning restore 0649
    public void FillHealthSubPanel(bool realTutorial, MonsterPowers powers = null)
    {
        LanguagesFillers.FillHealthSubPanel(Health, HealthBase, HealthLevel, HealthAbilities);
        if (realTutorial)
        {
            if (powers != null)
            {
                FillValuesWithPowers(powers);
            }            
        }
        else
        {
            if(powers != null)
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
        HealthBaseValue.text = powers.HealthPower.BaseHp.ToString();
        HealthLevelValue.text = powers.HealthPower.LevelHp.ToString();
        HealthAbilitiesValue.text = powers.HealthPower.BonusHp.ToString();
    }

    private void FillValuesFictious()
    {
        HealthBaseValue.text = "13";
        HealthLevelValue.text = "2.5";
        HealthAbilitiesValue.text = "3";
    }
}
