public class HealthPower
{
    private float multiplierIncrementer, multiplier, valueToMultiply, maxHp;
    protected const int ZERO = 0;
    readonly MonsterStats stats;
    public HealthPower(float maxHp, float hpMultiplierIncrementer, float hpMultiplier, float hpValueToMultiply, MonsterStats stats)
    {
        this.stats = stats;
        this.maxHp = maxHp;
        multiplierIncrementer = hpMultiplierIncrementer;
        multiplier = hpMultiplier;
        valueToMultiply = hpValueToMultiply;
        SetCurrentHp();
        FaintedStates = FaintedStates.ALIVE;
    }
    public FaintedStates FaintedStates { get; private set; }
    private int FightLevel { get; set; } = ZERO;
    public bool WasRevived { get; private set; } = false;
    public float CurrentHp { get; set; } = ZERO;
    public void SetCurrentHp() => CurrentHp = MaxHp;
    public float BonusHp { get; set; } = ZERO;
    public float MaxHp { get => maxHp + LevelHp + BonusHp; }
    public float BaseHp => maxHp;
    public float LastHeal { get; private set; }
    public void Revive(float hp)
    {
        if (!WasRevived)
        {
            CurrentHp = hp;
            WasRevived = true;
            FaintedStates = FaintedStates.REVIVED;
        }
    }
    public void ProcessDamage(float dmg)
    {
        if(CurrentHp - dmg > 0)
        {
            CurrentHp = MathConts.RoundNumber(CurrentHp- dmg); 
        }
        else
        {
            CurrentHp = 0;
            FaintedStates = FaintedStates.OUTOFCOMBAT;
        }
    }
    public float GetHp() => CurrentHp;
    public int GetLevel() => FightLevel > stats.Level ? FightLevel : stats.Level;
    public float ProcessMultipliers(float multiplierIncrementer, float multiplier, float valueToMultiply) => GetLevel() > 0 ? (((GetLevel() * multiplierIncrementer) + multiplier) * valueToMultiply) : ZERO;
    public float LevelHp { get => ProcessMultipliers(multiplierIncrementer, multiplier, valueToMultiply) - maxHp; }
    public void RestoreLife(float hp) => CurrentHp = LastHeal = MathConts.RoundNumber(CurrentHp  + (CurrentHp < MaxHp ? ((CurrentHp + hp > MaxHp) ? (MaxHp - CurrentHp) : hp) : ZERO));
    public void FightEvolve(int lvl) => FightLevel = lvl;
    public void ResetPowers()
    {
        SetCurrentHp();
        WasRevived = false;
    }
}
