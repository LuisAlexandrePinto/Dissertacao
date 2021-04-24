using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Random = UnityEngine.Random;

public class DuelFactory : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject duelTower;
#pragma warning restore 0649

    private List<GameObject> duelPool = new List<GameObject>();
    private List<DuelData> savedDuels = new List<DuelData>();
    private Dictionary<float, float> duelPositions = new Dictionary<float, float>();
    private float minRange = 4.0f, maxRange = 6.0f, waitTime = 30.0f;
    private BinaryFormatter bf = new BinaryFormatter();
    private string PATH;
    private int MaxDuels = 3;

    private void Awake() => PATH = Application.persistentDataPath + "/duelPositions.dat";
    // Start is called before the first frame update
    void Start()
    {
        Load();
        StartCoroutine(GenerateDuel());
    }

    // Update is called once per frame
    void Update() { }

    private IEnumerator GenerateDuel()
    {
        while (true)
        {
            InstantiateDuels();
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void InstantiateDuels()
    {
        //float x, y, z;
        GameObject duelClone;
        if (savedDuels.Count > 0 && duelPool.Count < MaxDuels)
        {
            foreach (DuelData duel in savedDuels)
            {
                duelClone = Instantiate(duelTower, new Vector3(duel.X, duel.Y, duel.Z), duelTower.transform.rotation);
                duelPool.Add(duelClone);
                Save();
            }
        }
        else
        {
            if (duelPool.Count < MaxDuels)
            {/*
                x = GenerateUniquePosition(GameManager.Instance.CurrentPlayer.transform.position.x);
                y = GameManager.Instance.CurrentPlayer.transform.position.y;
                z = GameManager.Instance.CurrentPlayer.transform.position.z + GenerateRange();
                duelClone = Instantiate(duelTower, new Vector3(x, y, z), duelTower.transform.rotation);
                duelPool.Add(duelClone);
                savedDuels.Add(new DuelData(x, y, z));
                duelPositions[x] = z;
                Save();*/
            }
        }
    }
    private float GenerateUniquePosition(float coordinate)
    {
        while (true)
        {
            float x = coordinate + GenerateRange();
            if (!duelPositions.ContainsKey(x) && duelPositions.Keys.ToList().TrueForAll(k => k < x - 5 || k > x + 5))
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
    private void Save()
    {
        FileStream file = File.Create(PATH);
        bf.Serialize(file, savedDuels);
        file.Close();
    }
    private void Load()
    {
        if (File.Exists(PATH))
        {
            FileStream file = File.Open(PATH, FileMode.Open);
            List<DuelData> locations = (List<DuelData>)bf.Deserialize(file);
            savedDuels = locations;
            file.Close();
            FilterDuelsByTime();
        }
    }
    private void FilterDuelsByTime()
    {
        //double i = DateTime.Now.Subtract(DateTime.Now).TotalDays;
        savedDuels.RemoveAll(duelData => DateTime.UtcNow.Date != duelData.SpawnTime.Date);
        savedDuels.RemoveAll(monsterData => DateTime.UtcNow.Minute - monsterData.SpawnTime.Minute >= 5);
    }
}
