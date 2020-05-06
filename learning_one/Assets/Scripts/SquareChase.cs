using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareChase : MonoBehaviour
{
    public float speed = 8;
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = target.position - transform.position;
        Vector3 direction = displacement.normalized;
        Vector3 velocity = direction* speed;

        float stop = displacement.magnitude;
        
        if(stop > 1f)
            transform.Translate(velocity * Time.deltaTime);
    }
}
