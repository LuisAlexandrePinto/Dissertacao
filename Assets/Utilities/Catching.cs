public class Catching
{
    public void MonsterCatchedData(Monster monster)
    {
        MonsterNameToCatch = monster.MonsterName;
        MonsterToCatchId = monster.Id;        
    }
    public string MonsterNameToCatch { get; private set; }
    public int MonsterToCatchId { get; private set; }
    public bool MonsterCatched { get; set; } = false;    
}
