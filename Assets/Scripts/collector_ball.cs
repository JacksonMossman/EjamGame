using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector_ball : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.GetComponent<Rigidbody>())
        {
            if (collision.gameObject.name != "player")
            {
                Debug.Log("Collided With Object That Was Collectable");
                collision.gameObject.transform.parent = this.transform;
            }
            else
            {
                Debug.Log("Collided With Player");
            }
        }
        else
        {
            Debug.Log("Collided With Object Without RigidBody");
        }
    }
}
