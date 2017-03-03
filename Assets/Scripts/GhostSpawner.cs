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
        Vector3 scale = GameObject.Find("scooby_bg").transform.localScale;
        Vector2 pos = new Vector2(Random.Range(1-scale.x,scale.x-1),Random.Range(1-scale.y,scale.y-1));
        Instantiate(GameObject.Find("Ghost"),pos,Quaternion.identity);
    }
}
