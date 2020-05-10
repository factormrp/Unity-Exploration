using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpawner : MonoBehaviour
{

    public GameObject tablePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10f,10),
                0, Random.Range(-10f,10f));
            Vector3 randomSpawnRotation = Vector3.up*Random.Range(0,360);

            GameObject newTable = (GameObject)Instantiate(tablePrefab,
                randomSpawnPosition,
                Quaternion.Euler(randomSpawnRotation));
            // instantiate is used to spawn a given prefab at a given
            // location with given rotation (taken in as a quaternion)
        
            newTable.transform.parent = transform;
        
        }        
    }
}
