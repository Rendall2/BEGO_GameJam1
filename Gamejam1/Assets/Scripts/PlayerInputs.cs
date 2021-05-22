using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Animator playerAnimator;
    float time = 0;
    public bool isRight = false;
    public bool isLeft = false;
    public bool isMid = true;
    private bool isRunning = true;
    Vector2 firstPressPos;
    Vector2 lastPressPos;
    Vector2 currentSwipe;
    private int jumpCount = 0;
    SceneLoader sceneLoader;


    [Range (0.5f,10f)]
    public float runSpeed = 4f;



    [Range (0.01f,1f)]
    public float swipeSensitivity = 0.5f;

    [Range(0.3f, 5f)]
    public float swipeVelocityPerTime = 2.9f;
    [Range(0.01f, 1f)]
    public float transitionTime = 0.2f;

    [Range(0.1f, 10f)]
    public float runLeftAnimSpeed = 1f;

    [Range(0.1f, 10f)]
    public float runRightAnimSpeed = 1f;



    [Range(50f, 500f)]
    public float jumpForce = 120f;

    [Range(0.1f, 10f)]
    public float jumpAnimSpeed = 1f;

    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    private void FixedUpdate()
    
    {
        if (isRunning == true)
        {
            Run();
        }

        ControlXaxis();

    }
    private void Update()
    {
        Swipe();
       
    }

    private void Run()
    {
        transform.Translate(transform.forward * runSpeed * Time.deltaTime);
    }

    private void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                lastPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector2(lastPressPos.x - firstPressPos.x, lastPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();
                //Swipe left
                if (currentSwipe.x < 0 && ((currentSwipe.y <= swipeSensitivity)|| (-swipeSensitivity >= currentSwipe.y  )) && isLeft == false && IsInvoking("RunLeft") == false && IsInvoking("RunRight") == false)
                {
                    

                    if (isRight) //saðdaysa ortaya geçti
                    {

                        time = Time.time;
                        playerAnimator.SetFloat("RunLeftSpeed", runLeftAnimSpeed);
                        playerAnimator.ResetTrigger("RunLeft");
                        playerAnimator.SetTrigger("RunLeft");
                        InvokeRepeating("RunLeft", 0, 0.001f);
                        CancelInvoke("RunRight");
                        isRight = false;
                        isMid = true;
                        
                    }

                    else if (isMid)  //ortadaysa sola geçti
                    {
                        time = Time.time;
                        playerAnimator.SetFloat("RunLeftSpeed", runLeftAnimSpeed);
                        playerAnimator.ResetTrigger("RunLeft");
                        playerAnimator.SetTrigger("RunLeft");
                        InvokeRepeating("RunLeft", 0, 0.001f);
                        CancelInvoke("RunRight");
                        isMid = false;
                        isLeft = true;
                        
                    }

                }

                //Swipe Right
                else if (currentSwipe.x > 0 && ((currentSwipe.y <= swipeSensitivity) || (-swipeSensitivity >= currentSwipe.y )) && isRight == false && IsInvoking("RunLeft") == false && IsInvoking("RunRight") == false)
                {


                    if (isLeft) //soldaysa ortaya geçti
                    {
                        time = Time.time;
                        playerAnimator.SetFloat("RunRightSpeed", runRightAnimSpeed);
                        playerAnimator.ResetTrigger("RunRight");
                        playerAnimator.SetTrigger("RunRight");
                        InvokeRepeating("RunRight", 0, 0.001f);
                        CancelInvoke("RunLeft");
                        isLeft = false;
                        isMid = true;
                    }

                    else if (isMid)  //ortadaysa saða geçti
                    {
                        time = Time.time;
                        playerAnimator.SetFloat("RunRightSpeed", runRightAnimSpeed);
                        playerAnimator.ResetTrigger("RunRight");
                        playerAnimator.SetTrigger("RunRight");
                        InvokeRepeating("RunRight", 0, 0.001f);
                        CancelInvoke("RunLeft");
                        isMid = false;
                        isRight = true;
                    }

                    
                }

                //Swipe Up Jump
                else if (currentSwipe.y > swipeSensitivity && jumpCount == 0)
                {
                    time = Time.time;
                    playerAnimator.SetFloat("JumpSpeed", jumpAnimSpeed);
                    playerAnimator.ResetTrigger("Jump");
                    playerAnimator.SetTrigger("Jump");
                    Jump();
                }

            }
        }
    }

    private void RunLeft()
    {
        if (time + transitionTime >= Time.time)
        {
            transform.Translate(transform.right * -1 * Time.deltaTime * swipeVelocityPerTime);

        }

        else
        {
            CancelInvoke("RunLeft");
        }
        
    }

    private void RunRight()
    {
        if (time + transitionTime >= Time.time)
        {
            transform.Translate(transform.right * Time.deltaTime * swipeVelocityPerTime);

        }

        else
        {
            CancelInvoke("RunRight");
        }

    }

    private void Jump()
    {
        jumpCount++;
        transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fl")
        {
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "SpikeCube")
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

    private void ControlXaxis()
    {
        if (transform.position.x > 1.06f)
        {
            transform.position = new Vector3(1.06f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -1.085f)
        {
            transform.position = new Vector3(-1.085f, transform.position.y, transform.position.z);
        }
    }

    private void ControlXaxis()
    {
        if(transform.position.x > 1.06f)
        {
            transform.position = new Vector3 (1.06f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -1.085f)
        {
            transform.position = new Vector3(-1.085f, transform.position.y, transform.position.z);
        }
    }
}
