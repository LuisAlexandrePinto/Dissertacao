using System.Linq;

public class DfII : Ability
{
    public override int MaxPoints => 1;
    public override int MaxComboPoints => 2;
    public override float PrimaryValue => 25.0f;
    public override float SecondaryValue => 7.5f;
    public override float ConditionValue => 50.0f;
    public override ActionType ActionType => ActionType.ONFAINT;
    public override AbilityIndex AbilityIndex => AbilityIndex.DEFENSE2;
    public override AbilityType AbilityType => AbilityType.DEFENSE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied && squadron.DefPowers.HealthPower.CurrentHp == 0)
        {
            if (MathConts.ProcessChance(ChanceValue, squadron.Inspiration, GetName()))
            {
                squadron.DefPowers.HealthPower.Revive(MathConts.GetPercentageOf(squadron.DefPowers.HealthPower.MaxHp, (EffectValue + ComboEffectValue)));
            }
            EffectApplied = true;
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(IsActive() ? ComboAbilities.Count(ability => ability.IsActive()) : ZERO);
    public override bool ComboOn() => ComboPoints > 0;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameDfII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionDfII(ChanceValue, EffectValue, ComboEffectValue);
}
