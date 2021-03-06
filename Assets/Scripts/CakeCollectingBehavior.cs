﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCollectingBehavior : MonoBehaviour
{
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Ingredient"))
        {
            Rigidbody[] childrenlist = other.gameObject.GetComponentsInChildren<Rigidbody>();

            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            for(int i = 0; i<other.gameObject.GetComponentsInChildren<Rigidbody>().Length;i++)
            {
                childrenlist[i].isKinematic = true;
                childrenlist[i].gameObject.GetComponent<Collider>().enabled = false;
                
            }
            other.gameObject.tag = "CollectedIngredient";
            Score++;
            
            other.gameObject.GetComponent<Transform>().SetParent(transform);
            //collision.gameObject.transform.parent = transform;
        }
    }
}
