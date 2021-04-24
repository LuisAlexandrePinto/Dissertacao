using UnityEngine;
using UnityEngine.UI;

public class AbilitiesMenuManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image Background;
    [SerializeField]
    private Text AttackLogo, DefenseLogo, SabotageLogo;
    [SerializeField]
    private Button Help;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private GameObject TutorialUI;
#pragma warning restore 0649
    private void Awake() => Help.onClick.AddListener(() => TurnOnTutorial());

    private void OnEnable()
    {
        CheckTutorial();
        ImagesFillers.AddRandomMenuBackground(Background);
        headerManager.Initialize();
        LanguagesFillers.FillAbilitiesMenuOptions(AttackLogo, DefenseLogo, SabotageLogo);
    }

    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.ABILITIES_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }
    private void TurnOnTutorial() => TutorialUI.SetActive(true);
}
