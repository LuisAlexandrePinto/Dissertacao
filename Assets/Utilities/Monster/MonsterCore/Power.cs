public abstract class Power
{
    protected const int ZERO = 0;
    protected HealthPower Stats;
    public float CheckIfHasHp(float value) => GetHp() > ZERO ? value : ZERO;
    public float CheckIfValueIsValid(float value) => value > ZERO ? value : ZERO;
    protected virtual float ProcessMultipliers(float multiplierIncrementer, float multiplier, float valueToMultiply) => Stats.ProcessMultipliers(multiplierIncrementer,  multiplier, valueToMultiply);
    protected virtual int GetLevel() => Stats.GetLevel();
    protected virtual float GetHp() => Stats.GetHp();
    public abstract void ResetPowers();    
}
