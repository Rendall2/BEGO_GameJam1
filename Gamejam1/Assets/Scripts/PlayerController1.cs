using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    float speed = 10.0f;
    float horizontalInput;
    float verticalInput;
    Rigidbody playerRb;
    float jumpForce = 120;
    bool isGrounded;
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * 5);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SpikeCube")
        {          
            bool isActive = collision.gameObject.GetComponent<MeshRenderer>().enabled;
            if (!isActive)
            {
                collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
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
