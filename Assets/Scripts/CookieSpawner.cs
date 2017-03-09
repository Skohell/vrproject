using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour {

    GameObject cookie;
    
    // Use this for initialization
    void Start()
    {
       
        StartCoroutine(spawnCookie());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnCookie()
    {

        yield return new WaitForSeconds(5); 
        
        Vector3 scale = GameObject.Find("scooby_bg").transform.localScale;
        Vector2 pos = new Vector2(Random.Range(1 - scale.x, scale.x - 1), Random.Range(1 - scale.y, scale.y - 1));
        cookie = Instantiate(GameObject.Find("Cookie"), pos, Quaternion.identity);
        
    }
}
