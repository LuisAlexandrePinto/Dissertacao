public class FightersManager
{
    public FightStages Player { get; private set; }
    public FightStages Enemy { get; private set; }    
    public FightersManager(EnemySquadronGenerator enemySquad)
    {
        Player = new FightStages(GameManager.Instance.CurrentPlayer.Squadron, GameManager.Instance.AbilitiesContainer, true);
        Enemy = new FightStages(enemySquad.Squadron, enemySquad.AbilitiesContainer, false);
        Player.Squad.UpdateCurrentHealth();
        Enemy.Squad.UpdateCurrentHealth();
        IsPlayerAttacking = MathConts.HalfChance();
    }
    public bool IsPlayerAttacking { get; private set; }
    public FightStages GetAttacker() => IsPlayerAttacking ? Player : Enemy;
    public FightStages GetDefender() => IsPlayerAttacking ? Enemy : Player;
    public void ManageRounds(FightStages attacker, FightStages defender)
    {
        attacker.Attacked = true;
        if (attacker.Attacked && defender.Attacked)
        {
            attacker.Round = defender.Round = +1;
            attacker.Attacked = defender.Attacked = false;
        }        
    }
    public void ChangeStances() => IsPlayerAttacking = !IsPlayerAttacking;
}
