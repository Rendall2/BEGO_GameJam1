using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeActive : MonoBehaviour
{
    SceneLoader sceneLoader;
    public GameObject[] spikes;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < spikes.Length; i++)
            {
                spikes[i].SetActive(true);
            }
            StartCoroutine(LevelFailed());
        }
    }
    IEnumerator LevelFailed()
    {
        yield return new WaitForSeconds(1);
        sceneLoader.loadCurrentScene();
    }
}

