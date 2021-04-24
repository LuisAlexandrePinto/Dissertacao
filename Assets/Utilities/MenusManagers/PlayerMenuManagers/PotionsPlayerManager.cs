using UnityEngine;
using UnityEngine.UI;

public class PotionsPlayerManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Potions, Health, HealthValue, Intellect, IntellectValue;
#pragma warning restore 0649
    public void Initialize(Player player)
    {
        LanguagesFillers.FillPotionsSubPanel(Potions, Health, Intellect);
        HealthValue.text = player.HpPotions.ToString();
        IntellectValue.text = player.InspPotions.ToString();
    }
}
