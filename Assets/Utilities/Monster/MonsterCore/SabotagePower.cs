public class SabotagePower : Power
{
    private readonly float baseSabotage, multiplierIncrementer, multiplier, valueToMultiply;
    private float decreaseEnemyDefense;
    private float decreaseEnemyAttack;
    private float decreaseEnemySabotage;
    private float decreaseEnemyDivergeDamage;
    private float fullDefense;
    private float fullAttack;
    private float decreaseEnemyCriticalResistance;

    public SabotagePower(float baseSabotage, float sabotageMultiplierIncrementer, float sabotageMultiplier, float sabotageValueToMultiply, HealthPower stats)
    {
        this.baseSabotage = baseSabotage;
        multiplierIncrementer = sabotageMultiplierIncrementer;
        multiplier = sabotageMultiplier;
        valueToMultiply = sabotageValueToMultiply;
        Stats = stats;
    }

    public float Base { get => MathConts.RoundNumber(baseSabotage + LevelSabotage); }
    public float Bonus { get; set; } = 0;
    public float LevelSabotage { get => ProcessMultipliers(multiplierIncrementer, multiplier, valueToMultiply) - baseSabotage; }
    public float Total => Base + Bonus;
    public float DecreaseEnemyDefense { get => CheckIfHasHp(decreaseEnemyDefense); set => decreaseEnemyDefense = CheckIfValueIsValid(value); }
    public float DecreaseEnemyAttack { get => CheckIfHasHp(decreaseEnemyAttack); set => decreaseEnemyAttack = CheckIfValueIsValid(value); }
    public float DecreaseEnemySabotage { get => CheckIfHasHp(decreaseEnemySabotage); set => decreaseEnemySabotage = CheckIfValueIsValid(value); }
    public float DecreaseEnemyDivergeDamage { get => CheckIfHasHp(decreaseEnemyDivergeDamage); set => decreaseEnemyDivergeDamage = CheckIfValueIsValid(value); }
    public float FullDefense { get => CheckIfHasHp(fullDefense); set => fullDefense = CheckIfValueIsValid(value); }
    public float FullAttack { get => CheckIfHasHp(fullAttack); set => fullAttack = CheckIfValueIsValid(value); }
    public float DecreaseEnemyCriticalResistance { get => CheckIfHasHp(decreaseEnemyCriticalResistance); set => decreaseEnemyCriticalResistance = CheckIfValueIsValid(value); }


    public override void ResetPowers()
    {
        DecreaseEnemyDefense = ZERO;
        DecreaseEnemyAttack = ZERO;
        DecreaseEnemySabotage = ZERO;
        DecreaseEnemyDivergeDamage = ZERO;
        FullDefense = ZERO;
        FullAttack = ZERO;
        DecreaseEnemyCriticalResistance = ZERO;
    }
}
