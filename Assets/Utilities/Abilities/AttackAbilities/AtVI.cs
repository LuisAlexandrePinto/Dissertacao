using System.Linq;

public class AtVI : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 3;
    public override float PrimaryValue => 5.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 0f;
    public override ActionType ActionType => ActionType.PASSIVE;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK6;
    public override AbilityType AbilityType => AbilityType.ATTACK;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {
            squadron.AtkPowers.HealthPower.BonusHp = 
                MathConts.GetPercentageOf(squadron.AtkPowers.HealthPower.MaxHp, EffectValue + ComboEffectValue);
            EffectApplied = true;
        }
    }
    public override void ApplyComboPoints()
    {
        PutComboPoints(Points == MaxPoints - 2 && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 2) ? MaxComboPoints - 2 : ZERO);
        PutComboPoints(Points == MaxPoints - 1 && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 1) ? MaxComboPoints - 1 : ZERO);
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    }
    public override bool ComboOn() => ComboPoints > ZERO;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtVI;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtVI(ChanceValue, EffectValue, ComboEffectValue);
}
