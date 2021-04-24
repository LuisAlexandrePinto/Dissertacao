using UnityEngine;
using UnityEngine.UI;

public class DefensorSabotageManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text SABI, DFX_SABVIII, ATVII, SABV, DefenseBase, DefenseTotal;
    [SerializeField]
    private Image MonsterHead;
#pragma warning restore 0649

    public void Initialize(string name, float sabi, float dfx_sabviii, float atvii, float sabv, float baseDefense, float totalDefense)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);
        SABI.text = LanguagesFillers.FormatAbilityValue(sabi, true);
        DFX_SABVIII.text = LanguagesFillers.FormatAbilityValue(dfx_sabviii, true);
        ATVII.text = LanguagesFillers.FormatAbilityValue(atvii, false);
        SABV.text = LanguagesFillers.FormatAbilityValue(sabv, false);
        DefenseBase.text = baseDefense.ToString();
        DefenseTotal.text = totalDefense.ToString();
    }

}
