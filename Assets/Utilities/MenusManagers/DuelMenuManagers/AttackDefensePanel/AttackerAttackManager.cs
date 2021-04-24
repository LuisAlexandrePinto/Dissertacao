using UnityEngine;
using UnityEngine.UI;

public class AttackerAttackManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text ATI, ATIII, ATV, ATVIII, ATIX, ATX, SABIV, AttackBase, AttackTotal;
    [SerializeField]
    private Image MonsterHead;
#pragma warning restore 0649
    public void Initialize(string name, float ati, float atiii, float atv, float atviii, float atix, float atx, float sabiv, float baseAttack, float totalAttack)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);
        ATI.text = LanguagesFillers.FormatAbilityValue(ati, true);
        ATIII.text = LanguagesFillers.FormatAbilityValue(atiii, true);
        ATV.text = LanguagesFillers.FormatAbilityValue(atv, true);
        ATVIII.text = LanguagesFillers.FormatAbilityValue(atviii, true);
        ATIX.text = LanguagesFillers.FormatAbilityValue(atix, true);
        ATX.text = LanguagesFillers.FormatAbilityValue(atx, true);
        SABIV.text = LanguagesFillers.FormatAbilityValue(sabiv, false);
        AttackBase.text = baseAttack.ToString();
        AttackTotal.text = totalAttack.ToString();
    }
}
