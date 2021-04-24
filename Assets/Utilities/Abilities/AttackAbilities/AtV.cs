using System.Linq;

public class AtV : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 5.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 10.0f;
    public override ActionType ActionType => ActionType.ONATTACK;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK5;
    public override AbilityType AbilityType => AbilityType.ATTACK;

    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied && MathConts.ProcessChance(ChanceValue, squadron.Inspiration, GetName()))
        {            
            squadron.AtkPowers.AttackPower.PassiveDamage = 
                MathConts.GetPercentageOf(squadron.AtkPowers.AttackPower.Total, EffectValue + ComboEffectValue);
            EffectApplied=true;            
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtV;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtV(ChanceValue, EffectValue, ComboEffectValue);
}
