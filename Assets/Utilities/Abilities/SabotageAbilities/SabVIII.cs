using System.Linq;

public class SabVIII : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 0.0f;
    public override float SecondaryValue => 10.0f;
    public override float ConditionValue => 10.0f;
    public override ActionType ActionType => ActionType.ONDEFENSE;
    public override AbilityIndex AbilityIndex => AbilityIndex.SABOTAGE8;
    public override AbilityType AbilityType => AbilityType.SABOTAGE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        squadron.SabPowers.SabotagePower.FullDefense = 
            IsActive() 
            &&
            MathConts.ProcessChance(ChanceValue + ComboEffectValue, squadron.Inspiration, GetName()) ? squadron.SabPowers.SabotagePower.Total : ZERO;
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameSabVIII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionSabVIII(ChanceValue, EffectValue, ComboEffectValue);
}
