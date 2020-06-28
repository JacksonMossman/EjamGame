using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMangerBehavior : MonoBehaviour
{
    public Text scoreValue;
    public GameObject cake;
    private CakeCollectingBehavior cakeCollectingBehavior;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = "Score: " + cakeCollectingBehavior.Score.ToString();
    }
}
