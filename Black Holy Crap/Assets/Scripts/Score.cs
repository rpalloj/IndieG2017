using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int _score = 0;
    private int _health = 3;

    public Text score;
    public Text distance;
    public Text health;

	// Use this for initialization
	void Start () {
        score.text = _score.ToString();
        health.text = _health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore()
    {
        ++_score;
        score.text = _score.ToString();
    }

    public void RemoveHealth()
    {
        --_health;
        health.text = _health.ToString();
    }

}
