using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformRaisingBehavior : MonoBehaviour
{
    Rigidbody rb;
    
    bool ballistOff = false;
    Stopwatch stopwatch = new Stopwatch();
    private GameObject cake;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ballistOff == true)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Force);
            stopwatch.Start();
        }
        if(stopwatch.ElapsedMilliseconds> 5000)
        {
            cake.transform.position = Vector3.zero;
            cake.transform.rotation = new Quaternion(0, 0, 0, 0);
            cake.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            DontDestroyOnLoad(cake);
            SceneManager.LoadScene(2);                           
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BakedCake"))
        {
            cake = other.gameObject;
            Vector3 store = other.transform.localScale ;
           
            other.transform.parent = other.gameObject.transform;
            
            other.GetComponent<Rigidbody>().isKinematic = false;
            ballistOff = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
    }
}
