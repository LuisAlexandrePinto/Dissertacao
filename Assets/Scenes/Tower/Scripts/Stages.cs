public abstract class Stages
{
    public Stages(Squadron squad) => Squad = squad;

    protected const int ZERO = 0;
    public Squadron Squad { get; private set; }    
    public float CripleStrikePower => Squad.AtkPowers.AttackPower.CripplingStrike;
    public bool DoubleStrike => Squad.AtkPowers.AttackPower.DoubleStrike;
    public float AdrenalineRush => Squad.AtkPowers.AttackPower.AdrenalineRush;
    public float CriticalHit => Squad.AtkPowers.AttackPower.CriticalHit;
    public float AtkOnTurnBonusAttack => Squad.AtkPowers.AttackPower.OnTurnBonusAttack;
    public float DefOnTurnBonusAttack => Squad.DefPowers.AttackPower.OnTurnBonusAttack;
    public float SabOnTurnBonusAttack => Squad.SabPowers.AttackPower.OnTurnBonusAttack;
    public float SabFullAttack => Squad.SabPowers.SabotagePower.FullAttack;
    public float SabFullDefense => Squad.SabPowers.SabotagePower.FullDefense;
    public float DecreaseEnemySabotage => Squad.SabPowers.SabotagePower.DecreaseEnemySabotage;
    public float DecreaseEnemyDefense => Squad.SabPowers.SabotagePower.DecreaseEnemyDefense;
    public float DecreaseEnemyAttack => Squad.SabPowers.SabotagePower.DecreaseEnemyAttack;
    public float DecreaseEnemyCriticalResistance => Squad.SabPowers.SabotagePower.DecreaseEnemyCriticalResistance;
    public float DecreaseDivergePower => Squad.SabPowers.SabotagePower.DecreaseEnemyDivergeDamage;
    public float PassiveDamage => Squad.AtkPowers.AttackPower.PassiveDamage;
    public float StopBleedingPower => Squad.DefPowers.DefensePower.StopPassiveDamage;
    public float AllGivenDamage { get; protected set; } = ZERO;
    public float AllDamageDefended { get; protected set; } = ZERO;
    public float CriticalHitResistance => Squad.DefPowers.DefensePower.CriticalHitResistance;
    public float DivergeDamageToDefense { get; protected set; } = ZERO;
    public float DivergeDamageToAttack { get; protected set; } = ZERO;
    public float DivergeDamageToSabotage { get; protected set; } = ZERO;
    public AbilityType MonsterToReceiveCrippleStrike { get; protected set; } = AbilityType.NONE;
    public float CripleStrikeToAttack { get; protected set; } = ZERO;
    public float CripleStrikeToDefense { get; protected set; } = ZERO;
    public float CripleStrikeToSabotage { get; protected set; } = ZERO;
    public float NormalDamageToAttack { get; protected set; } = ZERO;
    public float NormalDamageToDefense { get; protected set; } = ZERO;
    public float NormalDamageToSabotage { get; protected set; } = ZERO;
    public float CriticalDamageToAttack { get; protected set; } = ZERO;
    public float CriticalDamageToDefense { get; protected set; } = ZERO;
    public float CriticalDamageToSabotage { get; protected set; } = ZERO;
    public float PassiveDamageToAttack { get; protected set; } = ZERO;
    public float PassiveDamageToDefense { get; protected set; } = ZERO;
    public float PassiveDamageToSabotage { get; protected set; } = ZERO;
    public float NormalDamage { get; protected set; } = ZERO;
    public float DoubleStrikePower { get; protected set; } = ZERO;
    public float BleedingPower { get; protected set; } = ZERO;
    public float AdrenalineRushPower { get; protected set; } = ZERO;
    public float CriticalHitPower { get; protected set; } = ZERO;
    public float CriticalResistanteDecrease { get; set; } = ZERO;
    public float DefenseDecrease { get; protected set; } = ZERO;
    public float SabotageDecrease { get; protected set; } = ZERO;
    public float AttackDecrease { get; protected set; } = ZERO;
    public float AttackBasePower { get; protected set; } = ZERO;
    public float AttackOffensivePower { get; protected set; } = ZERO;
    public float DefenseOffensivePower { get; protected set; } = ZERO;
    public float SabotageOffensivePower { get; protected set; } = ZERO;
    public float AttackDefensivePower { get; protected set; } = ZERO;
    public float DefenseDefensivePower { get; protected set; } = ZERO;
    public float SabotageDefensivePower { get; protected set; } = ZERO;
    public float PercentageDamageAttack { get; protected set; } = ZERO;
    public float PercentageDamageDefense { get; protected set; } = ZERO;
    public float PercentageDamageSabotage { get; protected set; } = ZERO;
    public bool AttackMonsterFainted => Squad.AtkPowers.HealthPower.CurrentHp == 0;
    public bool DefenseMonsterFainted => Squad.DefPowers.HealthPower.CurrentHp == 0;
    public bool SabotageMonsterFainted => Squad.SabPowers.HealthPower.CurrentHp == 0;
    public float TotalAttackPower => AttackOffensivePower + DefenseOffensivePower + SabotageOffensivePower;
    public float TotalDefensePower => AttackDefensivePower + DefenseDefensivePower + SabotageDefensivePower;
    public float DamageToAttack => NormalDamageToAttack + PassiveDamageToAttack + CriticalDamageToAttack;
    public float DamageToDefense => NormalDamageToDefense + PassiveDamageToDefense + CriticalDamageToDefense;
    public float DamageToSabotage => NormalDamageToSabotage + PassiveDamageToSabotage + CriticalDamageToSabotage;
    public float GetAttackDecrease(float attackPower) => MathConts.ProcessPercentage(DecreaseEnemyAttack, attackPower);    
    public float GetDefenseDecrease(float defense) => MathConts.ProcessPercentage(DecreaseEnemyDefense, defense);
    public float GetSabotageDecrease(float sabotage) => MathConts.ProcessPercentage(DecreaseEnemySabotage, sabotage);    
    public float GetPassiveDamageDecrease(float passiveDamage) => MathConts.ProcessPercentage(StopBleedingPower, passiveDamage);
    public float GetCriticalResistanceDecrease(float resistancePower) => MathConts.ProcessPercentage(DecreaseEnemyCriticalResistance, resistancePower);
    protected void ResetAttack()
    {
        MonsterToReceiveCrippleStrike = AbilityType.NONE;
        AttackBasePower = 0;        
        AttackOffensivePower = Squad.AtkPowers.AttackPower.Total;
        DefenseOffensivePower = Squad.DefPowers.AttackPower.Total;
        SabotageOffensivePower = Squad.SabPowers.SabotagePower.Total;
        CriticalHitPower = 0;
        DoubleStrikePower = 0;
        AdrenalineRushPower = 0;
        BleedingPower = 0;
        AttackDecrease = 0;
        SabotageDecrease = 0;
        PassiveDamageToAttack = 0;
        PassiveDamageToDefense = 0;
        PassiveDamageToSabotage = 0;
        NormalDamageToAttack = 0;
        NormalDamageToDefense = 0;
        NormalDamageToSabotage = 0;
        CriticalDamageToAttack = 0;
        CriticalDamageToDefense = 0;
        CriticalDamageToSabotage = 0;
    }

    protected void ResetDefense()
    {
        PercentageDamageAttack = 0;
        PercentageDamageDefense = 0;
        PercentageDamageSabotage = 0;
        SabotageDecrease = 0;
        DefenseDecrease = 0;
        AttackDefensivePower = Squad.AtkPowers.DefensePower.Total;
        DefenseDefensivePower = Squad.DefPowers.DefensePower.Total;
        SabotageDefensivePower = Squad.SabPowers.DefensePower.Total;
        DivergeDamageToDefense = Squad.DefPowers.DefensePower.DivergeDamageToDefense;
    }
}
