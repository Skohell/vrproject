using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public static int pts;
    public static int best_pts;

    // Use this for initialization
    void Start () {
        pv = 3;
        pts = 0;
        using (BinaryReader reader = new BinaryReader(File.Open("scores.bin", FileMode.Open)))
        {
            best_pts = reader.ReadInt16();
        }
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

                if(best_pts<pts)
                    best_pts = pts;
                vie1.sprite = coeur_vide;
                Destroy(this);
                waitEnd();

                break;
            case 1:
                vie1.sprite = coeur_plein;
                vie2.sprite = coeur_vide;
                vie3.sprite = coeur_vide;
                break;
            case 2:
                vie1.sprite = coeur_plein;
                vie2.sprite = coeur_plein;
                vie3.sprite = coeur_vide;
                break;
            case 3:
                vie1.sprite = coeur_plein;
                vie2.sprite = coeur_plein;
                vie3.sprite = coeur_plein;
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

    }

    private IEnumerator disableHitbox()
    {
        SpriteRenderer scooby_sprite = GetComponent<SpriteRenderer>();
        Collider2D scooby = GetComponent<CircleCollider2D>();

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("ghost");
        foreach(GameObject g in ghosts)
        {
            Collider2D g2 =g.GetComponent<CircleCollider2D>();
            Physics2D.IgnoreCollision(g2,scooby);
        }


        scooby_sprite.sprite = scooby_blesse;

        GetComponent<Transform>().localScale.Set(0.20f, 0.20f, 0f); 
        
        yield return new WaitForSeconds(3); // Réactivation de la hitbox après 3 secondes

        foreach (GameObject g in ghosts)
        {
            Collider2D g2 = g.GetComponent<CircleCollider2D>();
            Physics2D.IgnoreCollision(g2, scooby, false);
        }
        scooby_sprite.sprite = scooby_normal;


        StopCoroutine(disableHitbox());

    }

    private void waitEnd()
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open("scores.bin", FileMode.OpenOrCreate)))
        {
            writer.Write(best_pts);
        }

        StopAllCoroutines();
        echap.YesPress();  
    }

   
    
}
