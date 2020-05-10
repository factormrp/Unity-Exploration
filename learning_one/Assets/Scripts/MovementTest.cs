using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    public Transform sphereTransform;


    // Start is called before the first frame update
    void Start()
    {
        sphereTransform.parent = transform; // implicit call to cube's
        // transform data
    
        sphereTransform.localScale = Vector3.one*2; // scales up sphere
    
    }

    // Update is called once per frame
    void Update()
    {
        // transform.eulerAngles += new Vector3(0,180*Time.deltaTime,0);
        // Vector3.up is (0,1,0)

        transform.Rotate(Vector3.up*Time.deltaTime*180);
        // by default, it works in local space; can be toggled by adding
        // parameter Space.World

        transform.Translate(Vector3.forward*Time.deltaTime*7, Space.World);
        // can be set to propogate by toggling Space.World

        if(Input.GetKeyDown(KeyCode.Space)){
            sphereTransform.position = Vector3.zero;
        }


    }
}
