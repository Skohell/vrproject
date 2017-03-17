using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour {

    public GameObject ghost;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawnGhost());
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    private IEnumerator spawnGhost()
    {
        yield return new WaitForSeconds (10);
        Vector2 pos = new Vector2(Random.Range(-8,8),Random.Range(-4,4));
        Instantiate(ghost,pos,Quaternion.identity);
    }
}
