using UnityEngine;
using UnityEngine.UI;

public class CaptureSceneManager : MonoBehaviour
{
#pragma warning disable 0649        
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private Vector3 spawnPoint;
    [SerializeField]
    private GameObject place, OrbCounter, CaptureResult;
    [SerializeField]
    private CaptureResultManager captureResultManager;
    [SerializeField]
    private Text orbCountText;
#pragma warning restore 0649
    private int maxThrowAttempts = 3;    
    public int CurrentThrowAttempts { get; private set; }
    public CaptureSceneStatus Status { get; private set; } = CaptureSceneStatus.InProgress;
    private Monster monster;
    private int level, presentLevel;    
    private void Start()
    {
        PositionMonster(GameManager.Instance.MonsterManager.GetMonsterByName(GameManager.Instance.Catching.MonsterNameToCatch));        
        CalculateMaxThrows();
        CurrentThrowAttempts = maxThrowAttempts;
        orbCountText.text = CurrentThrowAttempts.ToString();
    }
    private void PositionMonster(Monster m)
    {
        level = m.Stats.Level;
        monster = Instantiate(m, place.transform.position, place.transform.rotation);        
        monster.OnMonsterCollision += MonsterCollision;
        GameManager.Instance.MonsterManager.IncrementSeenOnMonster(monster);
        monster.transform.position = place.transform.position;
        //monster.transform.Rotate(0.0f, -180f, 0.0f, 0.0f);
    }
    private void CalculateMaxThrows() => maxThrowAttempts += maxThrowAttempts + GameManager.Instance.CurrentPlayer.ExtraThrows;
    public void OrbDestroyed()
    {
        CurrentThrowAttempts--;
        if (CurrentThrowAttempts <= 0 && Status != CaptureSceneStatus.Successful)
        {
            GameManager.Instance.Catching.MonsterCatched = false;
            Status = CaptureSceneStatus.Failed;
            OrbCounter.SetActive(false);
            CaptureResult.SetActive(true);
            presentLevel = GameManager.Instance.MonsterManager.GetMonsterByName(GameManager.Instance.Catching.MonsterNameToCatch).Stats.Level;
            captureResultManager.Initialize(GameManager.Instance.Catching.MonsterNameToCatch, false, presentLevel > level);            
        }
        else
        {
            OrbCounter.SetActive(true);
            orbCountText.text = CurrentThrowAttempts.ToString();
            Instantiate(orb, spawnPoint, Quaternion.identity);
        }
    }
    public void MonsterCollision()
    {
        Status = CaptureSceneStatus.Successful;
        GameManager.Instance.Catching.MonsterCatched = true;
        GameManager.Instance.MonsterManager.AddCatchedMonster();
        GameManager.Instance.CurrentPlayer.UpdateMonsters();
        OrbCounter.SetActive(false);
        CaptureResult.SetActive(true);
        presentLevel = GameManager.Instance.MonsterManager.GetMonsterByName(GameManager.Instance.Catching.MonsterNameToCatch).Stats.Level;
        captureResultManager.Initialize(GameManager.Instance.Catching.MonsterNameToCatch, true, presentLevel > level);       
    }
}
