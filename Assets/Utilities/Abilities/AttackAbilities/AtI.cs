using System.Linq;

public class AtI : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 5.0f;
    public override float SecondaryValue => 2.5f;
    public override float ConditionValue => 0f;
    public override ActionType ActionType => ActionType.PASSIVE;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK1;
    public override AbilityType AbilityType => AbilityType.ATTACK;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {            
            squadron.AtkPowers.AttackPower.Bonus += 
                MathConts.GetPercentageOf(squadron.AtkPowers.AttackPower.Base, EffectValue + ComboEffectValue);
            EffectApplied = true;            
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtI;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtI(ChanceValue, EffectValue, ComboEffectValue);
}
