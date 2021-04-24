using UnityEngine;
using UnityEngine.UI;

public class TutorialFooterManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text TurnHelpOffTitle, CloseBtnTitle, PreviousTitle, NextTitle;
    [SerializeField]
    private Toggle TurnHelpOff;
    [SerializeField]
    private TutorialIdentifier tutorialIdentifier;
#pragma warning restore 0649
    private enum TutorialIdentifier { Menu, Definitions, Bestiary, Squadron, Player, Monster, Abilities, AbilityLine, WorldMap, Capture, Duel }
    public void Initialize(bool continueClose) => 
        LanguagesFillers.FillTutorialOptions(TurnHelpOffTitle, CloseBtnTitle, continueClose, PreviousTitle, NextTitle);
    public void MarkTutorial()
    {
        string marker = "";
        switch (tutorialIdentifier)
        {
            case TutorialIdentifier.Menu: marker = SquadUpConstants.MENU_TUTORIAL; break;
            case TutorialIdentifier.Definitions: marker = SquadUpConstants.DEFINITIONS_TUTORIAL; break;
            case TutorialIdentifier.Bestiary: marker = SquadUpConstants.BESTIARY_TUTORIAL; break;
            case TutorialIdentifier.Squadron: marker = SquadUpConstants.SQUADRON_TUTORIAL; break;
            case TutorialIdentifier.Player: marker = SquadUpConstants.PLAYER_TUTORIAL; break;
            case TutorialIdentifier.Monster: marker = SquadUpConstants.MONSTERMENU_TUTORIAL; break;
            case TutorialIdentifier.Abilities: marker = SquadUpConstants.ABILITIES_TUTORIAL; break;
            case TutorialIdentifier.AbilityLine: marker = SquadUpConstants.ABILITIES_LINE_TUTORIAL; break;
            case TutorialIdentifier.WorldMap: marker = SquadUpConstants.WORLDMAP_TUTORIAL; break;
            case TutorialIdentifier.Capture: marker = SquadUpConstants.CAPTURE_TUTORIAL; break;
            case TutorialIdentifier.Duel: marker = SquadUpConstants.DUEL_TUTORIAL; break;
        }
        PlayerPrefs.SetInt(marker, TurnHelpOff.isOn ? 1 : 0);
    }
}
