using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelChanger : MonoBehaviour
{

    SceneLoader sceneLoader;
    GameManager gameManager;
    PlayerInputs playerInput;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInput.NextLevel();
            
        }
    }
}
