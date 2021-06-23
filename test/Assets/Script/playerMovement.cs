using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float xForce, yForce;
    float x = 0;
    public float maxVelocity=10f;
    public float maxRotationSpeed, maxRotation;
    float screWidth;
    Rigidbody rb;
    Animator animator;
    public float minimunVelocity;
    public float animaionTriggerVelocity;

    public float kickBackForce;
    private void Start()
    {
        animator = GetComponent<Animator>();
        screWidth = Screen.width / 2;
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
#if UNITY_EDITOR
        // GetInputFromKeyBoard();
#endif
#if ANDROID

          
#endif
        GetInputFromTouch();
        //Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.y<minimunVelocity)
        {

            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

         
        // y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //if (x != 0) rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * yForce * Mathf.Abs(x) );
        rb.AddForce(Vector3.right * xForce * x);
            
    }
    void GetInputFromKeyBoard()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            rb.velocity = Vector3.zero;
           // SetPlayersRotation(0);
        }
        if (Input.GetMouseButton(0))
        {
            x = -1;
            SetPlayersRotation(-1);
            if (rb.velocity.magnitude > animaionTriggerVelocity)
            {
                animator.SetBool("turnRight", false);
                animator.SetBool("turnLeft", true);
            }
           
        }
        else if (Input.GetMouseButton(1))
        {
            x = 1;
            SetPlayersRotation(1);
            if(rb.velocity.magnitude>animaionTriggerVelocity)
            {
                animator.SetBool("turnRight", true);
                animator.SetBool("turnLeft", false);
            }
           
        }
        else
        {
            x = 0;
            SetPlayersRotation(0);
            animator.SetBool("turnRight", false);
            animator.SetBool("turnLeft", false);
        }
    }
    void GetInputFromTouch()
    {
        
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rb.velocity = Vector3.zero;
            }
            if (Input.GetTouch(0).position.x > screWidth)
            {
                x = 1;
                SetPlayersRotation(1);
                if (rb.velocity.magnitude > animaionTriggerVelocity)
                {
                    animator.SetBool("turnRight", true);
                    animator.SetBool("turnLeft", false);
                }
                   
            }
            else
            {
                SetPlayersRotation(-1);
                x = -1;
                if (rb.velocity.magnitude > animaionTriggerVelocity)
                {
                    animator.SetBool("turnRight", false);
                    animator.SetBool("turnLeft", true);
                }
                   
            }
        }
        else
        {
            x = 0;
            SetPlayersRotation(0);
            animator.SetBool("turnRight", false);
            animator.SetBool("turnLeft", false);
        }
    }
    void SetPlayersRotation(int x)
    {
        if(x==0)
        {
            transform.rotation= Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime);
        }else if(x==1)
        {
            //rotate right
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f,-maxRotation), maxRotationSpeed*Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, maxRotation), maxRotationSpeed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "shipTop")
        {
            
            rb.velocity = rb.velocity / 2f;
            rb.AddForce(Vector3.up * Time.deltaTime * kickBackForce, ForceMode.Impulse);
        }
        
    }
}
