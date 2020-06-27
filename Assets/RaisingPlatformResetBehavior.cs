using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingPlatformResetBehavior : MonoBehaviour
{
    public GameObject thingtoReset;
    public GameObject PreFabOfObjectToReset;
    private Transform ObjectsTransform;
    // Start is called before the first frame update
    void Start()
    {
        ObjectsTransform = thingtoReset.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("thisfar");

            GameObject ResetObject = PreFabOfObjectToReset;
            ResetObject.transform.position = ObjectsTransform.position;
            ResetObject.transform.parent = null;
            Instantiate(ResetObject);
            //Instantiate(ResetObject);
            //ResetObject.SetActive(true);
            Destroy(transform.parent.parent.gameObject);

        }
    }
}
