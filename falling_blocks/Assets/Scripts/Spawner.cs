using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlock;
    public Vector2 spawnSizeBounds;

    // used to delineate spawn location
    Vector2 screenHalfSize;
    public float spawnAngleBound;
    //used to specify the spawn rate
    float nextSpawn;
    public Vector2 spawnDelayBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect*Camera.main.orthographicSize,Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
            float spawnDelay = Mathf.Lerp(spawnDelayBounds.x, spawnDelayBounds.y, Difficulty.GetDifficultyPercent());
            nextSpawn = Time.time + spawnDelay;

            float spawnSize = Random.Range(spawnSizeBounds.x, spawnSizeBounds.y);
            float spawnAngle = Random.Range(spawnSizeBounds.x, spawnSizeBounds.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x,screenHalfSize.x),
                screenHalfSize.y+spawnSize);

            GameObject block = Instantiate(fallingBlock, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
            block.transform.localScale = Vector2.one*spawnSize;
        }

    }
}