using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour {

    //vitesse du fantome
    float speed;
    GameObject scooby;
    float type;
    bool goRight;
    bool goUp;
    SpriteRenderer ghost_sprite;
    [SerializeField]Sprite ghost_follow;
    [SerializeField]Sprite ghost_vertical;
    [SerializeField]Sprite ghost_horizontal;

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(0.5f, 3);
        scooby = GameObject.Find("sprite_scooby");
        type = Random.Range(0f, 1f);
        goRight = true;
        goUp = true;
        ghost_sprite = GetComponent<SpriteRenderer>();
        if (type < 0.33)
        {
            ghost_sprite.sprite = ghost_follow;
        }
        else if (type > 0.33 && type < 0.66)
        {
            ghost_sprite.sprite = ghost_horizontal;

        }
        else
        {
            ghost_sprite.sprite = ghost_vertical;

        }
        
    }

    // Update is called once per frame
    void Update () {

        if (scooby != null)
        {
            Vector2 scooby_pos = scooby.transform.position;

            Vector2 position = transform.position;

            if (type < 0.33)
            #region Normal Ghost
            {
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
            }
            #endregion
            else if (type > 0.33 && type < 0.66)
            #region Horizontal Ghost
            {
                if (goRight)
                    position = new Vector2(position.x + speed * Time.deltaTime, position.y);
                else
                    position = new Vector2(position.x - speed * Time.deltaTime, position.y);
            }
            #endregion
            else
            #region Vertical Ghost
            {
                if (goUp)
                    position = new Vector2(position.x, position.y + speed * Time.deltaTime);
                else
                    position = new Vector2(position.x, position.y - speed * Time.deltaTime);
            }
            #endregion

            transform.position = position;
        }
	}


    void OnCollisionStay2D(Collision2D col)
    {
        goRight = !goRight;
        goUp = !goUp;

    }




}
