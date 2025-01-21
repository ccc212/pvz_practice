using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpawnState
{
    NotStart,
    Spawning,
    Finished
}

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager instance { get; private set; }
    private SpawnState spawnState = SpawnState.NotStart;
    public Transform[] spawnPointList;
    public GameObject zombiePrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }

    // 生成僵尸
    IEnumerator SpawnZombie()
    {
        // 第一波
        for (int i = 0; i < 5; i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(1);

        // 第二波
        for (int i = 0; i < 10; i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(1);

        // 第三波
        for (int i = 0; i < 15; i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(1);
        }
    }

    // 随机生成僵尸
    private void SpawnRandomZombie()
    {
        int index = Random.Range(0, spawnPointList.Length);
        Instantiate(zombiePrefab, spawnPointList[index].position, Quaternion.identity);
    }
}
