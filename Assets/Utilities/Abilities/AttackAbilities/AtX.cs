using System.Linq;

public class AtX : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 10.0f;
    public override float SecondaryValue => 10.0f;
    public override float ConditionValue => 7.0f;
    public override ActionType ActionType => ActionType.ONATTACK;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK10;
    public override AbilityType AbilityType => AbilityType.ATTACK;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && MathConts.ProcessChance(ChanceValue, squadron.Inspiration, GetName()))
        {            
            squadron.AtkPowers.AttackPower.OnTurnBonusAttack = MathConts.GetPercentageOf(squadron.AtkPowers.AttackPower.Total, EffectValue + ComboEffectValue);
            squadron.DefPowers.AttackPower.OnTurnBonusAttack = MathConts.GetPercentageOf(squadron.DefPowers.AttackPower.Total, EffectValue + ComboEffectValue);
            squadron.SabPowers.AttackPower.OnTurnBonusAttack = MathConts.GetPercentageOf(squadron.SabPowers.SabotagePower.Total/2, EffectValue + ComboEffectValue);            
        }
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn()=> ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtX;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtX(ChanceValue, EffectValue, ComboEffectValue);
}
