public class MonsterPowers
{
    public MonsterPowers(float maxHp, float hpMultiplierIncrementer, float hpMultiplier, float hpValueToMultiply, MonsterStats stats) => HealthPower = new HealthPower(maxHp, hpMultiplierIncrementer, hpMultiplier, hpValueToMultiply, stats);
    public HealthPower HealthPower { get; private set; }
    public AttackPower AttackPower { get; private set; }
    public DefensePower DefensePower { get; private set; }
    public SabotagePower SabotagePower { get; private set; }

    public void InitializeAttack(float baseAttack, float attackMultiplierIncrementer, float attackMultiplier, float attackValueToMultiply) => AttackPower = new AttackPower(baseAttack, attackMultiplierIncrementer, attackMultiplier, attackValueToMultiply, HealthPower);
    public void InitializeDefense(float baseDefense, float defenseMultiplierIncrementer, float defenseMultiplier, float defenseValueToMultiply) => DefensePower = new DefensePower(baseDefense, defenseMultiplierIncrementer, defenseMultiplier, defenseValueToMultiply, HealthPower);
    public void InitializeSabotage(float baseSabotage, float sabotageMultiplierIncrementer, float sabotageMultiplier, float sabotageValueToMultiply) => SabotagePower = new SabotagePower(baseSabotage, sabotageMultiplierIncrementer, sabotageMultiplier, sabotageValueToMultiply, HealthPower);
}
