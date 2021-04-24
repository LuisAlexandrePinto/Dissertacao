using System.Linq;

public class ATVIII : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 8.0f;
    public override ActionType ActionType => ActionType.ONATTACK;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK8;
    public override AbilityType AbilityType => AbilityType.ATTACK;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        squadron.AtkPowers.AttackPower.DoubleStrike = 
            IsActive() 
            &&
            MathConts.ProcessChance(ChanceValue + ComboEffectValue, squadron.Inspiration, GetName());
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtVIII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtVIII(ChanceValue, EffectValue, ComboEffectValue);
}
