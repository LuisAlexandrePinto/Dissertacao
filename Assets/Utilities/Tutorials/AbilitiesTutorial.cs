using UnityEngine;
using UnityEngine.UI;

public class AbilitiesTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject TutorialUI, Attack, Defense, Sabotage;
    [SerializeField]
    private Button Close, Previous, Next;
    [SerializeField]
    private Text AttackSubtitle, DefenseSubtitle, SabotageSubtitle;
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
    private void OnEnable()
    {
        state = -1;
        footerManager.Initialize(true);
        LanguagesFillers.FillAbilitiesTutorialOptions(AttackSubtitle, DefenseSubtitle, SabotageSubtitle);
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
            TurnOptionOn(Attack);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(Defense);
            footerManager.Initialize(true);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Sabotage);
            footerManager.Initialize(false);
        }
        if (state == 3)
        {
            CloseTutorial();
        }
    }
    private void TurnOptionOn(GameObject option) => option.SetActive(true);
    private void TurnOptionsOff()
    {
        Attack.SetActive(false);
        Defense.SetActive(false);
        Sabotage.SetActive(false);
    }
    private void CloseTutorial()
    {
        footerManager.MarkTutorial();
        TutorialUI.SetActive(false);
    }
}
