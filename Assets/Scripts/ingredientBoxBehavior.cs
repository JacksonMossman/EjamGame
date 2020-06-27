using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientBoxBehavior : MonoBehaviour
{
    public List<GameObject> ingredientCollected = new List<GameObject>();
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
        if(other.gameObject.CompareTag("Ingredient"))
        {
            ingredientCollected.Add(other.gameObject);
            Destroy(other.gameObject);
        }
    }

}
