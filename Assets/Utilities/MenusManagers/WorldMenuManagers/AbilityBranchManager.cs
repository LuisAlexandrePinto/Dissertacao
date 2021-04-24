using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBranchManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform contentPanel;
    [SerializeField]
    private Button HelpBtn;
    [SerializeField]
    private GameObject abilityModel, abilityModelNoCombos, TutorialUI;
    [SerializeField]
    private Image background;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private Text attackCounter, defenseCounter, sabotageCounter, userCounter;
#pragma warning restore 0649

    private AbilityType abilityType;
    private List<GameObject> attackPrefabs, defensePrefabs, sabotagePrefabs;
    private List<AbilityPrefabManager> managers;
    private void Awake()
    {
        HelpBtn.onClick.AddListener(() => TurnOnTutorial());
        Initialize();
    }
    private void OnEnable()
    {
        CheckTutorial();
        ImagesFillers.AddRandomMenuBackground(background);
        headerManager.Initialize(abilityType);
        TogglePrefabs(true);
    }
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.ABILITIES_LINE_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }

    private void TurnOnTutorial() => TutorialUI.SetActive(true);
    public void Initialize()
    {
        managers = new List<AbilityPrefabManager>();
        attackPrefabs = GeneratePrefabs(GameManager.Instance.AbilitiesContainer.GetTypeAbilities(AbilityType.ATTACK, false), attackCounter);
        defensePrefabs = GeneratePrefabs(GameManager.Instance.AbilitiesContainer.GetTypeAbilities(AbilityType.DEFENSE, false), defenseCounter);
        sabotagePrefabs = GeneratePrefabs(GameManager.Instance.AbilitiesContainer.GetTypeAbilities(AbilityType.SABOTAGE, false), sabotageCounter);
        AssociateManagers();
        TurnOnOffPrefabs(attackPrefabs, false);
        TurnOnOffPrefabs(defensePrefabs, false);
        TurnOnOffPrefabs(sabotagePrefabs, false);
    }
    private List<GameObject> GeneratePrefabs(List<Ability> abilities, Text counter)
    {
        List<GameObject> prefabs = new List<GameObject>();
        foreach (Ability ability in abilities)
        {
            GameObject gameObject = Instantiate(abilityModel, contentPanel);
            AbilityPrefabManager abilityManager = gameObject.GetComponent<AbilityPrefabManager>();
            abilityManager.LinkPrefabToScript(ability, counter, userCounter);
            managers.Add(abilityManager);
            prefabs.Add(gameObject);
        }
        return prefabs;
    }

    private void AssociateManagers()
    {
        foreach (AbilityPrefabManager manager in managers)
        {
            List<AbilityPrefabManager> managerCombos = new List<AbilityPrefabManager>();
            manager.GetCombosIndexes().ForEach(index => managerCombos.Add(GetManager(index)));
            manager.PutCombosList(managerCombos);
        }
    }
    private AbilityPrefabManager GetManager(AbilityIndex abilityIndex) => managers.Find(manager => manager.GetIndex() == abilityIndex);


    public void SelectedAbilityBranch(AbilityType abilityType) => this.abilityType = abilityType;
    public void TogglePrefabs(bool toggle)
    {
        switch (abilityType)
        {
            case AbilityType.ATTACK: TurnOnOffPrefabs(attackPrefabs, toggle); break;
            case AbilityType.DEFENSE: TurnOnOffPrefabs(defensePrefabs, toggle); break;
            case AbilityType.SABOTAGE: TurnOnOffPrefabs(sabotagePrefabs, toggle); break;
        }
    }
    private void TurnOnOffPrefabs(List<GameObject> abilities, bool toggle) => abilities.ForEach(ability => ability.SetActive(toggle));
}
