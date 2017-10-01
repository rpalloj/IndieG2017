using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debri : MonoBehaviour
{

    public Score score;
    private bool ObjectHit = false;
    Animator anim;
	public bool powerup = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
        if (!ObjectHit)
        {
            if (score != null)
            {
				ObjectHit = true;
				anim.SetBool ("Destroy", true);
				if (powerup) {
					score.powerUp ();
					GetComponent<AudioSource> ().Play ();
				}
				else
					score.RemoveHealth ();
				StartCoroutine (DestroyObject ());
			}
            else
            {
                Debug.Log("Attach score script to debri object");
            }
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.25F);
        Destroy(gameObject);
    }
}
