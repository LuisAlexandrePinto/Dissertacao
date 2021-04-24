using System.Linq;

public class SabVII : Ability
{
    public override int MaxPoints => 3;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 0.0f;
    public override float SecondaryValue => 10.0f;
    public override float ConditionValue => 10.0f;
    public override ActionType ActionType => ActionType.ONATTACK;
    public override AbilityIndex AbilityIndex => AbilityIndex.SABOTAGE7;
    public override AbilityType AbilityType => AbilityType.SABOTAGE;
    public override void ApplyPrimaryEffect(Squadron squadron) => 
        squadron.SabPowers.SabotagePower.FullAttack =
        IsActive()
        &&
        MathConts.ProcessChance(ChanceValue + ComboEffectValue, squadron.Inspiration, GetName()) ? squadron.SabPowers.SabotagePower.Total : ZERO;
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameSabVII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionSabVII(ChanceValue, EffectValue, ComboEffectValue);   
}
