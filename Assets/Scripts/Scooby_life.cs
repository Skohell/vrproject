using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooby_life : MonoBehaviour {

    int pv;

    GameObject vie1;
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
            vie1.GetComponent<SpriteRenderer>().sprite = ;
        }
     
        if(pv < 0)
        {
            Destroy(GameObject.Find("Scooby"));

        }


    }
}
