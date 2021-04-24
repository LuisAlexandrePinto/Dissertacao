using UnityEngine;
using UnityEngine.UI;

public class DefensorAttackManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text DFX, ATVII, DefenseBase, DefenseTotal;
    [SerializeField]
    private Image MonsterHead;
#pragma warning restore 0649

    public void Initialize(string name, float dfx, float atvii, float baseDefense, float totalDefense)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);
        DFX.text = LanguagesFillers.FormatAbilityValue(dfx, true);
        ATVII.text = LanguagesFillers.FormatAbilityValue(atvii, false);
        DefenseBase.text = baseDefense.ToString();
        DefenseTotal.text = totalDefense.ToString();
    }
}
