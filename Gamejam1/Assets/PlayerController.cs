using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isRight = false;
    public bool isLeft = false;
    public bool isMiddle = true;
    GameObject roadLeft;
    GameObject roadMiddle;
    GameObject roadRight;
    // Start is called before the first frame update
    void Start()
    {
        roadLeft = GameObject.FindWithTag("RoadLeft");
        roadRight = GameObject.FindWithTag("RoadRight");
        roadMiddle= GameObject.FindWithTag("RoadMiddle");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        if (isMiddle)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                isMiddle = false;
                isLeft = true;
            }else if (Input.GetKeyDown(KeyCode.D))
            {
                isMiddle = false;
                isRight = true;
                transform.position = roadRight.transform.position;
            }
        }else if (isLeft)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                isMiddle = true;
                isLeft = false;
            }
        }
        else if (isRight)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                isMiddle = true;
                isRight = false;
            }
        }
    }
}
