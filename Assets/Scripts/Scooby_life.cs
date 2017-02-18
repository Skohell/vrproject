using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooby_life : MonoBehaviour {

    int pv;
    GameObject vie1;
    GameObject vie2;
    
    SpriteRenderer vie3;
	// Use this for initialization
	void Start () {
        pv = 3;
	}
	
	// Update is called once per frame
	void Update () {
        vie3 = GameObject.Find("vie3").GetComponent<SpriteRenderer>();


    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        vie3.sprite = Resources.Load("coeur_vide", typeof(Sprite)) as Sprite;
    }
}
