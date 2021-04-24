using UnityEngine;
using UnityEngine.UI;

public class AbilitiesBranchTutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject 
        TutorialUI, Header, AbilityExample, Icon, ComboIcon1, ComboIcon2, Title, 
        Description, Combo, Counter, ComboCounter1, ComboCounter2, ButtonsSubtitle, 
        InfoSubtitle, IconsSubtitle, Plusbtn, MinusBtn, AbilityCore, ListSubtitle;
    [SerializeField]
    private Button Close, Previous, Next;
    [SerializeField]
    private Text 
        HeaderSubtitle, AbyTitle, AbyCounter, AbyComboCounter1, AbyComboCounter2, 
        AbyCombo, description, buttonsSubtitle, infoSubtitle, iconsSubtitle, listSubtitle;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private TutorialFooterManager footerManager;
#pragma warning restore 0649

    private Ability ability;
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
        ability = GameManager.Instance.AbilitiesContainer.GetTypeAbilities(AbilityType.ATTACK, false)[0];
        footerManager.Initialize(true);
        headerManager.Initialize();                       
        LanguagesFillers.FillAbilityExample(HeaderSubtitle, buttonsSubtitle, infoSubtitle, iconsSubtitle, listSubtitle);
        UpdateTexts();
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
            TurnAbilityOptionsOff();
            TurnOptionsOff();
            TurnOptionOn(Header);
        }
        if (state == 1)
        {
            TurnAbilityOptionsOff();
            TurnOptionsOff();
            TurnOptionOn(AbilityExample);
            TurnOptionOn(Plusbtn);
            TurnOptionOn(MinusBtn);
            TurnOptionOn(ButtonsSubtitle);
        }
        if (state == 2)
        {
            TurnOptionsOff();
            TurnIcons(true);
            TurnOptionOn(IconsSubtitle);
        }
        if (state == 3)
        {
            TurnOptionsOff();
            TurnInfo(true);
            TurnOptionOn(InfoSubtitle);
            footerManager.Initialize(true);
        }
        if (state == 4)
        {
            TurnOptionsOff();
            TurnOptionOn(Plusbtn);
            TurnOptionOn(MinusBtn);
            TurnOptionOn(ListSubtitle);
            TurnIcons(true);
            TurnInfo(true);
            footerManager.Initialize(false);
        }
        if (state == 5)
        {
            CloseTutorial();
        }
    }
    private void TurnOptionOn(GameObject option) => option.SetActive(true);
    private void CloseTutorial()
    {
        AbilityExample.SetActive(false);
        footerManager.MarkTutorial();
        TutorialUI.SetActive(false);
    }

    private void UpdateTexts()
    {
        AbyTitle.text = ability.AbilityName;
        description.text = ability.Description;
        PutPointsAndColor(ability, AbyCounter);
        PutPointsAndColor(ability.ComboAbilities[0], AbyComboCounter1);
        if (ability.ComboAbilities.Count > 1)
        {
            PutPointsAndColor(ability.ComboAbilities[1], AbyComboCounter2);
        }
    }
    private void PutPointsAndColor(Ability ability, Text text)
    {
        text.text = ability.FormatedPoints();
        switch (ability.AbilityType)
        {
            case AbilityType.ATTACK: text.color = Color.red; break;
            case AbilityType.DEFENSE: text.color = Color.green; break;
            case AbilityType.SABOTAGE: text.color = Color.magenta; break;
        }
    }

    private void TurnAbilityOptionsOff()
    {
        TurnIcons(false);
        TurnInfo(false);
        ButtonsSubtitle.SetActive(false);
        IconsSubtitle.SetActive(false);
        InfoSubtitle.SetActive(false);
        Plusbtn.SetActive(false);
        MinusBtn.SetActive(false);
    }
    private void TurnIcons(bool onOff)
    {
        Icon.SetActive(onOff);
        Combo.SetActive(onOff);
        ComboIcon1.SetActive(onOff);
        ComboIcon2.SetActive(onOff);
        Counter.SetActive(onOff);
        ComboCounter1.SetActive(onOff);
        ComboCounter2.SetActive(onOff);
    }
    private void TurnInfo(bool onOff)
    {
        Title.SetActive(onOff);
        Description.SetActive(onOff);
    }
    private void TurnOptionsOff()
    {
        Header.SetActive(false);        
        TurnAbilityOptionsOff();
    }
}
