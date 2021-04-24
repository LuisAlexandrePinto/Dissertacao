using UnityEngine;
using UnityEngine.UI;

public class MenuTutorialOptions : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private MenuOption menuOption;
    [SerializeField]
    private Text Title, Explanation;
#pragma warning restore 0649
    private enum MenuOption { Exit, Definitions, Bestiary, Player, Squadron, Abilities }
    // Start is called before the first frame update
    void Start() => FillOptionInformation();
    private void FillOptionInformation()
    {
        switch (menuOption)
        {
            case MenuOption.Exit: LanguagesFillers.FillExitTutorialOption(Title, Explanation); break;
            case MenuOption.Definitions: LanguagesFillers.FillDefinitionsTutorialOption(Title, Explanation); break;
            case MenuOption.Bestiary: LanguagesFillers.FillBestiaryTutorialOption(Title, Explanation); break;
            case MenuOption.Player: LanguagesFillers.FillPlayerTutorialOption(Title, Explanation); break;
            case MenuOption.Squadron: LanguagesFillers.FillSquadronTutorialOption(Title, Explanation); break;
            case MenuOption.Abilities: LanguagesFillers.FillAbilitiesTutorialOption(Title, Explanation); break;
        }
    }
}
