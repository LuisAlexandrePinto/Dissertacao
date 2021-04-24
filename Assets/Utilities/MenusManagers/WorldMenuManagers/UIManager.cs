using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text xptext, leveltext, leveltitle, HelpBtntitle;
    [SerializeField]
    private GameObject menu, levelLoader, TutorialUI;
    [SerializeField]
    private Button HelpBtn;
    [SerializeField]
    private AudioClip menuBtnSound;
    [SerializeField]
    private Animator transition;
#pragma warning restore 0649
    private AudioSource audioSource;
    private void Awake()
    {
        Initialize();
        HelpBtn.onClick.AddListener(() => TurnOnTutorial());
        SceneTransitionManager.Instance.SetLoader(levelLoader);
        SceneTransitionManager.Instance.SetAnimator(transition);
        audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(xptext);
        Assert.IsNotNull(leveltext);
        Assert.IsNotNull(menu);
        Assert.IsNotNull(menuBtnSound);
    }

    private void OnEnable()
    {
        CheckTutorial();
        Initialize();
        UpdateXP();
    }

    public void UpdateXP() =>
        xptext.text = GameManager.Instance.CurrentPlayer.Xp + " / " + GameManager.Instance.CurrentPlayer.RequiredXp;

    private void ToggleMenu() => menu.SetActive(!menu.activeSelf);

    public void MenuBtnClicked()
    {
        audioSource.PlayOneShot(menuBtnSound);
        ToggleMenu();
    }

    public void Initialize()
    {
        HelpBtntitle.text = LanguagesFillers.Lang.Help;
        leveltitle.text = LanguagesFillers.Lang.Level;
        leveltext.text = GameManager.Instance.CurrentPlayer.Level.ToString();
    }
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.WORLDMAP_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }
    private void TurnOnTutorial() => TutorialUI.SetActive(true);
}
