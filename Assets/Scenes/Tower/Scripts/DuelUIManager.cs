using UnityEngine;
using UnityEngine.UI;

public class DuelUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text HPPotion, Insp, Fight, ContinueToFight, RunAway, ExitQuestion, Yes, No;
    [SerializeField]
    private GameObject RunAwayGO, ContinueGO, HPGO, InspirationGO, FightGO,
        EndDuelPanelGO, AttackDefensePanel, RoundResultPanel, LevelLoader, ConfirmationUI, DuelUI;
    [SerializeField]
    private Button RunAwayBtn, YesBtn, NoBtn;
    [SerializeField]
    private Animator transition;
#pragma warning restore 0649
    public void ProcedeToFight(int hpAmount, int inspAmount, bool attackDefend)
    {
        RunAwayGO.SetActive(false);
        ContinueGO.SetActive(false);
        HPGO.SetActive(true);
        InspirationGO.SetActive(true);
        FightGO.SetActive(true);
        LanguagesFillers.FillDuelFigthtButtons(HPPotion, Insp, hpAmount, inspAmount);
        ToggleFightStance(attackDefend);
    }

    public void ToggleFightStance(bool attackDefend) => LanguagesFillers.ToggleFightPosition(Fight, attackDefend);

    // Start is called before the first frame update
    void Start()
    {
        SceneTransitionManager.Instance.SetLoader(LevelLoader);
        SceneTransitionManager.Instance.SetAnimator(transition);
        LanguagesFillers.FillDuelOptionsButtons(RunAway, ContinueToFight);
        RunAwayBtn.onClick.AddListener(() => ActivateConfirmationSubPanel());        
    }

    public void ToggleFightPanel(bool onOff) => AttackDefensePanel.SetActive(onOff);
    public void ToggleResultPanel(bool onOff) => RoundResultPanel.SetActive(onOff);
    public void ToggleEndDuelPanel() => EndDuelPanelGO.SetActive(true);
    public void ReduceHpPotions(int hpAmount) => LanguagesFillers.UpdateHPPotions(HPPotion, hpAmount);
    public void ReduceInspPotions(int inspAmount) => LanguagesFillers.UpdateInspPotions(Insp, inspAmount);
    private void ActivateConfirmationSubPanel()
    {        
        ToggleConfirmation(true);
        LanguagesFillers.FillConfirmationSubPanel(ExitQuestion, Yes, No);
        YesBtn.onClick.AddListener(() => SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_WORLD));
        NoBtn.onClick.AddListener(() => ToggleConfirmation(false));
    }    
    private void ToggleConfirmation(bool onOff) => ConfirmationUI.SetActive(onOff);
}
