using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform pathHolder;
    public float speed = 10;
    public float wait = 0.3f;
    public float turnSpeed = 90;

    void Start(){
        Vector3[] waypts = new Vector3[pathHolder.childCount];
        for(int i=0; i<waypts.Length; i++){
            waypts[i] = pathHolder.GetChild(i).position;
            waypts[i] = new Vector3(waypts[i].x, transform.position.y, waypts[i].z);
        }
        StartCoroutine(FollowPath(waypts));
    }
    IEnumerator FollowPath(Vector3[] waypoints){
        transform.position = waypoints[0];
        int current = 1;
        Vector3 destination = waypoints[current];
        transform.LookAt(destination);
        
        while(true){
            transform.position = Vector3.MoveTowards(transform.position,
                destination, speed*Time.deltaTime);
            if(transform.position == destination){
                current = (current + 1) % waypoints.Length;
                destination = waypoints[current];
                yield return new WaitForSeconds(wait);    
                yield return StartCoroutine(TurnToFace(destination));
            }
            yield return null;
        }
    }
    IEnumerator TurnToFace(Vector3 target){
        Vector3 directionToTarget = (target - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(directionToTarget.z, directionToTarget.x)*Mathf.Rad2Deg;

        while(Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f ){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle,
                turnSpeed*Time.deltaTime);
            transform.eulerAngles = Vector3.up*angle;
            yield return null;
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
