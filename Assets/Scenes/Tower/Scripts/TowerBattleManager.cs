using UnityEngine;
using UnityEngine.UI;

public class TowerBattleManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Button ContinueBtn, HPBtn, InspirationBtn, FightBtn, ContinueToResultBtn, EndRoundBtn, HelpBtn;
    [SerializeField]
    private AttackerManager AttackerManager;
    [SerializeField]
    private DefensorManager DefensorManager;
    [SerializeField]
    private DamagePanelManager DamagePanelManager;
    [SerializeField]
    private EndDuelPanel EndDuelPanel;
    [SerializeField]
    private GameObject plDefPos, plAtkPos, plSabPos, enDefPos, enAtkPos, enSabPos, plBigBoss, enBigBoss, TutorialUI;
    [SerializeField]
    private Text HelpBtnTitle;
    [SerializeField]
    private HealthManager healthManager;
    [SerializeField]
    private DuelUIManager uIManager;
    [SerializeField]
    private Animator transition;
#pragma warning restore 0649

    private EnemySquadronGenerator EnemySquad;
    private Player player;
    private CombatManager combatManager;
    private FightersManager fightersManager;
    private bool hpPotionUsed, inspPotionUsed = false;
    private void Awake() => HelpBtn.onClick.AddListener(() => TurnOnTutorial());
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.DUEL_TUTORIAL) == 0)
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
        player = GameManager.Instance.CurrentPlayer;
        EnemySquad = new EnemySquadronGenerator(player);
        fightersManager = new FightersManager(EnemySquad);
        InstantiateMonsters(player.Squadron, plDefPos, plAtkPos, plSabPos, true);
        InstantiateMonsters(EnemySquad.Squadron, enAtkPos, enDefPos, enSabPos, false);
        combatManager = new CombatManager(fightersManager);
        StartHpBars();
        ContinueBtn.onClick.AddListener(() => Continue());
        InitializePanelsGOs(fightersManager);
    }
    private void InitializePanelsGOs(FightersManager fightersManager)
    {
        AttackerManager.Initialize(fightersManager);
        DefensorManager.Initialize(fightersManager);
        DamagePanelManager.Initialize(fightersManager);
        EndDuelPanel.Initialize(fightersManager);
    }

    private void StartHpBars()
    {
        healthManager.StartPlayerHPs(player.Squadron);
        healthManager.StartEnemyHPs(EnemySquad.Squadron);
    }
    private void InstantiateMonsters(Squadron squadron, GameObject defPos, GameObject atkPos, GameObject sabPos, bool playerEnemy)
    {
        defPos.transform.rotation = squadron.DefMonster.MonsterName.Equals("BigBoss") ? playerEnemy ? plBigBoss.transform.rotation : enBigBoss.transform.rotation : defPos.transform.rotation;
        GenerateMonsterByPosition(squadron.DefMonster, defPos.transform);
        GenerateMonsterByPosition(squadron.AtkMonster, atkPos.transform);
        GenerateMonsterByPosition(squadron.SabMonster, sabPos.transform);
    }
    private void GenerateMonsterByPosition(Monster monster, Transform position) => Instantiate(monster, position.transform.position, position.transform.rotation);

    public void HealthPotion()
    {
        if (!hpPotionUsed && player.HpPotions > 0)
        {
            hpPotionUsed = true;
            player.Squadron.UseHPPotion();
            healthManager.UpdateHPs(player.Squadron, true);
            uIManager.ReduceHpPotions(player.HpPotions);
        }
    }
    public void InspirationPotion()
    {
        if (!inspPotionUsed && player.InspPotions > 0)
        {
            inspPotionUsed = true;
            player.Squadron.UseInspPotion(true);
            uIManager.ReduceInspPotions(player.InspPotions);
        }
    }
    public void Continue()
    {
        uIManager.ProcedeToFight(player.HpPotions, player.InspPotions, fightersManager.IsPlayerAttacking);
        FightBtn.onClick.AddListener(() => Fight());
    }
    private void Fight()
    {
        if (!combatManager.GameFinished)
        {            
            combatManager.Fight();
            healthManager.UpdateHPs(player.Squadron, true);
            healthManager.UpdateHPs(EnemySquad.Squadron, false);
            uIManager.ToggleFightPanel(true);
            ContinueToResultBtn.onClick.AddListener(() =>
            {
                uIManager.ToggleFightPanel(false);
                uIManager.ToggleResultPanel(true);
                uIManager.ToggleFightStance(fightersManager.IsPlayerAttacking);
                player.Squadron.UseInspPotion(true);
                hpPotionUsed = inspPotionUsed = false;
                EndRoundBtn.onClick.AddListener(() =>
                {
                    uIManager.ToggleResultPanel(false);
                    if (combatManager.GameFinished)
                    {
                        uIManager.ToggleEndDuelPanel();
                    }
                });
            });            
        }
    }
}
