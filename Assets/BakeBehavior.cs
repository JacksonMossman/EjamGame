using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeBehavior : MonoBehaviour
{
    public GameObject ingredientBox;
    public List<bool> enabledIngredients;
    public GameObject cake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        cake.SetActive(true); 
        if(collision.gameObject.CompareTag("player"))
        {  
            foreach(int i in ingredientBox.GetComponent<ingredientBoxBehavior>().ingredientCollected)
            {
                //make cake Script
                cake.GetComponent<CakeBehavior>().ingredients[i].SetActive(true);
            }

        }
    
    }
}
