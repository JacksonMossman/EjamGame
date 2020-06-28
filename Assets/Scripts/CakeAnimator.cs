using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] matList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OvenFlame"))
        {
            gameObject.GetComponent<MeshRenderer>().material = matList[1];
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("OvenFlame"))
        {
            gameObject.GetComponent<MeshRenderer>().material = matList[2];
            gameObject.tag = "BakedCake";
        }
        
    }
}
