using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public Score score;

    // Use this for initialization
    void Start()
    {
        if (score == null)
        {
            score = GameObject.Find("Canvas").GetComponent<Score>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (score != null)
        {
            score.UpdateScore();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Attach score script to collectible object");
        }
    }
}
