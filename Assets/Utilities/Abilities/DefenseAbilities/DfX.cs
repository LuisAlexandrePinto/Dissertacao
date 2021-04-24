using System.Linq;

public class DfX : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 6.0f;
    public override float SecondaryValue => 10.0f;
    public override float ConditionValue => 0.0f;
    public override ActionType ActionType => ActionType.PASSIVE;
    public override AbilityIndex AbilityIndex => AbilityIndex.DEFENSE10;
    public override AbilityType AbilityType => AbilityType.DEFENSE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {            
            squadron.AtkPowers.DefensePower.Bonus = MathConts.GetPercentageOf(squadron.AtkPowers.DefensePower.Base, EffectValue + ComboEffectValue);
            squadron.SabPowers.DefensePower.Bonus = MathConts.GetPercentageOf(squadron.SabPowers.SabotagePower.Base / 2, EffectValue + ComboEffectValue);
            EffectApplied=true;            
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameDfX;
    protected override string GetDescription() => 
        GameManager.Instance.PlayerPreferences.Lang.DescriptionDfIX(ChanceValue, EffectValue, ComboEffectValue);
}
