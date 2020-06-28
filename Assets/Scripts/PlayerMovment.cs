using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
        public bool isGrounded = false;
        private Transform tranform;
        public Rigidbody rb;
        private Vector3 move_dir;
        public float move_force;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            tranform = GetComponent<Transform>();
        }

        void Update()
        {
            move_dir = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                move_dir += Vector3.up;
            }
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                move_dir += tranform.forward;
            }
            if (Input.GetKeyDown(KeyCode.A) && isGrounded)
            {
                move_dir += -tranform.right;
            }
            if (Input.GetKeyDown(KeyCode.S) && isGrounded)
            {
                move_dir += -tranform.forward;
            }
            if (Input.GetKeyDown(KeyCode.D) && isGrounded)
            {
                move_dir += tranform.right;
            }

            rb.AddForce(move_dir.normalized * move_force, ForceMode.Impulse);
        }

        void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("Hello");
            if (collision.gameObject.name != "Untagged")
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            //Debug.Log("goodbye");
            if (collision.gameObject.name != "Untagged")
            {
                isGrounded = false;
            }
        }
    
}
