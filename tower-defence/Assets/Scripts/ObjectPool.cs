using UnityEngine;
using System;
using System.Collections;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float waitToSpawn = 1.5f;
    [SerializeField] private int poolSize = 5;

    private WaitForSecondsRealtime _waitTime;
    private GameObject[] _pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        _pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            _pool[i] = Instantiate(_enemyPrefab, transform);
            _pool[i].SetActive(false);
        }
    }

    private void Start()
    {
        _waitTime = new WaitForSecondsRealtime(waitToSpawn);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return _waitTime;
        }
        
    }

    private void EnableObjectInPool()
    {
        foreach(var enemy in _pool)
        {
            if (enemy.activeInHierarchy)
                continue;
            enemy.SetActive(true);
            return;
        }
    }
}
