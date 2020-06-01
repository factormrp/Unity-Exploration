using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7;
    public float smoothTime = 0.1f;
    public float turnSpeed = 8;
    RigidBody body;
    float angle;
    float smoothInputMagnitude;
    float smoothVelocity;
    Vector3 velocity;

    void Start(){
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        float magnitude = inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, magnitude, ref smoothVelocity, smoothTime); 

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z)*Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime*turnSpeed*magnitude);
        velocity = transform.forward*moveSpeed*smoothInputMagnitude;
    }

    void FixedUpdate() {
        body.MoveRotation(Quaternion.Euler(Vector3.up*angle));
        body.MovePosition(body.position + velocity*Time.deltaTime);
    }
}
