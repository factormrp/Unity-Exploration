using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform[] path;

    IEnumerator current;
    
    void Start()
    {
        string[] messages = {"Welcome", "to", "this", "amazing", "game!"};    
        StartCoroutine(PrintMessages(messages, 0.5f));
        StartCoroutine(FollowPath());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(current != null)
                StopCoroutine(current);

            current = Move(Random.onUnitSphere*5, 8);
            StartCoroutine(current);        
        }
    }

    IEnumerator PrintMessages(string[] m, float delay){
        foreach(string s in m){
            print(s);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator Move(Vector3 destination, float speed){
        while(transform.position != destination){
            transform.position = Vector3.MoveTowards(transform.position,
                destination, speed*Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator FollowPath(){
        foreach(Transform waypoint in path){
            yield return StartCoroutine(Move(waypoint.position, 8));
        }
    }

    
}
