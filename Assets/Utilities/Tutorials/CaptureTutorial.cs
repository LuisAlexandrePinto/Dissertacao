using UnityEngine;
using UnityEngine.UI;

public class CaptureTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject TutorialUI, Options, OrbCounter, Orb;
    [SerializeField]
    private Text OptionsMessage, OrbCounterMessage, OrbMessage, RunAwayTitle, ContinueTitle;
    [SerializeField]
    private Button Close, Previous, Next;
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
        footerManager.Initialize(true);
        LanguagesFillers.FillDuelOptionsButtons(RunAwayTitle, ContinueTitle);
        LanguagesFillers.FillCaptureTutorialOptions(OptionsMessage, OrbCounterMessage, OrbMessage);
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
            TurnOptionOn(Options);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(OrbCounter);
            footerManager.Initialize(true);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Orb);
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
        Options.SetActive(false);
        OrbCounter.SetActive(false);
        Orb.SetActive(false);        
    }
}
