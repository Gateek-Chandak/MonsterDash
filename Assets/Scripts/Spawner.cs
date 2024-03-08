﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public float decreaseTime;
    public float minTime = 0.65f;

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randPoint = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[randPoint], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}