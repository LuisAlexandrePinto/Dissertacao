using UnityEngine;
using UnityEngine.UI;

public class CaptureUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject CaptureUI, LevelLoader, ConfirmationUI, Orb, TutorialUI;
    [SerializeField]
    private Button RunAwayBtn, ContinueBtn, YesBtn, NoBtn, HelpBtn;
    [SerializeField]
    private Text RunAwayTitle, ContinueTitle, ExitQuestion, Yes, No, HelpBtnTitle;
    [SerializeField]
    private Animator transition;
#pragma warning restore 0649

    private void Awake() => HelpBtn.onClick.AddListener(() => TurnOnTutorial());
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.CAPTURE_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }

    private void TurnOnTutorial() => TutorialUI.SetActive(true);
    // Start is called before the first frame update
    private void Start()
    {
        CheckTutorial();
        HelpBtnTitle.text = LanguagesFillers.Lang.Help;
        LanguagesFillers.FillDuelOptionsButtons(RunAwayTitle, ContinueTitle);
        SceneTransitionManager.Instance.SetLoader(LevelLoader);
        SceneTransitionManager.Instance.SetAnimator(transition);
        RunAwayBtn.onClick.AddListener(() => ActivateConfirmationSubPanel());
        ContinueBtn.onClick.AddListener(() => ContinueToCapture());
    }
    private void ContinueToCapture()
    {
        ToggleUI(false);
        Orb.SetActive(true);
    }
    private void ActivateConfirmationSubPanel()
    {        
        ToggleConfirmation(true);
        LanguagesFillers.FillConfirmationSubPanel(ExitQuestion, Yes, No);
        YesBtn.onClick.AddListener(() => SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_WORLD));
        NoBtn.onClick.AddListener(() => ToggleConfirmation(false));
    }
    private void ToggleUI(bool onOff) => CaptureUI.SetActive(onOff);
    private void ToggleConfirmation(bool onOff) => ConfirmationUI.SetActive(onOff);
}
