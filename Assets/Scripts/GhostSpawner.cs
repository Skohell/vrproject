using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour {

    public GameObject[] ghosts;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawnGhost());
	}
	
	// Update is called once per frame
	void Update () {

        spawnGhost();
	}

    private IEnumerator spawnGhost()
    {
        yield return new WaitForSeconds (10);
        Vector2 pos = new Vector2(0,0);
        Instantiate(GameObject.Find("Ghost"),pos,Quaternion.identity);
    }
}
