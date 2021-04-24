public class CombatManager
{
    public CombatManager(FightersManager fightersManager)
    {
        this.fightersManager = fightersManager;                
        PlayerSquadTotalHealth = fightersManager.Player.Squad.GetTotalHealth();
        EnemySquadTotalHealth = fightersManager.Enemy.Squad.GetTotalHealth();
    }
    private FightersManager fightersManager;
    public float TotalDamage { get; protected set; } = 0;
    public float CriticalDamage { get; protected set; } = 0;
    public float PassiveDamage { get; private set; } = 0;
    public float PlayerSquadTotalHealth { get; private set; } = 0;
    public float PlayerAckMonsterHealth { get; private set; } = 0;
    public float PlayerDefMonsterHealth { get; private set; } = 0;
    public float PlayerSabMonsterHealth { get; private set; } = 0;
    public float EnemySquadTotalHealth { get; private set; } = 0;
    public float EnemyAckMonsterHealth { get; private set; } = 0;
    public float EnemyDefMonsterHealth { get; private set; } = 0;
    public float EnemySabMonsterHealth { get; private set; } = 0;
    public bool GameFinished { get; private set; }
    public bool EnemyWinner { get; private set; }
    private void CalculateDamage(FightStages attacker, FightStages defender)
    {
        TotalDamage = CalculateTotalDamage(attacker, defender);
        attacker.Attack.CalculateBaseDamage(TotalDamage, defender.Defense.PercentageDamageAttack, defender.Defense.PercentageDamageDefense, defender.Defense.PercentageDamageSabotage);
        if (attacker.Attack.CriticalHitPower > 0)
        {
            attacker.Attack.CalculateCriticalDamage(defender.Defense.PercentageDamageAttack, defender.Defense.PercentageDamageDefense, defender.Defense.PercentageDamageSabotage);
        }
        if (attacker.Attack.PassiveDamage > 0)
        {
            attacker.Attack.CalculatePassiveDamage(defender.Defense.PercentageDamageAttack, defender.Defense.PercentageDamageDefense, defender.Defense.PercentageDamageSabotage);
        }
    }

    private float CalculateTotalDamage(FightStages attacker, FightStages defender)
    {
        float attack = attacker.Attack.TotalAttackPower;
        float defense = defender.Defense.TotalDefensePower;
        return (attack <= 0 || attack < defense) ? 0 : attack - defense;
    }
    public void Fight()
    {
        FightStages attacker = fightersManager.GetAttacker();
        FightStages defender = fightersManager.GetDefender();
        fightersManager.ManageRounds(attacker, defender);
        attacker.BuildAttackStats();
        defender.BuildDefenseStats();
        attacker.Attack.ProcessPowers(defender.Defense);
        defender.Defense.ProcessPowers(attacker.Attack);
        defender.Defense.CalculatePercentagesOfDamage();
        CalculateDamage(attacker, defender);
        defender.ApplyDamage(attacker.Attack.DamageToAttack, attacker.Attack.DamageToDefense, attacker.Attack.DamageToSabotage);
        if (defender.ProcessInjuries())
        {
            GameFinished = true;
            attacker.Won = true;
        }
        else
        {
            defender.RestoreHealth();
        }

    }


}
