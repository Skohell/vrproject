using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour {

    private static GameObject cookie;
    static int k = 0;
    
    // Use this for initialization
    void Start()
    {
        cookie = GameObject.Find("Cookie");
        firstCookie();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void firstCookie()
    {
        if(k == 0)
        {
 
            Vector2 pos = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
            GameObject clone = Instantiate(cookie, pos, Quaternion.identity);
            clone.GetComponent<CircleCollider2D>().isTrigger = false;
            k = 1;
        }

    }
    public static void spawnCookie()
    {

        Vector2 pos = new Vector2(Random.Range(-8,8), Random.Range(-4,4));
        GameObject clone = Instantiate(cookie, pos, Quaternion.identity);
        clone.GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
