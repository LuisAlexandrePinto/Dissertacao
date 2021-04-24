using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterFactory : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float waitTime = 65.0f, minRange = 5.0f, maxRange = 40.0f; //1.0f
    [SerializeField]
    private int startingMonsters = 2;
#pragma warning restore 0649
    private int maxMonsters = 5;
    private bool bootUp;
    private Dictionary<float, float> monstersPositions = new Dictionary<float, float>();
    private List<MonsterLocationData> monsterLocations = new List<MonsterLocationData>();
    public List<Monster> LiveMonsters { get; private set; } = new List<Monster>();
    private string path;
    private BinaryFormatter bf;

    private void Awake() => path = Application.persistentDataPath + "/monsterLocations.dat";
    // Start is called before the first frame update
    void Start()
    {
        Load();
        InstantiateStartingMonsters();
        bootUp = true;
        StartCoroutine(DestroyMonsterByTime());
        StartCoroutine(GenerateMonstersByTime());
        Save();
    }
    private IEnumerator DestroyMonsterByTime()
    {
        while (true)
        {
            Debug.Log("Entered Destroy");
            DestroyMonster();
            yield return new WaitForSeconds(waitTime + 2.0f);
        }
    }
    private void DestroyMonster()
    {
        if (!bootUp)
        {
            MonsterLocationData locationToRemove = monsterLocations.Find(data => data.Id == LiveMonsters.First().Id);
            monstersPositions.Remove(locationToRemove.X);
            monsterLocations.RemoveAll(data => data.Id == LiveMonsters.First().Id);
            Monster toDestroy = LiveMonsters.First();

            LiveMonsters.RemoveAt(0);
            Debug.Log("Destroying" + LiveMonsters.First().MonsterName);
            Destroy(toDestroy.gameObject);
        }
        else
        {
            bootUp = false;
        }
    }
    private IEnumerator GenerateMonstersByTime()
    {
        while (true)
        {
            InstantiateMonstersRandom();
            SaveLocations();
            Save();
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void InstantiateStartingMonsters()
    {
        if (monsterLocations.Count() <= 0 && LiveMonsters.Count() <= 0)
        {
            for (int i = 0; i < startingMonsters; i++)
            {
                InstantiateMonstersRandom();
            }
            SaveLocations();
        }
        else
        {
            foreach (MonsterLocationData item in monsterLocations)
            {
                Monster monster = GameManager.Instance.MonsterManager.GetMonsterByName(item.Name);
                monstersPositions[item.X] = item.Z;
                LiveMonsters.Add(Instantiate(monster, new Vector3(item.X, item.Y, item.Z), monster.transform.rotation));
            }
        }
    }
    private void InstantiateMonstersRandom()
    {
        if (LiveMonsters.Count < maxMonsters)
        {
            float x, y, z;
            Monster monster = GameManager.Instance.MonsterManager.GetRandomMonster();
            x = GenerateUniquePosition(player.transform.position.x);
            y = player.transform.position.y;
            z = player.transform.position.z + GenerateRange();
            monstersPositions[x] = z;
            monster = Instantiate(monster, new Vector3(x, y, z), monster.transform.rotation);
            LiveMonsters.Add(monster);
            Debug.Log(monster.MonsterName + "------" + monster.Id);
        }

    }
    private void SaveLocations()
    {
        LiveMonsters.RemoveAll(item => item == null);
        monsterLocations = LiveMonsters.Select(monster => new MonsterLocationData(
            monster.transform.position.x, monster.transform.position.y, monster.transform.position.z,
            monster.MonsterName, monster.Id)
        ).ToList();
    }
    private void Save()
    {
        bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, monsterLocations);
        file.Close();

    }
    private void Load()
    {
        if (File.Exists(path))
        {
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                bf = new BinaryFormatter();
                List<MonsterLocationData> locations = (List<MonsterLocationData>)bf.Deserialize(file);
                monsterLocations = locations;
                file.Close();
            }
            RemoveMonsterCatched();
            FilterMonstersByTime();
        }
    }
    private void RemoveMonsterCatched()
    {
        if (GameManager.Instance.Catching.MonsterCatched)
        {
            monsterLocations.RemoveAt(monsterLocations.FindIndex(ml => ml.Id == GameManager.Instance.Catching.MonsterToCatchId));
        }
    }
    /// <summary>
    /// This method will filter from the list of monster locations the monsters who have a timespan of 5 minutes or more than a day.
    /// </summary>
    private void FilterMonstersByTime()
    {
        //double i = DateTime.Now.Subtract(DateTime.Now).TotalDays;
        monsterLocations.RemoveAll(monsterData => DateTime.UtcNow.Date != monsterData.SpawnTime.Date);
        monsterLocations.RemoveAll(monsterData => DateTime.UtcNow.Minute - monsterData.SpawnTime.Minute >= 5);
    }
    private float GenerateUniquePosition(float coordinate)
    {
        while (true)
        {
            float x = coordinate + GenerateRange();
            if (!monstersPositions.ContainsKey(x) && monstersPositions.Keys.ToList().TrueForAll(k => k < x - 2 || k > x + 2))
            {
                return x;
            }
        }
    }
    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }
}
