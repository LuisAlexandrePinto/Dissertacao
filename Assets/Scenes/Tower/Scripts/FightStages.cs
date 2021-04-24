public class FightStages
{
    private readonly AbilitiesContainer AbilitiesContainer;
    public FightStages(Squadron squadron, AbilitiesContainer container, bool isPlayer)
    {
        IsPlayer = isPlayer;
        Squad = squadron;
        Attack = new Attack(squadron);
        Defense = new Defense(squadron);
        AbilitiesContainer = container;
        AbilitiesContainer.ApplyEffectsByActionType(Squad, ActionType.PASSIVE);
    }
    public bool Attacked { get; set; } = false;
    public bool Won { get; set; } = false;
    public int Round { get; set; } = 1;
    public bool IsPlayer { get; private set; }
    public Squadron Squad { get; private set; }
    public Attack Attack { get; private set; }
    public Defense Defense { get; private set; }
    public float DamageTaken { get; private set; }
    public float SquadHealth => Squad.GetTotalHealth();
    public float AllReceivedDamage { get; private set; }
    public void BuildAttackStats() => AbilitiesContainer.ApplyEffectsByActionType(Squad, ActionType.ONATTACK);
    public void BuildDefenseStats() => AbilitiesContainer.ApplyEffectsByActionType(Squad, ActionType.ONDEFENSE);
    public void ApplyDamage(float DamageToAttack, float DamageToDefense, float DamageToSabotage)
    {
        AllReceivedDamage += DamageToAttack + DamageToDefense + DamageToSabotage;
        Squad.ApplyDamage(DamageToAttack, DamageToDefense, DamageToSabotage);
        DamageTaken = DamageToAttack + DamageToDefense + DamageToSabotage;        
    }
    public bool ProcessInjuries()
    {
        if (Defense.AnyFainted())
        {
            AbilitiesContainer.ApplyEffectsByActionType(Squad, ActionType.ONFAINT);
        }
        return Defense.AllFainted();
    }
    public void RestoreHealth() => AbilitiesContainer.ApplyEffectsByActionType(Squad, ActionType.ONRESTORE);
}