using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public float speed = 10f;
    float wrapLimit;
    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        wrapLimit = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x > wrapLimit)
            transform.position = new Vector2(-wrapLimit,transform.position.y);

        if(transform.position.x < -wrapLimit)
            transform.position = new Vector2(wrapLimit,transform.position.y);

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "falling block"){
            if(OnPlayerDeath != null)
                OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
