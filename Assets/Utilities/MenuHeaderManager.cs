using UnityEngine;
using UnityEngine.UI;

public class MenuHeaderManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Title, BackButton, HelpButton = null, Points = null, AtkPoints = null,
        DefPoints = null, SabPoints = null, UserPoints = null;
    [SerializeField]
    private MenusIdentifier menusIdentifier;
#pragma warning restore 0649
    public void Initialize(AbilityType abilityType = AbilityType.NONE, string monsterName = "")
    {
        LanguagesFillers.FillMenuHeader(Title, BackButton, HelpButton, menusIdentifier,
            monsterName, abilityType, Points, AtkPoints, DefPoints, SabPoints, UserPoints);
    }
}
