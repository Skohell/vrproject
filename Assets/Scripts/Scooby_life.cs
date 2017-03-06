using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooby_life : MonoBehaviour {

    int pv;

    Sprite vie1;
    Sprite vie2;
    Sprite vie3;

    // Use this for initialization
    void Start () {
        pv = 3;
        
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "Ghost")
        {
            pv--;
            //vie1.GetComponent<SpriteRenderer>().sprite = ;
            Debug.Log(pv);
        }
     
        if(pv <= 0)
        {
            Destroy(GameObject.Find("Scooby"));
            Debug.Log("MORT");

        }

        


    }
    
    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("OnCollisionStay");

        if (col.gameObject.name == "Ghost")
        {
            StartCoroutine(disableHitbox());
        }

    }

    private IEnumerator disableHitbox()
    {
        Collider2D ghost = GameObject.Find("Ghost").GetComponent<CircleCollider2D>();
        Collider2D scooby = GameObject.Find("Scooby").GetComponent<CircleCollider2D>();

        Debug.Log("début routine");

        Physics2D.IgnoreCollision(ghost, scooby);

        yield return new WaitForSeconds(3); // Réactivation de la hitbox après 3 secondes

        Physics2D.IgnoreCollision(ghost, scooby, false);
       
        StopCoroutine(disableHitbox());
        Debug.Log("fin routine");
    }
}
