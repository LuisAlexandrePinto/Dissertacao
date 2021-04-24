public class AttackPower : Power
{
    private float bonusAttack, onTurnBonusAttack, cripplingStrike, adrenalineRush, criticalHit, passiveDamage = ZERO;
    private readonly float baseAttack, multiplierIncrementer, multiplier, valueToMultiply;
    public AttackPower(float baseAttack, float attackMultiplierIncrementer, float attackMultiplier, float attackValueToMultiply, HealthPower stats)
    {
        this.baseAttack = baseAttack;
        multiplierIncrementer = attackMultiplierIncrementer;
        multiplier = attackMultiplier;
        valueToMultiply = attackValueToMultiply;
        Stats = stats;
    }
    
    public float Base { get => CheckIfHasHp(baseAttack + LevelAttack); }
    public float LevelAttack { get => ProcessMultipliers(multiplierIncrementer, multiplier, valueToMultiply) - baseAttack; }
    public float Bonus { get => CheckIfHasHp(bonusAttack); set => bonusAttack = CheckIfValueIsValid(value); }
    public float Total => CheckIfHasHp(Base + Bonus);
    public float OnTurnBonusAttack { get => CheckIfHasHp(onTurnBonusAttack); set => onTurnBonusAttack = CheckIfValueIsValid(value); }
    public bool DoubleStrike { get; set; } = false;
    public float CripplingStrike { get => CheckIfHasHp(cripplingStrike); set => cripplingStrike = CheckIfValueIsValid(value); }
    public float AdrenalineRush { get => CheckIfHasHp(adrenalineRush); set => adrenalineRush = CheckIfValueIsValid(value); }
    public float CriticalHit { get => CheckIfHasHp(criticalHit); set => criticalHit = CheckIfValueIsValid(value); }
    public float PassiveDamage { get => CheckIfHasHp(passiveDamage); set => passiveDamage = CheckIfValueIsValid(value); }

    public override void ResetPowers()
    {
        Bonus = ZERO;
        OnTurnBonusAttack = ZERO;
        DoubleStrike = false;
        CripplingStrike = ZERO;
        AdrenalineRush = ZERO;
        CriticalHit = ZERO;
        PassiveDamage = ZERO;
    }

    public void ResetChancePowers()
    {

    }
}
