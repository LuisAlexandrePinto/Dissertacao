public class DefensePower : Power
{
    private readonly float baseDefense, multiplierIncrementer, multiplier, valueToMultiply = ZERO;
    private float bonusDefense, criticalHitResistance, stopPassiveDamage, divergeDamageToDefense = ZERO;

    public DefensePower(float baseDefense, float defenseMultiplierIncrementer, float defenseMultiplier, float defenseValueToMultiply, HealthPower stats)
    {
        this.baseDefense = baseDefense;
        multiplierIncrementer = defenseMultiplierIncrementer;
        multiplier = defenseMultiplier;
        valueToMultiply = defenseValueToMultiply;
        Stats = stats;
    }

    public float Base { get => baseDefense + LevelDefense; }
    public float Bonus { get => CheckIfHasHp(bonusDefense); set => bonusDefense = CheckIfValueIsValid(value); }
    public float LevelDefense { get => ProcessMultipliers(multiplierIncrementer, multiplier, valueToMultiply) - baseDefense; }
    public float Total => Base + Bonus;
    public float CriticalHitResistance { get => CheckIfHasHp(criticalHitResistance); set => criticalHitResistance = CheckIfValueIsValid(value); }
    public float StopPassiveDamage { get => CheckIfHasHp(stopPassiveDamage); set => stopPassiveDamage = CheckIfValueIsValid(value); }
    public float DivergeDamageToDefense { get => CheckIfHasHp(divergeDamageToDefense); set => divergeDamageToDefense = CheckIfValueIsValid(value); }    

    public override void ResetPowers()
    {
        Bonus = ZERO;
        CriticalHitResistance = ZERO;
        StopPassiveDamage = ZERO;
        DivergeDamageToDefense = ZERO;
    }
}
