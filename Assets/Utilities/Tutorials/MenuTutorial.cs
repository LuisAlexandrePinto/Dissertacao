using UnityEngine;
using UnityEngine.UI;

public class MenuTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject Exit, Definitions, Bestiary, Player, Squadron, Abilities,
        ExitBtn, DefinitionsBtn, BestiaryBtn, PlayerBtn, SquadronBtn, AbilitiesBtn, TitleHelper, TutorialUI;
    [SerializeField]
    private Text Title, ExitTitle, DefinitionsTitle, BestiaryTitle, PlayerTitle, SquadronTitle, AbilitiesTitle,
        BackBtn, HelpBtn, BackBtnTitle, HelpBtnTitle;
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
        LanguagesFillers.FillMenuOptions(ExitTitle, DefinitionsTitle, BestiaryTitle, PlayerTitle, SquadronTitle, AbilitiesTitle);        
        LanguagesFillers.MenuTutorialHeaderFiller(BackBtnTitle, HelpBtnTitle);
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
            TurnOptionOn(TitleHelper);
        }
        if (state == 1)
        {
            TurnOptionsOff();
            TurnOptionOn(Exit);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnOptionOn(Definitions);
        }
        if (state == 3)
        {
            TurnOptionsOff();
            TurnOptionOn(Bestiary);
        }
        if (state == 4)
        {
            TurnOptionsOff();
            TurnOptionOn(Player);
        }
        if (state == 5)
        {
            TurnOptionsOff();
            TurnOptionOn(Squadron);
        }
        if (state == 6)
        {
            TurnOptionsOff();
            TurnOptionOn(Abilities);
            footerManager.Initialize(true);
        }
        if (state == 7)
        {
            TurnOptionsOff();
            ToggleButtons(true);
            footerManager.Initialize(false);            
        }
        if(state == 8)
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
        ToggleButtons(false);
        Exit.SetActive(false);
        Definitions.SetActive(false);
        Bestiary.SetActive(false);
        Player.SetActive(false);
        Squadron.SetActive(false);
        Abilities.SetActive(false);
        TitleHelper.SetActive(false);
    }
    private void ToggleButtons(bool onOff)
    {
        ExitBtn.SetActive(onOff);
        DefinitionsBtn.SetActive(onOff);
        BestiaryBtn.SetActive(onOff);
        PlayerBtn.SetActive(onOff);
        SquadronBtn.SetActive(onOff);
        AbilitiesBtn.SetActive(onOff);
    }
}
