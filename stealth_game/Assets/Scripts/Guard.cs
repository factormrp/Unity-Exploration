using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform pathHolder;
    public float speed;
  
    void Start(){
        Vector3[] waypts = new Vector3[pathHolder.childCount];
        for(int i=0; i<waypts.Length; i++){
            waypts[i] = pathHolder.GetChild(i).position;
            waypts[i].y += transform.position.y;
        }
        StartCoroutine(FollowPath(waypts));
    }
    IEnumerator Move(Vector3 destination, float speed){
        while(transform.position != destination){
            transform.position = Vector3.MoveTowards(transform.position,
                destination, speed*Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator FollowPath(Vector3[] waypoints){
        while(true){
            foreach(Vector3 pt in waypoints){
                yield return StartCoroutine(Move(pt,speed));
            }
        }
    }
    void OnDrawGizmos(){

        Vector3 startPos = pathHolder.GetChild(0).position;
        Vector3 lastPos = startPos;

        foreach(Transform waypt in pathHolder){
            Gizmos.DrawSphere(waypt.position, 0.3f);
            Gizmos.DrawLine(lastPos, waypt.position);
            lastPos = waypt.position;
        }
        Gizmos.DrawLine(lastPos, startPos);
    }
}
