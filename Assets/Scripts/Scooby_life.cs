using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Scooby_life : MonoBehaviour {

    int pv;

    public gameEchap echap;

    [SerializeField] Sprite coeur_vide;
    [SerializeField] Sprite coeur_plein;
    [SerializeField] Sprite scooby_normal;
    [SerializeField] Sprite scooby_blesse;

    public SpriteRenderer vie1;
    public SpriteRenderer vie2;
    public SpriteRenderer vie3;
        

    public Text score;
    public AudioSource audiohurt;
    public AudioSource audioover;
    int pts;

    // Use this for initialization
    void Start () {
        pv = 3;
        pts = 0;
        vie1 = GameObject.Find("vie1").GetComponent<SpriteRenderer>();
        CookieSpawner.spawnCookie();


    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!echap.getQuitMenu())

                echap.ExitPress();
            else
                echap.NoPress();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        string patternGhost = @"Ghost\W*";
        string patternCookie = @"Cookie\W*";
        if (Regex.IsMatch(col.gameObject.name, patternGhost))
        {
            pv--;
            Debug.Log(pv);

            audiohurt.Play();

        }
        
        if (Regex.IsMatch(col.gameObject.name, patternCookie))
        {
            pts++;
            if (pv < 3 && pts%10 == 0)
                pv++;

            
            score.text = pts.ToString();
            CookieSpawner.spawnCookie();
            Destroy(col.gameObject);
            
        }

        switch (pv)
        {
            case 0:
                GameObject.Find("vie1").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                GameObject.Find("vie2").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                GameObject.Find("vie3").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                Destroy(GameObject.Find("sprite_scooby"));
                Debug.Log("MORT");
                waitEnd();

                break;
            case 1:
                GameObject.Find("vie1").GetComponent<SpriteRenderer>().sprite = coeur_plein;
                GameObject.Find("vie2").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                GameObject.Find("vie3").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                break;
            case 2:
                GameObject.Find("vie1").GetComponent<SpriteRenderer>().sprite = coeur_plein;
                GameObject.Find("vie2").GetComponent<SpriteRenderer>().sprite = coeur_plein;
                GameObject.Find("vie3").GetComponent<SpriteRenderer>().sprite = coeur_vide;
                break;
            case 3:
                GameObject.Find("vie1").GetComponent<SpriteRenderer>().sprite = coeur_plein;
                GameObject.Find("vie2").GetComponent<SpriteRenderer>().sprite = coeur_plein;
                GameObject.Find("vie3").GetComponent<SpriteRenderer>().sprite = coeur_plein;
                break;
            default:
                break;

        }

    }
    
    void OnCollisionStay2D(Collision2D col)
    {
        string pattern = @"Ghost\W*";
        if(Regex.IsMatch(col.gameObject.name, pattern))
        {
            StartCoroutine(disableHitbox());
        }
        Debug.Log("OnCollisionStay");

    }

    private IEnumerator disableHitbox()
    {
        Collider2D scooby = GameObject.Find("sprite_scooby").GetComponent<CircleCollider2D>();

        Debug.Log("début routine");


        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("ghost");
        foreach(GameObject g in ghosts)
        {
            Collider2D g2 =g.GetComponent<CircleCollider2D>();
            Physics2D.IgnoreCollision(g2,scooby);
        }


        GetComponent<SpriteRenderer>().sprite = scooby_blesse;
        GetComponent<Transform>().localScale.Set(0.20f, 0.20f, 0f); 
        
        yield return new WaitForSeconds(3); // Réactivation de la hitbox après 3 secondes

        foreach (GameObject g in ghosts)
        {
            Collider2D g2 = g.GetComponent<CircleCollider2D>();
            Physics2D.IgnoreCollision(g2, scooby, false);
        }
        GetComponent<SpriteRenderer>().sprite = scooby_normal;


        StopCoroutine(disableHitbox());
        Debug.Log("fin routine");
    }

    private void waitEnd()
    {
        Debug.Log("enter waitend");
        echap.YesPress();  
    }
    
}
