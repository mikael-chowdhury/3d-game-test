using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float TimeBetweenWaves;

    public GameObject enemy_object;

    protected List<Transform> spawnPoints = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        GameObject wps = GameObject.FindGameObjectWithTag("Spawnpoints");

        foreach (Transform t in wps.transform)
        {
            spawnPoints.Add(t);
        }

        InvokeRepeating("SpawnWave", TimeBetweenWaves, TimeBetweenWaves);
    }

    private void SpawnWave()
    {
        Vector3 spawnpoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].position;
        GameObject enemy = Instantiate(enemy_object, spawnpoint, Quaternion.identity);
    }
}
