using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Vector2 speedBounds;
    float speed; 
    float OutofBound;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedBounds.x, speedBounds.y, Difficulty.GetDifficultyPercent());
    
        OutofBound = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*speed*Time.deltaTime);    
   
        if(transform.position.y < OutofBound)
            Destroy(gameObject);
    }
}
