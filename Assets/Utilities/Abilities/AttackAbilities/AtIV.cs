using System.Linq;

public class AtIV : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 6.0f;
    public override float SecondaryValue => 10.0f;
    public override float ConditionValue => 0f;
    public override ActionType ActionType => ActionType.PASSIVE;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK4;
    public override AbilityType AbilityType => AbilityType.ATTACK;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {        
        if (IsActive() && !EffectApplied)
        {            
            squadron.DefPowers.AttackPower.Bonus += MathConts.GetPercentageOf(squadron.DefPowers.AttackPower.Base, (EffectValue + ComboEffectValue));            
            squadron.SabPowers.AttackPower.Bonus += MathConts.GetPercentageOf(squadron.SabPowers.SabotagePower.Base/2, (EffectValue + ComboEffectValue));
            EffectApplied = true;            
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn()=> ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtIV;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtIV(ChanceValue, EffectValue, ComboEffectValue);
}
