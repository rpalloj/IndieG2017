using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static Score instance = null;

    private float _score = 0;
    private int _health = 5;

    public Text score;
    //public Text distance;
    public Text health;
	public static float diffinc = 1;
	public AudioSource powerupAud;

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        score.text = _score.ToString();
        health.text = _health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScore ();
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void UpdateScore()
    {
		_score += Time.deltaTime;
		score.text = Mathf.Round(_score).ToString();
    }

	public void powerUp()
	{
		_score += 10;
		_health += 1;
		health.text = _health.ToString();
		powerupAud.Play ();
	}

    public void RemoveHealth()
    {
        --_health;
        health.text = _health.ToString();

		GetComponent<AudioSource> ().Play ();

        if(_health <= 0)
        {
			PlayerPrefs.SetInt("HighScore", (int)_score);
            SceneManager.LoadScene("Start");
            diffinc = 1;
        }
    }


}
