using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    Rigidbody rb;
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(new Vector3(0,.05f,0), ForceMode.Force);

      if(transform.position.y > 0)
        {
            up = false;
        }
      else if(transform.position.y < -.2)
        {
            up = true;
        }
      if(up)
        {
            rb.AddForce(new Vector3(0, .1f, 0));
        }
      else
        {
            rb.AddForce(new Vector3(0, -.1f, 0));
        }
        

    }

}
