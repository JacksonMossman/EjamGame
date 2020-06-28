using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_marks : MonoBehaviour
{
    public Rigidbody rb;
    public float jump_cdr = 0.5f; //cooldown for jump in secs
    public float jump_force = 200f; //force of jump force.Impulse
    public float move_force = 10f;
    private float nextTimeAbleToJump = 0.0f; //store next time able to jump, prevents unnatual "jumping + running". 
    public float distanceToGround = 0.21f;
    public float groundTestLength = 0.1f;
    //public bool isGrounded; //stores if the character is "on a jumpable surface"
    public GameObject cam_obj; //camera object used for finding directions


    public Vector3 move_dir; //store the desired move direction relative to player transform

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam_obj = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        //Vertical Movement (only Jumping ATM)
        if (Time.time > nextTimeAbleToJump)
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded())
            {
                rb.AddForce(Vector3.up * jump_force * Time.fixedDeltaTime, ForceMode.Impulse);
                nextTimeAbleToJump = Time.time + jump_cdr;
            }
        }


        //Horizontal Movement
        move_dir = Vector3.zero; //reset old move_dir
        Vector3 forward = new Vector3(cam_obj.transform.forward.x, 0, cam_obj.transform.forward.z);

        if (Input.GetKey(KeyCode.W)) { move_dir += forward.normalized; } //forward
        if (Input.GetKey(KeyCode.S)) { move_dir += -forward.normalized; } //backward

        if (Input.GetKey(KeyCode.A)) { move_dir += -cam_obj.transform.right; } //left
        if (Input.GetKey(KeyCode.D)) { move_dir += cam_obj.transform.right; } //right

        rb.AddForce(move_dir.normalized * move_force * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    bool isGrounded()
    {
        
        Vector3 bottom = new Vector3(transform.position.x, transform.position.y - distanceToGround, transform.position.z);
        bool grounded = Physics.Raycast(
            bottom,
            Vector3.down,
            groundTestLength);

        Debug.Log("GroundTested-->" + grounded);

        return grounded;
    }
}
