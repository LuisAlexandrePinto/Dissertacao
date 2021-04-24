using System.Linq;
public class DfIII : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 10.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 0f;
    public override ActionType ActionType => ActionType.ONDEFENSE;
    public override AbilityIndex AbilityIndex => AbilityIndex.DEFENSE3;
    public override AbilityType AbilityType => AbilityType.DEFENSE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {
            squadron.DefPowers.DefensePower.DivergeDamageToDefense = EffectValue + ComboEffectValue;            
            EffectApplied = true;
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameDfIII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionDfIII(ChanceValue, EffectValue, ComboEffectValue);
}
