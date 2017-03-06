﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooby_life : MonoBehaviour {

    int pv;

    [SerializeField] Sprite coeur_vide;
    [SerializeField] Sprite scooby_normal;
    [SerializeField] Sprite scooby_blesse;

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
            Debug.Log(pv);
          
        }
        
        switch(pv)
        {
            case 0:
                GameObject.Find("vie1").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                break;
            case 1:
                GameObject.Find("vie2").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                break;
            case 2:
                GameObject.Find("vie3").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                break;
            default:
                break;
        }
        if(pv <= 0)
        {
            Destroy(GameObject.Find("sprite_scooby"));
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
        Collider2D scooby = GameObject.Find("sprite_scooby").GetComponent<CircleCollider2D>();

        Debug.Log("début routine");

        Physics2D.IgnoreCollision(ghost, scooby);
        GetComponent<SpriteRenderer>().sprite = scooby_blesse;
        GetComponent<Transform>().localScale.Set(0.17f, 0.17f, 0f); 
        

        yield return new WaitForSeconds(3); // Réactivation de la hitbox après 3 secondes

        Physics2D.IgnoreCollision(ghost, scooby, false);
        GetComponent<SpriteRenderer>().sprite = scooby_normal;


        StopCoroutine(disableHitbox());
        Debug.Log("fin routine");
    }

    
}
