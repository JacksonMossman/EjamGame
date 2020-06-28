using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject punching_object; //must have collider
    public float punch_cdr = 0.5f;
    private float punch_next_time = 0f;
    private float end_of_punch_time = 0f;
    public bool punching = false;
    public float punchLength = 1f;
    public float punchSpeed = 0.1f;
    private float punchDur;
    private Vector3 puncher_reset_pos;

    void Start()
    {
        punchDur = punchLength / punchSpeed;
        puncher_reset_pos = punching_object.transform.localPosition;
    }
    void Update()
    {
        if(Time.time > punch_next_time && !punching && Input.GetMouseButtonDown(1))
        {
            punching = true;
            end_of_punch_time = Time.time + punchDur;
        }

        if (punching)
        {
            Vector3 move = punching_object.transform.localRotation * Vector3.forward * punchSpeed * Time.deltaTime; 
            punching_object.transform.localPosition += move;
        }
        else
        {
            punching_object.transform.localPosition = puncher_reset_pos;
        }

        if(Time.time > end_of_punch_time)
        {
            punching = false;
        }
        
    }
}
