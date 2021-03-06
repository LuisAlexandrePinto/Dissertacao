using System.Linq;

public class SabIII : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 3;
    public override float PrimaryValue => 4.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 0.0f;
    public override ActionType ActionType => ActionType.PASSIVE;
    public override AbilityIndex AbilityIndex => AbilityIndex.SABOTAGE3;
    public override AbilityType AbilityType => AbilityType.SABOTAGE;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        if (IsActive() && !EffectApplied)
        {
            squadron.SabPowers.SabotagePower.DecreaseEnemyDefense = EffectValue + ComboEffectValue;
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
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameSabIII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionSabIII(ChanceValue, EffectValue, ComboEffectValue);
}
