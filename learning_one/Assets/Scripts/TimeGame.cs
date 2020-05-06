using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundstart;
    int wait;

    float roundDelay = 3;
    bool started;

    // Start is called before the first frame update
    void Start()
    {
        print("Press the spacebar when you think the allotted time"
        +" is up");
        Invoke("setRandTime",roundDelay);
    }

    // Update is called once per frame
    void Update()
    {   
            if (started && Input.GetKeyDown(KeyCode.Space)){
                started = false;

                float player = Time.time - roundstart;
                float error = Mathf.Abs(wait - player);
                
                print("you waited:" + player + " seconds.\nyou were: "
                + error + " seconds off");
            }
    }

    void setRandTime(){
        wait = Random.Range(5,21);
        roundstart = Time.time;
        started = true;

        print(wait + " seconds");
    }
}
