using System.Linq;

public class DfVII : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 3;
    public override float PrimaryValue => 1.0f;
    public override float SecondaryValue => 1.5f;
    public override float ConditionValue => 0.0f;
    public override ActionType ActionType => ActionType.ONRESTORE;
    public override AbilityIndex AbilityIndex => AbilityIndex.DEFENSE7;
    public override AbilityType AbilityType => AbilityType.DEFENSE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && squadron.AtkPowers.HealthPower.CurrentHp > 0)
        {
            squadron.AtkPowers.HealthPower.RestoreLife(
                MathConts.GetPercentageOf(squadron.AtkPowers.HealthPower.MaxHp, EffectValue + ComboEffectValue));
        }
    }
    public override void ApplyComboPoints()
    {
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 2) ? MaxComboPoints - 2 : ZERO);
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 1) ? MaxComboPoints - 1 : ZERO);
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    }
    public override bool ComboOn() => ComboPoints > ZERO;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameDfVII;
    protected override string GetDescription() =>
        GameManager.Instance.PlayerPreferences.Lang.DescriptionDfVII(ChanceValue, EffectValue, ComboEffectValue);    
}
