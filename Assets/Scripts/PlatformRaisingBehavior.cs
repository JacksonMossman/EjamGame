using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRaisingBehavior : MonoBehaviour
{
    Rigidbody rigidbody;
    int boxcount = 4;
    bool ballistOff = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ballistOff == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
             //rigidbody.AddForce(new Vector3(0, 1000, 0),ForceMode.Force);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cake"))
        {
            other.transform.parent = gameObject.transform;
            other.GetComponent<Rigidbody>().isKinematic = true;
            ballistOff = true;
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
    }
}
