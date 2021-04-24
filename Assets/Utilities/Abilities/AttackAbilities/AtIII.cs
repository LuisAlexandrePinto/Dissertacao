using System.Linq;

public class AtIII : Ability
{
    public override int MaxPoints => 5;
    public override int MaxComboPoints => 3;
    public override float PrimaryValue => 7.0f;
    public override float SecondaryValue => 5.0f;
    public override float ConditionValue => 8.0f;
    public override ActionType ActionType => ActionType.ONATTACK;
    public override AbilityIndex AbilityIndex => AbilityIndex.ATTACK3;
    public override AbilityType AbilityType => AbilityType.ATTACK;
    public override void ApplyPrimaryEffect(Squadron squadron)
    {
        squadron.AtkPowers.AttackPower.CriticalHit = 
            IsActive() 
            && 
            MathConts.ProcessChance(ChanceValue, squadron.Inspiration, GetName()) ? EffectValue + ComboEffectValue : ZERO;
    }
    public override void ApplyComboPoints()
    {
        PutComboPoints(Points == MaxPoints - 2 && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 2) ? MaxComboPoints - 2 : ZERO);
        PutComboPoints(Points == MaxPoints - 1 && ComboAbilities.All(ability => ability.Points == ability.MaxPoints - 1) ? MaxComboPoints - 1 : ZERO);
        PutComboPoints(Points == MaxPoints && ComboAbilities.All(ability => ability.Points == ability.MaxPoints) ? MaxComboPoints : ZERO);
    }
    public override bool ComboOn() => ComboPoints > ZERO;
    protected override string GetName() => GameManager.Instance.PlayerPreferences.Lang.NameAtIII;
    protected override string GetDescription() => GameManager.Instance.PlayerPreferences.Lang.DescriptionAtIII(ChanceValue, EffectValue, ComboEffectValue);
}
