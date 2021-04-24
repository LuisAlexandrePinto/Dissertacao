using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryPrefabManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject MonsterPlate, TutorialUI;
    [SerializeField]
    private Transform ContentPanel;
    [SerializeField]
    private Text Uncommon;
    [SerializeField]
    private GameObject PanelController;
    [SerializeField]
    private Image Background;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private Button allTypes, attackType, defenseType, sabotageType,
        allRarities, commonMonsters, uncommonMonsters, rareMonsters, mythicMonsters, HelpBtn;
#pragma warning restore 0649

    private MonsterManager monsterManager;
    private List<GameObject> monsterPlates, attackPlates, defensePlates, sabotagePlates;
    private bool attackOnOff, defenseOnOff, sabotageOnOff, common, uncommon, rare, mythic;

    private void Awake() => HelpBtn.onClick.AddListener(() => TurnOnTutorial());

    // Start is called before the first frame update
    void Start()
    {
        monsterManager = GameManager.Instance.MonsterManager;
        monsterPlates = new List<GameObject>();
        attackPlates = new List<GameObject>();
        defensePlates = new List<GameObject>();
        sabotagePlates = new List<GameObject>();
        InitiateScrollView();
        ActivateButtons();
        attackOnOff = defenseOnOff = sabotageOnOff = true;
        common = uncommon = rare = mythic = false;
    }
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.BESTIARY_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }
    private void TurnOnTutorial() => TutorialUI.SetActive(true);

    private void InitiateScrollView()
    {
        foreach (Monster monster in monsterManager.Monsters)
        {
            GameObject monsterFrame = Instantiate(MonsterPlate, ContentPanel);
            BestiaryPlateManager plate = monsterFrame.GetComponent<BestiaryPlateManager>();
            plate.LinkPrefabToScript(monster, PanelController);
            monsterPlates.Add(monsterFrame);
            AddOnTypeList(monster.Type, monsterFrame);
        }
    }
    private void AddOnTypeList(MonsterType type, GameObject monsterFrame)
    {
        switch (type)
        {
            case MonsterType.ATTACK: attackPlates.Add(monsterFrame); break;
            case MonsterType.DEFENSE: defensePlates.Add(monsterFrame); break;
            case MonsterType.SABOTAGE: sabotagePlates.Add(monsterFrame); break;
        }
    }
    private void ActivateButtons()
    {
        allTypes.onClick.AddListener(() =>
        {
            common = uncommon = rare = mythic = false;
            ActivatePlates(true, true, true);            
        });
        attackType.onClick.AddListener(() => ActivateTypePlates(MonsterType.ATTACK));
        defenseType.onClick.AddListener(() => ActivateTypePlates(MonsterType.DEFENSE));
        sabotageType.onClick.AddListener(() => ActivateTypePlates(MonsterType.SABOTAGE));
        allRarities.onClick.AddListener(() =>
        {
            common = uncommon = rare = mythic = false;
            ActivatePlates(attackOnOff, defenseOnOff, sabotageOnOff);            
        });
        commonMonsters.onClick.AddListener(() => ActivateRarityPlates(MonsterRarity.COMMON));
        uncommonMonsters.onClick.AddListener(() => ActivateRarityPlates(MonsterRarity.UNCOMMON));
        rareMonsters.onClick.AddListener(() => ActivateRarityPlates(MonsterRarity.RARE));
        mythicMonsters.onClick.AddListener(() => ActivateRarityPlates(MonsterRarity.MYTHIC));
    }
    private void ActivatePlates(bool attack, bool defense, bool sabotage)
    {
        attackOnOff = attack;
        defenseOnOff = defense;
        sabotageOnOff = sabotage;
        attackPlates.ForEach(plate => plate.SetActive(attackOnOff));
        defensePlates.ForEach(plate => plate.SetActive(defenseOnOff));
        sabotagePlates.ForEach(plate => plate.SetActive(sabotageOnOff));
        ActivateTypeAndRarity();
    }
    private void ActivateTypeAndRarity()
    {
        if (common)
        {
            ActivateRarityPlates(MonsterRarity.COMMON);
        }
        if (uncommon)
        {
            ActivateRarityPlates(MonsterRarity.UNCOMMON);
        }
        if (rare)
        {
            ActivateRarityPlates(MonsterRarity.RARE);
        }
        if (mythic)
        {
            ActivateRarityPlates(MonsterRarity.MYTHIC);
        }
    }
    private void ActivateRarityPlates(MonsterRarity rarity)
    {
        switch (rarity)
        {
            case MonsterRarity.COMMON: common = true; uncommon = rare = mythic = false; break;
            case MonsterRarity.UNCOMMON: uncommon = true; common = rare = mythic = false; break;
            case MonsterRarity.RARE: rare = true; common = uncommon = mythic = false; break;
            case MonsterRarity.MYTHIC: mythic = true; common = uncommon = rare = false; break;
        }
        if (attackOnOff)
        {
            attackPlates.ForEach(plate => plate.SetActive(plate.GetComponent<BestiaryPlateManager>().GetMonsterRarity() == rarity));
        }
        if (defenseOnOff)
        {
            defensePlates.ForEach(plate => plate.SetActive(plate.GetComponent<BestiaryPlateManager>().GetMonsterRarity() == rarity));
        }
        if (sabotageOnOff)
        {
            sabotagePlates.ForEach(plate => plate.SetActive(plate.GetComponent<BestiaryPlateManager>().GetMonsterRarity() == rarity));
        }
    }
    private void ActivateTypePlates(MonsterType type)
    {
        switch (type)
        {
            case MonsterType.ATTACK: ActivatePlates(true, false, false); break;
            case MonsterType.DEFENSE: ActivatePlates(false, true, false); break;
            case MonsterType.SABOTAGE: ActivatePlates(false, false, true); break;
        }
    }
    private void OnEnable()
    {
        CheckTutorial();
        ImagesFillers.AddRandomMenuBackground(Background);
        Uncommon.text = LanguagesFillers.Lang.Uncommon.Substring(0, 1);
        headerManager.Initialize();
    }
}
