using UnityEngine;
using UnityEngine.EventSystems;

public class PanelController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject attackButton, defenseButton, rogueButton;
    [SerializeField]
    public GameObject
        currentScreen, mainMenu, definitionsMenu, playerMenu, uiManagerMenu,
        squadronMenu, bestiaryMenu, abilitiesMenu, abilityMenu, monsterMenu;
#pragma warning restore 0649

    private AbilityType abilityType;
    private AbilityBranchManager abilityBranchManager;
    private MonsterPage monsterPage;
    private MenuManager menuManager;
    private UIManager uiManager;

    void Start()
    {
        monsterPage = monsterPage ?? monsterMenu.GetComponent<MonsterPage>();
        abilityBranchManager = abilityBranchManager ?? abilityMenu.GetComponent<AbilityBranchManager>();
        menuManager = menuManager ?? mainMenu.GetComponent<MenuManager>();
        uiManager = uiManager ?? uiManagerMenu.GetComponent<UIManager>();
    }
    public void GetBackPanel(GameObject backPanel)
    {
        currentScreen.SetActive(false);
        if (currentScreen == definitionsMenu && backPanel == mainMenu)
        {
            menuManager.Initialize();
            uiManager.Initialize();
        }
        currentScreen = backPanel;
    }

    public void GoToNextPanel(GameObject nextPanel)
    {
        currentScreen = nextPanel;
        currentScreen.SetActive(true);
    }

    public void GetOutOfAbilitiesMenu(GameObject nextPanel)
    {
        GameManager.Instance.AbilitiesContainer.UpdateAbilitiesValuesWithData();
        GameManager.Instance.CurrentPlayer.UpdateAbilities();
        GetBackPanel(nextPanel);
    }

    public void GoToMonsterPanel(GameObject nextPanel, Monster monster)
    {
        monsterPage.monster = monster;
        GoToNextPanel(nextPanel);
    }
    public void GoToAbilityBranch(GameObject nextPanel)
    {
        if (EventSystem.current.currentSelectedGameObject.name == attackButton.name)
        {
            abilityType = AbilityType.ATTACK;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == defenseButton.name)
        {
            abilityType = AbilityType.DEFENSE;

        }
        else if (EventSystem.current.currentSelectedGameObject.name == rogueButton.name)
        {
            abilityType = AbilityType.SABOTAGE;
        }

        abilityBranchManager.SelectedAbilityBranch(abilityType);
        GoToNextPanel(nextPanel);
    }

    public void BackToAbilitiesMenu(GameObject backPanel)
    {
        abilityBranchManager.TogglePrefabs(false);
        GetBackPanel(backPanel);
    }
}
