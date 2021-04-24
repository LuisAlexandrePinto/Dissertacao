using UnityEngine;
using UnityEngine.UI;

public class DuelTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject TutorialUI, Options, DuelHPs, DuelCombatSkillsPhase, DuelResultPhase;
    [SerializeField]
    private Text OptionsMessage, DuelHPsMessage, DuelCombatSkillsMessage, DuelResultMessage;
    [SerializeField]
    private Image AttackPhase, DefensePhase, HPs, CombatSkill, Result;
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
    private void OnEnable()
    {
        state = -1;
        footerManager.Initialize(true);
        ImagesFillers.AddDuelAttackPhaseImage(AttackPhase);
        ImagesFillers.AddDuelDefensePhaseImage(DefensePhase);
        ImagesFillers.AddDuelHPsImage(HPs);
        ImagesFillers.AddDuelCombatSkillsImage(CombatSkill);
        ImagesFillers.AddDuelCombatResultImage(Result);
        LanguagesFillers.FillDuelTutorialOptions(OptionsMessage, DuelHPsMessage, DuelCombatSkillsMessage, DuelResultMessage);
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
        StateManager(nextPrevious, 4);
        if (state == 0)
        {
            TurnOptionsOff();
            TurnOptionOn(Options);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(DuelHPs);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(DuelCombatSkillsPhase);
            footerManager.Initialize(true);
        }
        if (state == 3)
        {
            TurnOptionsOff();
            TurnOptionOn(DuelResultPhase);
            footerManager.Initialize(false);
        }
        if (state == 4)
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
        DuelHPs.SetActive(false);
        DuelCombatSkillsPhase.SetActive(false);
        DuelResultPhase.SetActive(false);
    }
}
