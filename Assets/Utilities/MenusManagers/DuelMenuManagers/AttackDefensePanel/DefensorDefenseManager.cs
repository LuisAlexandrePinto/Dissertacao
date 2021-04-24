using UnityEngine;
using UnityEngine.UI;

public class DefensorDefenseManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text DFI, DFIII, DFV, DFIX, SABIII, SABIX, ATVII, DefenseBase, DefenseTotal;
    [SerializeField]
    private Image MonsterHead;
#pragma warning restore 0649

    public void Initialize(string name, float dfi, float dfiii, float dfv, float dfix, float sabiii, float sabix, float atvii,  float baseDefense, float totalDefense)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);
        DFI.text = LanguagesFillers.FormatAbilityValue(dfi, true);
        DFIII.text = LanguagesFillers.FormatAbilityValue(dfv, true);
        DFV.text = LanguagesFillers.FormatAbilityValue(dfix, true);
        DFIX.text = LanguagesFillers.FormatAbilityValue(dfiii, true);
        SABIII.text = LanguagesFillers.FormatAbilityValue(sabiii, false);
        SABIX.text = LanguagesFillers.FormatAbilityValue(sabix, false);
        ATVII.text = LanguagesFillers.FormatAbilityValue(atvii, false);
        DefenseBase.text = baseDefense.ToString();
        DefenseTotal.text = totalDefense.ToString();
    }
}
