using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debri : MonoBehaviour
{

    public Score score;
    private bool ObjectHit = false;
    Animator anim;
	public bool powerup = false;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();
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
        float waitTime = 0.25F;

        if (!ObjectHit)
        {
            if (score != null)
            {
				ObjectHit = true;
				anim.SetBool ("Destroy", true);
				if (powerup) {
					score.powerUp ();
                    waitTime = 0;
                    if(audio != null)
                    {
                        audio.Play();
                    }
					//GetComponent<AudioSource> ().Play ();
                }
                else
					score.RemoveHealth ();
				StartCoroutine (DestroyObject (waitTime));
			}
            else
            {
                Debug.Log("Attach score script to debri object");
            }
        }
    }

    IEnumerator DestroyObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
