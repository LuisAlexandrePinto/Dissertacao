using System.Linq;

public class DfIX : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 5.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 10.0f;
    public override ActionType ActionType => ActionType.ONDEFENSE;
    public override AbilityIndex AbilityIndex => AbilityIndex.DEFENSE9;
    public override AbilityType AbilityType => AbilityType.DEFENSE;
    public override void ApplyPrimaryEffect(Squadron squad)
    {
        squad.DefPowers.DefensePower.StopPassiveDamage = 
            IsActive() 
            && 
            MathConts.ProcessChance(ChanceValue, squad.Inspiration, GetName()) 
                ? 
                (EffectValue + ComboEffectValue) 
                : 
                ZERO;
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameDfIX;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionDfIX(ChanceValue, EffectValue, ComboEffectValue);
}
