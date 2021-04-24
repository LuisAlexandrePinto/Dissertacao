public class EnemySquadronGenerator
{
    private int AttackPoints, DefensePoints, SabotagePoints = 0;
    private Monster EnemyAttackMonster { get; set; }
    private Monster EnemyDefenseMonster { get; set; }
    private Monster EnemySabotageMonster { get; set; }
    public AbilitiesContainer AbilitiesContainer { get; private set; }
    public Squadron Squadron { get; private set; }
    public EnemySquadronGenerator(Player player)
    {
        DistributePointsToAbilitiesLines(player.PlayerMaxPoints);
        AbilitiesContainer = new AbilitiesContainer(AttackPoints, DefensePoints, SabotagePoints);
        GenerateEnemySquadron(player.Squadron);
    }
    private void DistributePointsToAbilitiesLines(int playerPoints)
    {
        int aux = playerPoints, min = 0, abilitiesLines = 3;
        for (; ; )
        {
            if (aux % abilitiesLines == 0)
            {
                AttackPoints = DefensePoints = SabotagePoints = aux / abilitiesLines;
                aux = playerPoints - aux;
                break;
            }
            else
            {
                aux--;
            }
        }
        for (; aux > 0; aux--)
        {
            switch (UnityEngine.Random.Range(min, abilitiesLines))
            {
                case 0: AttackPoints++; break;
                case 1: DefensePoints++; break;
                case 2: SabotagePoints++; break;
            }
        }
    }
    private void GenerateEnemySquadron(Squadron playerSquad)
    {
        EnemyAttackMonster = GameManager.Instance.MonsterManager.GetTypeLineRandomMonster(MonsterType.ATTACK);
        EnemyDefenseMonster = GameManager.Instance.MonsterManager.GetTypeLineRandomMonster(MonsterType.DEFENSE);        
        EnemySabotageMonster = GameManager.Instance.MonsterManager.GetTypeLineRandomMonster(MonsterType.SABOTAGE);
        Squadron = new Squadron(EnemyAttackMonster, EnemyDefenseMonster, EnemySabotageMonster);
        Squadron.AtkPowers.HealthPower.FightEvolve(playerSquad.AtkMonster.Stats.Level);
        Squadron.DefPowers.HealthPower.FightEvolve(playerSquad.DefMonster.Stats.Level);
        Squadron.SabPowers.HealthPower.FightEvolve(playerSquad.SabMonster.Stats.Level);

        /*EnemyAttackMonster.Stats.FightEvolve(playerSquad.Attack.Stats.Level);        
        EnemyDefenseMonster.Stats.FightEvolve(playerSquad.Defense.Stats.Level);        
        EnemySabotageMonster.Stats.FightEvolve(playerSquad.Sabotage.Stats.Level);*/

    }
}
