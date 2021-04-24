using UnityEngine;
using UnityEngine.UI;

public class WorldMapTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject TutorialUI, Wellcome, Powers, Monsters, MonstersMsg, 
        MonstersMsg2, MonstersMsg3, MonstersMsg4, Duel, Players;
    [SerializeField]
    private Text WellcomeMessage, PowersMessage, MonstersMessage, MonstersMessage2, MonstersMessage3, 
        MonstersMessage4, DuelMessage, PlayersMessage;
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
        LanguagesFillers.FillWorldMapTutorialOptions(WellcomeMessage, PowersMessage, MonstersMessage, 
            MonstersMessage2, MonstersMessage3, MonstersMessage4, DuelMessage, PlayersMessage);
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
        StateManager(nextPrevious, 8);
        if (state == 0)
        {
            TurnOptionsOff();
            TurnOptionOn(Wellcome);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(Powers);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Monsters);
            TurnOptionOn(MonstersMsg);
        }
        if (state == 3)
        {
            TurnOptionsOff();
            TurnOptionOn(Monsters);
            TurnOptionOn(MonstersMsg2);
        }
        if (state == 4)
        {
            TurnOptionsOff();
            TurnOptionOn(Monsters);
            TurnOptionOn(MonstersMsg3);
        }
        if (state == 5)
        {
            TurnOptionsOff();
            TurnOptionOn(Monsters);
            TurnOptionOn(MonstersMsg4);
        }
        if (state == 6)
        {
            TurnOptionsOff();
            TurnOptionOn(Duel);
            footerManager.Initialize(true);
        }
        if (state == 7)
        {
            TurnOptionsOff();
            TurnOptionOn(Players);
            footerManager.Initialize(false);
        }
        if (state == 8)
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
        Wellcome.SetActive(false);
        Powers.SetActive(false);
        Monsters.SetActive(false);
        MonstersMsg.SetActive(false);
        MonstersMsg2.SetActive(false);
        MonstersMsg3.SetActive(false);
        MonstersMsg4.SetActive(false);
        Duel.SetActive(false);
        Players.SetActive(false);
    }
}
