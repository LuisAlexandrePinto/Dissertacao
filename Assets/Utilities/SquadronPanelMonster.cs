using UnityEngine;

public class SquadronPanelMonster : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private SquadronPanelMonsterInfo monsterInfo;
    [SerializeField]
    private SquadronPanelHP panelHP;
    [SerializeField]
    private SquadronPanelAttack panelAttack;
    [SerializeField]
    private SquadronPanelDefense panelDefense;
    [SerializeField]
    private SquadronPanelSabotage panelSabotage = null;
    [SerializeField]
    private MonsterType monsterType;
    [SerializeField]
    private bool realTutorial;
#pragma warning restore 0649
    private MonsterPowers Powers;
    private Monster Monster;
    private void Awake()
    {
        GameManager.Instance.AbilitiesContainer.ApplyEffectsByActionType(
            GameManager.Instance.CurrentPlayer.Squadron, ActionType.PASSIVE);
    }
    public void OnEnable()
    {
        Monster = GetMonsterByType(monsterType);
        Powers = GetPowersByType(monsterType);
        monsterInfo.FillTitles(realTutorial, monsterType, Monster);
        panelHP.FillHealthSubPanel(realTutorial, Powers);
        panelAttack.FillAttackSubPanel(realTutorial, Powers);
        panelDefense.FillDefenseSubPanel(realTutorial, Powers);
        if (panelSabotage != null)
        {
            panelSabotage.FillSabotageSubPanel(realTutorial, Powers);
        }
    }
    private Monster GetMonsterByType(MonsterType monsterType)
    {
        switch (monsterType)
        {
            case MonsterType.ATTACK: return GameManager.Instance.CurrentPlayer.Squadron.AtkMonster;
            case MonsterType.DEFENSE: return GameManager.Instance.CurrentPlayer.Squadron.DefMonster;
            case MonsterType.SABOTAGE: return GameManager.Instance.CurrentPlayer.Squadron.SabMonster;
            default: return null;
        }
    }
    private MonsterPowers GetPowersByType(MonsterType monsterType)
    {
        switch (monsterType)
        {
            case MonsterType.ATTACK: return GameManager.Instance.CurrentPlayer.Squadron.AtkPowers;
            case MonsterType.DEFENSE: return GameManager.Instance.CurrentPlayer.Squadron.DefPowers;
            case MonsterType.SABOTAGE: return GameManager.Instance.CurrentPlayer.Squadron.SabPowers;
            default: return null;
        }
    }

}
