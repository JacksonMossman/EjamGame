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

             rigidbody.AddForce(new Vector3(0, 1, 0),ForceMode.Impulse);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Block"))
        {
            boxcount--;
        }
        if(boxcount <=2)
        {
            ballistOff = true;
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
