using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlock;
    Vector2 screenHalfSize;
    float halfBlockHeight;
    public float spawnDelay = 1;
    float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        halfBlockHeight = transform.localScale.y / 2f;
        screenHalfSize = new Vector2(Camera.main.aspect*Camera.main.orthographicSize,Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnDelay;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x,screenHalfSize.x),
                screenHalfSize.y+halfBlockHeight);
            Instantiate(fallingBlock, spawnPosition, Quaternion.identity);
        }
    }
}
