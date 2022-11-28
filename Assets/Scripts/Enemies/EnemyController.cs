using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = GetCurrentTime();
    }

    private float GetCurrentTime()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

    // Update is called once per frame
    void Update()
    {
        if ((GetCurrentTime() - startTime) / 1000 >= 5)
        {
            startTime = GetCurrentTime();

        }
    }
}
