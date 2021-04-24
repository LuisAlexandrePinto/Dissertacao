using System.Linq;

public class SabI : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 5.0f;
    public override float SecondaryValue => 2.5f;
    public override float ConditionValue => 0.0f;
    public override ActionType ActionType => ActionType.PASSIVE;
    public override AbilityIndex AbilityIndex => AbilityIndex.SABOTAGE1;
    public override AbilityType AbilityType => AbilityType.SABOTAGE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {
            squadron.SabPowers.SabotagePower.Bonus += MathConts.GetPercentageOf(squadron.SabPowers.SabotagePower.Base, (EffectValue + ComboEffectValue));
            EffectApplied = true;
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) && Points == MaxPoints ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameSabI;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionSabI(ChanceValue, EffectValue, ComboEffectValue);
}
