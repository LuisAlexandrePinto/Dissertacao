using UnityEngine;
using UnityEngine.UI;

public class AttackerDefenseManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text ATIV, ATX, AttackBase, AttackTotal;
    [SerializeField]
    private Image MonsterHead;
#pragma warning restore 0649
    public void Initialize(string name, float ativ, float atx, float baseAttack, float totalAttack)
    {
        ImagesFillers.AddMonsterHead(MonsterHead, name);
        ATIV.text = LanguagesFillers.FormatAbilityValue(ativ, true);        
        ATX.text = LanguagesFillers.FormatAbilityValue(atx, true);
        AttackBase.text = baseAttack.ToString();
        AttackTotal.text = totalAttack.ToString();
    }    
}
