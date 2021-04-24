using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image background;
    [SerializeField]
    private Text logout, definitions, bestiary, player, squadron, abilities, ExitQuestion, Yes, No;
    [SerializeField]
    private Button YesBtn, NoBtn, HelpBtn;
    [SerializeField]
    private GameObject ConfirmationUI, TutorialUI;
    [SerializeField]
    private MenuHeaderManager headerManager;
#pragma warning restore 0649

    private void Awake() => HelpBtn.onClick.AddListener(() => TurnOnTutorial());
    private void OnEnable()
    {
        CheckTutorial();
        Initialize();
    }
    private void CheckTutorial()
    {
        if(PlayerPrefs.GetInt(SquadUpConstants.MENU_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }

    private void TurnOnTutorial() => TutorialUI.SetActive(true);
    public void Initialize()
    {
        ImagesFillers.AddRandomMenuBackground(background);
        headerManager.Initialize();
        LanguagesFillers.FillMenuOptions(logout, definitions, bestiary, player, squadron, abilities);
    }
    public void OnClickLogout()
    {       
        PlayerPrefs.SetInt(SquadUpConstants.REMEMBER_ME, 0);
        PlayerPrefs.SetString(SquadUpConstants.USERNAME, "");
        SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_START);
    }

    public void ActivateConfirmationSubPanel()
    {
        ConfirmationUI.SetActive(true);
        LanguagesFillers.FillConfirmationSubPanel(ExitQuestion, Yes, No);
        YesBtn.onClick.AddListener(() => OnClickLogout());
        NoBtn.onClick.AddListener(() => ConfirmationUI.SetActive(false));
    }
}
