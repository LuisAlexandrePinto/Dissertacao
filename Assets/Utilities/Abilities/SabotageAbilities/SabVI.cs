using System.Linq;

public class SabVI : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 1;
    public override float PrimaryValue => 2.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 7.0f;
    public override ActionType ActionType => ActionType.ONATTACK;
    public override AbilityIndex AbilityIndex => AbilityIndex.SABOTAGE6;
    public override AbilityType AbilityType => AbilityType.SABOTAGE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        squadron.SabPowers.SabotagePower.DecreaseEnemyDivergeDamage = 
            IsActive() 
            && 
            MathConts.ProcessChance(ChanceValue, squadron.Inspiration, GetName()) ? EffectValue + ComboEffectValue : ZERO;
    }
    public override void ApplyComboPoints() => PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    public override bool ComboOn() => ComboPoints == MaxComboPoints;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameSabVI;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionSabVI(ChanceValue, EffectValue, ComboEffectValue);
}
