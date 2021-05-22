using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelChanger : MonoBehaviour
{

    SceneLoader sceneLoader;
    bool levelFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sceneLoader.loadNextScene();
        }
    }
}
