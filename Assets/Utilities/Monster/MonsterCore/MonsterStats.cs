using System.Collections.Generic;
using System.Linq;

public class MonsterStats
{
    private const int ZERO = 0;
    public List<int> CatchesIds = new List<int>();

    public float SpawnRate { get; private set; } = ZERO;
    public float CatchRate { get; private set; } = ZERO;
    public int BaseCatchToEvolve { get; private set; } = 10;
    public int CurrentCatchToEvolve { get; private set; } = ZERO;
    public int Level { get; private set; }
    public int CatchesToEvolve => BaseCatchToEvolve - CurrentCatchToEvolve;  
    public bool Seen { get => SeenAmount > ZERO; }
    public bool Catched { get => CatchedAmount > -1; }
    public int SeenAmount { get; private set; } = 1;
    public int CatchedAmount { get => CatchesIds.Count; }
    public void IncrementSeen() => SeenAmount++;

    public MonsterStats(float SpawnRate, float CatchRate, int level, int seen = 0, List<int> CatchesIds = null)
    {
        this.SpawnRate = SpawnRate;
        this.CatchRate = CatchRate;
        Level = level;
        SeenAmount = SeenAmount < seen ? seen : SeenAmount;
        UpdateIdsByList(CatchesIds);
    }
    public void AddId(int id)
    {
        CatchesIds.Add(id);
        CurrentCatchToEvolve++;
        if (CurrentCatchToEvolve >= BaseCatchToEvolve)
        {
            Evolve();
        }
    }
    private void Evolve()
    {
        Level++;
        CurrentCatchToEvolve = 0;
        if (Level % 5 == 0)
        {
            BaseCatchToEvolve++;
        }
    }

    public void UpdateIdsByList(List<int> newIds)
    {
        if (newIds != null)
        {
            List<int> idContainer = new List<int>(CatchesIds.Count + newIds.Count);
            idContainer.AddRange(CatchesIds);
            idContainer.AddRange(newIds);
            CatchesIds = idContainer.Distinct().ToList();
        }
    }

}
