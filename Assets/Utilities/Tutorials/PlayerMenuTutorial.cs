using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject PlayerTutorialUI, XP, Points, Batles, Monsters, Potions;
    [SerializeField]
    private Text XPSubtitle, PointsSubtitle, BatlesSubtitle, MonstersSubtitle,  PotionsSubtitle;
    [SerializeField]
    private Button Close, Previous, Next;
    [SerializeField]
    private XPPlayerManager XPManager;
    [SerializeField]
    private PointsPlayerManager PointsManager;
    [SerializeField]
    private MonstersPlayerManager MonstersManager;
    [SerializeField]
    private BattlesPlayerManager BatlesManager;
    [SerializeField]
    private PotionsPlayerManager PotionsManager;    
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
        Player player = GameManager.Instance.CurrentPlayer;
        MonsterManager monsterManager = GameManager.Instance.MonsterManager;
        XPManager.Initialize(player);
        PointsManager.Initialize(player);
        MonstersManager.Initialize(monsterManager);
        BatlesManager.Initialize(player);
        PotionsManager.Initialize(player);
        footerManager.Initialize(true);
        LanguagesFillers.FillPlayerTutorial(XPSubtitle, PointsSubtitle, BatlesSubtitle, MonstersSubtitle, PotionsSubtitle);
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
        StateManager(nextPrevious, 5);
        if (state == 0)
        {
            TurnOptionsOff();
            TurnOptionOn(XP);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(Points);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Batles);
        }
        if (state == 3)
        {
            TurnOptionsOff();
            TurnOptionOn(Monsters);
            footerManager.Initialize(true);
        }
        if (state == 4)
        {
            TurnOptionsOff();
            TurnOptionOn(Potions);
            footerManager.Initialize(false);            
        }
        if (state == 5)
        {
            CloseTutorial();
        }
    }

    private void CloseTutorial()
    {
        footerManager.MarkTutorial();
        PlayerTutorialUI.SetActive(false);
    }
    private void TurnOptionOn(GameObject option) => option.SetActive(true);
    private void TurnOptionsOff()
    {
        XP.SetActive(false);
        Points.SetActive(false);
        Batles.SetActive(false);
        Monsters.SetActive(false);
        Potions.SetActive(false);
    }
}
