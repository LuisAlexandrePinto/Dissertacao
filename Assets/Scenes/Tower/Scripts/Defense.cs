public class Defense : Stages
{    
    public Defense(Squadron squad) : base(squad) { }
    public void ProcessPowers(Attack attack)
    {
        ResetDefense();
        SabotageDecrease = attack.GetSabotageDecrease(SabotageDefensivePower);
        DefenseDecrease = attack.GetDefenseDecrease(DefenseDefensivePower);
        CalculateDiverges(attack);
        CriticalResistanteDecrease = attack.GetCriticalResistanceDecrease(Squad.DefPowers.DefensePower.CriticalHitResistance);
        //CriticalHitResistance = Squad.DEFMonsterPowers.DefensePower.CriticalHitResistance - CriticalResistanteDecrease;
        ProcessSabPower();
        ProcessAtkPower();
        ProcessDefPower();
        CriplingStrike(attack);
        AllDamageDefended += AttackDefensivePower + DefenseDefensivePower + SabotageDefensivePower; 
    }
    private void CalculateDiverges(Attack attack)
    {
        if (!DefenseMonsterFainted)
        {
            DivergeDamageToDefense = Squad.DefPowers.DefensePower.DivergeDamageToDefense - attack.DecreaseDivergePower;
            if(DivergeDamageToDefense < 0)
            {
                DivergeDamageToAttack = DivergeDamageToSabotage = DivergeDamageToDefense / 2;
            }
            else
            {
                DivergeDamageToAttack = 0;
                DivergeDamageToSabotage = 0;
            }
        }
        else
        {
            DivergeDamageToDefense = 0;
            if (AttackMonsterFainted && !SabotageMonsterFainted)
            {
                DivergeDamageToSabotage = attack.DecreaseDivergePower;
            }
            else if(!SabotageMonsterFainted && AttackMonsterFainted)
            {
                DivergeDamageToAttack = attack.DecreaseDivergePower;
            }
            else
            {
                DivergeDamageToAttack = DivergeDamageToSabotage = attack.DecreaseDivergePower / 2;
            }
        }
    }
    public void CalculatePercentagesOfDamage()
    {
        float maxPercentage = 100.0f;       
        float totalPercentage = maxPercentage - DivergeDamageToDefense - DivergeDamageToAttack - DivergeDamageToSabotage;
        int numberOfMonstersAlive = HowManyAlive();
        float percentageToMonsters = MathConts.RoundNumber(totalPercentage / numberOfMonstersAlive);
        PercentageDamageDefense = !DefenseMonsterFainted ? percentageToMonsters + DivergeDamageToDefense : 0;
        PercentageDamageAttack = !AttackMonsterFainted ? percentageToMonsters + DivergeDamageToAttack : 0;
        PercentageDamageSabotage = !SabotageMonsterFainted ? percentageToMonsters + DivergeDamageToSabotage : 0;
        float percentages = PercentageDamageDefense + PercentageDamageAttack + PercentageDamageSabotage;
        if (percentages > maxPercentage)
        {
            PercentageDamageDefense = MathConts.RoundNumber(PercentageDamageDefense -(percentages - maxPercentage));

        }
        else
        {
            PercentageDamageDefense = MathConts.RoundNumber(PercentageDamageDefense + (maxPercentage - percentages));
        }
    }
    public bool AllFainted() => AttackMonsterFainted & DefenseMonsterFainted & SabotageMonsterFainted;
    public bool AnyFainted() => AttackMonsterFainted || DefenseMonsterFainted || SabotageMonsterFainted;
    public int HowManyAlive()
    {
        int alive = 0;
        alive += AttackMonsterFainted ? 0 : 1;
        alive += DefenseMonsterFainted ? 0 : 1;
        alive += SabotageMonsterFainted ? 0 : 1;
        return alive;
    }
    public void ProcessAtkPower() => AttackDefensivePower = MathConts.RoundNumber(Squad.AtkPowers.DefensePower.Total);
    private void ProcessDefPower() => DefenseDefensivePower = MathConts.RoundNumber(DefenseDefensivePower - DefenseDecrease);
    private void ProcessSabPower() => SabotageDefensivePower = 
        MathConts.RoundNumber(SabFullDefense > 0 ? 
            SabFullDefense 
            : 
            ((SabotageDefensivePower - SabotageDecrease) / 2) + Squad.SabPowers.DefensePower.Total
        );
    private void CriplingStrike(Attack attack)
    {
        if (attack.CripleStrikePower > 0)
        {
            switch (attack.GetCripleStrikeTarget())
            {
                case AbilityType.ATTACK: CripleStrikeToAttack = MathConts.GetPercentageOf(AttackDefensivePower, attack.CripleStrikePower); break;
                case AbilityType.DEFENSE: CripleStrikeToDefense = MathConts.GetPercentageOf(DefenseDefensivePower, attack.CripleStrikePower); break;
                case AbilityType.SABOTAGE: CripleStrikeToSabotage -= MathConts.GetPercentageOf(SabotageDefensivePower, attack.CripleStrikePower); break;
            }
        }
        AttackDefensivePower = MathConts.RoundNumber(AttackDefensivePower - CripleStrikeToAttack);
        DefenseDefensivePower = MathConts.RoundNumber(DefenseDefensivePower - CripleStrikeToDefense);
        SabotageDefensivePower = MathConts.RoundNumber(SabotageDefensivePower -CripleStrikeToSabotage);
    }
}
