using System.Linq;

public class DfV : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 3;
    public override float PrimaryValue => 7.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 0f;
    public override ActionType ActionType => ActionType.ONDEFENSE;
    public override AbilityIndex AbilityIndex => AbilityIndex.DEFENSE5;
    public override AbilityType AbilityType => AbilityType.DEFENSE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {
            squadron.DefPowers.DefensePower.CriticalHitResistance = EffectValue + ComboEffectValue;
            EffectApplied = true;
        }
    }
    public override void ApplyComboPoints()
    {
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 2) ? MaxComboPoints - 2 : ZERO);
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 1) ? MaxComboPoints - 1 : ZERO);
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    }
    public override bool ComboOn() => ComboPoints > ZERO;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameDfV;
    protected override string GetDescription() => 
        GameManager.Instance.PlayerPreferences.Lang.DescriptionDfV(ChanceValue, EffectValue, ComboEffectValue);
}
