using UnityEngine;
using UnityEngine.UI;

public class MonsterTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject Header, Stats, TutorialUI, Help;
    [SerializeField]
    public Text addBtnText, addSubtitle, statsSubtitle, helpSubtitle;
    [SerializeField]
    private Button Close, Previous, Next;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private TutorialFooterManager footerManager;
#pragma warning restore 0649

    private int state;

    private void Awake()
    {
        Close.onClick.AddListener(() => CloseTutorial());
        Previous.onClick.AddListener(() => PresentTutorial(false));
        Next.onClick.AddListener(() => PresentTutorial(true));
    }
    void OnEnable()
    {
        state = -1;
        headerManager.Initialize();
        footerManager.Initialize(true);
        LanguagesFillers.FillAddToSquadButtonState(addBtnText, false);
        LanguagesFillers.FillMonsterTutorial(addSubtitle, statsSubtitle, helpSubtitle);
        PresentTutorial(true);
    }
    private void StateManager(bool incrDecr, int max)
    {
        state = incrDecr ? state + 1 : state - 1;
        state = state < 0 ? 0 : state;
        state = state > max ? max : state;
    }
    private void PresentTutorial(bool nextPrevious)
    {
        StateManager(nextPrevious, 3);
        if (state == 0)
        {
            TurnOptionsOff();
            TurnOptionOn(Header);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(Stats);
            footerManager.Initialize(true);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Help);
            footerManager.Initialize(false);
        }
        if (state == 3)
        {
            CloseTutorial();
        }        
    }
    private void CloseTutorial()
    {
        footerManager.MarkTutorial();
        TutorialUI.SetActive(false);
    }
    private void TurnOptionOn(GameObject option) => option.SetActive(true);
    private void TurnOptionsOff()
    {
        Header.SetActive(false);
        Stats.SetActive(false);
        Help.SetActive(false);
    }
}
