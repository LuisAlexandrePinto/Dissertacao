public class Attack : Stages
{
    public Attack(Squadron squad) : base(squad) { }
    public void ProcessPowers(Defense defense)
    {
        ResetAttack();
        CriticalHitPower =
            MathConts.ProcessPercentage(
                CriticalHit - GetCriticalResistanceDecrease(defense.CriticalHitResistance)
                ,
                AttackOffensivePower
            );
        BleedingPower = PassiveDamage - defense.GetPassiveDamageDecrease(PassiveDamage);
        ProcessAtkBasePower();
        DoubleStrikePower = ApplyDoubleStrike(AttackBasePower);
        AdrenalineRushPower = ApplyAdrenalineRush(Squad.AtkPowers.HealthPower.CurrentHp, AttackBasePower + DoubleStrikePower);
        AttackDecrease = defense.GetAttackDecrease(AttackOffensivePower);
        SabotageDecrease = defense.GetSabotageDecrease(SabotageOffensivePower);
        ProcessAtkPower();
        ProcessDefPower();
        ProcessSabPower();
    }

    public AbilityType GetCripleStrikeTarget()
    {
        if (CripleStrikePower != 0)
        {
            int min = 1, max = 3;
            switch (UnityEngine.Random.Range(min, max))
            {
                case 1: MonsterToReceiveCrippleStrike = AbilityType.ATTACK; break;
                case 2: MonsterToReceiveCrippleStrike = AbilityType.DEFENSE; break;
                case 3: MonsterToReceiveCrippleStrike = AbilityType.SABOTAGE; break;
            }
        }
        return MonsterToReceiveCrippleStrike;
    }
    public void CalculateBaseDamage(float TotalDamage, float attackPercentage, float defensePercentage, float sabotagePercentage)
    {
        NormalDamage = TotalDamage;
        AllGivenDamage += TotalDamage;
        NormalDamageToAttack = MathConts.GetPercentageOf(TotalDamage, attackPercentage);
        NormalDamageToDefense = MathConts.GetPercentageOf(TotalDamage, defensePercentage);
        NormalDamageToSabotage = MathConts.GetPercentageOf(TotalDamage, sabotagePercentage);
    }
    public void CalculatePassiveDamage(float attackPercentage, float defensePercentage, float sabotagePercentage)
    {
        AllGivenDamage += BleedingPower;
        PassiveDamageToAttack = MathConts.GetPercentageOf(BleedingPower, attackPercentage);
        PassiveDamageToDefense = MathConts.GetPercentageOf(BleedingPower, defensePercentage);
        PassiveDamageToSabotage = MathConts.GetPercentageOf(BleedingPower, sabotagePercentage);
    }
    public void CalculateCriticalDamage(float attackPercentage, float defensePercentage, float sabotagePercentage)
    {
        AllGivenDamage += CriticalHitPower;
        CriticalDamageToAttack = MathConts.GetPercentageOf(CriticalHitPower, attackPercentage);
        CriticalDamageToDefense = MathConts.GetPercentageOf(CriticalHitPower, defensePercentage);
        CriticalDamageToSabotage = MathConts.GetPercentageOf(CriticalHitPower, sabotagePercentage);
    }
    private float ApplyDoubleStrike(float attackPower) => DoubleStrike ? MathConts.RoundNumber(attackPower * 2) : 0;
    private float ApplyAdrenalineRush(float currentHp, float attackPower) => (AdrenalineRush > 0 && currentHp < MathConts.GetPercentageOf(Squad.AtkPowers.HealthPower.MaxHp, 30.0f)) ? MathConts.GetPercentageOf(attackPower, AdrenalineRush) : 0;
    private void ProcessAtkBasePower() => AttackBasePower = AttackOffensivePower + AtkOnTurnBonusAttack - AttackDecrease - CriticalHitPower;
    private void ProcessAtkPower() => AttackOffensivePower = MathConts.RoundNumber(AdrenalineRushPower + DoubleStrikePower + AttackBasePower);
    private void ProcessDefPower() => DefenseOffensivePower = MathConts.RoundNumber(DefenseOffensivePower + DefOnTurnBonusAttack);
    private void ProcessSabPower() => SabotageOffensivePower =
        MathConts.RoundNumber(
            (SabFullAttack > 0 ?
                SabFullAttack
                :
            (((SabotageOffensivePower - SabotageDecrease) / 2) + Squad.SabPowers.AttackPower.Total)) + SabOnTurnBonusAttack
        );

}
