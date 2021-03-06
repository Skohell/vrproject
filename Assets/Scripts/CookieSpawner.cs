﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour {

    private static GameObject cookie;
    static int k = 0;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void spawnCookie()
    {

        cookie = GameObject.Find("Cookie");
        Vector2 pos = new Vector2(Random.Range(-8,8), Random.Range(-4,4));
        GameObject clone = Instantiate(cookie, pos, Quaternion.identity);
        CircleCollider2D clone_component = clone.GetComponent<CircleCollider2D>();
        clone_component.isTrigger = false;

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("ghost");
        foreach (GameObject g in ghosts)
        {
            Collider2D g2 = g.GetComponent<CircleCollider2D>();
            Physics2D.IgnoreCollision(g2, clone_component);
        }

    }
}
