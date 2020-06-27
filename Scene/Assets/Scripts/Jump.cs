using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
  
    private Transform tranform;
    private bool grounded;
    public Rigidbody rb;
    private Vector3 move_dir;
    public float move_force = 10.0f;
    public float jump_force = 100.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tranform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        move_dir = Vector3.zero;

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jump_force * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            move_dir += tranform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        { 
            move_dir += -tranform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move_dir += -tranform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move_dir += tranform.right;
        }
        rb.AddForce(move_dir.normalized * move_force * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    
    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false; 
    }
}