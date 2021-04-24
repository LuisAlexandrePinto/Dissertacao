using UnityEngine;
using UnityEngine.UI;

public class AttackerSabotageManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text SABI, ATIV_SABVII, ATX, SABV, AttackBase, AttackTotal;
    [SerializeField]
    private Image MonsterHead;
#pragma warning restore 0649

    public void Initialize(string name, float sab1, float ativ_sabvii, float atx, float sabv, float baseAttack, float totalAttack) 
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);
        SABI.text = LanguagesFillers.FormatAbilityValue(sab1, true);
        ATIV_SABVII.text = LanguagesFillers.FormatAbilityValue(ativ_sabvii, true);
        ATX.text = LanguagesFillers.FormatAbilityValue(atx, true);
        SABV.text = LanguagesFillers.FormatAbilityValue(sabv, true);
        AttackBase.text = baseAttack.ToString();
        AttackTotal.text = totalAttack.ToString();
    }
}
