using UnityEngine;
using UnityEngine.UI;

public class EndDuelPanel : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject EvolutionPanel;
    [SerializeField]
    private Button EndDuelBtn;
    [SerializeField]
    private Text Title, ExperienceTitle, WonTitle, TotalTitle, WonValue, TotalValue, DamageTitle, ReceivedTitle, ReceivedValue, 
        GivenTitle, GivenValue, DefendedTitle, DefendedValue, EndDuel, Evolution, WonPointsTitle, TotalPointsTitle, WonPointsValue, TotalPointsValue;
#pragma warning restore 0649

    private FightersManager fightersManager;
    private bool ProcessExperienceResult(FightStages player)
    {
        int level = GameManager.Instance.CurrentPlayer.Level;
        GameManager.Instance.CurrentPlayer.AddXp(player.Won ? 25.0f : 12.5f);
        return level < GameManager.Instance.CurrentPlayer.Level;
    }
    public void Initialize(FightersManager fightersManager) => this.fightersManager = fightersManager;

    public void OnEnable()
    {
        FightStages player = fightersManager.Player;
        LanguagesFillers.FillEndDuelPanel(player.Won, Title, ExperienceTitle, WonTitle, TotalTitle, DamageTitle, ReceivedTitle, GivenTitle, DefendedTitle, EndDuel);
        if (ProcessExperienceResult(player))
        {
            EvolutionPanel.SetActive(true);
            LanguagesFillers.FillPlayerLevelUp(Evolution, WonPointsTitle, TotalPointsTitle, WonPointsValue, TotalPointsValue);
        }
        WonValue.text = player.Won ? "25" : "12.5";
        TotalValue.text = GameManager.Instance.CurrentPlayer.Xp.ToString();
        ReceivedValue.text = player.AllReceivedDamage.ToString();
        GivenValue.text = player.Attack.AllGivenDamage.ToString();
        DefendedValue.text = player.Defense.AllDamageDefended.ToString();
        EndDuelBtn.onClick.AddListener(() => SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_WORLD));        
    }
}
