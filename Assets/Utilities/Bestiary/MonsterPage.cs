using UnityEngine;
using UnityEngine.UI;

public class MonsterPage : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    public Image background;
    [SerializeField]
    private Button HelpBtn, AddBtn;
    [SerializeField]
    public Text addBtnText;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private AttackDefenseMonsterManager attackDefense;
    [SerializeField]
    private SabotageMonsterManager sabotage;
    [SerializeField]
    private GameObject AtkDefStats, AtkShield, DefShield, SabStats, SabShield, TutorialUI;
#pragma warning restore 0649
    public Monster monster;
    private bool IsAdded;

    private void Awake()
    {
        HelpBtn.onClick.AddListener(() => TurnOnTutorial());
        AddBtn.onClick.AddListener(() => AddMonsterToPlayerSquad());
    }

    private void OnEnable()
    {
        CheckTutorial();
        string monsterName = monster.MonsterName + "\n" + LanguagesFillers.Lang.Level + " " + monster.Stats.Level;
        headerManager.Initialize(AbilityType.NONE, monsterName);                  
        IsAdded = GameManager.Instance.CurrentPlayer.Squadron.IsMonsterInSquadron(monster);
        LanguagesFillers.FillAddToSquadButtonState(addBtnText, IsAdded);        
        ImagesFillers.AddMonsterMenubackground(background, monster.Type);        
        if(monster.Type == MonsterType.SABOTAGE)
        {
            sabotage.Initialize(monster);
            AtkDefStats.SetActive(false);
            AtkShield.SetActive(false);
            DefShield.SetActive(false);
        }
        else
        {
            attackDefense.Initialize(monster);
            SabStats.SetActive(false);
            SabShield.SetActive(false); 
        }
    }
    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt(SquadUpConstants.MONSTERMENU_TUTORIAL) == 0)
        {
            TurnOnTutorial();
        }
    }
    private void TurnOnTutorial() => TutorialUI.SetActive(true);
    public void AddMonsterToPlayerSquad()
    {
        if (!IsAdded)
        {
            GameManager.Instance.CurrentPlayer.Squadron.AddMonster(monster);
            GameManager.Instance.CurrentPlayer.Save();
            IsAdded = true;
        }
        LanguagesFillers.FillAddToSquadButtonState(addBtnText, IsAdded);
    }
}
