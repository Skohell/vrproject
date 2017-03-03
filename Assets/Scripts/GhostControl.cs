using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour {

    //vitesse du fantome
    float speed;
    GameObject scooby;

    

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 3);
        scooby = GameObject.Find("sprite_scooby");
    }
	
	// Update is called once per frame
	void Update () {

        if (scooby != null)
        {
            Vector2 scooby_pos = scooby.transform.position;

            Vector2 position = transform.position;

            if (scooby_pos.x > position.x && scooby_pos.y > position.y)
            {
                position = new Vector2(position.x + speed * Time.deltaTime, position.y + speed * Time.deltaTime);

            }
            else if (scooby_pos.x > position.x && scooby_pos.y < position.y)
            {
                position = new Vector2(position.x + speed * Time.deltaTime, position.y - speed * Time.deltaTime);

            }
            else if (scooby_pos.x < position.x && scooby_pos.y > position.y)
            {
                position = new Vector2(position.x - speed * Time.deltaTime, position.y + speed * Time.deltaTime);

            }
            else
            {
                position = new Vector2(position.x - speed * Time.deltaTime, position.y - speed * Time.deltaTime);

            }
            transform.position = position;
        }
	}


}
