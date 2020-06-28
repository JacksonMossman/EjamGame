using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Oven Effects Turn on when Colliders of Oven are Collided With (i.e. something placed into oven)
public class OvenBehavior : MonoBehaviour
{
    //Particle System
    public ParticleSystem smoke;

    void Start()
    {
        smoke = GetComponent<ParticleSystem>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cake"))
        { smoke.Play(); }
       
    }
}
