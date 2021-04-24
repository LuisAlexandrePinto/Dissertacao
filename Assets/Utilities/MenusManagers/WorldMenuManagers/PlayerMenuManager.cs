using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject TutorialUI;
    [SerializeField]
    private Image Background;
    [SerializeField]
    private Button HelpBtn;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private Text BackBtn, UsernameLevel, HelpBtnTitle;
    [SerializeField]
    private XPPlayerManager XP;
    [SerializeField]
    private PointsPlayerManager Points;
    [SerializeField]
    private MonstersPlayerManager Monsters;
    [SerializeField]
    private BattlesPlayerManager Batles;
    [SerializeField]
    private PotionsPlayerManager Potions;
#pragma warning restore 0649
    private void Awake() => HelpBtn.onClick.AddListener(() => TurnOnTutorial());

    private void OnEnable()
    {
        CheckTutorial();
        Player player = GameManager.Instance.CurrentPlayer;
        MonsterManager monsterManager = GameManager.Instance.MonsterManager;
        ImagesFillers.AddRandomMenuBackground(Background);
        headerManager.Initialize();        
        XP.Initialize(player);
        Points.Initialize(player);
        Monsters.Initialize(monsterManager);
        Batles.Initialize(player);
        Potions.Initialize(player);
    }
    private void TurnOnTutorial() => TutorialUI.SetActive(true);
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.PLAYER_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }
}
