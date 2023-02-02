using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public GameObject[] ItemPrefabs;
    public Transform[] SpawnPoints;
    public Transform ItemGroup;
    //public float spawnTime = 3f;
    //public float nextSpawnTime = 5f;
    [Header("Config")]
    [SerializeField] float SpawnProbability = 0.5f;
    void Start()
    {
        //InvokeRepeating("SpawnPrefab", spawnTime, nextSpawnTime);
        //
        SpawnPrefab();
    }
    void Update()
    {

    } 
    public void SpawnPrefab()
    {
        foreach (var point in SpawnPoints)
        {
            if (Random.Range(0f, 1f) < SpawnProbability)
            {
                int prefabsIndex = Random.Range(0, ItemPrefabs.Length);
                Instantiate(ItemPrefabs[prefabsIndex], point.position, point.rotation, ItemGroup);
            }
        }
    }
}
