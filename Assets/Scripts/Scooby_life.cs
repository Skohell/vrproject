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
        Debug.Log("début routine");
        this.GetComponent<CircleCollider2D>().enabled = false; // ATTENTION
        yield return new WaitForSeconds(3);
        this.GetComponent<CircleCollider2D>().enabled = true; // là on peut sortir de l'écran, désactiver la box des fantomes à la place

        StopCoroutine(disableHitbox());
        Debug.Log("fin routine");
    }
}
