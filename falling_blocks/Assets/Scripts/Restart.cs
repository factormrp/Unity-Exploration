using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameObject screen;
    public Text survived;
    bool gameOver;

    void Start() {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;    
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            if(Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(0);
        }        
    }

    void OnGameOver(){
        screen.SetActive(true);
        survived.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
