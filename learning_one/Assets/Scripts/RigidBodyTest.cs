using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyTest : MonoBehaviour
{
    public float speed = 17;
    Vector3 velocity;

    Rigidbody rigidBody;

    int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),
            0,Input.GetAxisRaw("Vertical"));
        
        Vector3 direction = input.normalized;
        velocity = direction*speed;
    }

    void FixedUpdate() { // called automatically by MonoBehaviour
        rigidBody.position += velocity*Time.fixedDeltaTime;
        // fixedDeltaTime is constant between calls
        // can also call deltaTime and will return fixed because compiler
        //      recognizes the call inside FixedUpdate

    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Coin"){
            Destroy(other.gameObject);
            coins++;
        }
    }

}
