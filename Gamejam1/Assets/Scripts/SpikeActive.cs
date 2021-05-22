using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeActive : MonoBehaviour
{
    public GameObject[] spikes;
    // Start is called before the first frame update
    void Start()
    {
       
        
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
        }
    }
}
