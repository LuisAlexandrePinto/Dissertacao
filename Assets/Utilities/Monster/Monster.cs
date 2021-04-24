using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private float
        spawnRate = 0,
        catchRate = 0,
        baseAttack = 0,
        baseDefense = 0,
        baseSabotage = 0,
        maxHp = 0,        
        attackMultiplier,
        defenseMultiplier,
        sabotageMultiplier,
        hpMultiplier,
        attackMultiplierIncrementer,
        defenseMultiplierIncrementer,
        sabotageMultiplierIncrementer,
        hpMultiplierIncrementer,
        attackValueToMultiply,
        defenseValueToMultiply,
        sabotageValueToMultiply,
        hpValueToMultiply;
    [SerializeField]
    private AudioClip crySound;
    private AudioSource audioSource;
    [SerializeField]
    private string monsterName;
    [SerializeField]
    private MonsterType type;
    [SerializeField]
    private MonsterSubType subType;
    [SerializeField]
    private int level;
    [SerializeField]
    private MonsterRarity monsterRarity;
#pragma warning restore 0649
    public MonsterStats Stats { get; private set; }
    public AudioClip CrySound => crySound;
    public MonsterType Type => type;
    public MonsterSubType SubType => subType;
    public MonsterRarity GetRarity => monsterRarity;
    public string MonsterName => monsterName;
    public int Id { get; private set; }

    public delegate void MonsterCollision();
    public event MonsterCollision OnMonsterCollision;
    public void InitiateByData(MonsterData monster)
    {
        Id = monster.Id;
        level = level < monster.Level ? monster.Level : level;        
        Stats = new MonsterStats(spawnRate, catchRate, level, monster.SeenAmount, monster.CatchesIds);
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        InitiateData();
    }

    public void InitiateData()
    {
        Id = MonsterRng.GenerateNumber();
        Stats = new MonsterStats(spawnRate, catchRate, level, 0, null);
    }

    public MonsterPowers GetPowers()
    {
        MonsterPowers monsterPowers = new MonsterPowers(maxHp, hpMultiplierIncrementer, hpMultiplier, hpValueToMultiply, Stats);
        monsterPowers.InitializeAttack(baseAttack, attackMultiplierIncrementer, attackMultiplier, attackValueToMultiply);
        monsterPowers.InitializeDefense(baseDefense, defenseMultiplierIncrementer, defenseMultiplier, defenseValueToMultiply);
        monsterPowers.InitializeSabotage(baseSabotage, sabotageMultiplierIncrementer, sabotageMultiplier, sabotageValueToMultiply);
        return monsterPowers;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    } 


    protected void OnMouseDown()
    {
        if (!IsPointerOverUIObject())
        {
            GameManager.Instance.Catching.MonsterCatchedData(this);
            SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_CAPTURE);
        }
      /*
       * if (!EventSystem.current.IsPointerOverGameObject() && SceneManager.GetActiveScene().name.Equals(SquadUpConstants.SCENE_WORLD))//verifica se o tipo de gameobject é UI
        {
            GameManager.Instance.Catching.MonsterCatchedData(this);
            SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_CAPTURE);
            //audioSource.PlayOneShot(CrySound);
        }
      */
    }

    private void OnCollisionEnter(Collision other)
    {
        if(OnMonsterCollision != null)
        {
            OnMonsterCollision();
        }
    }
}
